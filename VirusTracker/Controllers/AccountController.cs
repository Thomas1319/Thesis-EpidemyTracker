using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VirusTracker.Data;
using VirusTracker.Helpers;
using VirusTracker.Models;

namespace VirusTracker.Controllers
{
    public class AccountController : Controller
    {
        private readonly VirusTrackerContext _context;
        private readonly UserManager<Doctor> _userManager;
        private readonly SignInManager<Doctor> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly long _sizeLimit;
        private readonly string _filePath;
        private Dictionary<string, string> fileTypes;


        public AccountController(UserManager<Doctor> userManager, SignInManager<Doctor> signInManager, VirusTrackerContext context, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _roleManager = roleManager;
            _sizeLimit = 1500000;
            _filePath = Directory.GetParent(Environment.CurrentDirectory) + "/NewDoctors";
            fileTypes = new Dictionary<string, string>() {  { ".pdf", "application/pdf" },
                                                            { ".doc", "application/msword" },
                                                            { ".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" } };

        }
        public IActionResult Index()
        {
            var docList = _context.Doctor.ToList();

            // System.Diagnostics.Debug.WriteLine(docList[0].Email.ToString() + "----------------------------------");
            return View(docList);
        }
        public IActionResult Register()
        {

            // DataSeeder data = new DataSeeder(_context);
            //data.Seed(200);
            //_context.SaveChanges();
            //var res = new PythonManager();
            //System.Diagnostics.Debug.WriteLine(res.Run(@"D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\PythonScripts\predict_text.py", "My life is miserable but i love dogs"));
            return View();
        }

        public IActionResult Enroll()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Doctor doctor, IFormCollection formdata)
        {
            var code = formdata["code"].ToString();
            var found = _context.Codes.ToList().Find(c => c.Code == code);
            if (found != null && found.doctorId == null)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.FindByNameAsync(doctor.UserName);
                    var res = await _userManager.CreateAsync(doctor, doctor.password);
                    var createdUser = await _userManager.FindByNameAsync(doctor.UserName);
                    found.doctorId = createdUser.Id;
                    bool x = await _roleManager.RoleExistsAsync("DefaultUser");
                    if (!x)
                    {
                        var role = new IdentityRole();
                        role.Name = "DefaultUser";
                        await _roleManager.CreateAsync(role);
                    }
                    await _context.SaveChangesAsync();
                    if (res.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(doctor, "DefaultUser");
                        var signInRes = await _signInManager.PasswordSignInAsync(doctor, doctor.password, false, false);

                        if (signInRes.Succeeded)
                        {
                            return RedirectToAction("Index", "Dashboard");
                        }
                        else
                            System.Diagnostics.Debug.WriteLine("sad register");
                    }
                    System.Diagnostics.Debug.WriteLine("sad create");
                } else {
                    System.Diagnostics.Debug.WriteLine("Code invalid or taken");
                }
            }
                
            return RedirectToAction("Register");
        }

        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Doctor doctor)
        {

            var user = await _userManager.FindByNameAsync(doctor.UserName);

            if(user != null)
            {
                var res = await _signInManager.PasswordSignInAsync(user, doctor.password, false, false);

                if (res.Succeeded)
                {
                    var x = await _userManager.IsInRoleAsync(user, "Administrator");
                    if(x == true)
                        return RedirectToAction("Index", "Admin");
                    else
                        return RedirectToAction("Index", "Dashboard");
                }
                else
                    System.Diagnostics.Debug.WriteLine("sad login");
                System.Diagnostics.Debug.WriteLine("found user");
            }
            return RedirectToAction("Login");
        }
        [HttpPost]
        public async Task<IActionResult> Enroll(EnrollModel model, IFormFile CV, IFormFile Letter)
        {
            if (!ModelState.IsValid)
            {
                System.Diagnostics.Debug.WriteLine("Bad model");
                return View("Enroll");
            }
            long size = CV.Length + Letter.Length;
            System.Diagnostics.Debug.WriteLine(size.ToString() + " " + _sizeLimit.ToString());
            if (size <= _sizeLimit)
            {
                if (!Directory.Exists(_filePath + "/" + model.Id + "_" + model.firstName + "_" + model.lastName))
                {
                    _context.Enroll.Add(model);
                    await _context.SaveChangesAsync();
                    var ok = 0;
                    Directory.CreateDirectory(_filePath + "/" + model.Id + "_" + model.firstName + "_" + model.lastName);
                    if (CV.Length > 0 && fileTypes.FirstOrDefault(x => x.Value == CV.ContentType).Key != null)
                    {
                        var filePath = Path.Combine(_filePath + "/"  + model.Id + "_" + model.firstName + "_" + model.lastName, model.firstName + "_" + model.lastName + "_CV" + fileTypes.FirstOrDefault(x => x.Value == CV.ContentType).Key); //Patient.firstName + "_" + Patient.lastName + "_" + i + ".txt"
                        using (var stream = System.IO.File.Create(filePath))
                        {
                            await CV.CopyToAsync(stream);
                            System.Diagnostics.Debug.WriteLine("Saved CV");
                            ok += 1;
                        }
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid file type for CV : " + CV.ContentType);
                    }
                    if (Letter.Length > 0 && fileTypes.FirstOrDefault(x => x.Value == Letter.ContentType).Key != null)
                    {
                        var filePath = Path.Combine(_filePath + "/" + model.Id + "_" + model.firstName + "_" + model.lastName, model.firstName + "_" + model.lastName + "_Letter" + fileTypes.FirstOrDefault(x => x.Value == CV.ContentType).Key); //Patient.firstName + "_" + Patient.lastName + "_" + i + ".txt"
                        using (var stream = System.IO.File.Create(filePath))
                        {
                            await Letter.CopyToAsync(stream);
                            System.Diagnostics.Debug.WriteLine("Saved Letter");
                            ok += 1;
                        }
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid file type for Letter : " + CV.ContentType);
                    }

                    if (ok != 2)
                    {
                        _context.Enroll.Remove(model);
                        Directory.Delete(_filePath + "/" + model.Id + "_" + model.firstName + "_" + model.lastName, true);
                        await _context.SaveChangesAsync();
                    } 
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Doctor already enrolled!");
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Size too big");
            }
    
            return RedirectToAction("Enroll");
        }


    }
    
}