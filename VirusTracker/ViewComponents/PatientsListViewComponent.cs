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


        public PatientsListViewComponent(VirusTrackerContext dataContext)
        {
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
