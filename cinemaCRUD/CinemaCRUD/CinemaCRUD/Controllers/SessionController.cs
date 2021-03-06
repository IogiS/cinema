using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CinemaCRUD
{
    class SessionController
    {
        public List<string> sessions = new List<string>();
        public void Add(DateTime session)
        {
            sessions.Clear();
            SessionModel sessionModel = new SessionModel() { timeSession = session };
            sessions.Add(JsonConvert.SerializeObject(sessionModel));
            FileWorker.saveToFile(sessions, FileWorker.pathToSession);

        }
        public void Delete(DateTime dateTime, string writePath)
        {
            sessions.Clear();
            string[] arStr = File.ReadAllLines(writePath);
            using (FileStream fs = new FileStream(writePath, FileMode.Open))
            {

                using (StreamReader r = new StreamReader(fs, Encoding.Default))
                {
                    for (int i = 0; i < arStr.Length; i++)
                    {
                        var film = JsonConvert.DeserializeObject<SessionModel>(arStr[i]);
                        if (film == null)
                            continue;
                        else if (dateTime.ToString() == film.timeSession.ToString())
                            continue;

                        sessions.Add(JsonConvert.SerializeObject(film));
                    }
                }

                FileWorker.editFromFile(sessions, writePath);
            }
        }
        public List<string> Shows(string writePath)
        {
            using (FileStream fs = new FileStream(writePath, FileMode.OpenOrCreate))
            {
                using (StreamReader r = new StreamReader(fs, Encoding.Default))
                {
                    sessions.Clear();
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        sessions.Add(line);
                    }
                    return sessions;
                }
            }
        }





    }
}
