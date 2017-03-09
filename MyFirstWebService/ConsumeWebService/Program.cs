using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFirstWebService;
using MyFirstWebService.Models;
using MyFirstWebService.StockReference;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ConsumeWebService
{
    class Program
    {
        static void Main(string[] args)
        {
            TheWebService webServe = new TheWebService();

            Console.WriteLine("Now say {0}", webServe.HelloWorld());

            Console.ReadLine();

            var gameList = webServe.CurrentGames();

            Console.WriteLine("***************");

            foreach (var game in gameList)
            {
                Console.WriteLine($"ID : {game.Id}");
                Console.WriteLine($"Title : {game.Title}");
                Console.WriteLine($"Release Date : {game.Release}");
                Console.WriteLine($"ESRB Rating : {game.ESRB}");
                Console.WriteLine($"Studio : {game.Studio}");
                Console.WriteLine($"Rating 1-10 : {game.Rating}");
                Console.WriteLine("***************");
            }

            Console.WriteLine("Would you like to check your stocks? Y/N?");
            string rv = Console.ReadLine();

            if (rv == "Y")
            {
                checkStocks();
            }

            Console.WriteLine("Let's add a game");
            Game newGame = new Game();
            Console.WriteLine();

            Console.WriteLine("What is the Title of the game?");
            string gameName = Console.ReadLine();
            Console.WriteLine("When is/was the Release of the game?");
            string release = Console.ReadLine();
            DateTime releaseDate = DateTime.Parse(release);
            Console.WriteLine("What is the ESRB rating of the game?");
            string rating = Console.ReadLine();
            Console.WriteLine("What Studio created the game?");
            string studio = Console.ReadLine();
            Console.WriteLine("What is the rating of the game? (1-10)");
            string review = Console.ReadLine();
            Decimal reviewRating = Decimal.Parse(review);

            newGame.Title = gameName;
            newGame.Release = releaseDate;
            newGame.ESRB = rating;
            newGame.Studio = studio;
            newGame.Rating = reviewRating;

            webServe.addGame(newGame); 

            Console.ReadLine();
        }

        public static string saveXML(string xmlString)
        {
            string FILENAME = @"C:\_repos\TheGrind\MyFirstWebService\MyFirstWebService.Data\StockXML\";
            string FILEEXT = ".xml";

            var filename = FILENAME + DateTime.Today.ToString("yyyy-MM-dd") + FILEEXT;

            using (StreamWriter sw = File.CreateText(filename))
            {
                sw.WriteLine(xmlString);
                sw.Close();  
            }

            deserialize(filename);

            return filename;
        }

        public static void checkStocks()
        {
            StockQuoteSoapClient soap = new StockQuoteSoapClient();

            Console.WriteLine("Enter the name of the stock symbol...");

            string symbol = Console.ReadLine();

            string quote = soap.GetQuote(symbol);

            //Console.WriteLine(quote);

            saveXML(quote);
        }

        public static void deserialize(string path)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Stock.StockQuotes));
            StreamReader sr = new StreamReader(path);
            Stock.StockQuotesStock newStock = (Stock.StockQuotesStock)xml.Deserialize(sr);

            Console.WriteLine($"Company Stock Information");
            Console.WriteLine($"_____________________________");
            Console.WriteLine($"Company Name: {newStock.Name}");
            Console.WriteLine($"Company Symbol: {newStock.Symbol}");
            Console.WriteLine($"Last Market Value: {newStock.Last}");
            Console.WriteLine($"Percentage of Change: {newStock.PercentageChange}");
            Console.WriteLine($"Company's Annual Range: {newStock.AnnRange}");
            Console.WriteLine($"_____________________________");

            Console.ReadLine();

        }

       
    }
}
