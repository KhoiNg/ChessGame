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
            ChessBoard = new Class.ChessBoardManager(PictureChess,RichTextBoxTurn,RichTextBoxMove,RichTextBoxDie);
            ChessBoard.DrawChessBoard();
            ChessBoard.CreateMapChessPosition();
            ChessBoard.playerturn();
            richTextBox1.Text = "30:00";
            richTextBox2.Text = "30:00";
            RichTextBoxDie.Text = "Player 1 Death Piece \n";
            RichTextBoxDie.Text += "Pawn : 0, Rook : 0, Knight : 0, Bishop : 0 ,Queen : 0 \n";
            RichTextBoxDie.Text += "Player 2 Death Piece \n";
            RichTextBoxDie.Text += "Pawn : 0, Rook : 0, Knight : 0, Bishop : 0 ,Queen : 0 \n";

        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChessBoard.MakeNewRound();
            richTextBox1.Text = "30:00";
            richTextBox2.Text = "30:00";
            OrigTime1 = 1800;
            OrigTime2 = 1800;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" It is a draw game ");
            Application.Exit();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("It is a 2-player Chess Game", "Made By Khoi . Enjoy! ");
        }

        #region Timer
        static int OrigTime1 = 1800;
        static int OrigTime2 = 1800;
        private void timer_Tick(object sender, EventArgs e)
        {
            if (ChessBoard.round == Class.ChessColor.White)
            {
                OrigTime1--;
                richTextBox1.Text = OrigTime1 / 60 + ":" + ((OrigTime1 % 60) >= 10 ? (OrigTime1 % 60).ToString() : "0" + OrigTime1 % 60);
            }
            else
            {
                OrigTime2--;
                richTextBox2.Text = OrigTime2 / 60 + ":" + ((OrigTime2 % 60) >= 10 ? (OrigTime2 % 60).ToString() : "0" + OrigTime2 % 60);
            }

            if (OrigTime1 == 0)
            {
                MessageBox.Show("Player 1 lose.");
                Application.Exit();
            }
            if (OrigTime2 == 0)
            {
                MessageBox.Show("Player 2 lose.");
                Application.Exit();
            }
            
        }

        private void disableTimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }
        #endregion

    }
}
