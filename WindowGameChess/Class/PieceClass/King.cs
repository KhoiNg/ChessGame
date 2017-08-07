using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowGameChess.Class.PieceClass
{
    public class King : ChessPiece
    {
        public King(ChessColor color)
        {
            base.ChessType = ChessEnum.King;
            base.Color = color;
            this.canCastle = true;
            //CalculateMoves();
        }
        public King(ChessColor color, bool castle)
        {
            base.ChessType = ChessEnum.King;
            base.Color = color;
            this.canCastle = castle;
            //CalculateMoves();
        }

        public override List<ChessPosition> CalculateMoves()
        {
            availableMoves = new List<ChessPosition>();
            GetMovementArray(1, Direction.FORWARD);
            GetMovementArray(1, Direction.BACKWARD);
            GetMovementArray(1, Direction.LEFT);
            GetMovementArray(1, Direction.RIGHT);
            GetDiagnalMovementArray(1, DiagnalDirection.FORWARD_LEFT);
            GetDiagnalMovementArray(1, DiagnalDirection.FORWARD_RIGHT);
            GetDiagnalMovementArray(1, DiagnalDirection.BACKWARD_LEFT);
            GetDiagnalMovementArray(1, DiagnalDirection.BACKWARD_RIGHT);
            if (this.canCastle)
            {
                availableMoves.Add(new ChessPosition() { X = 2, Y = 0 });
                availableMoves.Add(new ChessPosition() { X = -2, Y = 0 });
            }
            return availableMoves;
        }
        public static List<ChessPosition> Test()
        {
            List<ChessPosition> availableMoves = new List<ChessPosition>();
            GetMovementArray(1, Direction.FORWARD);
            GetMovementArray(1, Direction.BACKWARD);
            GetMovementArray(1, Direction.LEFT);
            GetMovementArray(1, Direction.RIGHT);
            GetDiagnalMovementArray(1, DiagnalDirection.FORWARD_LEFT);
            GetDiagnalMovementArray(1, DiagnalDirection.FORWARD_RIGHT);
            GetDiagnalMovementArray(1, DiagnalDirection.BACKWARD_LEFT);
            GetDiagnalMovementArray(1, DiagnalDirection.BACKWARD_RIGHT);
            return availableMoves;
        }
    }
}
