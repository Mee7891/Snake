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
                p.Move(dir, i);
                pList.Add(p);
            }
        }
    }
}
