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
    }
}
