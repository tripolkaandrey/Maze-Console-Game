using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Maze.Controllers;
using Maze.Models;

namespace Maze


{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.Start();
        }

    }
}
