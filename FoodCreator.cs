using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake1
{
    class FoodCreator
    {
        int mapWidth, mapHeight;
        char sym;

        public Point food;

        Random random = new Random();

        public FoodCreator(int mapWidth, int mapHeight, char sym)
        {
            this.mapHeight = mapHeight; this.mapWidth = mapWidth;
            this.sym = sym;
        }

        Point CreateFood()
        {
            int x = random.Next(2, mapWidth - 2);
            int y = random.Next(2, mapHeight - 2);
            food = new Point(x, y, sym);
            return food;
        }


    }
}
