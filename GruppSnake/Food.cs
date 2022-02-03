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
        Player spelare;
        
        public Food(char appearance, GameWorld gameWorld, Player spelare1)
        {

            
            this.appearance = appearance;
            world = gameWorld;
            spelare = spelare1;
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
                Tail svans = new Tail(spelare, 'o', world);
                world.gameObjects.Add(svans);
            }
        }
    }
}
