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

            for(int i = pList.Count - 1;  --i>=0;)
            {
                pList.ElementAt(i).Move(pList.ElementAt(i + 1));
            }

            pList.Last().Move(dir);
        }
    }
}
