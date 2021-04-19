using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CinemaCRUD
{
    public class FilmController
    {
        public List<string> films = new List<string>();
        public void Add(string Name, string Genre, string AgeRating, string Director, string description, List<int> session,string pathToPoster)
        {
            films.Clear();
            FilmModel film = new FilmModel() { Name = Name, Genre = Genre, AgeRating = AgeRating, Director = Director, Description = description , IDSession = session, PathToPoster = pathToPoster };
            films.Add(JsonConvert.SerializeObject(film));
            FileWorker.saveToFile(films, FileWorker.pathToDesktopFilms);

        }

        public void Edit(string oldname, string newname, string writePath, string Genre, string AgeRating, string Director, string description)
        {
            films.Clear();
            string[] arStr = File.ReadAllLines(writePath);
            using (FileStream fs = new FileStream(writePath, FileMode.Open))
            {

                using (StreamReader r = new StreamReader(fs, Encoding.Default))
                {
                    for (int i = 0; i < arStr.Length; i++)
                    {
                        var film = JsonConvert.DeserializeObject<FilmModel>(arStr[i]);
                        if (film == null)
                            continue;
                        else
                        {
                            if (oldname == film.Name)
                            {
                                film.Name = newname;
                                FilmModel newfilm = new FilmModel() { Name = film.Name,  Genre = Genre, AgeRating = AgeRating, Director = Director, Description = description };
                                films.Add(JsonConvert.SerializeObject(newfilm));
                                continue;
                            }
                        }
                        films.Add(JsonConvert.SerializeObject(film));
                    }
                }

                FileWorker.editFromFile(films, writePath);
            }
        }
        public void Delete(string name, string writePath)
        {
            films.Clear();
            string[] arStr = File.ReadAllLines(writePath);
            using (FileStream fs = new FileStream(writePath, FileMode.Open))
            {

                using (StreamReader r = new StreamReader(fs, Encoding.Default))
                {
                    for (int i = 0; i < arStr.Length; i++)
                    {
                        var film = JsonConvert.DeserializeObject<FilmModel>(arStr[i]);
                        if (film == null)
                            continue;
                        else if (name == film.Name)
                            continue;

                        films.Add(JsonConvert.SerializeObject(film));
                    }
                }

                FileWorker.editFromFile(films, writePath);
            }
        }
        public List<string> Shows(string writePath)
        {
            using (FileStream fs = new FileStream(writePath, FileMode.Open))
            {
                using (StreamReader r = new StreamReader(fs, Encoding.Default))
                {
                    films.Clear();
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        films.Add(line);
                    }
                    return films;
                }
            }
        }
    }
}
