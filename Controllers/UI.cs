using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Maze.Models;

namespace Maze.Controllers
{
    class State
    {
        public bool Cancel;

    }

    class Ui
    {
        public int Time = 0;

        public void Gui(Player player)
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Cash:    |   Lives:     |   Score: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(6, 0);
            Console.Write("${0}", player.Cash);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(20, 0);
            Console.Write("H{0}", player.Health);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(34, 0);
            Console.Write("{0}XP", player.Score);
            //Console.SetCursorPosition(48, 0);
            //Console.Write(Time);

        }

        public void Menu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("New Game(N)");
            Console.WriteLine("Instructions(I)");
            Console.WriteLine("Change Radius(R)");
            Console.WriteLine("Exit(Esc)");
            if (Console.ReadKey(true).Key == ConsoleKey.N)
            {
            }
            else if (Console.ReadKey(true).Key == ConsoleKey.I)
            {
                Instructions();
            }
            else if (Console.ReadKey(true).Key == ConsoleKey.R)
            {
                ChangeRadius();
            }
            else if (Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                Environment.Exit(1);
            }
        }

        public void Instructions()
        {
            Console.Clear();
            Console.WriteLine("Instructions");
            Console.WriteLine("--------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Вы в лабиринте, из которого нужно найти выход(значок %)");
            Console.WriteLine(
                "Стрелочки - для передвижения.H - HP, $ - Валюта(прибавляет валюту и количество очков), T - Ловушка(отнимает хп)");
            Console.WriteLine("В меню можно выбрать радиус поля видимости(уровень сложности)");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("Press escape to return to the menu");
            while (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {

            }

            Menu();

        }

        public void ChangeRadius()
        {
            Console.Clear();
            Console.WriteLine("Enter the radius you'd like to play with(from 1 to 3)");
            var radius = Convert.ToByte(Console.ReadLine()); //Add validation
            if (radius > 0 && radius < 4)
            {
                Map.Radius = radius;
                Console.WriteLine("Press escape to return to the menu");
            }
            else
            {
                Console.WriteLine("Incorrect input");
            }

            while (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {

            }

            Menu();
        }

        public void Music(object o)
        {
            var state = (State) o;
            while (!state.Cancel)
            {
                Console.Beep(784, 150);
                Thread.Sleep(300);
                Console.Beep(784, 150);
                Thread.Sleep(300);
                Console.Beep(932, 150);
                Thread.Sleep(150);
                Console.Beep(1047, 150);
                Thread.Sleep(150);
                Console.Beep(784, 150);
                Thread.Sleep(300);
                Console.Beep(784, 150);
                Thread.Sleep(300);
                Console.Beep(699, 150);
                Thread.Sleep(150);
                Console.Beep(740, 150);
                Thread.Sleep(150);
                Console.Beep(784, 150);
                Thread.Sleep(300);
                Console.Beep(784, 150);
                Thread.Sleep(300);
                Console.Beep(932, 150);
                Thread.Sleep(150);
                Console.Beep(1047, 150);
                Thread.Sleep(150);
                Console.Beep(784, 150);
                Thread.Sleep(300);
                Console.Beep(784, 150);
                Thread.Sleep(300);
                Console.Beep(699, 150);
                Thread.Sleep(150);
                Console.Beep(740, 150);
                Thread.Sleep(150);
                Console.Beep(932, 150);
                Console.Beep(784, 150);
                Console.Beep(587, 1200);
                Thread.Sleep(75);
                Console.Beep(932, 150);
                Console.Beep(784, 150);
                Console.Beep(554, 1200);
                Thread.Sleep(75);
                Console.Beep(932, 150);
                Console.Beep(784, 150);
                Console.Beep(523, 1200);
                Thread.Sleep(150);
                Console.Beep(466, 150);
                Console.Beep(523, 150);
            }
        }

        /* public void Timer(object o)
         {
             var state = (State)o;
             Time = 0;
             while (!state.Cancel)
             {
                 Time++;
                 Thread.Sleep(1000);
             }
         }
     */
    }
}
