﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal
{
    class CommandOptionParameterlessAttribute : System.Attribute
    {
        public CommandOptionParameterlessAttribute(string name)
        {
            this.propertyName = name;
        }
        public string propertyName { get; set; }
    }
}
