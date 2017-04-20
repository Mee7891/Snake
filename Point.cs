using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake1
{
    class Point
    {
        public int X   { get; set; }
        public int Y   { get; set; }
        public char Sym { get; set; }

        public Point(int x = 0, int y = 0, char sym = '*')
        {
            X = x; Y = y; Sym = sym;
        }

        public Point(Point p) : this(p.X, p.Y, p.Sym) { }

        protected internal event EventHandler<PointEventArgs> Drawn;
        protected internal void CallEvent(PointEventArgs e, EventHandler<PointEventArgs> handler)
        {
            if (e != null && handler != null)
                handler.Invoke(this, e);
        }
        protected internal void OnDrawn(PointEventArgs e)
        {
            CallEvent(e, Drawn);
        }

        public void Draw()
        {
            OnDrawn(new PointEventArgs(X, Y, Sym));
        }

        public void Erase()
        {
            char temp = Sym;
            Sym = ' ';
            Draw();
            Sym = temp;
        }

        public void Move(int x, int y)
        {
            X = x; Y = y;
            Draw();
        }

        public void Move(Point p)
        {
            Move(p.X, p.Y);
        }

        public void Move(Direction dir, int step)
        {
            switch (dir)
            {
                case Direction.Down:
                    {
                        Move(X, Y + step);
                        break;
                    }
                case Direction.Up:
                    {
                        Move(X, Y - step);
                        break;
                    }
                case Direction.Left:
                    {
                        Move(X - step, Y);
                        break;
                    }
                case Direction.Right:
                    {
                        Move(X + step, Y);
                        break;
                    }
            }
        }

        public void Move(Direction dir)
        {
            Move(dir, 1);
        }

        public override bool Equals(object obj)
        {
            if(obj is Point)
            {
                Point p = (Point) obj;
                if (this.X == p.X && this.Y == p.Y)
                    return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public static bool operator ==(Point p1, Point p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator !=(Point p1, Point p2)
        {
            return !p1.Equals(p2);
        }
    }
}
