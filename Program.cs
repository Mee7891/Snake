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
            HorisontalLine l1 = new HorisontalLine(3, 8, 2, '*');
            VerticalLine l2 = new VerticalLine(4, 12, 15, '&');

            SetHandlersForFigures(DrawPoint, l1, l2);

            l1.Draw();
            l2.Draw();

            Console.ReadKey();
        }

        static void DrawPoint(object sender, PointEventArgs e)
        {
            Console.SetCursorPosition(e.X, e.Y);
            Console.WriteLine(e.Sym);
        }

        static void SetHandlersForFigures(EventHandler<PointEventArgs> handler, params Figure [] figArr)
        {
            foreach (Figure f in figArr)
                f.setEventHandler(handler);
        }
    }
}
