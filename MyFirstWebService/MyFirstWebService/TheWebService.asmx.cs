using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MyFirstWebService.Models;
using MyFirstWebService.Data;
using System.Configuration;

namespace MyFirstWebService
{
    /// <summary>
    /// Summary description for TheWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class TheWebService : System.Web.Services.WebService
    {
        private string _connectionString;

        public TheWebService()
        {
            string connectionString;
            connectionString = ConfigurationManager
                                    .ConnectionStrings["RegConnectionString"]
                                    .ConnectionString;

            _connectionString = connectionString;

        }


        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public List<Game> CurrentGames()
        {
            GameRepository repo = new GameRepository(_connectionString);


            return repo.GetAll();
        }



    }
}
