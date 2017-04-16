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
            Console.SetWindowSize(80, 26);
            Console.SetBufferSize(80, 26);


            //Отрисовка рамки
            HorisontalLine topLine    = new HorisontalLine(0, 78,  0, '+');
            HorisontalLine bottomLine = new HorisontalLine(0, 78, 24, '+');
            VerticalLine leftLine     = new   VerticalLine(0,  0, 24, '+');
            VerticalLine rightLine    = new   VerticalLine(78, 0, 24, '+');
            SetHandlersForFigures(DrawPoint, topLine, bottomLine, leftLine, rightLine);
            topLine.Draw(); bottomLine.Draw(); leftLine.Draw(); rightLine.Draw();
            /////////////////////////////////////////////////////////////////////////////

            Console.SetCursorPosition(40, 10);
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
