using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Models
{
    class EmptyCell:GameObject
    {
        public override char Icon { get; set; } = ' ';
        public override ConsoleColor Color { get; set; } = ConsoleColor.Black;
        public override void Process(Player player)
        {

        }
    }
}
