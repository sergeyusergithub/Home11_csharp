using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home11_csharp
{
    internal interface IFilm
    {
        string Name { get; set; }
        string Year { get; set; }
        string Producer { get; set; }
        string Genre { get; set; }
    }
}
