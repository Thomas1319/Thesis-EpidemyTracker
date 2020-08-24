using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VirusQuestionaire.Data;
using VirusQuestionaire.Models;


namespace VirusQuestionaire.Pages
{
    public class QuestionaireModel : PageModel
    {
        private readonly VirusQuestionaire.Data.VirusQuestionaireContext _context;
        private readonly long _sizeLimit;
        private readonly string _filePath;
        private Dictionary<string, string> fileTypes;      
        public QuestionaireModel(VirusQuestionaire.Data.VirusQuestionaireContext context)
        {
            _context = context;
            _sizeLimit = 1500000;
            _filePath = Directory.GetParent(Environment.CurrentDirectory) + "/NewPatients";
            fileTypes = new Dictionary<string, string>() {  { ".pdf", "application/pdf" }, 
                                                            { ".doc", "application/msword" },
                                                            { ".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" } };
        }

        public IActionResult OnGet()
        {
            ViewData["symptoms"] = "fever,dry cough,tiredness,aches and pains,sore throat,diarrhea,conjunctivitis,headache,lack of taste or smell,rashes on skin,discolouration of fingers or toes,difficulty breathing,chest pain or pressure,loss of speech or movement";
            return Page();
        }

        [BindProperty]
        public Patient Patient { get; set; }

        public async Task<IActionResult> OnPostAsync(List<IFormFile> files)
        {
            if (!ModelState.IsValid)
            {
                System.Diagnostics.Debug.WriteLine("Wrong state");
                return Page();
            }

            var symptoms = Request.Form["symptom"];
            var extras = Request.Form["extra"];
            List<Tuple<string, string>> list = new List<Tuple<string, string>>();
            string symptomsString = "";
            System.Diagnostics.Debug.WriteLine("I AM HERE");
            for(int j = 0; j < symptoms.Count; j++)
            {
                Tuple<string, string> tuple = new Tuple<string, string>(symptoms[j], extras[j]);
                list.Add(tuple);
            }
            foreach(var s in list)
            {
                symptomsString += s.Item1 + ":" + s.Item2 + ",";
            }
            symptomsString = symptomsString.Substring(0, symptomsString.Length - 2); //remove trailing ","
            Patient.firstName = Patient.firstName.Trim(); //TRIMMED
            Patient.lastName = Patient.lastName.Trim(); // TRIMMED
            Patient.symptoms = symptomsString;
            System.Diagnostics.Debug.WriteLine(Patient.symptoms.ToString());
            Patient.quarantineEndDate = Convert.ToDateTime("13/02/1999 00:00:00");
            _context.Patient.Add(Patient);
            await _context.SaveChangesAsync();
            long size = files.Sum(f => f.Length);
            System.Diagnostics.Debug.WriteLine(size.ToString() + " " + _sizeLimit.ToString());
            int i = 0;
            if (size <= _sizeLimit)
            {
                if (!Directory.Exists(_filePath + "/" + Patient.ID + "_" + Patient.firstName + "_" + Patient.lastName))
                {
                    var ok = false;
                    Directory.CreateDirectory(_filePath + "/" + Patient.ID + "_" + Patient.firstName + "_" + Patient.lastName);
                    foreach (var formFile in files)
                    {
                        if (formFile.Length > 0 && fileTypes.FirstOrDefault(x => x.Value == formFile.ContentType).Key != null)
                        {
                            var safeFileName = Patient.firstName + "_" + Patient.lastName + "_" + i;
                            var filePath = Path.Combine(_filePath + "/" + Patient.ID + "_" + Patient.firstName + "_" + Patient.lastName, safeFileName + fileTypes.FirstOrDefault(x => x.Value == formFile.ContentType).Key); //Patient.firstName + "_" + Patient.lastName + "_" + i + ".txt"
                            using (var stream = System.IO.File.Create(filePath))
                            {
                                await formFile.CopyToAsync(stream);
                                System.Diagnostics.Debug.WriteLine("Saved file");
                                ok = true;
                                i++;
                            }
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("Invalid file type : " + formFile.ContentType);
                        }
                    }
                    if (ok == false)
                        Directory.Delete(_filePath + "/" + Patient.ID + "_" + Patient.firstName + "_" + Patient.lastName);
                } else
                {
                    System.Diagnostics.Debug.WriteLine("Patient already enrolled!");
                }
                    
            } else
            {
                System.Diagnostics.Debug.WriteLine("Size too big");
            }
            

            return RedirectToAction("/");
        }
    }
}