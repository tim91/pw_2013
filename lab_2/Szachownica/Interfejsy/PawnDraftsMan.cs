using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfejsy
{
    public interface PawnDraftsMan
    {
        Pawn createPawn(int xPosition, int yPosition, Interfejsy.StaticVariables.PawnType pawnType);

        //Zawraca tablice pionkow ktore powinny byc umieszczone na planszy przy starcie
        Pawn[] initialize();

        Point[] generateNeightborPoints(int currX, int currY, string type);
    }
}
