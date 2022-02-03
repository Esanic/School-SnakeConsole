using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppSnake
{
    internal class Player : GameObject
    {
        GameWorld world;

        public Player(char appearance, GameWorld gameWorld)
        {
            this.appearance = appearance;
            world = gameWorld;
            position = new Position(world.bredd/2, world.höjd/2);
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
                if(position.x<=0)
                {
                    position.x = world.bredd-1;
                }
                else
                position.x -= 1;
            }
            if (direction == Direction.Right)
            {
                if(position.x >= world.bredd-1)
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
                    position.y = world.höjd-1;
                }
                else
                position.y -= 1;
            }
            if (direction == Direction.Down)
            {
                if (position.y >= world.höjd-1)
                {
                    position.y = 0;
                }
                else
                position.y += 1;
            }
        }
    }
}
