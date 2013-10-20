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

        public Pawn createPawn(int xPosition, int yPosition, Interfejsy.StaticVariables.PawnType pawnType)
        {
            if (pawnType == StaticVariables.PawnType.CHECKER_WHITE)
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


        public Pawn[] initialize()
        {
            Pawn[] pawns = new Pawn[24];

            int pawnIterator = 0;

            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if ((y % 2) == 0)
                    {
                        pawns[pawnIterator] = new WhiteChecker(x * 2 + 1, y);
                    }
                    else
                    {
                        pawns[pawnIterator] = new WhiteChecker(x * 2, y);
                    }
                    pawnIterator++;
                }
            }

            for (int y = 5; y < 8; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if ((y % 2) == 0)
                    {
                        pawns[pawnIterator] = new BlackChecker(x * 2 + 1, y);
                    }
                    else
                    {
                        pawns[pawnIterator] = new BlackChecker(x * 2, y);
                    }
                    pawnIterator++;
                }
            }

            return pawns;
        }
    }
}
