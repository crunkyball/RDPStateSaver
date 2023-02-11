using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace RDPStateSaver
{
    class Log
    {
        private static string LogPath { get { return Application.LocalUserAppDataPath + "\\Log.txt"; } }

        public static void Clear()
        {
            File.WriteAllText(LogPath, string.Empty);
        }

        public static void Add(string text)
        {
            System.Console.WriteLine(text);

            StreamWriter logFile = File.AppendText(LogPath);
            logFile.WriteLine(text);
            logFile.Close();
        }
    }
}
