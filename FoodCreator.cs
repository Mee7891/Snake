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
        EventHandler<PointEventArgs> FoodDrawHandler;

        Random random = new Random();

        public FoodCreator(int mapWidth, int mapHeight, char sym)
        {
            this.mapHeight = mapHeight; this.mapWidth = mapWidth;
            this.sym = sym;

            food = new Point();
        }

        public void CreateFood()
        {
            int x = random.Next(2, mapWidth - 2);
            int y = random.Next(2, mapHeight - 2);
            food = new Point(x, y, sym);
            food.Drawn += FoodDrawHandler;
            food.Draw();
        }

        public void CreateFood(object sender, SnakeEventArgs e)
        {
            CreateFood();
        }

        public void setEventHandler(EventHandler<PointEventArgs> handler)
        {
            FoodDrawHandler += handler;
        }

    }
}
