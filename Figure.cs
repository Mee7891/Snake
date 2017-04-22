using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake1
{
    abstract class Figure: IEnumerable
    {
        protected List<Point> pList;

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

        public Point this[int n]
        {
            get
            {
                try
                { return pList[n]; }
                catch
                {
                    throw new Exception("Неверный индекс в обращении к точкам фигуры");
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return pList.GetEnumerator();
        }
    }
}
