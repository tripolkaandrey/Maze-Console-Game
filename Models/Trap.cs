using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maze.Controllers;

namespace Maze.Models
{
    class Trap:GameObject
    {
        public override char Icon { get; set; } = 'T';
        public override ConsoleColor Color { get; set; } = ConsoleColor.DarkBlue;
        public override void Process(Player player)
        {
            player.Health--;
            if (player.Score > 5)
            {
                player.Score -= 5;
            }
            else
            {
                player.Score = 0;
            }
        }
    }
}
