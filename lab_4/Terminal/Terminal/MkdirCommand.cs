using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal
{
    [CommendAttribute("mkdir")]
    class MkdirCommand
    {
        [ExecuteCommandAttribute()]
        public void execute()
        {
            
        }

        [CommandOptionWithParameter("-m")]
        public string minusM { set; get; }

        [CommandOptionWithParameter("-p")]
        public string minusP { set; get; }

        [CommandOptionWithParameter("-v")]
        public string minusV { set; get; }

        [OtherCommandArgumentsAttribute]
        public List<String> otherProperties { set; get; }
    }
}
