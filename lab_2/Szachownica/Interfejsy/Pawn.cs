using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Reflection;

namespace Interfejsy
{
    public abstract class Pawn
    {
        public Image image { get; set; }

        public int xPosiition { get; set; }
        public int yPosiition { get; set; }

        public abstract void movePawn(int newXPosition, int newYPosition);
        public abstract void removePawn();

        public void loadImage()
        {

            Assembly exe;
            exe = System.Reflection.Assembly.GetAssembly(this.GetType());
            string[] resources = exe.GetManifestResourceNames();
            foreach (string s in resources)
            {
                string g = this.GetType().ToString().Split('.')[1];
                if (s.Contains(g))
                {
                    System.IO.Stream file = exe.GetManifestResourceStream(s);
                    this.image = Image.FromStream(file);
                    break;
                }
            }
        }
    }
}
