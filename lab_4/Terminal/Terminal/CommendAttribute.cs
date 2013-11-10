using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal
{
    [AttributeUsage(AttributeTargets.All)]
    class CommendAttribute : System.Attribute
    {
        private string commandType;

        public CommendAttribute(string commandType)
        {
            this.commandType = commandType;
        }

        public string getCommandType()
        {
            return this.commandType;
        }
    }
}
