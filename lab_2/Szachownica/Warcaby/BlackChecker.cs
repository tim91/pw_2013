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
    public class BlackChecker : Pawn
    {
        public BlackChecker(int x, int y)
        {
            this.xPosition = x;
            this.yPosition = y;
            loadImage();
        }

        public override bool canMovePawn(int newXPosition, int newYPosition, string type)
        {
            if (type == null || (type != null && type.Equals("WhiteChecker")))
            {//pole bez pionka lub pionek przeciwnika, no to idziemy
                return true;
            }
            return false;
        }

        public override void removePawn()
        {
            throw new NotImplementedException();
        }
    }
}
