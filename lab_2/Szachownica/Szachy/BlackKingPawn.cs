using Interfejsy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szachy
{
    class BlackKingPawn : Pawn
    {
        public BlackKingPawn(int x, int y)
        {
            this.xPosiition = x;
            this.yPosiition = y;
            loadImage();
        }

        public override void movePawn(int newXPosition, int newYPosition)
        {
            throw new NotImplementedException();
        }

        public override void removePawn()
        {
            throw new NotImplementedException();
        }
    }
}
