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
            
            this.SetBounds(this.Left, this.Top, 180, 180);
            
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

            this.SetBounds(this.Left, this.Top, 415, 438);

            bool white = true;
            for (int y = 0; y < 8; y++)
            {
                if ((y % 2) == 0)
                    white = true;
                else
                    white = false;
                for (int x = 0; x < 8; x++)
                {
                    BoardField b = new BoardField();
                    b.Name = y + "" + x;
                    b.Width = SIZE;
                    b.Height = SIZE;
                    b.Top = y * SIZE;
                    b.Left = x * SIZE;

                    b.Click += b_Click;
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

        private BoardField selectedField;

        void b_Click(object sender, EventArgs e)
        {
            BoardField boardField = sender as BoardField;
            if (selectedField != null )
            {//przenosimy w to miejsce
                //sprawdzam czy pole ktore chce przesunac jest sasiadem pola na ktore chce przeniesc
                int x = -1;
                int y = -1; ;
                string type = null;
                if (selectedField.isFieldFromList(boardField))
                {
                    
                    if (boardField.pawn != null)
                    {
                        x = boardField.pawn.xPosition;
                        y = boardField.pawn.yPosition;
                        type = boardField.pawn.GetType().ToString().Split('.')[1];
                    }
                    else
                    {
                        x = boardField.Location.X/SIZE;
                        y = boardField.Location.Y/SIZE;
                    }

                    
                    if (this.selectedField.pawn.canMovePawn(x, y, type))
                    {
                        boardField.BackgroundImage = this.selectedField.BackgroundImage;
                        boardField.pawn = this.selectedField.pawn;
                        boardField.BackgroundImageLayout = this.selectedField.BackgroundImageLayout;
                        this.selectedField.removeNeighbors();
                        this.selectedField.pawn = null;

                        boardField.pawn.xPosition = x;
                        boardField.pawn.yPosition = y;
                        boardField.removeNeighbors();
                        addNeightbours(x, y);
                        this.selectedField.removeNeighbors();
                        this.selectedField.BackgroundImage = null;
                        this.Refresh();
                    }
                    Console.WriteLine("w IF");
                }

                this.selectedField = null;
            }
            else
            {//wciaskmy do przeniesienia jezeli jest tam pionek
                
                if( boardField.pawn != null)
                {
                    this.selectedField = boardField;
                }
            }

            
        }

        private void addNeightbours(int x, int y)
        {
            Control[] c = this.Controls.Find("mainPanel", false);
            Panel panel = c[0] as Panel;

            Control[] control = panel.Controls.Find(y + "" + x, false);

            BoardField bf = control[0] as BoardField;

            Point [] points = new Point[2];

            if (bf.pawn != null)
            {
                points = this.selected.generateNeightborPoints(bf.pawn.xPosition, bf.pawn.yPosition, bf.pawn.GetType().ToString().Split('.')[1]);

                foreach (Point p in points)
                {
                    if (p != null)
                    {
                        Control[] cc = panel.Controls.Find(p.Y + "" + p.X, false);
                        if (cc.Length > 0 && cc[0] != null)
                        {
                            bf.addNeighbor(cc[0] as BoardField);
                        }
                    }
                }
            }
        }

        private PawnDraftsMan selected = null;

        private void button1_Click(object sender, EventArgs e)
        {
            this.selected = this.gameComboBox.SelectedItem as PawnDraftsMan;
            if( this.selected != null)
            {
                drawBoard();

                Pawn [] pawns = selected.initialize();

                Control[] c = this.Controls.Find("mainPanel", false);
                Panel panel = c[0] as Panel;

                foreach (Pawn pawn in pawns)
                {
                    string name = pawn.yPosition + "" + pawn.xPosition;
                    Control[] b = panel.Controls.Find(name, true);
                    BoardField field = b[0] as BoardField;
                    field.BackgroundImage = pawn.image;
                    field.BackgroundImageLayout = ImageLayout.Zoom;
                    field.pawn = pawn;
                    //field.Click += b_Click;

                    Point[] points = this.selected.generateNeightborPoints(pawn.xPosition, pawn.yPosition, pawn.GetType().ToString().Split('.')[1]);

                    foreach (Point p in points)
                    {
                        if (p != null)
                        {
                            Control[] cc = panel.Controls.Find(p.Y + "" + p.X, false);
                            if (cc.Length > 0 && cc[0] != null)
                            {
                                field.addNeighbor(cc[0] as BoardField);
                            }
                        }
                    }
                    
                }
               
            }
            //else return,
            Console.WriteLine();
            
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
