using System;
using System.ComponentModel;

namespace Maze.Models
{
    public class Player : GameObject
    {
        public override char Icon { get; set; } = 'o';
        public override ConsoleColor Color { get; set; } = ConsoleColor.Yellow;
        public int MapNo { get; set; }
        public byte Radius { get; set; }
        public int Cash { get; set; }
        public int Score { get; set; }
        public int Health { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Player(byte radius = 2)
        {
            MapNo = 1;
            Cash = 0;
            Score = 0;
            Health = 1;
            Radius = radius;
        }

        public void ChangeRadius(byte radius)
        {
            Radius = radius;
        }

        public void Reset()
        {
            MapNo = 1;
            Score = 0;
            Health = 1;
        }

        public override void Process(Player player)
        {

        }
    }
}

