using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal
{
    class CommandOptionWithParameterAttribute : System.Attribute
    {
        public CommandOptionWithParameterAttribute(String s)
        {
             this.propertyName = s;
        }

        public string propertyName { get; set; }
    }
}
