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
        }

        public override List<ChessPosition> ListCanMove(ChessPosition pos_start, ChessPiece[,] Map_Chess)
        {
            List<ChessPosition> list = new List<ChessPosition>();
            list.AddRange(knightmove(pos_start, Map_Chess));
            return list;
        }

        public static List<ChessPosition> knightmove(ChessPosition pos_start, ChessPiece[,] Map_Chess)
        {
            List<ChessPosition> list = new List<ChessPosition>();
            ChessColor color = Map_Chess[pos_start.X, pos_start.Y].Color;
            if (color == ChessColor.Die) return list;
            ChessEnum type = Map_Chess[pos_start.X, pos_start.Y].ChessType;
            for (int val = 0; val < 8; val++)
            {
                int _x = pos_start.X + maps_knight[val, 0];
                int _y = pos_start.Y + maps_knight[val, 1];
                if (_x < 0 | _x > 7 | _y < 0 | _y > 7) continue;//outside 
                if (Map_Chess[_x, _y].Color == color) continue; // if ally -> can't move
                else list.Add(new ChessPosition() { X = _x, Y = _y });
            }
            return list;
        }

    }
}
