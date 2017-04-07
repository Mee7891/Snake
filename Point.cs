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

        protected internal event EventHandler<PointEventArgs> Drawn;
        protected internal void CallEvent(PointEventArgs e, EventHandler<PointEventArgs> handler)
        {
            if (e != null && handler != null)
                handler.Invoke(this, e);
        }
        protected internal void onDrawn(PointEventArgs e)
        {
            CallEvent(e, Drawn);
        }

        public void Draw()
        {
            onDrawn(new PointEventArgs(X, Y, Sym));
        }
        
    }
}
