using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowGameChess.Class.PieceClass
{
    public class Pawn : ChessPiece
    {
        private bool canEnPassantLeft;
        public bool CanEsPassantLeft
        {
            get { return canEnPassantLeft; }
            set { canEnPassantLeft = value; }
        }
        private bool canEnPassantRight;
        public bool CanEsPassantRight
        {
            get { return canEnPassantRight; }
            set { canEnPassantRight = value; }
        }
        private bool canDoubleJump;
        public bool CanDoubleJump
        {
            get { return canDoubleJump; }
            set { canDoubleJump = value; }
        }
        public Pawn(ChessColor color)
        {
            base.ChessType = ChessEnum.Pawn;
            base.Color = color;
            this.CanDoubleJump = true;
            //CalculateMoves();
        }
        public Pawn(ChessColor color,bool doubleJump = true, bool enPassantLeft = false, bool enPassantRight = false)
        {
            base.ChessType = ChessEnum.Pawn;
            base.Color = color;
            this.canDoubleJump = doubleJump;
            this.canEnPassantLeft = enPassantLeft;
            this.canEnPassantRight = enPassantRight;
            //CalculateMoves();
        }
        public override List<ChessPosition> CalculateMoves()
        {
            Direction forward;
            DiagnalDirection forwardLeft, forwardRight;
            if (base.Color == ChessColor.White)
            {
                forward = Direction.BACKWARD;
                forwardLeft = DiagnalDirection.BACKWARD_LEFT;
                forwardRight = DiagnalDirection.BACKWARD_RIGHT;
            }
            else
            {
                forward = Direction.FORWARD;
                forwardLeft = DiagnalDirection.FORWARD_LEFT;
                forwardRight = DiagnalDirection.FORWARD_RIGHT;
            }

            availableMoves = new List<ChessPosition>();
            if ( this.canDoubleJump)
                GetMovementArray(2, forward);
            else
                GetMovementArray(1, forward);

            GetDiagnalMovementArray(1, forwardLeft);
            GetDiagnalMovementArray(1, forwardRight);

            return availableMoves;
        }
    }
}
