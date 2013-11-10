using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal
{
    [CommendAttribute("grep")]
    public class GrepCommand
    {
        [ExecuteCommandAttribute()]
        public void execute()
        {
        }

        [CommandOptionWithParameter("-r")]
        public string minusR { set; get; }

        //grep boo /etc/passwd
        [CommandOptionWithParameter("oridinary")]
        public string kwyWordAndFiles { set; get; }

        //grep -i "boo" /etc/passwd
        [CommandOptionWithParameter("-i")]
        public string minusI { set; get; }

        [OtherCommandArgumentsAttribute]
        public List<String> otherProperties { set; get; }
    }
}
