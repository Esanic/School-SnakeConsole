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
            for(int i = gameObjects.Count-1; i >=0; i--)
            {
                gameObjects[i].Update();
            }
            
            //foreach (GameObject obj in gameObjects.ToList())
            //{
            //    obj.Update();
            //}
        }
    }
}
