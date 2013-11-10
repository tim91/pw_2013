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
            String command = "Wykonuje : cd";
            if (minusP.Length > 0)
                command += " " + minusP;
            if (minusM.Length > 0)
                command += " " + minusM;
            if (minusV.Length > 0)
                command += " " + minusV;

            command += " Nieobslugiwane :";
            foreach (String s in otherProperties)
            {
                command += " " + s;
            }
            Console.WriteLine(command);
        }

        private string minusM;
        private string minusP;
        private string minusV;

        [CommandOptionWithParameter("-m")]
        public void setMinusM(string s)
        {
            this.minusM = s;
        }

        [CommandOptionWithParameter("-p")]
        public void setMinusP(string s)
        {
            this.minusP = s;
        }

        [CommandOptionWithParameter("-v")]
        public void setMinusV(string s)
        {
            this.minusV = s;
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
            this.minusM = "";
            this.minusP = "";
            this.minusV = "";
        }
    }
}
