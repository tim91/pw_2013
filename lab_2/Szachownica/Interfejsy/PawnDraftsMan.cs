﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfejsy
{
    interface PawnDraftsMan
    {
        Pawn createPawn(int xPosition, int yPosition, Interfejsy.StaticVariables.pawnType pawnType);
    }
}
