﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake1
{
    class Program
    {
        static void Main(string[] args)
        {
            //подготовка "площадки"
            const int xM = 80;
            const int yM = 26;
            Console.SetWindowSize(xM, yM);
            Console.SetBufferSize(xM, yM);

            Walls walls = new Walls(xM, yM);
            walls.setDrawEventHandler(DrawPoint);
            walls.Draw();
            ///////////////////////////////////

            //Создадим змейку
            Snake snake = new Snake(2, 10, 4, Direction.Right);
            snake.setEventHandler(DrawPoint);
            snake.Draw();
            ///////////////////////////////////////

            //Создадим "создатель еды"
            FoodCreator foodCreator = new FoodCreator(xM, yM, '$');
            foodCreator.setEventHandler(DrawPoint);
            foodCreator.CreateFood();
           
            snake.Eaten += foodCreator.CreateFood; //сигнал от змейки, что она поела, надо создавать еще еду

            //для красоты
            Console.CursorVisible = false;
            Console.SetCursorPosition(40, 10);

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true); //без true рамка будет съедаться змейкой
                    if (keyInfo.Key == ConsoleKey.Escape)
                        break;

                    snake.KeyHandleConsole(keyInfo.Key);
                }

                Thread.Sleep(300);
                snake.Move();
                snake.Eat(foodCreator.food);
            }


            Console.ReadKey();
        }

        static void DrawPoint(object sender, PointEventArgs e)
        {
            Console.SetCursorPosition(e.X, e.Y);
            Console.WriteLine(e.Sym);
        }

    }
}
