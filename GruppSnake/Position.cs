using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppSnake
{
    public class Position
    {
        public int x;
        public int y;

        public Position(int bredd, int höjd)
        {
            this.x = bredd;
            this.y = höjd;
        }
    }
}
