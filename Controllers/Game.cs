using System;
using System.ComponentModel.Design;
using System.Threading;
using Maze.Models;

namespace Maze.Controllers
{
    class Game
    {
        public Player Player;
        public static bool GameOver = false;
        public Map Map;
        public Ui Ui;

        public Game()
        {
            Player = new Player();
            Map = new Map();
            Ui = new Ui();
        }

        public void Start()
        { 
            Console.CursorVisible = false;
            Ui.Menu();
            Map.LoadMap(Player);
            Thread music = new Thread(new ThreadStart(Ui.Music));
            music.Start();
            while (!GameOver)
            {
               Map.DrawMap(Player);
               Ui.Gui(Player);
               GetInput();
               if (Player.Health < 0)
               {
                   Over(false);
               }
               if (Map.MapNo > 2)
               {
                   Over(true);
               }
            }
            
        }
        public void Over(bool victory)
        {
            Console.Clear();
            Console.WriteLine(victory ? "Victory" : "GAME OVER");
            Console.WriteLine("Press enter to open menu");
            Console.ReadLine();
            Map.MapNo = 1;
            Player.Score = 0;
            Player.Health = 0;
            Start();
        }


        public void GetInput()
        {
            var keyInput = Console.ReadKey(true);
            Map.MovePlayer(keyInput, Player);
        }
        

    }
}
