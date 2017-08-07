using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowGameChess.Class.PieceClass
{
    public class Knight : ChessPiece
    {
        public Knight(ChessColor color)
        {
            base.ChessType = ChessEnum.Knight;
            base.Color = color;
            //CalculateMoves();
        }

        public override List<ChessPosition> CalculateMoves()
        {
            availableMoves = new List<ChessPosition>();
            availableMoves.Add(new ChessPosition() { X = 1, Y = 2 });
            availableMoves.Add(new ChessPosition() { X = 2, Y = 1 });
            availableMoves.Add(new ChessPosition() { X = -1, Y = -2 });
            availableMoves.Add(new ChessPosition() { X = -2, Y = -1 });
            availableMoves.Add(new ChessPosition() { X = -1, Y = -2 });
            availableMoves.Add(new ChessPosition() { X = -2, Y = -1 });
            availableMoves.Add(new ChessPosition() { X = 1, Y = -2 });
            availableMoves.Add(new ChessPosition() { X = 2, Y = -1 });
            return availableMoves;
        }
    }
}
