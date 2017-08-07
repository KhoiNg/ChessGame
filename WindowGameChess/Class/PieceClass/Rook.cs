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
            this.canCastle = true;
            //CalculateMoves();
        }
        public Rook(ChessColor color, bool castle)
        {
            base.ChessType = ChessEnum.Rook;
            base.Color = color;
            this.canCastle = castle;
            //CalculateMoves();
        }

        public override List<ChessPosition> CalculateMoves()
        {
            availableMoves = new List<ChessPosition>();
            GetMovementArray(MaxDistance, Direction.FORWARD);
            GetMovementArray(MaxDistance, Direction.BACKWARD);
            GetMovementArray(MaxDistance, Direction.RIGHT);
            GetMovementArray(MaxDistance, Direction.LEFT);
            return availableAttack;
        }
    }
}
