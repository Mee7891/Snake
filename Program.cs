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
            //подготовка "площадки"
            const int xm = 0;
            const int ym = 0;
            const int xM = 80;
            const int yM = 26;
            Console.SetWindowSize(xM, yM);
            Console.SetBufferSize(xM, yM);
            DrawFramework(xm, ym, xM - 2, yM - 2, '+');

            Snake snake = new Snake(2, 10, 4, Direction.Right);
            snake.setEventHandler(DrawPoint);
            snake.Draw();

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

        static void DrawFramework(int xm, int ym, int xM, int yM, char sym)
        {
            HorisontalLine topLine    = new HorisontalLine(xm, xM, ym, sym);
            HorisontalLine bottomLine = new HorisontalLine(xm, xM, yM, sym);
            VerticalLine   leftLine   = new   VerticalLine(xm, ym, yM, sym);
            VerticalLine   rightLine  = new   VerticalLine(xM, ym, yM, sym);
            SetHandlersForFigures(DrawPoint, topLine, bottomLine, leftLine, rightLine);
            topLine.Draw(); bottomLine.Draw(); leftLine.Draw(); rightLine.Draw();
        }
    }
}
