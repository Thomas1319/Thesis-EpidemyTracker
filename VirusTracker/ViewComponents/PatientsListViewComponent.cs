using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirusTracker.Data;
using VirusTracker.Models;

namespace VirusTracker.ViewComponents
{
    public class PatientsListViewComponent : ViewComponent
    {
        private readonly VirusTrackerContext _dataContext;
        private readonly UserManager<Doctor> _userManager;
        private readonly SignInManager<Doctor> _signInManager;


        public PatientsListViewComponent(UserManager<Doctor> userManager, SignInManager<Doctor> signInManager, VirusTrackerContext dataContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dataContext = dataContext;
        }
        public async Task<IViewComponentResult> InvokeAsync(string doctorId)
        {
            var patients = _dataContext.Patient.ToList();
            var myPatients = patients.FindAll(p => p.doctorId == doctorId);
            foreach (var p in myPatients)
            {
                System.Diagnostics.Debug.WriteLine(p.firstName + " " + p.lastName + " " + p.symptoms);
            }
            return View(myPatients);
        }
    }
}
