using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Interfejsy
{
    public abstract class Pawn
    {
        public Image image { get; set; }

        public int xPosiition { get; set; }
        public int yPosiition { get; set; }

        public abstract void movePawn(int newXPosition, int newYPosition);
        public abstract void removePawn();
    }
}
