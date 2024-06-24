namespace Home11_csharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FilmManager filmManager = new FilmManager();

            filmManager.AddFilm(new Film { Name = "Терминатор", Year = "1984", Producer = "Джеймс Кэмерон", Genre = "Боевик. Научная фантастика." });
            filmManager.AddFilm(new Film { Name = "Терминатор 2", Year = "1991", Producer = "Джеймс Кэмерон", Genre = "Боевик. Научная фантастика." });
            filmManager.AddFilm(new Film { Name = "Хищник", Year = "1987", Producer = "Джон Мактирнан", Genre = "Ужасы. Научная фантастика." });
            filmManager.AddFilm(new Film { Name = "Хищник 2", Year = "1990", Producer = "Стивен Хопкинс", Genre = "Ужасы. Научная фантастика." });
            filmManager.AddFilm(new Film { Name = "Чужой", Year = "1979", Producer = "Ридли Скотт", Genre = "Ужасы. Научная фантастика." });


            filmManager.SaveToXML("FilmManager.xml");

            FilmManager newFilmList = new FilmManager();

            newFilmList.LoadFromXML("FilmManager.xml");

            foreach (Film item in newFilmList.films)
            {
                Console.WriteLine($"Фильм: {item.Name}, год выпуска: {item.Year}, режиссер: {item.Producer}, жанр: {item.Genre}");
            }

            /*filmManager.SaveToJson("FileManager.json");

            FilmManager newFilmListJson = new FilmManager();

            newFilmListJson.LoadFromJson("FileManager.json");

            foreach (Film item in newFilmListJson.films)
            {
                Console.WriteLine($"Фильм: {item.Name}, год выпуска: {item.Year}, режиссер: {item.Producer}, жанр: {item.Genre}");
            }*/
        }
    }
}
