using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowGameChess.Class
{
    public abstract class ChessPiece
    {
        #region properties
        protected ChessEnum chessType = ChessEnum.Empty;
        public ChessEnum ChessType
        {
            get { return chessType; }
            set { chessType = value; }
        }

        protected ChessColor color = ChessColor.Die;
        public ChessColor Color
        {
            get { return color; }
            set { color = value; }
        }

        protected int indexControl = -1;
        public int IndexControl
        {
            get { return indexControl; }
            set { indexControl = value; }
        }
        #endregion

        #region method for moving
        public static int[,] maps_diagonal = new int[4, 2] { { -1, -1 }, { -1, 1 }, { 1, -1 }, { 1, 1 } };
        public static int[] maps_vertical_n_horizontal = new int[2] { +1, -1 };

        public abstract List<ChessPosition> ListCanMove(ChessPosition pos_start, ChessPiece[,] Map_Chess);
 
        protected virtual List<ChessPosition> Diagonal(ChessPosition pos_start, ChessPiece[,] Map_Chess)
        {
            List<ChessPosition> List = new List<ChessPosition>();
            ChessColor color = Map_Chess[pos_start.X, pos_start.Y].Color;
            if (color == ChessColor.Die) return List;
            ChessEnum type = Map_Chess[pos_start.X, pos_start.Y].ChessType;
            for (int val = 0; val < 4; val++)
            {
                int _x = maps_diagonal[val, 0];
                int _y = maps_diagonal[val, 1];
                while (pos_start.X + _x >= 0 && pos_start.X + _x <= 7 && pos_start.Y + _y >= 0 && pos_start.Y + _y <= 7)
                {
                    if (Map_Chess[pos_start.X + _x, pos_start.Y + _y].Color == color) break; // if ally -> can't move
                    else
                    {
                        List.Add(new ChessPosition() { X = pos_start.X + _x, Y = pos_start.Y + _y });
                        if (Map_Chess[pos_start.X + _x, pos_start.Y + _y].Color != ChessColor.Die) break; // if enemy -> eat
                    }
                    _x = _x + maps_diagonal[val, 0];
                    _y = _y + maps_diagonal[val, 1];
                }
            }
            return List;
        }

        protected virtual List<ChessPosition> Vertical(ChessPosition pos_start, ChessPiece[,] Map_Chess)
        {
            List<ChessPosition> list = new List<ChessPosition>();
            ChessColor color = Map_Chess[pos_start.X, pos_start.Y].Color;
            ChessEnum type = Map_Chess[pos_start.X, pos_start.Y].ChessType;
            if (color == ChessColor.Die) return list;
            for (int index = 0; index < 2; index++)
            {
                int val = maps_vertical_n_horizontal[index];
                while (pos_start.Y + val >= 0 && pos_start.Y + val <= 7)
                {
                    if (Map_Chess[pos_start.X, pos_start.Y + val].Color == color) break;// if ally -> can't move
                    else
                    {
                        list.Add(new ChessPosition() { X = pos_start.X, Y = pos_start.Y + val });
                        if (Map_Chess[pos_start.X, pos_start.Y + val].Color != ChessColor.Die) break; // if enemy -> eat 
                    }
                    val = val + maps_vertical_n_horizontal[index];
                }
            }
            return list;
        }

        protected virtual List<ChessPosition> Horizontal(ChessPosition pos_start, ChessPiece[,] Map_Chess)
        {
            List<ChessPosition> list = new List<ChessPosition>();
            ChessColor color = Map_Chess[pos_start.X, pos_start.Y].Color;
            if (color == ChessColor.Die) return list;
            ChessEnum type = Map_Chess[pos_start.X, pos_start.Y].ChessType;
            for (int index = 0; index < 2; index++)
            {
                int val = maps_vertical_n_horizontal[index];
                while (pos_start.X + val >= 0 && pos_start.X + val <= 7)
                {
                    if (Map_Chess[pos_start.X + val, pos_start.Y].Color == color) break;// if ally -> can't move
                    else
                    {
                        list.Add(new ChessPosition() { X = pos_start.X + val, Y = pos_start.Y });
                        if (Map_Chess[pos_start.X + val, pos_start.Y].Color != ChessColor.Die) break;// if enemy -> eat 
                    }
                    val = val + maps_vertical_n_horizontal[index];
                }
            }
            return list;
        }
        #endregion
    }

}
    