using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowGameChess.Class.PieceClass
{
    public class Queen : ChessPiece
    {
        public Queen(ChessColor color)
        {
            base.ChessType = ChessEnum.Queen;
            base.Color = color;
            //CalculateMoves();
        }

        public override List<ChessPosition> CalculateMoves()
        {
            availableMoves = new List<ChessPosition>();

            GetMovementArray(MaxDistance, Direction.FORWARD);
            GetMovementArray(MaxDistance, Direction.BACKWARD);
            GetMovementArray(MaxDistance, Direction.RIGHT);
            GetMovementArray(MaxDistance, Direction.LEFT);
            GetDiagnalMovementArray(MaxDistance, DiagnalDirection.FORWARD_LEFT);
            GetDiagnalMovementArray(MaxDistance, DiagnalDirection.FORWARD_RIGHT);
            GetDiagnalMovementArray(MaxDistance, DiagnalDirection.BACKWARD_LEFT);
            GetDiagnalMovementArray(MaxDistance, DiagnalDirection.BACKWARD_RIGHT);
            return availableMoves;
        }

    }
}
