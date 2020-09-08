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
            var myPatients = _dataContext.Patient.Where(p => p.doctorId == doctorId).ToList();
            List<Tuple<Patient, double>> patientWithSent = new List<Tuple<Patient, double>>();
            foreach(var p in myPatients)
            {
                var sent = _dataContext.Sentiment.Where(s => s.patientId == p.ID).ToList();

                if (sent.Count > 0)
                {
                    //System.Diagnostics.Debug.WriteLine(sent.sentiment);

                    patientWithSent.Add(new Tuple<Patient, double>(p, sent.LastOrDefault().sentiment));
                } else
                {
                   // System.Diagnostics.Debug.WriteLine("set to 5");

                    patientWithSent.Add(new Tuple<Patient, double>(p, 5.0));
                }

            }
           
            return View(patientWithSent);
        }
    }
}
