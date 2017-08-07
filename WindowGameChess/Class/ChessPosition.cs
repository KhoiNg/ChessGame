using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowGameChess.Class
{
    public class ChessPosition
    {
        private int x;
        public int X
        {
            get { return X; }
            set { X = value; }
        }
        private int y;
        public int Y
        {
            get { return Y; }
            set { Y = value; }
        }

        private bool eat = false; 
        public bool Eat
        {
            get { return eat; }
            set { Eat = value; }
        }


    }
}
