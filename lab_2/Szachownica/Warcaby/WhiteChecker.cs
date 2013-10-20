using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfejsy;
using System.Drawing;
using System.Reflection;

namespace Warcaby
{
    class WhiteChecker : Pawn
    {
        public WhiteChecker(int x, int y)
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
