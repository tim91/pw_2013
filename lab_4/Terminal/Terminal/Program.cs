using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Terminal
{
    class Program
    {
        private static Dictionary<String, Object> commands = new Dictionary<String, Object>();
        static void Main(string[] args)
        {
            Terminal terminal = new Terminal();

            while (true)
            {
                Console.Write(">");

                String command = Console.ReadLine();

                if (command.Length == 0)
                    continue;

                terminal.Execute(command);
               
            }
        }

    }
}
