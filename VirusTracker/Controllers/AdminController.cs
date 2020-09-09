using System;
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
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        public IActionResult Index(string searchString)
        {
            var doctors = _userManager.Users.ToList();
            var patients = _dataContext.Patient.ToList();
            var codes = _dataContext.Codes.Where(c => c.doctorId != null).ToList();
            dynamic mymodel = new ExpandoObject();
            mymodel.Patients = patients;
            mymodel.Codes = codes;
            /*DataSeeder seeder = new DataSeeder(_dataContext);
            seeder.Seed(1000);
            _dataContext.SaveChanges();*/

            List<Doctor> searchResult = new List<Doctor>();
            if (!String.IsNullOrEmpty(searchString))
            {
                searchString.ToLower();
                foreach (var p in doctors)
                {
                    if (p.firstName.ToLower().Contains(searchString) || p.lastName.ToLower().Contains(searchString))
                        searchResult.Add(p);
                }
                TempData["searchCheck"] = "true";
                mymodel.Doctors = searchResult;
            }
            else
            {
                TempData["searchCheck"] = "false";
                mymodel.Doctors = doctors;

            }

            return View(mymodel);
        }

        public IActionResult Patients(string searchString)
        {
            var patients = _dataContext.Patient.ToList();

            List<Patient> searchResult = new List<Patient>();
            if (!String.IsNullOrEmpty(searchString))
            {
                searchString.ToLower();
                foreach (var p in patients)
                {
                    if (p.firstName.ToLower().Contains(searchString) || p.lastName.ToLower().Contains(searchString))
                        searchResult.Add(p);
                }
                TempData["searchCheck"] = "true";
                return View(searchResult);
            }
            else
            {
                TempData["searchCheck"] = "false";
                return View(patients);
            }
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
            if (doctor != null)
            {
                var doctorCode = _dataContext.Codes.ToList().Find(c => c.doctorId == doctor.Id);
                mydynamic.Doctor = doctor;
                mydynamic.Code = doctorCode;
            } else
            {
                mydynamic.Code = null;
                mydynamic.Doctor = null;
            }
            mydynamic.Patient = patient;
            return View(mydynamic);
        }

        public async Task<IActionResult> RemoveDoctor(string doctorId)
        {
            //System.Diagnostics.Debug.WriteLine("blabla" + doctorId);
            var toRemove = await _userManager.FindByIdAsync(doctorId);
            if (toRemove!= null)
            {
                var patients = _dataContext.Patient;
                foreach (var p in patients)
                {
                    if (p.doctorId == toRemove.Id)
                        p.doctorId = null;
                }
                _dataContext.Codes.FirstOrDefault(c => c.doctorId == toRemove.Id).doctorId = null;
                await _dataContext.SaveChangesAsync();
                await _userManager.DeleteAsync(toRemove);
                TempData["doctorName"] = toRemove.firstName + " " + toRemove.lastName;
            } else
            {
                TempData["doctorName"] = "fail";
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveFromDoctor(string patientId, string docId)
        {
            var patient = _dataContext.Patient.ToList().Find(p => p.ID.ToString() == patientId);
            if (patient != null)
            {
                patient.doctorId = null;
                await _dataContext.SaveChangesAsync();
                TempData["removeDoctorCheck"] = "success";
            }
            else
            {
                TempData["removeDoctorCheck"] = "fail";
            }
            return RedirectToAction("EditDoctor", new { doctorId = docId });
        }

        public async Task<IActionResult> RemoveFromPatient(string patId)
        {
            var patient = _dataContext.Patient.ToList().Find(p => p.ID.ToString() == patId);
            if(patient != null)
            {
                patient.doctorId = null;
                await _dataContext.SaveChangesAsync();
                TempData["removePatientCheck"] = "success";
            } else
            {
                TempData["removePatientCheck"] = "fail";
            }

            return RedirectToAction("EditPatient", new { patientId = patId });
        }

        [HttpPost]
        public async Task<IActionResult> SaveChangesDoctor(IFormCollection formdata)
        {
            //System.Diagnostics.Debug.WriteLine(formdata["fname"].ToString());
            var doctor = _userManager.Users.ToList().Find(d => d.Id == formdata["id"]);
            if(doctor != null)
            {
                doctor.firstName = formdata["fname"];
                doctor.lastName = formdata["lname"];
                doctor.UserName = formdata["username"];
                doctor.password = formdata["password"];
                doctor.Email = formdata["email"];
                doctor.PhoneNumber = formdata["phone"];
                await _dataContext.SaveChangesAsync();
                TempData["editDoctorCheck"] = doctor.firstName + " " + doctor.lastName;
            } else
            {
                TempData["editDoctorCheck"] = "fail";
            }
            
            return RedirectToAction("EditDoctor", new { doctorId = formdata["id"] });
        }

        [HttpPost]
        public async Task<IActionResult> SaveChangesPatient(IFormCollection formdata)
        {
            //System.Diagnostics.Debug.WriteLine(formdata["id"].ToString());
            var patient = _dataContext.Patient.ToList().Find(p => p.ID.ToString() == formdata["id"]);
            if(patient != null)
            {
                patient.firstName = formdata["fname"];
                patient.lastName = formdata["lname"];
                patient.address = formdata["address"];
                patient.emailAddress = formdata["email"];
                patient.phoneNumber = formdata["phone"];

                patient.contactFirstName = formdata["cfname"];
                patient.contactLastName = formdata["clname"];
                patient.contactAddress = formdata["caddress"];
                patient.contactEmailAddress = formdata["cemail"];
                patient.contactPhoneNumber = formdata["cphone"];

                patient.age = Int32.Parse(formdata["age"]);
                patient.weight = Int32.Parse(formdata["weight"]);
                patient.height = Int32.Parse(formdata["height"]);
                patient.symptoms = formdata["symptoms"];
                patient.treatment = formdata["treatment"];
                patient.treatmentComments = formdata["treatmentComments"];


                await _dataContext.SaveChangesAsync();
                TempData["editPatientCheck"] = patient.firstName + " " + patient.lastName;
            }
            else
            {
                TempData["editPatientCheck"] = "fail";
            }

            return RedirectToAction("EditPatient", new { patientId = formdata["id"] });
        }

        [HttpPost]
        public async Task<IActionResult> RemovePatient(IFormCollection data)
        {
            var toRemove = await _dataContext.Patient.FindAsync(Int32.Parse(data["patientId"]));
            if(toRemove!= null)
            {
                _dataContext.Remove(toRemove);
                await _dataContext.SaveChangesAsync();
                //await Response.WriteAsync("Patient " + toRemove.firstName.Trim() + " " + toRemove.lastName.Trim() + " has been removed successfully!");
                TempData["patientName"] = toRemove.firstName + " " + toRemove.lastName;
            } else
            {
                TempData["patientName"] = "fail";
            }
            
            return RedirectToAction("Patients");
        }

        public async Task<IActionResult> AnswerMessage(int messageId, string answer)
        {
            var x = _dataContext.Message.Find(messageId);
           
            return RedirectToAction("Messages");
        }
        public async Task<IActionResult> RemoveMessage(int messageId)
        {
            var toRemove = await _dataContext.Message.FindAsync(messageId);
            if(toRemove != null)
            {
                _dataContext.Remove(toRemove);
                await _dataContext.SaveChangesAsync();
                TempData["messageCheck"] = "Message removed successfully";

            }
            else
            {
                TempData["messageCheck"] = "fail";
            }

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
            //System.Diagnostics.Debug.WriteLine("1");
            var code = _dataContext.Codes.First(c => c.doctorId == null);
            if (code!= null)
            {
                var enrolled = _dataContext.Enroll.First(e => e.Id.ToString() == id);
                enrolled.status = "approved";
                EmailMessage emailMessage = new EmailMessage();
                EmailAddress from = new EmailAddress();
                from.Name = "EpidemyTracker Admin";
                from.Address = "epidemytracker@gmail.com";
                // System.Diagnostics.Debug.WriteLine("2");

                EmailAddress to = new EmailAddress();
                to.Name = enrolled.firstName + " " + enrolled.lastName;
                to.Address = enrolled.emailAddress.Trim();

                emailMessage.ToAddress = to;
                emailMessage.FromAddress = from;
                emailMessage.Subject = "Epidemy tracker response";
                emailMessage.Content = "Hello " + enrolled.firstName + ", \n We are glad to announce you that you have been approved to register on our platform! We are looking forward to working " +
                    "with you in order to help people in need in such a a time of crysis. \n Your assigned register code is: " + code.Code.ToString() + ", please use it in order to create a new account.";

                EmailService emailService = new EmailService(_emailConfiguration);
                // System.Diagnostics.Debug.WriteLine("2.5");

                emailService.Send(emailMessage);
           // System.Diagnostics.Debug.WriteLine("3");

                await _dataContext.SaveChangesAsync();
                TempData["requestCheck"] = "Request has been approved successfully";
            } else
            {
                TempData["requestCheck"] = "fail";
            }

            // System.Diagnostics.Debug.WriteLine("4");

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
            TempData["requestCheck"] = "Request has been denied successfully";

            return RedirectToAction("Requests");
        }


    }
}