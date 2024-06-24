using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home11_csharp
{
    public class Film : IFilm
    {
        public string Name { get; set; }
        public string Year { get; set; }
        public string Producer { get; set; }
        public string Genre { get; set; }
    }
}
