using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfejsy;

namespace Szachy
{
    public class CheesBuilder : PawnDraftsMan
    {
        public Pawn createPawn(int xPosition, int yPosition, Interfejsy.StaticVariables.PawnType pawnType)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "Chees";
        }


        public Pawn[] initialize()
        {
            Pawn[] pawns = new Pawn[32];

            int pawnIterator = 0;

            for (int y = 0; y < 2; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if ((y % 2) == 0)
                    {//pierwszy rzad
                        if ((x % 7) == 0)
                        {
                            //Rook
                            pawns[pawnIterator] = new BlackRookPawn(x, y);
                        }
                        else if (y == 1 || y == 6)
                        {
                            //Knight
                            pawns[pawnIterator] = new BlackKnightPawn(x, y);
                        }
                        else if (y == 2 || y == 5)
                        {
                            //Bishop
                            pawns[pawnIterator] = new BlackBishopPawn(x, y);
                        }
                        else if (y == 3)
                        {
                            //Queen
                            pawns[pawnIterator] = new BlackQueenPawn(x, y);
                        }
                        else
                        {
                            //King
                            pawns[pawnIterator] = new BlackKingPawn(x, y);
                        }
                    }
                    else
                    {
                        //Pawn
                        pawns[pawnIterator] = new BlackPawn(x, y);
                    }
                    pawnIterator++;
                }
            }

            for (int y = 6; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if ((y % 2) == 1)
                    {//7 rzad
                        if ((x % 7) == 0)
                        {
                            //Rook
                            pawns[pawnIterator] = new WhiteRookPawn(x, y);
                        }
                        else if (y == 1 || y == 6)
                        {
                            //Knight
                            pawns[pawnIterator] = new WhiteKnightPawn(x, y);
                        }
                        else if (y == 2 || y == 5)
                        {
                            //Bishop
                            pawns[pawnIterator] = new WhiteBishopPawn(x, y);
                        }
                        else if (y == 3)
                        {
                            //Queen
                            pawns[pawnIterator] = new WhiteQueenPawn(x, y);
                        }
                        else
                        {
                            //King
                            pawns[pawnIterator] = new WhiteKingPawn(x, y);
                        }
                    }
                    else
                    {
                        //Pawn
                        pawns[pawnIterator] = new WhitePawn(x, y);
                    }
                    pawnIterator++;
                }
            }

            return pawns;
        }
    }
}
