using IronPython.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Scripting.Hosting;
using Microsoft.VisualStudio.Web.CodeGeneration.Templating;
using Microsoft.Scripting;
using System.Diagnostics;

namespace VirusTracker.Helpers
{
    public class PythonManager
    {
        private ProcessStartInfo start;
        private Process process;
        public PythonManager()
        {
            start = new ProcessStartInfo();
            start.FileName = @"D:\Python\python.exe"; // route where to find python
            start.UseShellExecute = false;
            start.CreateNoWindow = true;
            start.RedirectStandardOutput = true;
            start.RedirectStandardError = true;
            start.LoadUserProfile = true;
        }
        public string PredictSentiment(string cmd, string args)
        {
            start.Arguments = string.Format("\"{0}\" \"{1}\"", cmd, args);
            process = Process.Start(start);
            StreamReader reader = process.StandardOutput;
            string stderr = process.StandardError.ReadToEnd();
            string result = reader.ReadToEnd();
            Debug.Write(stderr);
            return(result);
        }
        public void CloseProcess()
        {
            process.Kill();
        }
    }
}
