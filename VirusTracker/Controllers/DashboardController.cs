using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirusTracker.Data;
using VirusTracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace VirusTracker.Controllers
{
    [Authorize(Roles = "DefaultUser, Administrator")]
    public class DashboardController : Controller
    {

        private readonly VirusTrackerContext _dataContext;
        private readonly UserManager<Doctor> _userManager;
        private readonly SignInManager<Doctor> _signInManager;


        public DashboardController(UserManager<Doctor> userManager, SignInManager<Doctor> signInManager, VirusTrackerContext dataContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dataContext = dataContext;
        }
        public async Task<IActionResult> Index(string searchString, string sortOrder)
        {
            ViewData["fNameSort"] = sortOrder == "fname" ? "fname_desc" : "fname";
            ViewData["lNameSort"] = sortOrder == "lname" ? "lname_desc" : "lname";
            ViewData["addressSort"] = sortOrder == "address" ? "address_desc" : "address";
            ViewData["genderSort"] = sortOrder == "gender" ? "gender_desc" : "gender";
            ViewData["ageSort"] = sortOrder == "age" ? "age_desc" : "age";
            ViewData["symptomsSort"] = sortOrder == "symptoms" ? "symptoms_desc" : "symptoms";

            var applicationUser = await _userManager.GetUserAsync(User); 
            var patients = _dataContext.Patient.ToList();
            var myPatients = patients.FindAll(p => p.doctorId == applicationUser.Id);
            List<Patient> uncheckedPatients = patients.FindAll(p => p.doctorId == null); 

           // System.Diagnostics.Debug.WriteLine(searchString);
            TempData["doctorId"] = applicationUser.Id;
            List<Patient> searchResult = new List<Patient>();

            switch (sortOrder)
            {
                case "fname_desc":
                    uncheckedPatients = uncheckedPatients.OrderByDescending(p => p.firstName).ToList();
                    break;
                case "fname":
                    uncheckedPatients = uncheckedPatients.OrderBy(p => p.firstName).ToList();
                    break;
               case "lname_desc":
                    uncheckedPatients = uncheckedPatients.OrderByDescending(p => p.lastName).ToList();
                    break;
               case "lname":
                    uncheckedPatients = uncheckedPatients.OrderBy(p => p.lastName).ToList();
                    break;
               case "address_desc":
                    uncheckedPatients = uncheckedPatients.OrderByDescending(p => p.address).ToList();
                    break;
               case "address":
                    uncheckedPatients = uncheckedPatients.OrderBy(p => p.address).ToList();
                    break;
               case "gender_desc":
                    uncheckedPatients = uncheckedPatients.OrderByDescending(p => p.gender).ToList();
                    break;
               case "gender":
                    uncheckedPatients = uncheckedPatients.OrderBy(p => p.gender).ToList();
                    break;
               case "age_desc":
                    uncheckedPatients = uncheckedPatients.OrderByDescending(p => p.age).ToList();
                    break;
               case "age":
                    uncheckedPatients = uncheckedPatients.OrderBy(p => p.age).ToList();
                    break;
               case "symptoms_desc":
                    uncheckedPatients = uncheckedPatients.OrderByDescending(p => p.symptoms.Split(", ")[p.symptoms.Split(", ").Length - 1]).ToList();
                    break;
               case "symptoms":
                    uncheckedPatients = uncheckedPatients.OrderBy(p => p.symptoms.Split(", ")[p.symptoms.Split(", ").Length - 1]).ToList();
                    break;
                default:
                    uncheckedPatients = uncheckedPatients.OrderBy(p => p.symptomsDate).ToList();
                    break;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                searchString.ToLower();
                foreach(var p in uncheckedPatients)
                {
                    if (p.firstName.ToLower().Contains(searchString) || p.lastName.ToLower().Contains(searchString) || p.address.ToLower().Contains(searchString) || p.gender.ToLower().Contains(searchString) || p.symptoms.ToLower().Contains(searchString))
                        searchResult.Add(p);
                }
                TempData["searchCheck"] = "true";
                return View(searchResult);
            }
            else
            {
                TempData["searchCheck"] = "false";
                return View(uncheckedPatients);

            }

        }

       
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

            ViewData.Clear();
            HttpContext.Session.Clear();

            return RedirectToAction("Login", "Account");
        }
    }
}