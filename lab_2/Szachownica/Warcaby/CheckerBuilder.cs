using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfejsy;

namespace Warcaby
{
    public class CheckerBuilder : PawnDraftsMan
    {
        public CheckerBuilder() { }

        public Pawn createPawn(int xPosition, int yPosition, Interfejsy.StaticVariables.pawnType pawnType)
        {
            if (pawnType == StaticVariables.pawnType.CHECKER_WHITE)
            {
                return new WhiteChecker(xPosition, yPosition);
            }
            else
            {
                return new BlackChecker(xPosition, yPosition);
            }
            
        }

        public override string ToString()
        {
            return "Checkers";
        }
    }
}
