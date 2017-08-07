using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowGameChess.Class
{
    public enum ChessEnum
    {
        Empty = 0,
        Pawn = 1,
        Bishop = 2,
        Knight = 3,
        Rook = 4,
        Queen = 5,
        King = 6
    }
    public enum ChessColor
    {
        White = 1,
        Black = -1,
        Die = 0
    }
}
