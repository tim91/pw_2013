using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal
{
    [CommendAttribute("pwd")]
    class PwdCommand
    {
        [ExecuteCommandAttribute()]
        public void execute()
        {
        }

        [CommandOptionParameterless("")]
        public bool empty { set; get; }

        [CommandOptionParameterless("-P")]
        public bool minusP { set; get; }

        [CommandOptionWithParameter("-L")]
        public bool minusL { set; get; }

        [OtherCommandArgumentsAttribute]
        public List<String> otherProperties { set; get; }
    }
}
