using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VirusTracker.Data;
using VirusTracker.Helpers;
using VirusTracker.Models;

namespace VirusTracker.Controllers
{
    [Authorize(Roles = "DefaultUser, Administrator")]
    public class MessageController : Controller
    {
        private readonly VirusTrackerContext _dataContext;
        private readonly UserManager<Doctor> _userManager;
        private readonly IEmailConfiguration _emailConfiguration;

        public MessageController(UserManager<Doctor> userManager, VirusTrackerContext dataContext, IEmailConfiguration emailConfiguration)
        {
            _userManager = userManager;
            _dataContext = dataContext;
            _emailConfiguration = emailConfiguration;
        }
        public IActionResult Index(string doctorId)
        {
            dynamic mymodel = new ExpandoObject();
            var messages = _dataContext.Message.Where(m => m.doctorId == doctorId).ToList();
            var doctor = _userManager.Users.FirstOrDefault(u => u.Id == doctorId);
            TempData["doctorId"] = doctor.Id;
            mymodel.Messages = messages.OrderByDescending(d => d.timestamp).ToList();
            mymodel.Doctor = doctor; 
            
            return View(mymodel);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(IFormCollection data)
        {
            var msg = new Message();
            msg.doctorId = data["doctorId"];
            msg.Name = data["name"];
            msg.timestamp = DateTime.Parse(data["date"]);
            msg.subject = data["subject"];
            msg.messageContent = data["message"];
            msg.Email = data["email"];
            msg.type = data["type"];
            _dataContext.Message.Add(msg);
            await _dataContext.SaveChangesAsync();
            TempData["sendMessageCheck"] = "success";
            return RedirectToAction("Index", new { doctorId = data["doctorId"].ToString()});
        }

        [HttpPost]
        public async Task<IActionResult> AnswerInternal(IFormCollection data)
        {
            var msg = _dataContext.Message.ToList().Find(m => m.ID.ToString() == data["messageId"]);
            if (msg != null)
            {
                msg.answer = data["answer"];
                await _dataContext.SaveChangesAsync();
                TempData["messageCheck"] = "Internal message answered successfully";
            }
            else
            {
                TempData["messageCheck"] = "fail";
            }
            return RedirectToAction("Messages", "Admin");
        }

        [HttpPost]
        public async Task<IActionResult> AnswerExternal(IFormCollection data)
        {
            var msg = _dataContext.Message.ToList().Find(m => m.ID.ToString() == data["messageId"]);
            if(msg != null)
            {
                msg.answer = data["answer"];
                await _dataContext.SaveChangesAsync();
                EmailService emailService = new EmailService(_emailConfiguration);
                EmailMessage email = new EmailMessage();
                email.Content = msg.answer;
                email.FromAddress = new EmailAddress() { Name = "EpidemyTracker Admin", Address = "epidemytracker@gmail.com" };
                email.ToAddress = new EmailAddress() { Name = msg.Name.Trim(), Address = msg.Email.Trim() };
                email.Subject = msg.subject + " - Answer";
                emailService.Send(email);
                await _dataContext.SaveChangesAsync();
                TempData["messageCheck"] = "External message answered successfully";
            } else
            {
                TempData["messageCheck"] = "fail";
            }

            return RedirectToAction("Messages", "Admin");
        }
    }
}