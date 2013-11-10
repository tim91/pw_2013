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
            String command = "Wykonuje : cat";
            if (minusB.Length > 0)
                command += " " + minusB;
            if (minusS.Length > 0)
                command += " " + minusS;
            if (minusN.Length > 0)
                command += " " + minusN;

            command += " Nieobslugiwane :";
            foreach (String s in otherProperties)
            {
                command += " " + s;
            }
            Console.WriteLine(command);
        }

        private string minusB;
        private string minusS;
        private string minusN;

        [CommandOptionWithParameter("-b")]
        public void setMinusB(string b)
        {
            this.minusB = b;
        }

        [CommandOptionWithParameter("-s")]
        public void setMinusS(string b)
        {
            this.minusS = b;
        }

        [CommandOptionWithParameter("-n")]
        public void setMinusN(string b)
        {
            this.minusN = b;
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
            this.minusS = "";
            this.minusB = "";
            this.minusN = "";
        }
    }
}
