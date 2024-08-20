using ConsoleAppDZ13;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.Json.Serialization;
using System.Formats.Asn1;


namespace ConsoleAppDZ13
{
    public class FilmManager
    {
        public List<IFilm> list = new List<IFilm> ();

        public void AddFilm(IFilm obj) // Метод добавление фильма
        {
            try
            {
                var title1 = list.Any(x => x.Title == obj.Title);
                var date1 = list.Any(x => x.Year == obj.Year);
                if (title1 && date1)
                {
                    throw new InvalidContactException($"Фильм с данным индексом или названием уже существует");
                }
                else
                    list.Add(obj);
            }
            catch (InvalidContactException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        public void Remove()                                        // Удаление фильма из коллекции
        {
            Console.WriteLine("\nУдаление фильма.");
            Console.WriteLine("Введите  название фильма ->");
            string title = Console.ReadLine();
            var title1 = list.Any(x => x.Title.ToLower() == title.ToLower());
            try
            {
                if (!title1)
                {
                    throw new InvalidContactException($"Фильм с данным названием не существует в коллекции");
                }
                else
                    list.RemoveAll(x => x.Title.ToLower() == title.ToLower());
                Console.WriteLine("Фильм удален из коллекции");
            }
            catch (InvalidContactException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        public IEnumerable<IFilm> FiltrFilmsByGenry()            // Поиск по жанру
        {
            Console.WriteLine("\nПоиск фильмов по жанру");
            Console.WriteLine("\nВведите жанр фильма ->");
            string genry = Console.ReadLine();
            return list.Where(p => p.Genre.ToLower() == genry.ToLower());
        }
        public void Print()                 // Вывод на экран коллекции
        {
            foreach (var item in list)
            {
                Console.WriteLine($"Id: {item.Id} \nНазвание фильма: {item.Title} \nОписание фильма:" +
                    $" {item.Description} \nЖанр фильма: {item.Genre} \nГод выхода фильма: {item.Year} ");
            }
        }
        public void Clear() { list.Clear(); }
        public void SaveToJson(string path) // Метод сохранения в файл json
        {
            string json = JsonConvert.SerializeObject(list);
            File.WriteAllText(path, json);
        }
        public IEnumerable<IFilm> LoadFromJson(string path) // Возвращаем список, которые выпишем из нашего файла json
        {
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<Film>>(json);
        }


        
        public void SaveToXML(string path) // Метод сохранения коллекции фильмов в xml-файле
        {
            XElement xml = new XElement("Films",
                from f in list
                select new XElement("Film",
                new XAttribute("Title", f.Title),
                new XAttribute("Description", f.Description),
                new XAttribute("Id", f.Id),
                new XAttribute("Genre", f.Genre),
                new XAttribute("Year", f.Year)
                ));
            xml.Save(path);
        }

        public IEnumerable<IFilm> LoadFromXML(string path) // Метод загрузки фильмов из xml-файла
        {
            XDocument xml = XDocument.Load(path); 
            var result = xml.Descendants("Film").Select(p => new Film
                  { Title = p.Attribute("Title").Value,
                    Description = p.Attribute("Description").Value,
                    Id = long.Parse (p.Attribute("Id").Value),
                    Genre = p.Attribute("Genre").Value,
                    Year = int.Parse (p.Attribute("Year").Value)
                }).ToList();
            return result;
        }
    }
}
