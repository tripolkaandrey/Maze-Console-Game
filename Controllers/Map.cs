using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Maze.Controllers;
using Maze.Models;

namespace Maze.Controllers
{
    class Map
    {
        private GameObject[,] GameMap;
        private string[] MapValues;
        private Player player;
        public byte AmountOfMaps = 7;

        private string Path = @"..\..\maps\map";

        public Map(Player player)
        {
            this.player = player;
        }
        public void LoadMap()
        {
            if (player.MapNo > AmountOfMaps) return;
            Console.Clear();
            var fileLoader = new StreamReader(Path + player.MapNo + ".map");
            MapValues = File.ReadAllLines(Path + player.MapNo + ".map");
            var height = MapValues.Length;
            var length = fileLoader.ReadLine().Length;
            GameMap = new GameObject[height, length];


            for (var row = 0; row <= GameMap.GetUpperBound(0); row++)
            {
                for (var coll = 0; coll <= GameMap.GetUpperBound(1); coll++)
                {
                    var current = MapValues[row][coll];
                    switch (current)
                    {
                        //Chain of responsibilities?
                        case '1':
                            GameMap[row, coll] = new Wall('#',ConsoleColor.Cyan);
                            break;
                        case 'P':
                            GameMap[row, coll] = player;
                            player.X = coll;
                            player.Y = row;
                            break;
                        case 'F':
                            GameMap[row, coll] = new Exit('%',ConsoleColor.DarkYellow);
                            break;
                        case 'H':
                            GameMap[row,coll] = new Life('H',ConsoleColor.Red);
                            break;
                        case 'C':
                            GameMap[row, coll] = new Cash('$',ConsoleColor.DarkGreen);
                            break;
                        case 'T':
                            GameMap[row, coll] = new Trap('T',ConsoleColor.DarkBlue);
                            break;
                        case '0':
                            GameMap[row,coll] = new EmptyCell(' ',ConsoleColor.Black);
                            break;
                    }
                }
            }
        }
        public void DrawMap()
        {
            Console.Clear();
            var radiusX = new int[2]{player.X - player.Radius > 0 ? player.X - player.Radius : 0,player.X + player.Radius < GameMap.GetUpperBound(1) + 1 ? player.X + player.Radius : GameMap.GetUpperBound(1) + 1 };
            var radiusY = new int[2] { player.Y - player.Radius > 0 ? player.Y - player.Radius : 0, player.Y + player.Radius < GameMap.GetUpperBound(0) + 1 ? player.Y + player.Radius : GameMap.GetUpperBound(0) + 1 };
            for (var row = radiusY[0]; row < radiusY[1]; row++)
            {
                for (var coll = radiusX[0]; coll < radiusX[1]; coll++)
                {
                    Console.SetCursorPosition(coll, 1 + row);
                    var objectToDraw = GameMap[row, coll];
                    switch (objectToDraw)
                    {
                        case Wall wall:
                            Console.ForegroundColor = wall.Color;
                            Console.Write(wall.Icon);
                            break;
                        case Player p:
                            Console.ForegroundColor = player.Color;
                            break;
                        case Cash cash:
                            Console.ForegroundColor = cash.Color;
                            break;
                        case Life life:
                            Console.ForegroundColor = life.Color;
                            break;
                        case Exit exit:
                            Console.ForegroundColor = exit.Color;
                            break;
                        case Trap trap:
                            Console.ForegroundColor = trap.Color;
                            break;
                    }
                    Console.Write(objectToDraw.Icon);
                }
                Console.WriteLine();
            }
        }
        public void MovePlayer(ConsoleKeyInfo arrow)
        {
            switch (arrow.Key)
            {
                case ConsoleKey.UpArrow:
                    ProcessMove(player.X,player.Y - 1);
                    break;
                case ConsoleKey.DownArrow:
                    ProcessMove(player.X,player.Y + 1);
                    break;
                case ConsoleKey.LeftArrow:
                    ProcessMove(player.X - 1,player.Y);
                    break;
                case ConsoleKey.RightArrow:
                    ProcessMove(player.X + 1,player.Y);
                    break;
            }
        }
        private void ProcessMove(int cellX, int cellY)
        {
            if (cellY > GameMap.GetUpperBound(0) || cellY < 0 || cellX<0 || cellX > GameMap.GetUpperBound(1) || GameMap[cellY, cellX].Icon == '#') return;
            if (GameMap[cellY, cellX].Icon == '%')
            {
                player.Process(GameMap[cellY, cellX]);
                LoadMap();
                return;
            }
            GameMap[player.Y,player.X] = new EmptyCell(' ',ConsoleColor.Black);
            player.Process(GameMap[cellY, cellX]);
            GameMap[cellY, cellX] = player;
            player.Y = cellY;
            player.X = cellX;
        }
    }
}
