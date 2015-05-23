using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;
using System.IO;


namespace Moulinette
{
    class Exo
    {
        private string name, folder, stdout, stderr;

        public string getName() { return name; }
        public string getStdout() { return stdout; }
        public string getStderr() { return stderr; }


        public Exo(string folderName) 
        {
            DirectoryInfo d = new DirectoryInfo(folderName);
            name = d.Name;
            folder = folderName;
        }

        public bool execute() 
        {
            try
            {
                ProcessStartInfo p = new ProcessStartInfo();
                p.FileName = folder + "/exo.exe";
                p.RedirectStandardOutput = true;
                p.RedirectStandardError = true;
                p.UseShellExecute = false;
                Process exo = Process.Start(p);
                stderr = exo.StandardError.ReadToEnd().Replace("\r","");
                stdout = exo.StandardOutput.ReadToEnd().Replace("\r", "");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
