using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CinemaCRUD
{
    public static class FileWorker
    {
        public static string pathToDesktopFilms { get; } = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\Films.json";
        public static void saveToFile(List<string> text, string writePath)
        {
            openStreams("save", writePath, text);
        }
        public static void editFromFile(List<string> text, string writePath)
        {
            openStreams("edit", writePath, text);
        }

        private static void openStreams(string action, string writePath, List<string> text)
        {
            using (FileStream fs = new FileStream(writePath, FileMode.Append))
            {
                using (StreamWriter w = new StreamWriter(fs, Encoding.Default))
                {
                    if (action == "save")
                        w.WriteLine(text[0]);
                }
            }
            if (action == "edit")
                File.WriteAllLines(writePath, text);
        }
    }
}
