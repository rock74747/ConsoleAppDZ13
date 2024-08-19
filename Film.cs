using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDZ13
{
    public class Film : IFilm
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public long Id { get; set; }
        public string Genre { get; set; }  // жанр
        public int Date { get; set; } // выход фильма
        public Film (string title, string description, long id, string genre, int date)
        {
            this.Title = title;
            this.Description = description;
            this.Id = id;
            this.Genre = genre;
            this.Date = date;
        }


    }
}
