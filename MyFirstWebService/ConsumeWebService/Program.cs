using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFirstWebService;

namespace ConsumeWebService
{
    class Program
    {
        static void Main(string[] args)
        {
            TheWebService webServe = new TheWebService();

            Console.WriteLine("Now say {0}", webServe.HelloWorld());

            Console.ReadLine();
        }
    }
}
