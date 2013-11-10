using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
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
                Console.Write("Program : " + s + " parametry : ");
                Type type = o.GetType();
                MethodInfo[] mi = type.GetMethods();
                foreach (MethodInfo m in mi)
                {
                    Attribute a = null;
                    if ((a = m.GetCustomAttribute(typeof(CommandOptionParameterlessAttribute))) != null)
                    {
                        String ct = (a as CommandOptionParameterlessAttribute).propertyName;
                        Console.Write(ct + " | ");

                    }
                    if ((a = m.GetCustomAttribute(typeof(CommandOptionWithParameterAttribute))) != null)
                    {
                        String ct = (a as CommandOptionWithParameterAttribute).propertyName;
                        Console.Write(ct + " | ");
                    }
                }
                Console.WriteLine();
            }
        }

        public void Execute(String command)
        {
            command = Regex.Replace(command, " +", " ");

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

            if (parts.Length > 1 && !parts[1].Equals(""))
            {
                int l = parts.Length;
                for (int idx = 1; idx < l; idx++)
                {
                    String e = parts[idx];
                    if (e.ElementAt(0).Equals('-'))
                    {
                        MethodInfo mi = findMethod(commandClass, e);
                        if (mi == null)
                        {
                            MethodInfo m = getOtherFiledMethod(commandClass);
                            if (m == null)
                                return;
                            //odkladamy na liscie nieobslugiwanych
                            m.Invoke(commandClass, new object[] { e });
                        }
                        else if (mi.GetCustomAttribute(typeof(CommandOptionParameterlessAttribute)) != null)
                        {
                            mi.Invoke(commandClass, new object[] { true });
                        }
                        else if (mi.GetCustomAttribute(typeof(CommandOptionWithParameterAttribute)) != null)
                        {
                            //pobieramy dalsza czesc
                            String q = null;
                            if (idx + 1 < l)
                            {
                                q = parts[idx + 1];
                                if (!q.ElementAt(0).Equals('-'))
                                {
                                    e += " " + q;
                                    idx++;
                                }
                            }
                            
                            mi.Invoke(commandClass, new object[] { e });
                        }
                    }
                    else if (e.Length > 0)
                    {
                        MethodInfo mi = findMethod(commandClass, "");
                        if (mi == null)
                            return;
                        else if (mi.GetCustomAttribute(typeof(CommandOptionWithParameterAttribute)) != null)
                        {
                            mi.Invoke(commandClass, new object[] { e });
                        }
                    }
                }
            }
            else
            {
                MethodInfo mi = findMethod(commandClass, "");
                if (mi == null)
                    return;
                else if (mi.GetCustomAttribute(typeof(CommandOptionParameterlessAttribute)) != null)
                {
                    mi.Invoke(commandClass, new object[] { true });
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
                Attribute a = null;
                if ( (a = m.GetCustomAttribute(typeof(CommandOptionParameterlessAttribute))) != null)
                {
                    String ct = (a as CommandOptionParameterlessAttribute).propertyName;
                    if(ct.Equals(attributeArg))
                        return m;

                }
                if( ( a = m.GetCustomAttribute(typeof(CommandOptionWithParameterAttribute))) != null)
                {
                    String ct = (a as CommandOptionWithParameterAttribute).propertyName;
                    if (ct.Equals(attributeArg))
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
                if (m.GetCustomAttribute(typeof(ClearFields)) != null)
                {
                    m.Invoke(o, new object[] {});
                }
            }
        }

        private MethodInfo getOtherFiledMethod(Object o)
        {
            Type type = o.GetType();
            MethodInfo[] mi = type.GetMethods();
            foreach (MethodInfo m in mi)
            {
                if (m.GetCustomAttribute(typeof(OtherCommandArgumentsAttribute)) != null)
                {
                    return m;
                }
            }
            return null;
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
