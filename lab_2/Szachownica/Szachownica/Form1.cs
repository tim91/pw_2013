using Interfejsy;
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
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PawnDraftsMan[] games = loadDlls();
            foreach (PawnDraftsMan game in games)
            {
                if(game != null)
                    this.gameComboBox.Items.Add(game);
            }
            
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
            for (int y = 0; y < 8; y++)
            {
                if ((y % 2) == 0)
                    white = true;
                else
                    white = false;
                for (int x = 0; x < 8; x++)
                {
                    Button b = new Button();
                    b.Name = y + "" + x;
                    b.Width = SIZE;
                    b.Height = SIZE;
                    b.Top = y * SIZE;
                    b.Left = x * SIZE;
                    b.Margin = new Padding(0);

                    if (white)
                    {
                        b.BackColor = Color.LightBlue;
                    }
                    else
                    {
                        b.BackColor = Color.Blue;
                    }

                    white = !white;
                    panel.Controls.Add(b);
                }
            }

            this.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PawnDraftsMan selected = this.gameComboBox.SelectedItem as PawnDraftsMan;
            if( selected != null)
            {
                drawBoard();

                Pawn [] pawns = selected.initialize();

                Control[] c = this.Controls.Find("mainPanel", false);
                Panel panel = c[0] as Panel;

                foreach (Pawn pawn in pawns)
                {
                    string name = pawn.yPosiition + "" + pawn.xPosiition;
                    Control[] b = panel.Controls.Find(name, true);
                    b[0].BackgroundImage = pawn.image;
                    b[0].BackgroundImageLayout = ImageLayout.Zoom;
                }
               
            }
            //else return,
            Console.WriteLine();
            
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

        private PawnDraftsMan [] loadDlls()
        {
            PawnDraftsMan[] games = new PawnDraftsMan[10];

            int gamesCounter = 0;

            DirectoryInfo di = new DirectoryInfo(".");

            foreach (FileInfo f in di.GetFiles("*.dll"))
            {
                Assembly a = Assembly.LoadFile(f.FullName);
                Type[] types = a.GetTypes();
                foreach (Type t in types)
                {
                    if (t.GetInterfaces().Contains(typeof(Interfejsy.PawnDraftsMan)))
                    {
                        PawnDraftsMan s = Activator.CreateInstance(t) as PawnDraftsMan;
                        games[gamesCounter] = s;
                        gamesCounter++;
                    }
                }
            }
            return games;
        }
    }
}
