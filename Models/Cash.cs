using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Models
{
    struct Cash
    {
        public const char Icon = '$';
        public const char IconEncrypted = 'C';
        public const ConsoleColor Color = ConsoleColor.Green;

        public static void Process(Player player)
        {
            player.Cash += 1;
            player.Score += 10;
            /*
            Console.Beep(2000, 50);
            Console.Beep(3000, 50);
            */
        }
    }
}
