﻿using System;
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
            this.Player = new Player();
            this.Map = new Map();
            this.Ui = new Ui();
        }

        public void Start()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Ui.Menu();
            Map.LoadMap(Player);
            while (!GameOver)
            {
               Map.DrawMap();
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
