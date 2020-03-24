using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Models
{
    struct Life
    {
        public const char Icon = 'H';
        public const char IconEncrypted = 'L';
        public const ConsoleColor Color = ConsoleColor.Red;


        public static void Process(Player player)
        {
            player.Health++;
            /*
            Console.Beep(2000, 50);
            Console.Beep(3000, 50);
            */
        }
    }
}
