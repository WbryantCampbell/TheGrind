using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWebService.Models
{
     public class Game
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime Release { get; set; }

        public string ESRB { get; set; }

        public string Studio { get; set; }

        public decimal Rating { get; set; }
    }
}
