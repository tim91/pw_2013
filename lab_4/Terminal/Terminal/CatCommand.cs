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
    }
}
