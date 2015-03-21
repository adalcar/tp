using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Moulinette
{
    class Correction
    {
        private string name, folder, stdout, stderr;

        public string getName() { return name; }
        public string getStdout() { return stdout; }
        public string getStderr() { return stderr; }
        public Correction(string folderName) 
        {
            DirectoryInfo d = new DirectoryInfo(folderName);
            name = d.Name;
            folder = folderName;
        }

        public bool init() 
        {
            try
            {
                StreamReader s = new StreamReader((folder + "/stderr.txt"));
                stderr = s.ReadToEnd();
                s.Close();
                s = new StreamReader(folder + "/stdout.txt");
                stdout = s.ReadToEnd();
                s.Close();
                return true;
            }
            catch
            {
                Console.WriteLine("File not found");
                return false;
            }
        }
    }
}
