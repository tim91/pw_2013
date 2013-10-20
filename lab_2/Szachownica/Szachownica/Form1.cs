using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        private void Form1_Load(object sender, EventArgs e)
        {

            this.SetBounds(this.Left, this.Top, 200, 200);
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private static int SIZE = 50;

        private void drawBoard()
        {
            Control[] c = this.Controls.Find("mainPanel", false);
            Panel panel = c[0] as Panel;
            panel.Controls.RemoveByKey("startButton");
            panel.Controls.RemoveByKey("labelText");
            panel.Controls.RemoveByKey("gameComboBox");

            this.SetBounds(this.Left, this.Top, 465, 490);

            bool white = true;
            for (int y = 0; y < 9; y++)
            {
                if ((y % 2) == 0)
                    white = true;
                else
                    white = false;
                for (int x = 0; x < 9; x++)
                {
                    Button b = new Button();
                    b.Width = SIZE;
                    b.Height = SIZE;
                    b.Top = y * SIZE;
                    b.Left = x * SIZE;
                    b.Margin = new Padding(0);

                    if (white)
                    {
                        b.BackColor = Color.White;
                    }
                    else
                    {
                        b.BackColor = Color.Black;
                    }

                    white = !white;
                    panel.Controls.Add(b);
                }
            }

            this.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadDlls();
            //drawBoard();
            //getEmbeddedResource();
        }

        private static string REFLECTION_RESOURCE_PATH = "Szachownica.Resources.";

        private Image getEmbeddedImage(string className)
        {
            
            Assembly boardExe;
            boardExe = System.Reflection.Assembly.GetExecutingAssembly();
            //string[] resources = boardExe.GetManifestResourceNames();

            System.IO.Stream file = boardExe.GetManifestResourceStream(REFLECTION_RESOURCE_PATH + className + ".png");
            Image i = Image.FromStream(file);
            return i;
        }

        private void loadDlls()
        {
            DirectoryInfo di = new DirectoryInfo(".");

            foreach (FileInfo f in di.GetFiles("*.dll"))
            {
                Assembly a = Assembly.LoadFile(f.FullName);
                Type[] types = a.GetExportedTypes();
                Type[] tt = a.GetTypes();
                foreach (Type t in types)
                {
                    object[] o = t.GetCustomAttributes(true);

                    foreach (object oo in o)
                    {
                        Console.WriteLine(oo.ToString());
                        this.gameComboBox.Controls.Add(new Control(oo.ToString()));
                        /*
                        if (oo.ToString() == "Core.Plugin")
                        {
                            Core.IPlug plugin = oo as Core.IPlug;
                            if (oo != null)
                            {
                                plugin = (Core.IPlug)Activator.CreateInstance(t);
                                Console.WriteLine("Found Plugin !");
                                Console.WriteLine("Starting...");
                                plugin.Start();
                                Console.WriteLine("Displaing info");
                                Core.PluginInfo pi = plugin.Info();
                                Console.WriteLine(pi.ApplicationName + " " + pi.Version);
                                Console.WriteLine("Ending...");
                                plugin.End();
                            }
                        }*/
                    }
                }
            }
        }
    }
}
