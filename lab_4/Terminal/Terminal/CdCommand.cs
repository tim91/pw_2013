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
            String command = "Wykonuje : cd";
            if (parentDirectory)
                command += " ..";
            if (fileName.Length > 0)
                command += " " + fileName;
            if (getBack)
                command += " -";

            command += " Nieobslugiwane :";
            foreach (String s in otherProperties)
            {
                command += " " + s;
            }
            Console.WriteLine(command);
        }

        private string fileName;
        private bool parentDirectory;
        private bool getBack;

        //cd folder
        [CommandOptionWithParameter("")]
        public void seFileName(string b)
        {
            this.fileName = b;
        }

        [CommandOptionParameterless("..")]
        public void setParentirectory(bool b)
        {
            this.parentDirectory = b;
        }

        //cd -
        [CommandOptionParameterless("-")]
        public void setGetBack(bool b)
        {
            this.getBack = b;
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
            this.fileName = "";
            this.parentDirectory = false;
            this.getBack = false;
        }
    }
}
