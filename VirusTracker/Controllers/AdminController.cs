﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VirusTracker.Data;
using VirusTracker.Models;
using VirusTracker.Helpers;

namespace VirusTracker.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private readonly VirusTrackerContext _dataContext;
        private readonly UserManager<Doctor> _userManager;
        private readonly IEmailConfiguration _emailConfiguration;

        private Dictionary<string, string> fileTypes;

        public AdminController(UserManager<Doctor> userManager, VirusTrackerContext dataContext, IEmailConfiguration emailConfiguration)
        {
            _userManager = userManager;
            _dataContext = dataContext;
            _emailConfiguration = emailConfiguration;
            fileTypes = new Dictionary<string, string>() {  { ".pdf", "application/pdf" },
                                                            { ".doc", "application/msword" },
                                                            { ".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" } };
        }
        public IActionResult Index()
        {
            var doctors = _userManager.Users.ToList();
            var patients = _dataContext.Patient.ToList();
            dynamic mymodel = new ExpandoObject();
            mymodel.Doctors = doctors;
            mymodel.Patients = patients;
            return View(mymodel);
        }

        public IActionResult Patients()
        {
            var patients = _dataContext.Patient.ToList();

            return View(patients);
        }

        public IActionResult Messages()
        {
            var messages = _dataContext.Message.ToList();

            return View(messages);
        }

        public IActionResult Requests()
        {
            var enrollments = _dataContext.Enroll.ToList();
            return View(enrollments);
        }

        public IActionResult EditDoctor(string doctorId)
        {
            var doctor = _userManager.Users.ToList().Find(d => d.Id == doctorId);
            var patients = _dataContext.Patient.ToList().FindAll(p => p.doctorId == doctorId);
            dynamic mydynamic = new ExpandoObject();
            mydynamic.Doctor = doctor;
            mydynamic.Patients = patients;
            return View(mydynamic);
        }

        public IActionResult EditPatient(string patientId)
        {
            var patient = _dataContext.Patient.ToList().Find(p => p.ID.ToString() == patientId);
            var doctor = _userManager.Users.ToList().Find(d => d.Id == patient.doctorId);
            dynamic mydynamic = new ExpandoObject();
            mydynamic.Doctor = doctor;
            mydynamic.Patient = patient;
            return View(mydynamic);
        }

        public async Task<IActionResult> RemoveDoctor(string doctorId)
        {
            System.Diagnostics.Debug.WriteLine("blabla" + doctorId);
            var toRemove = await _userManager.FindByIdAsync(doctorId);
            var patients = _dataContext.Patient;
            foreach(var p in patients)
            {
                if (p.doctorId == toRemove.Id)
                    p.doctorId = null;
            }
            await _dataContext.SaveChangesAsync();
            await _userManager.DeleteAsync(toRemove);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveFromDoctor(string patientId, string docId)
        {
            var patient = _dataContext.Patient.ToList().Find(p => p.ID.ToString() == patientId);
            patient.doctorId = null;
            await _dataContext.SaveChangesAsync();
            return RedirectToAction("EditDoctor", new { doctorId = docId });
        }

        public async Task<IActionResult> RemoveFromPatient(string patId)
        {
            var patient = _dataContext.Patient.ToList().Find(p => p.ID.ToString() == patId);
            patient.doctorId = null;
            await _dataContext.SaveChangesAsync();
            return RedirectToAction("EditPatient", new { patientId = patId });
        }

        [HttpPost]
        public async Task<IActionResult> SaveChangesDoctor(IFormCollection formdata)
        {
            //System.Diagnostics.Debug.WriteLine(formdata["fname"].ToString());
            var doctor = _userManager.Users.ToList().Find(d => d.Id == formdata["id"]);
            doctor.firstName = formdata["fname"];
            doctor.lastName = formdata["lname"];
            doctor.UserName = formdata["username"];
            doctor.password = formdata["password"];
            doctor.Email = formdata["email"];
            doctor.PhoneNumber = formdata["phone"];
            await _dataContext.SaveChangesAsync();
            return RedirectToAction("EditDoctor", new { doctorId = formdata["id"] });
        }

        [HttpPost]
        public async Task<IActionResult> SaveChangesPatient(IFormCollection formdata)
        {
            //System.Diagnostics.Debug.WriteLine(formdata["id"].ToString());
            var patient = _dataContext.Patient.ToList().Find(p => p.ID.ToString() == formdata["id"]);
            patient.firstName = formdata["fname"];
            patient.lastName = formdata["lname"];
            patient.address = formdata["address"];
            patient.age = Int32.Parse(formdata["age"]);
            patient.emailAddress = formdata["email"];
            patient.phoneNumber = formdata["phone"];
            patient.weight = Int32.Parse(formdata["weight"]);
            patient.height = Int32.Parse(formdata["height"]);
            patient.symptoms = formdata["symptoms"];
            patient.treatment = formdata["treatment"];
            await _dataContext.SaveChangesAsync();
            return RedirectToAction("EditPatient", new { patientId = formdata["id"] });
        }

        public async Task<IActionResult> RemovePatient(int patientId)
        {
            var toRemove = await _dataContext.Patient.FindAsync(patientId);
            _dataContext.Remove(toRemove);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction("Patients");
        }

        public async Task<IActionResult> AnswerMessage(int messageId, string answer)
        {
            _dataContext.Message.Find(messageId).answer = answer;
            await _dataContext.SaveChangesAsync();
            return RedirectToAction("Messages");
        }
        public async Task<IActionResult> RemoveMessage(int messageId)
        {
            var toRemove = await _dataContext.Message.FindAsync(messageId);
            _dataContext.Remove(toRemove);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction("Messages");
        }
        public async Task<IActionResult> GetDocument(string document, string id)
        {
            var usr = _dataContext.Enroll.ToList().Find(e => e.Id.ToString() == id);
            var path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory) + "/NewDoctors", usr.Id + "_" + usr.firstName + "_" + usr.lastName);
            var files = Directory.GetFiles(path).ToList();
            string toFind = null;
            foreach(var f in files)
            {
                if(f.Contains(usr.firstName + "_" + usr.lastName + "_" + document))
                {
                    toFind = f;
                    break;
                }
            }
            
            System.Diagnostics.Debug.WriteLine(path);
            System.Diagnostics.Debug.WriteLine(toFind);
            if(toFind != null)
            {
                var memory = new MemoryStream();
                using (var stream = new FileStream(toFind, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }
                memory.Position = 0;
                var contentType = fileTypes.FirstOrDefault(t => t.Key == Path.GetExtension(toFind).ToLowerInvariant()).Value;
                return File(memory, contentType, Path.GetFileName(toFind));
            } else
            {
                System.Diagnostics.Debug.WriteLine("File not found");
                return RedirectToAction("Requests");
            }

        }
        public async Task<IActionResult> ApproveDoctor(string id)
        {
            System.Diagnostics.Debug.WriteLine("1");
            var code = _dataContext.Codes.First(c => c.doctorId == null);
            var enrolled = _dataContext.Enroll.First(e => e.Id.ToString() == id);
            enrolled.status = "approved";
            EmailMessage emailMessage = new EmailMessage();
            EmailAddress from = new EmailAddress();
            from.Name = "EpidemyTracker Admin";
            from.Address = "epidemytracker@gmail.com";
            System.Diagnostics.Debug.WriteLine("2");

            EmailAddress to = new EmailAddress();
            to.Name = enrolled.firstName + " " + enrolled.lastName;
            to.Address = enrolled.emailAddress.Trim();

            emailMessage.ToAddress = to;
            emailMessage.FromAddress = from;
            emailMessage.Subject = "Epidemy tracker response";
            emailMessage.Content = "Hello " + enrolled.firstName + ", \n We are glad to announce you that you have been approved to register on our platform! We are looking forward to working " +
                "with you in order to help people in need in such a a time of crysis. \n Your assigned register code is: " + code.Code.ToString() + ", please use it in order to create a new account.";

            EmailService emailService = new EmailService(_emailConfiguration);
            System.Diagnostics.Debug.WriteLine("2.5");

            emailService.Send(emailMessage);
            System.Diagnostics.Debug.WriteLine("3");

            await _dataContext.SaveChangesAsync();
            System.Diagnostics.Debug.WriteLine("4");

            return RedirectToAction("Requests");
        }
        public async Task<IActionResult> DenyDoctor(string id)
        {
            var enrolled = _dataContext.Enroll.First(e => e.Id.ToString() == id);
            enrolled.status = "denied";
            EmailMessage emailMessage = new EmailMessage();
            EmailAddress from = new EmailAddress();
            from.Name = "EpidemyTracker Admin";
            from.Address = "epidemytracker@gmail.com";

            EmailAddress to = new EmailAddress();
            to.Name = enrolled.firstName + " " + enrolled.lastName;
            to.Address = enrolled.emailAddress.Trim();

            emailMessage.ToAddress = to;
            emailMessage.FromAddress = from;
            emailMessage.Subject = "Epidemy tracker response";
            emailMessage.Content = "Hello " + enrolled.firstName + ", \n We are sad to annouce you that after reviewing your application, we didn't find you compatible" +
                "with out programme. We thank you for the interest shown and wish you the best in your future projects and activities!";
            EmailService emailService = new EmailService(_emailConfiguration);
            emailService.Send(emailMessage);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction("Requests");
        }


    }
}