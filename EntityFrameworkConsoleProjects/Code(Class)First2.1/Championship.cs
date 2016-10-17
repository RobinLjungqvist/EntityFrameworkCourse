using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Class_First2._1
{
    class Championship: DbContext
    {
        public int ChampionshipID { get; set; }
        public string ChampionshipName { get; set; }

        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }

    }
}
