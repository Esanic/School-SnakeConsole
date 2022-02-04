using System;
using System.Collections.Generic;
using System.Text;

namespace GruppSnake
{
    /// <summary>
    /// Class that specifies what the gameworld will look like and handles the score counting
    /// and handles gameObject list.
    /// </summary>
    class GameWorld
    {
        public int bredd;
        public int höjd;

        public int poäng = 0;

        public List<GameObject> gameObjects = new List<GameObject>();
        /// <summary>
        /// Constructor that specifies the size of the world.
        /// </summary>
        /// <param name="bredd">Specifies the width of the world</param>
        /// <param name="höjd">Specifies the height of the world</param>
        public GameWorld(int bredd, int höjd)
        {
            this.bredd = bredd;
            this.höjd = höjd; 
        }
        /// <summary>
        /// Method that will loop over all the objects within the gameObjects list and do their Update-method.
        /// </summary>
        public void Update()
        {
            for(int i = gameObjects.Count-1; i >=0; i--)
            {
                gameObjects[i].Update();
            }
        }
    }
}
