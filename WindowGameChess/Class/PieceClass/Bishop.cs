using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowGameChess.Class.PieceClass
{
    public class Bishop : ChessPiece
    {
        public Bishop(ChessColor color)
        {
            base.ChessType = ChessEnum.Bishop;
            base.Color = color;
        }

        public override List<ChessPosition> ListCanMove(ChessPosition pos_start, ChessPiece[,] Map_Chess)
        {
            List<ChessPosition> list = new List<ChessPosition>();
            list.AddRange(Diagonal(pos_start, Map_Chess));
            return list;
        }
    }
}
