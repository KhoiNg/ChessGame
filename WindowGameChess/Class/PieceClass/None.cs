using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowGameChess.Class.PieceClass
{
    public class None : ChessPiece
    {
        public None()
        {
            base.ChessType = ChessEnum.Empty;
            base.Color = ChessColor.Die;
        }

        public None (int indexer)
        {
            base.ChessType = ChessEnum.Empty;
            base.Color = ChessColor.Die;
            base.IndexControl = indexer;
        }

        public override List<ChessPosition> ListCanMove(ChessPosition pos_start, ChessPiece[,] Map_Chess)
        {
            List<ChessPosition> list = new List<ChessPosition>();
            ChessColor color = Map_Chess[pos_start.X, pos_start.Y].Color;
            if (color == ChessColor.Die) return list;
            return list;
        }
    }
}
