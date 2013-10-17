using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Szachy
{
    class Model
    {
        public Model()
        {
            //referencja

            
            //string greeting = rm.GetString("Greeting");

            //System.Type type = this.GetType();
            //typeof(Resource);
        }

        public void getPicture(string name)
        {
            ResourceManager rm = new ResourceManager("Penguins",typeof(Model).Assembly);
            Console.Write(rm.GetType());
        }

    }

}
