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

        [CommandOptionParameterless("-v")]
        bool abc;
    }
}
