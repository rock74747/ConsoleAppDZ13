using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleAppDZ13
{
    public class Film : IFilm
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public long Id { get; set; }
        public string Genre { get; set; }  // жанр
        public int Year { get; set; } // выход фильма
        public void Print() // Метод вывода фильма в консоль
        {
            Console.WriteLine($"Название: {Title}, Описание: {Description}. Id: {Id}, Жанр: {Genre}, Год выхода: {Year}");
        }
    }
}
