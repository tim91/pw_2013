using Interfejsy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szachy
{
    class BlackPawn : Pawn
    {
        public BlackPawn(int x, int y)
        {
            this.xPosition = x;
            this.yPosition = y;
            loadImage();
        }

        public override bool canMovePawn(int newXPosition, int newYPosition, string type)
        {
            return true;
        }

        public override void removePawn()
        {
            throw new NotImplementedException();
        }
    }
}
