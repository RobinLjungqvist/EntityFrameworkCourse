using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Class_First2._1
{
    class Player
    {
        public int PlayerID { get; }
        public string PlayerName { get; set; }

        public int Score { get; set; }

        public Player(string name)
        {
            PlayerName = name;
            Score = 0;
        }

    }
}
