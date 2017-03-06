using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFirstWebService.Models;

namespace MyFirstWebService.Data
{
    public class GameRepository
    {
        private string _connectionString;

        public GameRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Game> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
