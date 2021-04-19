using System;
using System.Collections.Generic;

namespace CinemaCRUD
{
    public class FilmModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<int> IDSession { get; set; }

    }
}
