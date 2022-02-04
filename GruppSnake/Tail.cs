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
        int följarNummer;

        public Tail(Player player, char appearance, GameWorld world, int follow) : base(appearance, world)
        {
            this.appearance = appearance;
            this.world = world;
            this.spelare = player;
            följarNummer = follow;

            for(int i = 0; i < world.gameObjects.Count; i++) 
            {
                position = new Position(world.gameObjects[i].position.x, world.gameObjects[i].position.y);
            }
        }

        public override void Update()
        {
            position = new Position(world.gameObjects[följarNummer].position.x, world.gameObjects[följarNummer].position.y);
        }
    }
}
