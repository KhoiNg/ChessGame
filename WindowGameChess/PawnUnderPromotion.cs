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
    public partial class PawnUnderPromotion : Form
    {
        public Class.ChessEnum chess = Class.ChessEnum.Pawn;
        Class.ChessColor color = Class.ChessColor.Die;
        public PawnUnderPromotion(Class.ChessColor color)
        {
            InitializeComponent();
            this.color = color;
        }

        private void button_Click(object sender, EventArgs e)
        {
            switch (BoxType.Text)
            {
                case "Rook": chess = Class.ChessEnum.Rook; break;
                case "Knight": chess = Class.ChessEnum.Knight; break;
                case "Bishop": chess = Class.ChessEnum.Bishop; break;
                case "Queen": chess = Class.ChessEnum.Queen; break;
                default: break;
            }
            this.Close();
        }
    }
}
