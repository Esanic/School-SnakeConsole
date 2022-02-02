using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppSnake
{
    internal class Tail : Player
    {
        GameWorld world;
        Player spelare;
        public Tail(Player spelare, char appearance, GameWorld world) : base(appearance, world)
        {
            this.appearance = appearance;
            this.world = world;
            this.spelare = spelare;

        }

        public override void Update()
        {
                if (spelare.direction == Direction.Left)
                {
                    position = new Position(world.gameObjects[1].position.x + 1, world.gameObjects[1].position.y);
                }
                if (spelare.direction == Direction.Right)
                {
                    position = new Position(world.gameObjects[1].position.x - 1, world.gameObjects[1].position.y);
                }
                if (spelare.direction == Direction.Up)
                {
                    position = new Position(world.gameObjects[1].position.x, world.gameObjects[1].position.y + 1);
                }
                if (spelare.direction == Direction.Down)
                {
                    position = new Position(world.gameObjects[1].position.x, world.gameObjects[1].position.y - 1);
                }
            //else
            //{
            //    for(int i = 3; i < world.gameObjects.Count; i++) { 
            //    if (spelare.direction == Direction.Left)
            //    {
            //        position = new Position(world.gameObjects[i].position.x + 1, world.gameObjects[i].position.y);
            //    }
            //    if (spelare.direction == Direction.Right)
            //    {
            //        position = new Position(world.gameObjects[i].position.x - 1, world.gameObjects[i].position.y);
            //    }
            //    if (spelare.direction == Direction.Up)
            //    {
            //        position = new Position(world.gameObjects[i].position.x, world.gameObjects[i].position.y + 1);
            //    }
            //    if (spelare.direction == Direction.Down)
            //    {
            //        position = new Position(world.gameObjects[i].position.x, world.gameObjects[i].position.y - 1);
            //    }
            //    }
            //}


        }
    }
}
