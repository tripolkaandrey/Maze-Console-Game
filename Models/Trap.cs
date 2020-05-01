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
        public Trap(char icon, ConsoleColor color) : base(icon, color)
        {
        }
    }
}
