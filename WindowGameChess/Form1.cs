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
        #endregion
        public FormChess()
        {
            InitializeComponent();
            ChessBoard = new Class.ChessBoardManager(PanelChessBoard);
            ChessBoard.DrawChessBoard();
        }
        
    }
}
