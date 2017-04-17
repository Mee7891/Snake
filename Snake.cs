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

        public Snake(int xTail, int yTail, int lenght, Direction _dir)
        {
            dir = _dir;
            pList = new List<Point>();

            for (int i = 0; i < lenght; i++)
            {
                Point p = new Point(xTail, yTail);
                p.Move(dir, i);
                pList.Add(p);
            }
        }
    }
}
