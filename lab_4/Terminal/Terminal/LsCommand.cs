using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal
{
    [CommendAttribute("ls")]
    class LsCommand
    {
        [ExecuteCommandAttribute()]
        public void execute()
        {
            //magic
        }

        [CommandOptionParameterless("-l")]
        public bool minusL { set; get; }

        [CommandOptionParameterless("-a")]
        public bool minusA { set; get; }

        [CommandOptionWithParameter("-d")]
        public string minusD { set; get; }

        [OtherCommandArgumentsAttribute]
        public List<String> otherProperties { set; get; }
    }
}
