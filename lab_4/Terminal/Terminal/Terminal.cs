using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Terminal
{
    class Terminal
    {
        private Dictionary<String, Object> commands = new Dictionary<String, Object>();

        public Terminal()
        {
            initialize();
            foreach (String s in commands.Keys)
            {
                Object o;
                commands.TryGetValue(s,out o);
                Console.WriteLine("Key : " + s + " value : " + o.ToString());
            }
        }

        public void Execute(String command)
        {
            string[] parts = command.Split(' ');

            if (parts.Length == 0)
                return;

            String commandName = parts[0];

            if (commandName == null || commandName.Length == 0)
                return;

            object commandClass;
            commands.TryGetValue(commandName, out commandClass);

            if (commandClass == null)
                return;

            Type type = commandClass.GetType();

            clearFields(commandClass);

            if (parts.Length > 1)
            {
                int l = parts.Length;
                for (int idx = 1; idx < l; idx++)
                {
                    String e = parts[idx];
                    if (e.ElementAt(0).Equals('-'))
                    {
                        MethodInfo mi = findMethod(commandClass, e);
                        if (mi.GetCustomAttribute(typeof(CommandOptionParameterlessAttribute)) != null)
                        {
                            //mi.Invoke(commandClass,
                        }
                    }
                }
            }

            MethodInfo executeMethod = getExecuteMethod(commandClass,typeof(ExecuteCommandAttribute));
            
            executeMethod.Invoke(commandClass,new object[]{});
        }

        private MethodInfo findMethod(Object o, String attributeArg)
        {
            //na wejsciu np -l
            Type type = o.GetType();
            MethodInfo[] mi = type.GetMethods();
            foreach (MethodInfo m in mi)
            {
                if (m.GetCustomAttribute(typeof(CommandOptionParameterlessAttribute)) != null
                    || m.GetCustomAttribute(typeof(CommandOptionWithParameterAttribute)) != null)
                {
                    return m;
                }
            }
            return null;
        }

        private void clearFields(Object o)
        {
            Type type = o.GetType();
            MethodInfo[] mi = type.GetMethods();
            foreach (MethodInfo m in mi)
            {
                if (m.GetCustomAttribute(typeof(CommandOptionParameterlessAttribute)) != null)
                {
                    m.Invoke(o, new object[] { false});
                }
                else if (m.GetCustomAttribute(typeof(CommandOptionWithParameterAttribute)) != null)
                {
                    m.Invoke(o, new object[] { "" });
                }
                else if (m.GetCustomAttribute(typeof(OtherCommandArgumentsAttribute)) != null)
                {
                    m.Invoke(o, new object[] { new List<String>() });
                }
            }
        }

        private MethodInfo getExecuteMethod(Object o, Type t)
        {
            Type type = o.GetType();
            MethodInfo[] mi = type.GetMethods();
            foreach (MethodInfo m in mi)
            {
                if (m.GetCustomAttribute(t) != null)
                {
                    return m;
                }
            }
            return null;
        }

        private void initialize()
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
        }
    }
}
