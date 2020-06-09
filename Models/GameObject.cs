using System;

namespace Maze.Models
{
    public abstract class GameObject
    {
        public virtual char Icon { get; set; }
        public virtual ConsoleColor Color { get; set; }
        public abstract void Process(Player player);
    }
}