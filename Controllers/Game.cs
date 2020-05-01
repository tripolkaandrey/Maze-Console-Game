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
        public GraphicalUserInterface GUI;
        public Timer Timer;


        public Game()
        {
            Player = new Player('o',ConsoleColor.Yellow,2);
            GUI = new GraphicalUserInterface(this,Player);
            Map = new Map(Player);
            Timer = new Timer();
        }
        public void Start()
        {
            Console.SetBufferSize(120, 35);
            Console.CursorVisible = false;
            GUI.Menu();
        }
        public void Play()
        {
            var timer = new Thread(new ThreadStart(Timer.Start));
            Map.LoadMap();
            timer.Start();
            while (!GameOver || Console.ReadKey().Key != ConsoleKey.Escape)
            {
                Map.DrawMap();
                GUI.PlayerInfo();
                GetInput();
                if (CheckGameOver())
                {
                    break;
                }
            }
            if(Player.Health <= 0)
            {
                GUI.GameOver(false);
            } else if(Player.MapNo > Map.AmountOfMaps)
            {
                GUI.GameOver(true);
            }

            Timer.State.IsAlive = false;
            timer.Join();
        }
        public void GetInput()
        {
            var keyInput = Console.ReadKey(true);
            Map.MovePlayer(keyInput);
        }

        public bool CheckGameOver()
        {
            return Player.Health <= 0 || Player.MapNo > Map.AmountOfMaps;
        }

    }
}
