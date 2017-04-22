using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake1
{
    class Walls
    {


        List<Figure> lines;

        public Walls(int mapWidth, int mapHeight, char sym = '+')
        {
            mapWidth  -= 2;
            mapHeight -= 2;

            lines = new List<Figure>();

            lines.Add(new HorisontalLine(       0, mapWidth,         0, sym));
            lines.Add(new HorisontalLine(       0, mapWidth, mapHeight, sym));
            lines.Add(new   VerticalLine(       0,        0, mapHeight, sym));
            lines.Add(new   VerticalLine(mapWidth,        0, mapHeight, sym));
        }

        public void setDrawEventHandler(EventHandler<PointEventArgs> handler)
        {
            foreach (Figure fig in lines)
                fig.setEventHandler(handler);
        }

        public void Draw()
        {
            foreach (Figure fig in lines)
                fig.Draw();
        }

        public bool isHit(Point p)
        {
            foreach (Figure fig in lines)
            {
                foreach (Point pFig in fig)
                    if (p == pFig)
                        return true;
            }
            return false;
        }
    }
}
