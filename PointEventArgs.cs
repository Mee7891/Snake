using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake1
{
    public class PointEventArgs: System.EventArgs
    {
        public int X    { get; private set; }
        public int Y    { get; private set; }
        public char Sym { get; private set; }

        public PointEventArgs(int x, int y, char sym)
        {
            X = x; Y = y; Sym = sym;
        }
    }
}
