using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowGameChess
{
    public partial class FormChess : Form
    {
        #region Properties
        Class.ChessBoardManager ChessBoard;
        Class.ChessPiece[,] Map_Chess = new Class.ChessPiece[8, 8];
        Class.ChessColor round = Class.ChessColor.Black;

        #endregion
        public FormChess()
        {
            InitializeComponent();
            ChessBoard = new Class.ChessBoardManager(PictureChess);
            ChessBoard.DrawChessBoard();
            ChessBoard.CreateMapChessPosition();
        }
        
    }
}
