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
        public char[,] MapChars;
        public static byte MapNo = 1;
        public string[] MapValues;

        public string Path = @"..\..\maps\map";
        public void LoadMap(Player player)
        {
            if (MapNo > 2) return;
            Console.Clear();
            var fileLoader = new StreamReader(Path + MapNo + ".map");
            MapValues = File.ReadAllLines(Path + MapNo + ".map");
            var height = MapValues.Length;
            var length = fileLoader.ReadLine().Length;
            MapChars = new char[height, length];


            for (var row = 0; row < MapChars.GetUpperBound(0) + 1; row++)
            {
                for (var coll = 0; coll < MapChars.GetUpperBound(1) + 1; coll++)
                {
                    var current = MapValues[row][coll];
                    switch (current)
                    {
                        //Chain of responsibilities?
                        case Wall.IconEncrypted:
                            MapChars[row, coll] = Wall.Icon;
                            break;
                        case Player.IconEncrypted:
                            MapChars[row, coll] = Player.Icon;
                            player.X = coll;
                            player.Y = row;
                            break;
                        case Exit.IconEncrypted:
                            MapChars[row, coll] = Exit.Icon;
                            break;
                        case Life.IconEncrypted:
                            MapChars[row, coll] = Life.Icon;
                            break;
                        case Cash.IconEncrypted:
                            MapChars[row, coll] = Cash.Icon;
                            break;
                        case Trap.IconEncrypted:
                            MapChars[row, coll] = Trap.Icon;
                            break;

                    }
                }
            }
        }

        public void DrawMap(Player player)
        {
            Console.Clear();
            const int radius = 3;
            var radiusX = new int[2]{player.X - radius > 0 ? player.X - radius : 0,player.X + radius < MapChars.GetUpperBound(1) + 1 ? player.X + radius : MapChars.GetUpperBound(1) + 1 };
            var radiusY = new int[2] { player.Y - radius > 0 ? player.Y - radius : 0, player.Y + radius < MapChars.GetUpperBound(0) + 1 ? player.Y + radius : MapChars.GetUpperBound(0) + 1 };
            for (var row = radiusY[0]; row < radiusY[1]; row++)
            {
                for (var coll = radiusX[0]; coll < radiusX[1]; coll++)
                {
                    Console.SetCursorPosition(coll, 1 + row);
                    var charToDraw = MapChars[row, coll];
                    switch (charToDraw)
                    {
                        case Wall.Icon:
                            Console.ForegroundColor = Wall.Color;
                            break;
                        case Player.Icon:
                            Console.ForegroundColor = Player.Color;
                            break;
                        case Cash.Icon:
                            Console.ForegroundColor = Cash.Color;
                            break;
                        case Life.Icon:
                            Console.ForegroundColor = Life.Color;
                            break;
                        case Exit.Icon:
                            Console.ForegroundColor = Exit.Color;
                            break;
                        case Trap.Icon:
                            Console.ForegroundColor = Trap.Color;
                            break;
                    }
                    Console.Write(charToDraw);
                }

                Console.WriteLine();
            }
        }

        public void MovePlayer(ConsoleKeyInfo arrow,Player player)
        {
            switch (arrow.Key)
            {
                case ConsoleKey.UpArrow:
                    ProcessMove(player,player.X,player.Y - 1);
                    break;
                case ConsoleKey.DownArrow:
                    ProcessMove(player,player.X,player.Y + 1);
                    break;
                case ConsoleKey.LeftArrow:
                    ProcessMove(player,player.X - 1,player.Y);
                    break;
                case ConsoleKey.RightArrow:
                    ProcessMove(player,player.X + 1,player.Y);
                    break;
            }
        }

        private void ProcessMove(Player player, int cellX, int cellY)
        {
            if (cellY > MapChars.GetUpperBound(0) || cellY < 0 || cellX<0 || cellX > MapChars.GetUpperBound(1) || MapChars[cellY, cellX] == Wall.Icon) return;
            MapChars[player.Y, player.X] = ' ';
            switch (MapChars[cellY, cellX])
            {
                case Life.Icon:
                    Life.Process(player);
                    break;
                case Cash.Icon:
                    Cash.Process(player);
                    break;
                case Trap.Icon:
                    Trap.Process(player);
                    break;
                case Exit.Icon:
                    MapNo++;
                    LoadMap(player);
                    return;
            }
            MapChars[cellY, cellX] = Player.Icon;
            player.Y = cellY;
            player.X = cellX;
        }

    }
}
