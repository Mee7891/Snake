using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake1
{
    class VerticalLine: Figure
    {
        public VerticalLine(int x, int yMin, int yMax, char sym)
        {
            pList = new List<Point>();

            for (int i = yMin; i <= yMax; i++)
            {
                Point p = new Point(x, i, sym);
                pList.Add(p);
            }
        }
    }
}
