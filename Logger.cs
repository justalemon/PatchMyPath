using System;
using System.IO;
using System.Reflection;

namespace PatchMyPath
{
    static class Logger
    {
        public static void Write(string TextToLog)
        {
            Console.WriteLine(TextToLog);

            string TimeAndDate = DateTime.Now.ToString();
            string LogFolder = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string LogFile = Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location) + ".log";
            string FileName = LogFolder + "\\" + LogFile;

            if (!File.Exists(FileName))
                File.Create(FileName).Close();

            StreamWriter OpenedFile = new StreamWriter(FileName, true);
            OpenedFile.WriteLine(string.Format("[{0}] {1}", TimeAndDate, TextToLog));
            OpenedFile.Close();
        }
    }
}
