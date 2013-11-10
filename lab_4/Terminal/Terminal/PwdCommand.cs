using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal
{
    [CommendAttribute("pwd")]
    class PwdCommand
    {
        [ExecuteCommandAttribute()]
        public void execute()
        {
            String command = "Wykonuje : pwd";
            if (minusP)
                command += " -P";
            if (minusL)
                command += " -L";

            command += " Nieobslugiwane :";
            foreach(String s in otherProperties)
            {
                command+= " " +s;
            }
            Console.WriteLine(command);
        }

       
        private bool empty;
        private bool minusP;
        private bool minusL;

        [CommandOptionParameterless("")]
        public void setEmpty(bool b)
        {
            this.empty = b;
        }

        [CommandOptionParameterless("-P")]
        public void setMinusP(bool b)
        {
            this.minusP = b;
        }

        [CommandOptionParameterless("-L")]
        public void setMinusL(bool b)
        {
            this.minusL = b;
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
            this.empty = false;
            this.minusP = false;
            this.minusL = false;
        }

    }
}
