using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CinemaCRUD.Controller
{
    public class CheckController
    {
        public List<string> checks = new List<string>();
        public void Add(string Name, string seats, string rows, int price, string session)
        {
            checks.Clear();
            CheckModel check = new CheckModel() { Name = Name, Seats = seats, Rows = rows, Session = session, Price = price };
            checks.Add(JsonConvert.SerializeObject(check));
            FileWorker.saveToFile(checks, FileWorker.pathToChecks);

        }
        public void Edit(string oldname, string newname, string seats, string rows, int price, string session)
        {
            checks.Clear();
            string[] arStr = File.ReadAllLines(FileWorker.pathToChecks);
            using (FileStream fs = new FileStream(FileWorker.pathToChecks, FileMode.Open))
            {

                using (StreamReader r = new StreamReader(fs, Encoding.Default))
                {
                    for (int i = 0; i < arStr.Length; i++)
                    {
                        var film = JsonConvert.DeserializeObject<CheckModel>(arStr[i]);
                        if (film == null)
                            continue;
                        else
                        {
                            if (oldname == film.Name)
                            {
                                CheckModel newfilm = new CheckModel() { Name = newname, Seats = seats, Rows = rows, Session = session, Price = price };
                                checks.Add(JsonConvert.SerializeObject(newfilm));
                                continue;
                            }
                        }
                        checks.Add(JsonConvert.SerializeObject(film));
                    }
                }

                FileWorker.editFromFile(checks, FileWorker.pathToChecks);
            }
        }
        public void Delete(string name, string writePath)
        {
            checks.Clear();
            string[] arStr = File.ReadAllLines(writePath);
            using (FileStream fs = new FileStream(writePath, FileMode.Open))
            {

                using (StreamReader r = new StreamReader(fs, Encoding.Default))
                {
                    for (int i = 0; i < arStr.Length; i++)
                    {
                        var film = JsonConvert.DeserializeObject<CheckModel>(arStr[i]);
                        if (film == null)
                            continue;
                        else if (name == film.Name)
                            continue;

                        checks.Add(JsonConvert.SerializeObject(film));
                    }
                }

                FileWorker.editFromFile(checks, writePath);
            }
        }
        public List<string> Shows(string writePath)
        {
            using (FileStream fs = new FileStream(writePath, FileMode.Open))
            {
                using (StreamReader r = new StreamReader(fs, Encoding.Default))
                {
                    checks.Clear();
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        checks.Add(line);
                    }
                    return checks;
                }
            }
        }
    }
}