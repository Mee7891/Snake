using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake1
{
    abstract class Figure
    {
        List<Point> pList;

        public void Draw()
        {
            foreach(Point p in pList)
            {
                p.Draw();
            }
        }

        public void setEventHandler(EventHandler<PointEventArgs> handler)
        {
            foreach(Point p in pList)
            {
                p.Drawn += handler;
            }
        }
    }
}
