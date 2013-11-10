using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal
{
    class CommandOptionParameterlessAttribute : System.Attribute
    {
        private string c;
        public CommandOptionParameterlessAttribute(String s)
        {
            this.c = s;
        }
    }
}
