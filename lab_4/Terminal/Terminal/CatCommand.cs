using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal
{
    [CommendAttribute("cat")]
    class CatCommand
    {

        [ExecuteCommandAttribute()]
        public void execute()
        {
        }

        //cat file.txt
        [CommandOptionWithParameter("")]
        public string fileName { set; get; }

        [CommandOptionWithParameter("-s")]
        public string minusS { set; get; }

        [CommandOptionWithParameter("-n")]
        public string minusN { set; get; }

        [OtherCommandArgumentsAttribute]
        public List<String> otherProperties { set; get; }
    }
}
