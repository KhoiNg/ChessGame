using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowGameChess.Class.PieceClass
{
    interface InterfaceKnight
    {
        List<ChessPosition> knightmove(ChessPosition pos_start, ChessPiece[,] Map_Chess);
    }
}
