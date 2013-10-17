using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szachownica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Assembly szachyAssembly;
            //szachyAssembly = Assembly.LoadFrom("Szachy.dll");
            //Assembly.LoadFrom("Warcaby.dll");
            //MethodInfo Method = szachyAssembly.GetTypes()[0].GetMethod("Method1");

            string ss = System.IO.Path.GetFullPath(Application.ExecutablePath);

            Console.WriteLine(ss);

            InitializeComponent();
        }
    }
}
