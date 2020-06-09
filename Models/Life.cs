using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Models
{
    class Life:GameObject
    {
        public override char Icon { get; set; } = 'H';
        public override ConsoleColor Color { get; set; } = ConsoleColor.DarkRed;
        public override void Process(Player player)
        {
            player.Health++;
        }
    }
}
