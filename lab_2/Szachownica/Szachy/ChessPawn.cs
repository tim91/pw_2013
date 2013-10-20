using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Interfejsy;
using System.Drawing;

namespace Szachy
{
    class ChessPawn : Pawn, Image
    {
        public ChessPawn(int xPosition, int yPosition)
        {
            this.xPosiition = xPosiition;
            this.yPosiition = yPosiition;
            //referencja
            //string greeting = rm.GetString("Greeting");

            //System.Type type = this.GetType();
            //typeof(Resource);
        }

        public void getPicture(string name)
        {
            ResourceManager rm = new ResourceManager("Penguins",typeof(ChessPawn).Assembly);
            Console.Write(rm.GetType());
        }

    }

}
