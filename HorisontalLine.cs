using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake1
{
    class HorisontalLine: Figure
    {
        public HorisontalLine(int xMin, int xMax, int y, char sym)
        {
            pList = new List<Point>();

            for(int i = xMin; i<=xMax; i++)
            {
                Point p = new Point(i, y, sym);
                pList.Add(p);
            }
        }
    }
}
