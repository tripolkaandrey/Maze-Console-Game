using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Models
{
    struct Wall
    {
        public const char Icon = '#';
        public const char IconEncrypted = '1';
        //public bool IsBreakable { get; set; }
        public const ConsoleColor Color = ConsoleColor.Cyan;

        /*public Wall(bool isBreakable)
        {
            this.IsBreakable = isBreakable;
            this.Color = IsBreakable ? ConsoleColor.Gray : ConsoleColor.White;
        }
        */
    }
}
