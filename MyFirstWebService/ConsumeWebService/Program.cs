using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFirstWebService;
using MyFirstWebService.Models;

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

            Console.ReadLine();
        }
    }
}
