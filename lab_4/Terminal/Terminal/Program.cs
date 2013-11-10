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
            initialize();

            Console.Read();
        }

        private static void initialize()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] classes = assembly.GetTypes();
            foreach (Type class_ in classes)
            {
                Attribute a = class_.GetCustomAttribute(typeof(CommendAttribute));

                if (a != null)
                {
                    String ct = (a as CommendAttribute).getCommandType();
                    //Console.WriteLine(class_.GetTypeInfo());
                    Object o = Activator.CreateInstance(class_);
                    commands.Add(ct, o);
                }
            }
            /*
            foreach (String s in commands.Keys)
            {
                Object o;
                commands.TryGetValue(s, out o);
                Console.WriteLine("Klucz : " + s + " wartosc : " + o.GetType().ToString());
            }*/
        }
    }
}
