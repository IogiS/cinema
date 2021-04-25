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

        public List<string> Shows(string writePath)
        {
            using (FileStream fs = new FileStream(writePath, FileMode.Open))
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
