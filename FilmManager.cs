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
    public class FilmManager<T> where T : IFilm
    {
        public List<Film> list = new List<Film> { };

        public void AddFilm(Film film)
        {
            try
            {
                var title1 = list.Any(x => x.Title == film.Title);
                var date1 = list.Any(x => x.Date == film.Date);
                if (title1 && date1)
                {
                    throw new InvalidContactException($"Фильм с данным индексом или названием уже существует");
                }
                else
                    list.Add(film);
            }
            catch (InvalidContactException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        public void Add()                                        // Добавление фильма в коллекцию
        {
            Console.WriteLine("\nДобавление фильма.");
            Console.WriteLine("Введите ID фильма ->");
            long id = (long)Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Введите название фильма ->");
            string title = Console.ReadLine();
            Console.WriteLine("Введите описание фильма ->");
            string description = Console.ReadLine();
            Console.WriteLine("Введите жанр фильма ->");
            string genre = Console.ReadLine();
            Console.WriteLine("Введите год выпуска фильма в прокат ->");
            int date = Convert.ToInt32(Console.ReadLine());
            try
            {
                var title1 = list.Any(x => x.Title == title);
                var date1 = list.Any(x => x.Date == date);
                if (title1 && date1)
                {
                    throw new InvalidContactException($"Фильм с данным названием уже существует");
                }
                else
                    list.Add(new Film(title, description, id, genre, date));
                Console.WriteLine("Фильм добавлен в коллекцию");
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
        public IEnumerable<Film> FiltrFilmsByGenry()            // Поиск по жанру
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
                    $" {item.Description} \nЖанр фильма: {item.Genre} \nГод выхода фильма: {item.Date} ");
            }
        }
        public void SaveToJson(string path) // Метод сохранения в файл json
        {
            string json = JsonConvert.SerializeObject(list);
            File.WriteAllText(path, json);
        }
        public void LoadFromJson(string path) // Возвращаем список, которые выпишем из нашего файла json
        {
            string json = File.ReadAllText(path);
            list = JsonConvert.DeserializeObject<List<Film>>(json);
        }
    }
}
