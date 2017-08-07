using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowGameChess.Class.PieceClass
{
    public class Rook : ChessPiece
    {
        public Rook(ChessColor color)
        {
            base.ChessType = ChessEnum.Rook;
            base.Color = color;
        }

        public override List<ChessPosition> ListCanMove(ChessPosition pos_start, ChessPiece[,] Map_Chess)
        {
            List<ChessPosition> list = new List<ChessPosition>();
            list.AddRange(Vertical(pos_start, Map_Chess));
            list.AddRange(Horizontal(pos_start, Map_Chess));

            return list;
        }
    }  
}
