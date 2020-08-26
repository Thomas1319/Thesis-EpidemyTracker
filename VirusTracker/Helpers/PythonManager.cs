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
        private ScriptEngine _engine;
        public PythonManager()
        {
            _engine = Python.CreateEngine();
            string dir = Path.GetDirectoryName(@"D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\PythonScripts\Libraries\");
            ICollection<string> paths = _engine.GetSearchPaths();
            if (!String.IsNullOrWhiteSpace(dir))
            {
                paths.Add(dir);
            }
            paths.Add(Environment.CurrentDirectory);
            
            _engine.SetSearchPaths(paths);
        }
        public string Run()
        {
            dynamic scope = _engine.CreateScope();
            _engine.ExecuteFile(@"D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\PythonScripts\predict_text.py", scope);
            //dynamic predicter = scope.GetVariable("predict_text");
            dynamic stopwords = scope.GetVariable("stop_words");
            /*var input = "Today it was an okay day eben though i had a very bad headache, but towards the night i felt better.";
            var sent = predicter.get_prediction(predicter.clean_text(input))
            var res = printer();*/
            return stopwords;

        }
    }
}
