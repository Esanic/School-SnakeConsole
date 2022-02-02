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
            if (spelare.direction == Direction.Left)
            {
                position = new Position(world.gameObjects[0].position.x + 1, world.gameObjects[0].position.y);
            }
            if (spelare.direction == Direction.Right)
            {
                position = new Position(world.gameObjects[0].position.x - 1, world.gameObjects[0].position.y);
            }

            if (spelare.direction == Direction.Up)
            {
                position = new Position(world.gameObjects[0].position.x, world.gameObjects[0].position.y+1);
            }
            if (spelare.direction == Direction.Right)
            {
                position = new Position(world.gameObjects[0].position.x, world.gameObjects[0].position.y-1);
            }

        }

        public override void Update()
        {
            if (direction == Direction.Pause)
            {
                position.x = position.x;
                position.y = position.y;
            }

            if (direction == Direction.Left)
            {
                if (position.x <= 0)
                {
                    position.x = world.bredd - 1;
                }
                else
                    position.x -= 1;
            }
            if (direction == Direction.Right)
            {
                if (position.x >= world.bredd - 1)
                {
                    position.x = 0;
                }
                else
                    position.x += 1;
            }
            if (direction == Direction.Up)
            {
                if (position.y <= 0)
                {
                    position.y = world.höjd - 1;
                }
                else
                    position.y -= 1;
            }
            if (direction == Direction.Down)
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
