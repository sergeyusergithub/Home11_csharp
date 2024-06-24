using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Home11_csharp
{
    public class FilmManager
    {
        public List<Film> films { get; set; } = new List<Film>();
        public void AddFilm(Film obj)
        {
            films.Add(obj);
        }
        public void RemoveFilm(Film obj)
        {
            films.Remove(obj);
        }

        // поиск фильмов по различным критериям
        // itemFind:
        // 1 - поиск по названию
        // 2 - поиск по году
        // 3 - поиск по режиссеру
        // 4 - поиск по жанру 
        public List<Film> FindFilm(Film obj, int itemFind)
        {
            switch (itemFind)
            {
                case 1:
                    return films.Where(f => f.Name == obj.Name).ToList();
                case 2:
                    return films.Where(f => f.Year == obj.Year).ToList();
                case 3:
                    return films.Where(f => f.Producer == obj.Producer).ToList();
                case 4:
                    return films.Where(f => f.Genre == obj.Genre).ToList();
                default:
                    throw new Exception("Ошибка: нет такой категории.");
            }
        }

        // метод сохранения в файл XML
        // принимает путь файла
        public void SaveToXML(string path)
        {
            // создаем XML документ
            XmlDocument xmlDoc = new XmlDocument();
            // создаем корневой элемент и закрепляем его в XML документе
            XmlElement root = xmlDoc.CreateElement("FilmManager");
            xmlDoc.AppendChild(root);

            // создаем новый элемент и закрепляем его в корневом элементе 
            XmlElement film;
            XmlElement itemFilm;
            foreach (var item in films)
            {
                film = xmlDoc.CreateElement("Film");
                root.AppendChild(film);


                itemFilm = xmlDoc.CreateElement("Name");
                itemFilm.InnerText = item.Name;
                film.AppendChild(itemFilm);

                itemFilm = xmlDoc.CreateElement("Year");
                itemFilm.InnerText = item.Year;
                film.AppendChild(itemFilm);


                itemFilm = xmlDoc.CreateElement("Producer");
                itemFilm.InnerText = item.Producer;
                film.AppendChild(itemFilm);

                itemFilm = xmlDoc.CreateElement("Genre");
                itemFilm.InnerText = item.Genre;
                film.AppendChild(itemFilm);

            }

            xmlDoc.Save(path);

        }


        // метод сохранения в файл JSON
        public void SaveToJson(string path)
        {
            var toJson = JsonConvert.SerializeObject(films,Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(path, toJson);
        }

        // метода загрузки из файла XML
        public void LoadFromXML(string path)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);

            XmlNode? root = xDoc.DocumentElement;

            if (!root.HasChildNodes)
                throw new Exception();
                        
            foreach(XmlNode itemNode in root.ChildNodes)
            {
                if (!itemNode.HasChildNodes)
                    throw new Exception();

                /* AddFilm(new Film
                 {
                     Name = itemNode["Name"].InnerText,
                     Year = itemNode["Year"].InnerText,
                     Producer = itemNode["Producer"].InnerText,
                     Genre = itemNode["Gener"].InnerText
                 });*/
                Console.WriteLine(itemNode["Name"].InnerText);
            }
        }

        // метод загрузки из файла JSON

        public void LoadFromJson(string path) 
        {
            var fromJson = File.ReadAllText(path);
            films = JsonConvert.DeserializeObject<List<Film>>(fromJson);
        }

    }
}
