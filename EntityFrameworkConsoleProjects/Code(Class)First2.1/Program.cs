using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Class_First2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new Championship())
            {
                Player player = new Player()
                {
                    PlayerName = "Chuck Norris"
                 };
                
            ctx.Players.Add(player);
            ctx.SaveChanges();

              var ply =  ctx.Players.Select(x => x.PlayerName).First();

                Console.WriteLine(ply);
            }
            Console.ReadKey();
        }
    }
}
