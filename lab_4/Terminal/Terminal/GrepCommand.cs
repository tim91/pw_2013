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
            String command = "Wykonuje : grep";
            if (minusV)
                command += " -V";
            if (minusR.Length > 0)
                command += " " + minusR;
            if (minusI.Length > 0)
                command += " " + minusI;

            command += " Nieobslugiwane :";
            foreach (String s in otherProperties)
            {
                command += " " + s;
            }
            Console.WriteLine(command);
        }

        private string minusR;
        private bool minusV;
        private string minusI;
        
        [CommandOptionWithParameter("-r")]
        public void setMinusR(String s)
        {
            this.minusR = s;
        }
        

        //grep -V
        [CommandOptionParameterless("-V")]
        public void setMinusV(bool s)
        {
            this.minusV = s;
        }

        //grep -i "boo" /etc/passwd
        [CommandOptionWithParameter("-i")]
        public void setMinusI(String s)
        {
            this.minusI = s;
        }

        private List<String> otherProperties = new List<string>();

        [OtherCommandArgumentsAttribute]
        public void addOtherProperties(String s)
        {
            this.otherProperties.Add(s);
        }

        [ClearOtherProperties]
        public void clearOtherProperties()
        {
            this.otherProperties.Clear();
        }

        [ClearFields]
        public void clearFields()
        {
            this.minusR = "";
            this.minusI = "";
            this.minusV = false;
        }

    }
}
