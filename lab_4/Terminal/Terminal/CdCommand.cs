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
    }
}
