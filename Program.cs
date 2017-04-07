using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake1
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(3, 4, '*');
            p1.Drawn += DrawPoint;

            p1.Draw();

            Console.ReadKey();
        }

        static void DrawPoint(object sender, PointEventArgs e)
        {
            Console.SetCursorPosition(e.X, e.Y);
            Console.WriteLine(e.Sym);
        }
    }
}
