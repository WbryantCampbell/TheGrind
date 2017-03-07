using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFirstWebService.Models;
using System.Data.SqlClient;

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
            SqlConnection sqlConn = new SqlConnection(_connectionString);

            List<Game> result = new List<Game>();
            SqlCommand sqlCmd = new SqlCommand(@"SELECT Id,Title,Release,ESRB,Studio,Rating FROM GameInfo", sqlConn);
            sqlConn.Open();
            SqlDataReader reader = sqlCmd.ExecuteReader();
            if (reader.HasRows == false) return new List<Game>();
            while (reader.Read())
            {
                Game game = new Game();
                game.Id = reader.GetInt32(0);
                game.Title = reader.GetString(1);
                game.Release = reader.GetDateTime(2);
                game.ESRB = reader.GetString(3);
                game.Studio = reader.GetString(4);
                game.Rating = reader.GetDecimal(5);
                result.Add(game);
            }
            sqlConn.Close();
            return result;

        }
    }
}
