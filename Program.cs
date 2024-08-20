using System.Collections.Generic;
using System.Reflection;

namespace ConsoleAppDZ13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FilmManager film = new FilmManager();

            film.AddFilm(new Film { Title = "Терминатор", Description = "Фильм о роботе из будущего", Id = 00001, Genre = "Фантастика", Year = 2002 });
            film.AddFilm(new Film{ Title = "Подлодка U-235", Description = "Фильм о немецкой подлодке во время II мировой", Id = 00002, Genre = "Боевик", Year = 2019 });
            film.AddFilm(new Film{ Title = "Битва богов", Description = "Фильм о вражде скандинавских богов", Id = 00003, Genre = "Фантастика", Year = 2021 });
            film.AddFilm(new Film{ Title = "Капитан Марвел", Description = "Фильм по комиксам известной компании Марвел ", Id = 00004, Genre = "Фантастика", Year = 2019 });
            film.AddFilm(new Film{ Title = "Паучий рейс", Description = "Фильм о самолете, тайно перевозящего смертельно опасных ядовитых пауков", Id = 00005, Genre = "Ужасы", Year = 2024 });
            film.AddFilm(new Film{ Title = "Плохие парни: навсегда", Description = "Фильм о полицейских", Id = 00006, Genre = "Триллер", Year = 2020 });
            film.AddFilm(new Film{ Title = "Оверлорд", Description = "Фильм о II мировой войне", Id = 00007, Genre = "Триллер", Year = 2018 });
            film.AddFilm(new Film{ Title = "Маска", Description = "Фильм о чудике, который нашел маску бога", Id = 00008, Genre = "Комедия", Year = 2002 });
            film.AddFilm(new Film{ Title = "Дюна", Description = "Фильм о противостоянии великих домов", Id = 00009, Genre = "Фантастика", Year = 2021 });
            film.AddFilm(new Film{ Title = "Звезда родилась", Description = "Фильм о любви музыканта Джексона и Элли", Id = 00010, Genre = "Мелодрама", Year = 2018 });
            film.AddFilm(new Film{ Title = "Терминатор", Description = "Фильм о роботе из будущего", Id = 000125, Genre = "Фантастика", Year = 2002 });

            
            film.Print();
            IEnumerable<IFilm> filtrFilm = film.FiltrFilmsByGenry (); // Поиск фильмов по жанру
            foreach (var item in filtrFilm)
            {
                Console.WriteLine($"Id: {item.Id} \nНазвание фильма: {item.Title} \nОписание фильма:" +
                    $" {item.Description} \nЖанр фильма: {item.Genre} \nГод выхода фильма: {item.Year} ");
            }
            film.SaveToXML("Films.xml"); // Сохранение в xml
            Console.WriteLine("\nЗагрузка фильмов из xml файла");
            film.Clear();
            foreach (IFilm el in film.LoadFromXML("Films.xml"))
            {
                film.AddFilm(el);
                el.Print();
            }

            film.SaveToJson("Film.json");      // // Сохранение в json
            Console.WriteLine("\nЗагрузка фильмов из json файла");
            film.Clear();
            foreach (var el in film.LoadFromJson("Film.json"))
            {
                film.AddFilm(el);
                el.Print();
            }

            film.Remove();
            film.Print();
        }
    }
}
