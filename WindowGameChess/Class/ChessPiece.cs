using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowGameChess.Class
{
    public class ChessPiece
    {
        protected ChessEnum chessType = ChessEnum.Empty;
        public ChessEnum ChessType
        {
            get { return chessType; }
            set { ChessType = value; }
        }
        protected ChessColor color = ChessColor.Die;
        public ChessColor Color
        {
            get { return color; }
            set { Color = value; }
        }

        protected int indexControl = -1;
        public int IndexControl
        {
            get { return indexControl; }
            set { IndexControl = value; }
        }

        protected static string FolderImage = Application.StartupPath + "\\ChessImage\\";
        protected string nameofimage;
    }

}
