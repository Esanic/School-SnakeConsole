﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppSnake
{
    /// <summary>
    /// Creates a navigable unit that will operate within the given area/world.
    /// </summary>
    internal class Player : GameObject
    {
        GameWorld world;
        public enum Direction
        {
            Right,
            Left,
            Up,
            Down,
            Pause
        }

        public Direction direction;

        /// <summary>
        /// Creates a new Player with given appearance and the GameWorld it is gonna operate in.
        /// </summary>
        /// <param name="appearance">What the player will look like when rendered.</param>
        /// <param name="gameWorld">What world the player will navigate in.</param>
        public Player(char appearance, GameWorld gameWorld, ConsoleColor color)
        {
            this.appearance = appearance;
            world = gameWorld;
            position = new Position(world.width/2, world.height/2);
            this.color = color;
        }
        
        /// <summary>
        /// Method that will correspond to the direction the user sets by pressing a valid direction-key 
        /// by incrementing och decrementing the position in both hortizontal and vertical axises of the navigable unit.
        /// </summary>
        public override void Update()
        {       
            if (direction == Direction.Left)
            {
                if(position.x<=0)
                {
                    position.x = world.width-1;
                }
                else
                position.x -= 1;
            }
            if (direction == Direction.Right)
            {
                if(position.x == world.width-1)
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
                    position.y = world.height-1;
                }
                else
                position.y -= 1;
            }
            if (direction == Direction.Down)
            {
                if (position.y == world.height-1)
                {
                    position.y = 0;
                }
                else
                position.y += 1;
            }
        }
        /// <summary>
        /// Method to check if the head collisions with the tail
        /// </summary>
        /// <returns>if the head collisions with it's tail it returns false, otherwise true</returns>
        public bool CollisionCheck()
        {
            for (int i = 4; i < world.gameObjects.Count; i++)
            {
                if (world.gameObjects[i].position.x == world.gameObjects[2].position.x && world.gameObjects[i].position.y == world.gameObjects[2].position.y)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
