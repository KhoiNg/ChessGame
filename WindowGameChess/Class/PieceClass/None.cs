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

        public override List<ChessPosition> CalculateMoves()
        {
            availableMoves = new List<ChessPosition>();
            return availableMoves;
        }
    }
}
