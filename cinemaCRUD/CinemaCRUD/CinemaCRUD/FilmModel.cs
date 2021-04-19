using System;
using System.Collections.Generic;

namespace CinemaCRUD
{
    public class FilmModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string AgeRating { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string PathToPoster { get; set; }
        public List<int> IDSession { get; set; }

    }
}
