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

        public override void Update()
        {

            for (int i = 2; i < world.gameObjects.Count; i++)
            {
                position = new Position(world.gameObjects[i-1].position.x, world.gameObjects[i-1].position.y);
            }
        }
    }
}
