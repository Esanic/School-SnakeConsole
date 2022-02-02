using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppSnake
{
    internal class Player : GameObject
    {
        public Direction direction;
        public GameWorld world;

        public enum Direction
        {
            Left,
            Right,
            Up,
            Down
        }

        public Player(char appearance, GameWorld gameWorld)
        {
            this.appearance = appearance;
            position = new Position(10, 10);
            world = gameWorld;
        }

        public override void Update()
        {
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
