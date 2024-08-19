using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDZ13
{
    public interface IFilm
    {
        string Title { get; }
        string Description { get; set; }
        long Id { get; set; }
        string Genre { get; set; }  // жанр
        int Date { get; set; } // год выхода фильма
        

    }
}
