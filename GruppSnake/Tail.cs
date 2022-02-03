using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppSnake
{
    internal class Tail : Player
    {

        //Problemet atm är logiken för hur svansen ska flytta sig.
        GameWorld world;
        Player spelare;
        public Tail(Player spelare, char appearance, GameWorld world) : base(appearance, world)
        {
            this.appearance = appearance;
            this.world = world;
            this.spelare = spelare;

            for(int i = 0; i < world.gameObjects.Count; i++) 
            {
                this.direction = world.gameObjects[i].direction;

                if (world.gameObjects[i].direction == Direction.Left)
                {
                    position = new Position(world.gameObjects[i].position.x, world.gameObjects[i].position.y);
                }
                if (world.gameObjects[i].direction == Direction.Right)
                {
                    position = new Position(world.gameObjects[i].position.x, world.gameObjects[i].position.y);
                }
                if (world.gameObjects[i].direction == Direction.Up)
                {
                    position = new Position(world.gameObjects[i].position.x, world.gameObjects[i].position.y);
                }
                if (world.gameObjects[i].direction == Direction.Down)
                {
                    position = new Position(world.gameObjects[i].position.x, world.gameObjects[i].position.y);
                }
            }
        }

        //Svansen är hårdkodad att börja efter world.gameObjects[1].
        //Har provat att använda for-loop men då blir svansen centrerad utan att följa efter Ormen.
        public override void Update()
        {
            for (int i = 0; i < world.gameObjects.Count; i++)
            {
                if (world.gameObjects[i].direction == Direction.Left)
                {
                    if (position.x <= 0)
                    {
                        position.x = world.bredd - 1;
                    }
                    else
                        position.x -= 1;
                }

                if (world.gameObjects[i].direction == Direction.Right)
                {
                    if (position.x >= world.bredd - 1)
                    {
                        position.x = 0;
                    }
                    else
                        position.x += 1;
                }

                if (world.gameObjects[i].direction == Direction.Up)
                {
                    if (position.y <= 0)
                    {
                        position.y = world.höjd - 1;
                    }
                    else
                        position.y -= 1;
                }

                if (world.gameObjects[i].direction == Direction.Down)
                {
                    if (position.y >= world.höjd - 1)
                    {
                        position.y = 0;
                    }
                    else
                        position.y += 1;
                }
            }



        }
    }
}
