using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VirusTracker.Data;
using VirusTracker.Models;
using MimeKit;
using MailKit;
using MailKit.Security;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using VirusTracker.Helpers;
using System.Dynamic;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace VirusTracker.Controllers
{
    [Authorize(Roles = "DefaultUser, Administrator")]
    public class HandlePatientController : Controller
    {
        private readonly VirusTrackerContext _dataContext;
        private readonly UserManager<Doctor> _userManager;
        private readonly SignInManager<Doctor> _signInManager;
        private readonly IEmailConfiguration _emailConfiguration;
        private Dictionary<string, string> fileTypes;
        private readonly string docsPath;

        public HandlePatientController(UserManager<Doctor> userManager, SignInManager<Doctor> signInManager, VirusTrackerContext dataContext, IEmailConfiguration emailConfiguration)
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
        public async Task<IActionResult> Index(string id, string searchString)
        {
            var doctor = await _userManager.GetUserAsync(User);
            var currentPatient = _dataContext.Patient.First<Patient>(p => p.ID.ToString() == id);

            var path = Path.Combine(docsPath, currentPatient.ID + "_" + currentPatient.firstName.Trim() + "_" + currentPatient.lastName.Trim());
            //System.Diagnostics.Debug.WriteLine(path);

            EmailService emailService = new EmailService(_emailConfiguration); //MAYBE MOVE THIS SOMEWHERE ELSE
            var emails = emailService.ReceiveEmail(currentPatient, doctor);
            var allSentiment = _dataContext.Sentiment.Where(s => s.patientId == currentPatient.ID).ToList();
            if (allSentiment.Count == 0)
            {
                SentimentModel sentiment = new SentimentModel();
                sentiment.patientId = currentPatient.ID;
                sentiment.sentiment = 5.0;
                sentiment.timestamp = DateTime.UtcNow;
                _dataContext.Sentiment.Add(sentiment);
                await _dataContext.SaveChangesAsync();
                System.Diagnostics.Debug.WriteLine("Created default sentiment");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(allSentiment.FirstOrDefault().sentiment);

            }
            if (emails.Count > 0)
            {
                PythonManager pm = new PythonManager();
                foreach (var e in emails)
                {
                    var result = pm.PredictSentiment(Environment.CurrentDirectory + "/PythonScripts/predict_text.py", e.content);
                    var splitResult = result.Split("\n");
                    var computedSent = 0.0;
                    System.Diagnostics.Debug.WriteLine(splitResult[1]);
                    System.Diagnostics.Debug.WriteLine(Double.Parse(splitResult[1]).ToString());
                    System.Diagnostics.Debug.WriteLine((Double.Parse(splitResult[1])/100).ToString());
                    if (splitResult[0].Contains("Negative"))
                        computedSent = allSentiment.Last().sentiment - 0.75 * Double.Parse(splitResult[1]) / 1000;
                    else
                        computedSent = allSentiment.Last().sentiment + 0.75 * Double.Parse(splitResult[1]) / 1000;
                    if (computedSent < 0)
                        computedSent = 0;
                    if (computedSent > 10)
                        computedSent = 10;
                    System.Diagnostics.Debug.WriteLine(result);
                    SentimentModel sent = new SentimentModel();
                    sent.patientId = currentPatient.ID;
                    sent.timestamp = DateTime.UtcNow;
                    sent.sentiment = computedSent;
                    _dataContext.Sentiment.Add(sent);


                    _dataContext.Emails.Add(e);
                    await _dataContext.SaveChangesAsync();
                    _dataContext.Patient.First(p => p.ID == currentPatient.ID).messages += e.Id + ",";
                }
                pm.CloseProcess();
                
            }
            await _dataContext.SaveChangesAsync();
            var emailsId = currentPatient.messages.Split(",").ToList();
            var messages = _dataContext.Emails.Where(e => emailsId.Contains(e.Id.ToString())).ToList().OrderBy(d => d.date);

            //var emails = _dataContext.Emails.Where(e => emailsId.Contains(e.Id.ToString())).ToList();
            //emails.OrderBy(d => d.date).ToList();

            var current_sent = _dataContext.Sentiment.Where(s => s.patientId == currentPatient.ID).ToList().Last().sentiment;


            dynamic mymodel = new ExpandoObject();
            mymodel.Sentiment = current_sent;
            var updates = _dataContext.PatientUpdates.Where(u => u.patientId == currentPatient.ID).ToList();
            if (updates.Count > 0)
            {
                foreach (var u in updates)
                    System.Diagnostics.Debug.WriteLine(u.currentSymptoms);
                updates.OrderBy(d => d.timestamp);
                mymodel.Updates = updates;
                mymodel.LastUpdate = updates.LastOrDefault();
            }
            else
            {
                mymodel.LastUpdate = null;
                mymodel.Updates = null;
            }
            mymodel.Patient = currentPatient;


            int files = 0;
            try
            {
                files = Directory.GetFiles(path).ToList().Count;
            } catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine("no files");
            }
            mymodel.Documents = files;
            TempData["doctorId"] = doctor.Id;
            if (!String.IsNullOrEmpty(searchString))
            {
                TempData["searchCheck"] = true;
                searchString = searchString.ToLower();
                var filtered = messages.Where(m => m.content.ToLower().Contains(searchString));
                mymodel.Messages = filtered;
                return View(mymodel);
            } else
            {
                TempData["searchCheck"] = false;
                mymodel.Messages = messages;
                return View(mymodel);
            }
            //System.Diagnostics.Debug.WriteLine(currentPatient.firstName + "-------------------------");
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(string patientId, string message)
        {
            var currentPatient = _dataContext.Patient.First<Patient>(p => p.ID.ToString() == patientId);
            var doctor = await _userManager.GetUserAsync(User);
            if(message != null && currentPatient != null && doctor != null)
            {
                EmailMessage emailMessage = new EmailMessage();
                EmailAddress from = new EmailAddress();
                from.Name = doctor.firstName + " " + doctor.lastName;
                from.Address = doctor.Email.Trim();

                EmailAddress to = new EmailAddress();
                to.Name = currentPatient.firstName + " " + currentPatient.lastName;
                to.Address = currentPatient.emailAddress.Trim();

                emailMessage.ToAddress = to;
                emailMessage.FromAddress = from;
                emailMessage.Subject = "Epidemy tracker response";
                emailMessage.Content = message;

                var newEmail = new EmailsModel();
                newEmail.doctorId = doctor.Id;
                newEmail.patientId = currentPatient.ID.ToString();
                newEmail.fromAddress = doctor.Email;
                newEmail.toAddress = currentPatient.emailAddress;
                newEmail.content = message;
                newEmail.date = DateTime.UtcNow;
                newEmail.subject = "Epidemy tracker response";
                _dataContext.Emails.Add(newEmail);
                await _dataContext.SaveChangesAsync();
                _dataContext.Patient.First(p => p.ID == currentPatient.ID).messages += newEmail.Id.ToString() + ",";
                await _dataContext.SaveChangesAsync();

                EmailService emailService = new EmailService(_emailConfiguration);
                emailService.AnswerPatient(emailMessage, currentPatient, doctor);
                TempData["sendMessagePatient"] = "success";
            } else
            {
                TempData["sendMessagePatient"] = "fail";

            }


            return RedirectToAction("Index", new {id = patientId });

            
        }

        [HttpPost]
        public async Task<IActionResult> CreateUpdate(IFormCollection data)
        {
            //System.Diagnostics.Debug.WriteLine("0");
            var allUpdates = _dataContext.PatientUpdates.Where(u => u.patientId.ToString() == data["patientId"].ToString()).ToList();
            var patient = _dataContext.Patient.First<Patient>(p => p.ID == Int32.Parse(data["patientId"]));
            var update = new PatientUpdateModel();
            //System.Diagnostics.Debug.WriteLine("1");
            //System.Diagnostics.Debug.WriteLine(data["nbSymp"]);
            var currSympBuilder = "";
            update.patientId = Int32.Parse(data["patientId"]);
            update.timestamp = DateTime.Parse(data["timestamp"]);
            var size = Int32.Parse(data["nbSymp"]);
            if (data["currSymp" + size] != "")
                size += 1;
            for(int i = 0; i < size; i++)
            {
                if(data["currSymptom " + i].ToString().Trim() != "")
                    currSympBuilder += data["currSymptom " + i].ToString().Trim() + ":" + data["currComment " + i].ToString().Trim() + ",";
                //System.Diagnostics.Debug.WriteLine(currSympBuilder);
            }
                    
            if(currSympBuilder.Length > 0)
            {
                currSympBuilder = currSympBuilder.Substring(0, currSympBuilder.Length - 1);
                update.currentSymptoms = currSympBuilder;
            } else
            {
                update.currentSymptoms = "";
            }
            update.currentTreatment = data["currTreatment"];
            update.currentTreatmentComments = data["currTreatComm"];
            if(allUpdates.Find(c =>  c.currentSymptoms == update.currentSymptoms
                                && c.currentTreatment == update.currentTreatment && c.currentTreatmentComments == c.currentTreatmentComments) == null && 
                                ((update.currentSymptoms == patient.symptoms.Trim()
                                && update.currentTreatment == patient.treatment.Trim() && update.currentTreatmentComments == patient.treatmentComments.Trim())) == false)
            {
                //System.Diagnostics.Debug.WriteLine("2");

                _dataContext.PatientUpdates.Add(update);
                await _dataContext.SaveChangesAsync();
                TempData["updateDataPatient"] = "success";
            }
            else
            {
                TempData["updateDataPatient"] = "fail";
            }
       
            return RedirectToAction("Index", new { id = data["patientId"] });
        }

        public async Task<IActionResult> DeleteUpdate(string id, string patientId)
        {
            //System.Diagnostics.Debug.WriteLine("IN DELETE" + id);
            var toDelete = _dataContext.PatientUpdates.First(u => u.Id.ToString() == id);
            if(toDelete != null)
            {
                _dataContext.PatientUpdates.Remove(toDelete);
                await _dataContext.SaveChangesAsync();
                TempData["deleteDataPatient"] = "success";
            }
            else
            {
                TempData["deleteDataPatient"] = "fail";
            }

            return RedirectToAction("Index", new { id = patientId });
            
        }

        [HttpPost]
        public async Task<IActionResult> StartQuarantine(IFormCollection data)
        {
            var currentPatient = _dataContext.Patient.First(p => p.ID.ToString() == data["patientId"].ToString());
           // System.Diagnostics.Debug.WriteLine(data["days"]);
           if(currentPatient != null)
            {
                currentPatient.quarantineEndDate = DateTime.UtcNow.AddDays(Double.Parse(data["days"].ToString()));
                await _dataContext.SaveChangesAsync();
                TempData["startQuarantinePatient"] = currentPatient.quarantineEndDate.ToString();
            }
            else
            {
                TempData["startQuarantinePatient"] = "fail";
            }


            return RedirectToAction("Index", new { id = data["patientId"] });
        }

        [HttpPost]
        public async Task<IActionResult> StopQuarantine(string patientId)
        {
            var currentPatient = _dataContext.Patient.First<Patient>(p => p.ID.ToString() == patientId);
            if(currentPatient != null)
            {
                currentPatient.quarantineEndDate = DateTime.Parse("13/02/1999 00:00:00");
                await _dataContext.SaveChangesAsync();
                TempData["stopQuarantinePatient"] = "success";
            }
            else
            {
                TempData["stopQuarantinePatient"] = "fail";
            }


            return RedirectToAction("Index", new { id = patientId });
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
                return RedirectToAction("Index", new { id = id});
            }
        }
    }
}