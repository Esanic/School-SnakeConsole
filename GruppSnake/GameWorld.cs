using System;
using System.Collections.Generic;
using System.Text;

namespace GruppSnake
{
    class GameWorld
    {
        public int bredd;
        public int höjd;

        public int poäng = 0;

        public List<GameObject> gameObjects = new List<GameObject>();

        public GameWorld(int bredd, int höjd)
        {
            this.bredd = bredd;
            this.höjd = höjd; 
        }

        public void Update()
        {
            foreach (GameObject obj in gameObjects)
            {
                obj.Update();
            }
        }
    }
}
