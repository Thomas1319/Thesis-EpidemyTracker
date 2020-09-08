using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using VirusTracker.Data;
using VirusTracker.Models;

namespace VirusTracker.Controllers
{
    // [Authorize(Roles = "Administrator")]
    public class ToolsController : Controller
    {
        private readonly VirusTrackerContext _dataContext;
        private readonly UserManager<Doctor> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly string severeSymptoms = "difficulty breathing,chest pain or pressure,loss of speech or movement";
        private readonly string seriousSymptoms = "aches and pains,sore throat, diarrhea, conjunctivitis, headache, lack of taste or smell, rashes on skin, discolouration of fingers or toes";
        private readonly string mildSymptoms = "fever, dry cough,tiredness";

        private static Random random = new Random();

        public ToolsController(UserManager<Doctor> userManager, VirusTrackerContext dataContext, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _dataContext = dataContext;
            _roleManager = roleManager;
        }
        public IActionResult Codes()
        {
            var codes = _dataContext.Codes.ToList();
            return View(codes);
        }

        public IActionResult CreateDoctor()
        {
            
            return View();
        }

        public IActionResult CreatePatient()
        {
            
            return View();
        }

        static int getWeekNumber(DateTime date)
        {
            date = date.Date;
            DateTime mday = new DateTime(date.Year, date.Month, 1);
            DateTime mmonth = mday.AddDays((DayOfWeek.Monday + 7 - mday.DayOfWeek) % 7);
            if(mmonth > date)
            {
                mday = mday.AddMonths(-1);
                mmonth = mday.AddDays((DayOfWeek.Monday + 7 - mday.DayOfWeek) & 7);
            }
            return (date - mmonth).Days / 7 + 1;
        }
        static bool checkIfContains(string toCheck, string[] elements)
        {
            foreach(var e in elements)
            {
                if (toCheck.Contains(e) == true)
                    return true;
            }
            return false;
        }
        public async Task<IActionResult> Statistics(IFormCollection data)
        {
            dynamic mydynamic = new ExpandoObject();
            Dictionary<int, int> days = new Dictionary<int, int>();
            string[] features = { "severe", "mild", "serious" };
            if (String.IsNullOrEmpty(data["feature"]) == false)
            {
                if (checkIfContains(data["feature"], features) == true)
                {
                    string[] splitSymp = null;
                    if (data["feature"] == "severe")
                    {
                        splitSymp = severeSymptoms.Split(",");
                    }
                    else if (data["feature"] == "serious")
                    {
                        splitSymp = seriousSymptoms.Split(",");
                    }
                    else if (data["feature"] == "mild")
                    {
                        splitSymp = mildSymptoms.Split(",");
                    }

                    var toShow = _dataContext.Patient.ToList().FindAll(p => checkIfContains(p.symptoms, splitSymp) == true);
                    toShow = toShow.FindAll(p => p.symptomsDate.ToString("MMMM") == data["month"]);
                    toShow = toShow.OrderBy(p => p.symptomsDate).ToList();
                    if (data["week"] == "0")
                    {
                        foreach (var t in toShow)
                        {
                            if (days.ContainsKey(t.symptomsDate.Day))
                            {
                                days[t.symptomsDate.Day] += 1;
                            }
                            else
                            {
                                days[t.symptomsDate.Day] = 1;
                            }
                        }
                    }
                    else
                    {
                        foreach (var t in toShow)
                        {
                            if (getWeekNumber(t.symptomsDate).ToString() == data["week"])
                            {
                                if (days.ContainsKey(t.symptomsDate.Day))
                                {
                                    days[t.symptomsDate.Day] += 1;
                                }
                                else
                                {
                                    days[t.symptomsDate.Day] = 1;
                                }
                            }
                        }

                    }
                    List<int> keys = new List<int>();
                    List<int> values = new List<int>();
                    foreach (var d in days)
                    {
                        keys.Add(d.Key);
                        values.Add(d.Value);
                    }
                    if (keys.Count() <= 0 || values.Count() <= 0)
                        mydynamic.Title = JsonConvert.SerializeObject("No data has been found for your selection");
                    else
                        mydynamic.Title = JsonConvert.SerializeObject(data["feature"] + " in " + data["month"] + ": " + data["week"]);
                    mydynamic.Labels = JsonConvert.SerializeObject(keys);
                    mydynamic.Data = JsonConvert.SerializeObject(values);
                }
                else
                {
                    var toShow = _dataContext.Patient.ToList();
                    toShow = toShow.FindAll(p => p.symptomsDate.ToString("MMMM") == data["month"]);
                    toShow = toShow.OrderBy(p => p.symptomsDate).ToList();
                    if (data["week"] != "0")
                    {
                        foreach (var t in toShow)
                        {
                            if (getWeekNumber(t.symptomsDate).ToString() == data["week"])
                            {
                                if (days.ContainsKey(t.symptomsDate.Day))
                                {
                                    days[t.symptomsDate.Day] += 1;
                                }
                                else
                                {
                                    days[t.symptomsDate.Day] = 1;
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (var t in toShow)
                        {
                            if (days.ContainsKey(t.symptomsDate.Day))
                            {
                                days[t.symptomsDate.Day] += 1;
                            }
                            else
                            {
                                days[t.symptomsDate.Day] = 1;
                            }
                        }
                    }

                    List<int> keys = new List<int>();
                    List<int> values = new List<int>();
                    foreach (var d in days)
                    {
                        keys.Add(d.Key);
                        values.Add(d.Value);
                    }
                    if(keys.Count() <= 0 || values.Count() <= 0)
                        mydynamic.Title = JsonConvert.SerializeObject("No data has been found for your selection");
                    else
                        mydynamic.Title = JsonConvert.SerializeObject(data["feature"] + " in " + data["month"] + ": " + data["week"]);
                    mydynamic.Labels = JsonConvert.SerializeObject(keys);
                    mydynamic.Data = JsonConvert.SerializeObject(values);
                }
            }
            else
            {
                mydynamic.Labels = "null";
                mydynamic.Data = "null";
                mydynamic.Title = JsonConvert.SerializeObject("No data has been selected yet");
            }
            
            return View(mydynamic);
        }
        public async Task<IActionResult> ManageRoles()
        {
            dynamic mymodel = new ExpandoObject();
            var users = _userManager.Users.ToList();
            var usersWithRoles = new List<Tuple<string, string>>();
            foreach(var u in users)
            {
                var role = await _userManager.GetRolesAsync(u);
                //System.Diagnostics.Debug.WriteLine(string.Join(",", role.ToArray()));
                usersWithRoles.Add(new Tuple<string, string>(u.Id, string.Join(",", role.ToArray())));
            }
            mymodel.Users = users;
            mymodel.Roles = usersWithRoles;
            mymodel.Codes = _dataContext.Codes.ToList();
            return View(mymodel);
        }

        public async Task<IActionResult> GenerateCodes(IFormCollection formdata)
        {
            // System.Diagnostics.Debug.WriteLine(formdata["number"].ToString());
            int amount = Int32.Parse(formdata["number"]);
            const string s = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            for(var i = 0; i < amount; i++)
            {
                var sb = new System.Text.StringBuilder();
                for (var j = 0; j < 8; j++)
                {
                    var c = s[random.Next(0, s.Length)];
                    sb.Append(c);
                }
                if(_dataContext.Codes.ToList().Find(c => c.Code == sb.ToString()) == null)
                {
                    Codes c = new Codes();
                    c.Code = sb.ToString();
                    _dataContext.Codes.Add(c);
                    await _dataContext.SaveChangesAsync();
                } else
                {
                    i--;
                }
            }

            return RedirectToAction("Codes");
        }

        public async Task<IActionResult> DeleteCode(int id)
        {
            var code = _dataContext.Codes.Find(id);
            if(code.doctorId == null)
                _dataContext.Codes.Remove(code);
            else
            {
                var user = await _userManager.FindByIdAsync(code.doctorId);
                var patients = _dataContext.Patient.ToList().FindAll(p => p.doctorId == user.Id);
                foreach (var p in patients)
                    p.doctorId = null;
                _dataContext.Codes.Remove(code);
                await _userManager.DeleteAsync(user);
                
            }
            await _dataContext.SaveChangesAsync();

            return RedirectToAction("Codes");
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoc(Doctor doctor, IFormCollection formdata)
        {
            var code = formdata["code"].ToString();
            var found = _dataContext.Codes.ToList().Find(c => c.Code == code);
            if (found != null && found.doctorId == null)
            {
                if (ModelState.IsValid)
                {
                    System.Diagnostics.Debug.WriteLine(doctor.firstName);
                    await _userManager.CreateAsync(doctor, doctor.password);
                    await _userManager.AddToRoleAsync(doctor, "DefaultUser");
                    var createdUser = await _userManager.FindByNameAsync(doctor.UserName);
                    found.doctorId = createdUser.Id;
                    await _dataContext.SaveChangesAsync();
                }
            } else
            {
                System.Diagnostics.Debug.WriteLine("Invalid or unavailable code");
            }
            

            return RedirectToAction("CreateDoctor");
        }

        [HttpPost]
        public async Task<IActionResult> CreatePat(Patient patient)
        {
            if (ModelState.IsValid)
            {
                System.Diagnostics.Debug.WriteLine(patient.firstName);
                var symptoms = Request.Form["symptom"];
                string symptomsString = "";
                System.Diagnostics.Debug.WriteLine("I AM HERE");
                foreach (var s in symptoms)
                {
                    symptomsString += s.ToString() + ", ";
                }
                symptomsString = symptomsString.Substring(0, symptomsString.Length - 2);
                patient.symptoms = symptomsString;
                patient.quarantineEndDate = Convert.ToDateTime("13/02/1999 00:00:00");
                _dataContext.Patient.Add(patient);
                await _dataContext.SaveChangesAsync();
            }

            return RedirectToAction("CreatePatient");
        }

        [HttpPost]
        public async Task<IActionResult> SetRole(string id, string role)
        {
            var user = await _userManager.FindByIdAsync(id);
            var roles = await _userManager.GetRolesAsync(user);
            bool x = await _roleManager.RoleExistsAsync(role);
            if (!x)
            {
                var newRole = new IdentityRole();
                newRole.Name = role;
                await _roleManager.CreateAsync(newRole);
            }
            await _userManager.RemoveFromRolesAsync(user, roles.ToArray());
            await _userManager.AddToRoleAsync(user, role);
            return RedirectToAction("ManageRoles");
        }

        

    }
}