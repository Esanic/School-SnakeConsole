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

        public enum Direction
        {
            Left,
            Right,
            Up,
            Down
        }

        public Player(char appearance)
        {
            this.appearance = appearance;
        }

     

        public override void Update()
        {
            if (direction == Direction.Left)
            {
               
                position.x -= 1;
            }
            if (direction == Direction.Right)
            {
                position.x += 1;
            }
            if (direction == Direction.Up)
            {
                position.y -= 1;
            }
            if (direction == Direction.Down)
            {
                position.y += 1;
            }
        }
    }
}
