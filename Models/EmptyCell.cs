using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Models
{
    class EmptyCell:GameObject
    {
        public EmptyCell(char icon, ConsoleColor color) : base(icon, color)
        {
        }
    }
}
