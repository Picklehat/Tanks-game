using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    struct GameArea
    {
        public int StartOfX => 0;
        public int StartOfY => 0;
        public int EndOfX => 800;
        public int EndOfY => 600;
        public int XSize => EndOfX- StartOfX;
        public int YSize => EndOfY- StartOfY;

        public Rectangle gameArea
        {
            get
            {
                return new Rectangle(StartOfX, StartOfY, XSize, YSize);
            }
        }
    }
}
