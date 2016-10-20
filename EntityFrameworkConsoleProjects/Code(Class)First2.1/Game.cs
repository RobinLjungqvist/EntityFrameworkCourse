using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Class_First2._1
{
    class Game
    {
        public int GameID { get; }
        public string GameName { get; set; }

        public bool GameOver { get; set; }

        public Game() { }
        public Game(string Name)
        {
            GameName = Name;
        }
    }
}
