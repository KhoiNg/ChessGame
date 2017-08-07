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
            //CalculateMoves();
        }

        public override List<ChessPosition> CalculateMoves()
        {
            availableMoves = new List<ChessPosition>();
            GetDiagnalMovementArray(MaxDistance, DiagnalDirection.FORWARD_LEFT);
            GetDiagnalMovementArray(MaxDistance, DiagnalDirection.FORWARD_RIGHT);
            GetDiagnalMovementArray(MaxDistance, DiagnalDirection.BACKWARD_LEFT);
            GetDiagnalMovementArray(MaxDistance, DiagnalDirection.BACKWARD_RIGHT);
            return availableMoves;
        }

    }
}
