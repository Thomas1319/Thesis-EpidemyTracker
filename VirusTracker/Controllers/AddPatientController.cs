using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VirusTracker.Data;
using VirusTracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using VirusTracker.Helpers;
using System.Dynamic;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace VirusTracker.Controllers
{
    [Authorize(Roles = "DefaultUser, Administrator")]
    public class AddPatientController : Controller
    {
        private readonly VirusTrackerContext _dataContext;
        private readonly UserManager<Doctor> _userManager;
        private readonly SignInManager<Doctor> _signInManager;
        private readonly IEmailConfiguration _emailConfiguration;
        private Dictionary<string, string> fileTypes;
        private readonly string docsPath;

        public AddPatientController(UserManager<Doctor> userManager, SignInManager<Doctor> signInManager, VirusTrackerContext dataContext, IEmailConfiguration emailConfiguration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dataContext = dataContext;
            _emailConfiguration = emailConfiguration;
            fileTypes = new Dictionary<string, string>() {  { ".pdf", "application/pdf" },
                                                            { ".doc", "application/msword" },
                                                            { ".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" } };
            docsPath = Directory.GetParent(Environment.CurrentDirectory) + "/NewPatients";
        }
        public async Task<IActionResult> Index(string id)
        {
            var doctor = await _userManager.GetUserAsync(User);
            var currentPatient = _dataContext.Patient.First<Patient>(p => p.ID.ToString() == id);
            var path = Path.Combine(docsPath, currentPatient.ID + "_" + currentPatient.firstName.Trim() + "_" + currentPatient.lastName.Trim());

            int files = 0;
            try
            {
                files = Directory.GetFiles(path).ToList().Count;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("no files");
            }

            System.Diagnostics.Debug.WriteLine(files);

            TempData["documents"] = files;
            TempData["doctorId"] = doctor.Id;
            //System.Diagnostics.Debug.WriteLine(currentPatient.firstName + "-------------------------");
            return View(currentPatient);
        }

        [HttpPost]
        public async Task<IActionResult> ProcessPatient(Patient patient, IFormCollection data)
        {
            var doctor = await _userManager.GetUserAsync(User);
            System.Diagnostics.Debug.WriteLine(doctor.Id + " " + doctor.UserName);
            var foundPatient = _dataContext.Patient.First<Patient>(p => p.ID.ToString() == patient.ID.ToString());
            if(doctor != null && foundPatient != null)
            {
                if (patient.treatment.Equals("Custom"))
                    foundPatient.treatment = data["treatmentCustom"];
                else
                    foundPatient.treatment = patient.treatment;
                foundPatient.treatmentComments = patient.treatmentComments;
                foundPatient.doctorId = doctor.Id.ToString();

                if (!patient.treatment.Equals("See a general practitioner") && !patient.treatment.Equals("Custom"))
                    foundPatient.quarantineEndDate = DateTime.Now.AddDays(14);


                EmailMessage emailMessage = new EmailMessage();
                EmailAddress from = new EmailAddress();
                from.Name = doctor.firstName + " " + doctor.lastName;
                from.Address = doctor.Email.Trim();

                EmailAddress to = new EmailAddress();
                to.Name = foundPatient.firstName + " " + foundPatient.lastName;
                to.Address = foundPatient.emailAddress.Trim();

                emailMessage.ToAddress = to;
                emailMessage.FromAddress = from;
                emailMessage.Subject = "Epidemy tracker response - " + foundPatient.treatment;
                emailMessage.Content = foundPatient.treatmentComments;
                if (foundPatient.quarantineEndDate > DateTime.Now)
                    emailMessage.Content += "\n You should be in quaratine at least until: " + foundPatient.quarantineEndDate.ToString();

                var newEmail = new EmailsModel();
                newEmail.doctorId = doctor.Id;
                newEmail.patientId = foundPatient.ID.ToString();
                newEmail.fromAddress = doctor.Email.Trim();
                newEmail.toAddress = foundPatient.emailAddress.Trim();
                newEmail.content = emailMessage.Content;
                newEmail.date = DateTime.UtcNow;
                newEmail.subject = "Epidemy tracker response";
                _dataContext.Emails.Add(newEmail);
                await _dataContext.SaveChangesAsync();

                foundPatient.messages += newEmail.Id.ToString() + ",";
                await _dataContext.SaveChangesAsync();

                EmailService emailService = new EmailService(_emailConfiguration);
                emailService.AnswerPatient(emailMessage, foundPatient, doctor);

                TempData["addPatientCheck"] = foundPatient.firstName + " " + foundPatient.lastName;
            } else
            {
                TempData["addPatientCheck"] = "fail";
            }
            
       
            return RedirectToAction("Index", "Dashboard");
        }

        public async Task<IActionResult> GetDocument(string number, string id)
        {
            var currentPatient = _dataContext.Patient.First<Patient>(p => p.ID.ToString() == id);
            var path = Path.Combine(docsPath, currentPatient.ID + "_" + currentPatient.firstName.Trim() + "_" + currentPatient.lastName.Trim());
            System.Diagnostics.Debug.WriteLine(path);
            var files = Directory.GetFiles(path).ToList();
            string toFind = null;
            foreach (var f in files)
            {
                if (f.Contains(currentPatient.firstName.Trim() + "_" + currentPatient.lastName.Trim() + "_" + number))
                {
                    toFind = f;
                    break;
                }
            }

            System.Diagnostics.Debug.WriteLine(path);
            System.Diagnostics.Debug.WriteLine(toFind);
            if (toFind != null)
            {
                var memory = new MemoryStream();
                using (var stream = new FileStream(toFind, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }
                memory.Position = 0;
                var contentType = fileTypes.FirstOrDefault(t => t.Key == Path.GetExtension(toFind).ToLowerInvariant()).Value;
                return File(memory, contentType, Path.GetFileName(toFind));
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("File not found");
                return RedirectToAction("Index", new { id = id });
            }
        }
    }
}