using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace steamC_
{
    internal class Program
    {
        public class Game
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Genre { get; set; }
            public int ReleaseYear { get; set; }
            public string Developer { get; set; }
            public double Rating { get; set; }
        }
        public class GameController
        {
            private List<Game> games;

            public GameController()
            {
                games = new List<Game>();
                LoadGamesFromXml();
            }
            public void ListGames()
            {
                Console.WriteLine("Бібліотека ігр:");
                foreach (var game in games)
                {
                    Console.WriteLine($"{game.Id}. {game.Title} ({game.Genre}) - {game.ReleaseYear} - {game.Developer} - Rating: {game.Rating}");
                }
            }
            public void AddGame(Game newGame)
            {
                newGame.Id = games.Count + 1;
                games.Add(newGame);
                SaveGamesToXml();
                Console.WriteLine($"Гра додана! {newGame.Id}");
            }
            public void EditGame(int id, Game updatedGame)
            {
                var gameToEdit = games.FirstOrDefault(g => g.Id == id);
                if (gameToEdit != null)
                {
                    gameToEdit.Title = updatedGame.Title;
                    gameToEdit.Genre = updatedGame.Genre;
                    gameToEdit.ReleaseYear = updatedGame.ReleaseYear;
                    gameToEdit.Developer = updatedGame.Developer;
                    gameToEdit.Rating = updatedGame.Rating;
                    SaveGamesToXml();
                    Console.WriteLine("Гра відредактовано успішно!");
                }
                else
                {
                    Console.WriteLine("Гра не знайдена!");
                }
            }

            public void DeleteGame(int id)
            {
                var gameToDelete = games.FirstOrDefault(g => g.Id == id);
                if (gameToDelete != null)
                {
                    games.Remove(gameToDelete);
                    SaveGamesToXml();
                    Console.WriteLine("Гра видалена!");
                }
                else
                {
                    Console.WriteLine("Гра не знайдена!");
                }
            }

            public void ViewGameDetails(int id)
            {
                var game = games.FirstOrDefault(g => g.Id == id);
                if (game != null)
                {
                    Console.WriteLine($"Заголовок: {game.Title}");
                    Console.WriteLine($"Жанр: {game.Genre}");
                    Console.WriteLine($"Реліз: {game.ReleaseYear}");
                    Console.WriteLine($"Розробник: {game.Developer}");
                    Console.WriteLine($"Рейтинг: {game.Rating}");
                }
                else
                {
                    Console.WriteLine("Гра не знайдена!");
                }
            }

            private void LoadGamesFromXml()
            {
                var doc = XDocument.Load("games.xml");
                games = doc.Root.Elements("Game")
                    .Select(x => new Game
                    {
                        Id = int.Parse(x.Element("Id").Value),
                        Title = x.Element("Title").Value,
                        Genre = x.Element("Genre").Value,
                        ReleaseYear = int.Parse(x.Element("ReleaseYear").Value),
                        Developer = x.Element("Developer").Value,
                        Rating = double.Parse(x.Element("Rating").Value)
                    })
                    .ToList();
            }
            private void SaveGamesToXml()
            {
                var doc = new XDocument(new XElement("Games",
                    games.Select(g => new XElement("Game",
                        new XElement("Id", g.Id),
                        new XElement("Title", g.Title),
                        new XElement("Genre", g.Genre),
                        new XElement("ReleaseYear", g.ReleaseYear),
                        new XElement("Developer", g.Developer),
                        new XElement("Rating", g.Rating)))));

                doc.Save("games.xml");
            }
        }
        public class View
        {
            public static void ShowMainMenu()
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Вибирите гру з бібліотеки");
                Console.WriteLine("2. Добавити гру");
                Console.WriteLine("3. Редактувати гру");
                Console.WriteLine("4. Видалити гру");
                Console.WriteLine("5. Показати деталі гри");
                Console.WriteLine("6. Вихід");
            }

            public static Game PromptForGameDetails()
            {
                Console.WriteLine("Деталі про гру:");
                Console.Write("Заголовок: ");
                string title = Console.ReadLine();
                Console.Write("Жанр: ");
                string genre = Console.ReadLine();
                Console.Write("Реліз: ");
                int releaseYear = int.Parse(Console.ReadLine());
                Console.Write("Розробник: ");
                string developer = Console.ReadLine();
                Console.Write("Рейтинг: ");
                double rating = double.Parse(Console.ReadLine());
                return new Game { Title = title, Genre = genre, ReleaseYear = releaseYear, Developer = developer, Rating = rating };
            }

            public static int PromptForGameSelection()
            {
                Console.Write("Введіть ID гри: ");
                return int.Parse(Console.ReadLine());
            }
        }

        static void Main(string[] args)
        {
            GameController controller = new GameController();

            bool exit = false;
            while (!exit)
            {
                View.ShowMainMenu();
                Console.Write("Choose an option: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        controller.ListGames();
                        break;
                    case 2:
                        Game newGame = View.PromptForGameDetails();
                        controller.AddGame(newGame);
                        break;
                    case 3:
                        int editId = View.PromptForGameSelection();
                        Game updatedGame = View.PromptForGameDetails();
                        controller.EditGame(editId, updatedGame);
                        break;
                    case 4:
                        int deleteId = View.PromptForGameSelection();
                        controller.DeleteGame(deleteId);
                        break;
                    case 5:
                        int viewId = View.PromptForGameSelection();
                        controller.ViewGameDetails(viewId);
                        break;
                    case 6:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Неправильне число.");
                        break;
                }
            }
        }
    }
}
