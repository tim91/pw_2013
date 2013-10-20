using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interfejsy;

namespace Szachownica
{
    class BoardField : Button
    {

        public Pawn pawn { get; set; }

        private List<BoardField> neighborFields = new List<BoardField>(); 

        public void addNeighbor(BoardField bf)
        {
            neighborFields.Add(bf);
        }

        public void removeNeighbor(string name)
        {
            foreach (BoardField bf in neighborFields)
            {
                if (bf.Name.Equals(name))
                {
                    neighborFields.Remove(bf);
                }
            }
        }

        public void removeNeighbors()
        {
            neighborFields.Clear();
        }

        public bool isFieldFromList(BoardField boardField)
        {
            foreach (BoardField bf in neighborFields)
            {
                if (bf.Name.Equals(boardField.Name))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
