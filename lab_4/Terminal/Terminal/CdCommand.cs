using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal
{
    [CommendAttribute("cd")]
    class CdCommand
    {

        [ExecuteCommandAttribute()]
        public void execute()
        {
        }

        //cd folder
        [CommandOptionWithParameter("")]
        public string fileName { set; get; }

        [CommandOptionParameterless("..")]
        public bool parentDirectory { set; get; }

        //cd -
        [CommandOptionParameterless("-")]
        public bool getBack { set; get; }

        [OtherCommandArgumentsAttribute]
        public List<String> otherProperties { set; get; }
    }
}
