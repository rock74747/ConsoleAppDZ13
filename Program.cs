using System.Collections.Generic;

namespace ConsoleAppDZ13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FilmManager <Film> film = new FilmManager <Film> ();
           
            film.AddFilm(new Film("Терминатор", "Фильм о роботе из будущего", 00001, "Фантастика", 2002));
            film.AddFilm(new Film("Подлодка U-235", "Фильм о немецкой подлодке во время II мировой", 00002, "Боевик", 2019));
            film.AddFilm(new Film("Битва богов", "Фильм о вражде скандинавских богов", 00003, "Фантастика", 2021));
            film.AddFilm(new Film("Капитан Марвел", "Фильм по комиксам известной компании Марвел ", 00004, "Фантастика", 2019));
            film.AddFilm(new Film("Паучий рейс", "Фильм о самолете, тайно перевозящего смертельно опасных ядовитых пауков", 00005, "Ужасы", 2024));
            film.AddFilm(new Film("Плохие парни: навсегда", "Фильм о полицейских", 00006, "Триллер", 2020));
            film.AddFilm(new Film("Оверлорд", "Фильм о II мировой войне", 00007, "Триллер", 2018));
            film.AddFilm(new Film("Маска", "Фильм о чудике, который нашел маску бога", 00008, "Комедия", 2002));
            film.AddFilm(new Film("Дюна", "Фильм о противостоянии великих домов", 00009, "Фантастика", 2021));
            film.AddFilm(new Film("Звезда родилась", "Фильм о любви музыканта Джексона и Элли", 00010, "Мелодрама", 2018));
            film.AddFilm(new Film("Терминатор", "Фильм о роботе из будущего", 000125, "Фантастика", 2002));

            
            film.Print();
            IEnumerable<Film> filtrFilm = film.FiltrFilmsByGenry (); // Поиск фильмов по жанру
            foreach (var item in filtrFilm)
            {
                Console.WriteLine($"Id: {item.Id} \nНазвание фильма: {item.Title} \nОписание фильма:" +
                    $" {item.Description} \nЖанр фильма: {item.Genre} \nГод выхода фильма: {item.Date} ");
            }
            film.Remove();
            film.Print();
            film.SaveToJson("Film.json"); // Сохранение в json
            Console.WriteLine("\nЗагрузка фильмов из json файла");
            film.LoadFromJson("Film.json"); // Загрузка из json файла
            foreach (var item in film.list)
            {
                Console.WriteLine($"Id: {item.Id} \nНазвание фильма: {item.Title} \nОписание фильма:" +
                    $" {item.Description} \nЖанр фильма: {item.Genre} \nГод выхода фильма: {item.Date} ");
            }
        }
    }
}
