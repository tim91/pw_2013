using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfejsy;

namespace Szachy
{
    class CheesBuilder : PawnDraftsMan
    {
        
        public Pawn createPawn(int pawnType, int xPosition, int yPosition)
        {
            return new ChessPawn(pawnType, xPosition, yPosition);
        }

        public override string ToString()
        {
            return "Chees";
        }
    }
}
