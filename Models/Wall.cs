using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Models
{
    class Wall:GameObject
    {
        public Wall(char icon, ConsoleColor color) : base(icon, color)
        {
        }

    }
}
