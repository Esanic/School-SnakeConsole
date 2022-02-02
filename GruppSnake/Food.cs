using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppSnake
{
    internal class Food : GameObject
    {
        private GameWorld world;
        
        public Food(char appearance, GameWorld gameWorld)
        {

            
            this.appearance = appearance;
            world = gameWorld;
            randomPosition();

        }
        public void randomPosition()
        {   
            Random rnd = new Random();
            int height = rnd.Next(world.höjd);
            int width = rnd.Next(world.bredd);
            position = new Position(width, height);
        }


        public override void Update()
        {
            if (position.x == world.gameObjects[1].position.x && position.y == world.gameObjects[1].position.y)
            {
                randomPosition();
                world.poäng++;
            }
        }
    }
}
