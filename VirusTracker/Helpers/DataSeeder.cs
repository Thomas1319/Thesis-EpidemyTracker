using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web.Helpers;
using VirusTracker.Data;
using VirusTracker.Models;

namespace VirusTracker.Helpers
{
    public class DataSeeder
    {
        private static string filePath;
        private string hardSymptoms = "difficulty breathing,chest pain or pressure,loss of speech or movement";
        private string mediumSymptoms = "aches and pains,sore throat,diarrhea,conjunctivitis,headache,lack of taste or smell,rashes on skin,discolouration of fingers or toes";
        private string lowSymptoms = "fever,dry cough,tiredness";
        private readonly VirusTrackerContext _dataContext;
        public DataSeeder(VirusTrackerContext dataContext)
        {
            _dataContext = dataContext;
            try
            {
                filePath = Environment.CurrentDirectory + "/Data/PatientData4.json";
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
            }
        }

        public async void Seed(int amount)
        {
            var fileContent = File.ReadAllText(filePath);
            JArray array = JArray.Parse(fileContent);
            for(int i = 0; i < amount; i++)
            {
                Patient patient = new Patient();
                patient.firstName = array[i]["first_name"].ToString();
                patient.lastName = array[i]["last_name"].ToString();
                patient.address = array[i]["address"].ToString();
                patient.emailAddress = array[i]["emailAddress"].ToString();
                patient.phoneNumber = array[i]["phoneNumber"].ToString();
                if(!String.IsNullOrEmpty(array[i]["contactFirstName"].ToString()))
                {
                    patient.contactFirstName = array[i]["contactFirstName"].ToString();
                    patient.contactLastName = array[i]["contactLastName"].ToString();
                    patient.contactAddress = array[i]["contactAddress"].ToString();
                    patient.contactEmailAddress = array[i]["contactEmailAddress"].ToString();
                    patient.contactPhoneNumber = array[i]["contactPhoneNumber"].ToString();
                }
               // System.Diagnostics.Debug.WriteLine(array[i]["contactFirstName"].ToString() + " " + array[i]["contactLastName"].ToString());
                patient.age = Int32.Parse(array[i]["age"].ToString());
                patient.height = Int32.Parse(array[i]["height"].ToString());
                patient.gender = array[i]["gender"].ToString();
                patient.weight = Int32.Parse(array[i]["weigth"].ToString());
                patient.symptomsDate = DateTime.Parse(array[i]["symptomsDate"].ToString());
                patient.quarantineEndDate = DateTime.Parse(array[i]["quarantineEndDate"].ToString());
                //System.Diagnostics.Debug.WriteLine(array[i]["symptoms"].ToString());
                var sortedString = SortSymptoms(array[i]["symptoms"].ToString());
                patient.symptoms = sortedString;
                //System.Diagnostics.Debug.WriteLine("----------------------------------------n");
                _dataContext.Patient.Add(patient);
            }
        }

        private string SortSymptoms(string s)
        {
            string newString = "";
            string helper = "";
            var asArray = s.Split(',').ToArray();
            foreach(var w in asArray)
            {
                if (hardSymptoms.Contains("w"))
                    newString += w + ",";
                else if (mediumSymptoms.Contains("w"))
                    helper += w + ",";
                else
                    helper = w + "," + helper;
            }
            newString = helper + newString;
            newString = newString.Substring(0, newString.Length - 1);
           // System.Diagnostics.Debug.WriteLine(newString);
            return newString;
        }
    }
}
