using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal
{
    [CommendAttribute("ls")]
    class LsCommand
    {
        [ExecuteCommandAttribute()]
        public void execute()
        {
            String command = "Wykonuje : ls";
            if (minusL)
                command += " -l";
            if (minusA)
                command += " -a";
            if (minusD.Length > 0)
                command += " " + minusD;

            command += " Nieobslugiwane :";
            foreach (String s in otherProperties)
            {
                command += " " + s;
            }
            Console.WriteLine(command);
        }

        private bool minusL;
        private bool minusA;
        private string minusD;

        [CommandOptionParameterless("-l")]
        public void serMinusL(bool s)
        {
            this.minusL = s;
        }

        [CommandOptionParameterless("-a")]
        public void serMinusA(bool s)
        {
            this.minusA = s;
        }

        [CommandOptionWithParameter("-d")]
        public void serMinusD(string s)
        {
            this.minusD = s;
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
            this.minusL = false;
            this.minusD = "";
            this.minusA = false;
        }
    }
}
