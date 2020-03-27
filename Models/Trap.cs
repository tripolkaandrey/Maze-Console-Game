using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maze.Controllers;

namespace Maze.Models
{
    struct Trap
    {
        public const char Icon = 'T';
        public const char IconEncrypted = 'T';
        public const ConsoleColor Color = ConsoleColor.DarkBlue;


        public static void Process(Player player)
        {
            player.Health--;
        }
    }
}
