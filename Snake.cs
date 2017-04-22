using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake1
{
    class Snake: Figure
    {
        Direction dir;

        public Snake(int xTail, int yTail, int length, Direction _dir): 
            this(new Point(xTail, yTail), length, _dir) {}

        public Snake(int xTail, int yTail, char sym, int length, Direction _dir) :
            this(new Point(xTail, yTail, sym), length, _dir) {}

        public Snake(Point p, int length, Direction _dir)
        {
            dir = _dir;
            pList = new List<Point>();

            for (int i = 0; i < length; i++)
            {
                Point p1 = new Point(p);
                p1.Move(dir, i);
                pList.Add(p1);
            }
        }

        public void Move()
        {
           pList.First().Erase();

           //Собственно движение змейки
           for (int i = 0; i < pList.Count-1; i++)
           {
                pList[i].Move(pList[i+1]);
           }

            pList.Last().Move(dir);

            //Проверка не врезались ли в хвост
            TailHitProve();
        }

        public void KeyHandleConsole(ConsoleKey key)
        {
            switch(key)
            {
                case ConsoleKey.DownArrow:
                {
                     if (dir != Direction.Up)
                            dir = Direction.Down;
                     break;
                }
                case ConsoleKey.UpArrow:
                {
                     if (dir != Direction.Down)
                            dir = Direction.Up;
                     break;
                }
                case ConsoleKey.RightArrow:
                {
                     if (dir != Direction.Left)
                            dir = Direction.Right;
                     break;
                }
                case ConsoleKey.LeftArrow:
                {
                     if (dir != Direction.Right)
                            dir = Direction.Left;
                     break;
                }
            }
        }

        private Point GetNextPoint()
        {
            Point nextPoint = new Point(pList.Last());

            nextPoint.Move(dir);

            return nextPoint;
        }

        public void Eat(Point food)
        {
            if(food == GetNextPoint())
            {
                food.Sym = pList.First().Sym;
                pList.Add(food);
                OnEaten(new SnakeEventArgs());
            }
        }

        public void HitProve(Walls walls)
        {
            if (walls.isHit(pList.Last()))
                OnHit(new SnakeEventArgs("Игра окончена!"));
        }

        private void TailHitProve()
        {
            for (int i = pList.Count - 1; --i >= 0;)
                if (pList[i] == pList.Last())
                    OnHit(new SnakeEventArgs("Игра окончена!"));
        }

        //События и то, что с ними связано
        protected internal event EventHandler<SnakeEventArgs> Eaten;
        protected internal event EventHandler<SnakeEventArgs> Hit;
        protected internal void CallEvent(SnakeEventArgs e, EventHandler<SnakeEventArgs> handler)
        {
            if (e != null && handler != null)
                handler.Invoke(this, e);
        }
        protected internal void OnEaten(SnakeEventArgs e)
        {
            CallEvent(e, Eaten);
        }
        protected internal void OnHit(SnakeEventArgs e)
        {
            CallEvent(e, Hit);
        }

    }
}
