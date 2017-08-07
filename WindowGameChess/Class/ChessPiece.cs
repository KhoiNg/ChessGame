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
        protected const int MaxDistance = 7;
        protected List<ChessPosition> availableMoves;
        public List<ChessPosition> AvailableMoves
        {
            get { return availableMoves; }
            set { availableMoves = value; }
        }
        protected List<ChessPosition> availableAttack;

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

        protected bool canCastle;
        public bool CanCastle
        {
            get { return canCastle; }
            set { canCastle = value; }
        }

        public abstract List<ChessPosition> CalculateMoves();
        public static List<ChessPosition> GetMovementArray(int distance, Direction direction)
        {
            List<ChessPosition> movement = new List<ChessPosition>();
            int xPosition = 0;
            int yPosition = 0;

            for (int i = 0; i < distance; i++)
            {
                switch (direction)
                {
                    case Direction.FORWARD:
                        yPosition++;
                        break;
                    case Direction.BACKWARD:
                        yPosition--;
                        break;
                    case Direction.LEFT:
                        xPosition++;
                        break;
                    case Direction.RIGHT:
                        xPosition--;
                        break;
                    default:
                        break;
                }
                movement.Add(new ChessPosition() { X = xPosition, Y = yPosition });
            }
            return movement;
        }
        public static List<ChessPosition> GetDiagnalMovementArray(int distance, DiagnalDirection direction)
        {
            List<ChessPosition> movement = new List<ChessPosition>();
            int xPosition = 0;
            int yPosition = 0;

            for (int i = 0; i < distance; i++)
            {
                switch (direction)
                {
                    case DiagnalDirection.FORWARD_LEFT:
                        xPosition--;
                        yPosition++;
                        break;
                    case DiagnalDirection.FORWARD_RIGHT:
                        xPosition++;
                        yPosition++;
                        break;
                    case DiagnalDirection.BACKWARD_LEFT:
                        xPosition--;
                        yPosition--;
                        break;
                    case DiagnalDirection.BACKWARD_RIGHT:
                        xPosition++;
                        yPosition--;
                        break;
                    default:
                        break;
                }
                movement.Add(new ChessPosition() { X = xPosition, Y = yPosition });
            }
            return movement;
        }
        #region test
        private static int[,] maps_diagonal = new int[4, 2] { { -1, -1 }, { -1, 1 }, { 1, -1 }, { 1, 1 } };
        private static int[] maps_vertical_n_horizontal = new int[2] { +1, -1 };
        private static int[,] maps_knight = new int[8, 2] { { -2, +1 }, { -2, -1 }, { +2, +1 }, { +2, -1 }, { +1, -2 }, { -1, -2 }, { +1, +2 }, { -1, +2 } };

        public virtual List<ChessPosition> ListCanMove(ChessPosition pos_start, ChessPiece[,] Map_Chess)
        {
            List<ChessPosition> list = new List<ChessPosition>();
            list.AddRange(diagonal(pos_start, Map_Chess));
            list.AddRange(vertical(pos_start, Map_Chess));
            list.AddRange(horizontal(pos_start, Map_Chess));
            list.AddRange(knight(pos_start, Map_Chess));
            return list;

        }

        protected static List<ChessPosition> diagonal(ChessPosition pos_start, ChessPiece[,] Map_Chess)
        {
            List<ChessPosition> list = new List<ChessPosition>();
            ChessColor color = Map_Chess[pos_start.X, pos_start.Y].Color;
            if (color == ChessColor.Die) return list;
            ChessEnum type = Map_Chess[pos_start.X, pos_start.Y].chessType;
            if (type == ChessEnum.Knight || type == ChessEnum.Rook) return list;//Knight & Castle can't move diagonal
            for (int val = 0; val < 4; val++)
            {
                int _x = maps_diagonal[val, 0];
                int _y = maps_diagonal[val, 1];
                while (pos_start.X + _x >= 0 && pos_start.X + _x <= 7 & pos_start.Y + _y >= 0 && pos_start.Y + _y <= 7)
                {
                    if (type == ChessEnum.Pawn && (int)color == maps_diagonal[val, 1]) break; //Pawn can't move behind
                    if ( Map_Chess[pos_start.X + _x, pos_start.Y + _y].Color == color)
                    {
                        break;// if ally -> can't move
                    }
                    else
                    {
                        if (type == ChessEnum.Pawn)
                        {
                            if (Map_Chess[pos_start.X + _x, pos_start.Y + _y].Color != ChessColor.Die)
                            {
                                list.Add(new ChessPosition() { X = pos_start.X + _x, Y = pos_start.Y + _y });
                            }
                        }
                        else
                        {
                            list.Add(new ChessPosition() { X = pos_start.X + _x, Y = pos_start.Y + _y });
                            if (Map_Chess[pos_start.X + _x, pos_start.Y + _y].Color != ChessColor.Die) break; // if enemy -> eat
                        }
                    }
                    if (type == ChessEnum.King || type == ChessEnum.Pawn) break; //King & Pawn max 1 step
                    _x = _x + maps_diagonal[val, 0];
                    _y = _y + maps_diagonal[val, 1];
                }
            }
            return list;
        }
        protected static List<ChessPosition> vertical(ChessPosition pos_start, ChessPiece[,] Map_Chess)
        {
            List<ChessPosition> list = new List<ChessPosition>();
            ChessColor color = Map_Chess[pos_start.X, pos_start.Y].Color;
            ChessEnum type = Map_Chess[pos_start.X, pos_start.Y].ChessType;
            if (color == ChessColor.Die) return list;
            if (type == ChessEnum.Knight || type == ChessEnum.Bishop) return list;//Knight & Bishop can't move vertical
            for (int index = 0; index < 2; index++)
            {
                int val = maps_vertical_n_horizontal[index];
                while (pos_start.Y + val >= 0 && pos_start.Y + val <= 7)
                {
                    if (type == ChessEnum.Pawn && (int)color == maps_vertical_n_horizontal[index]) break; //Pawn can't move behind
                    if (Map_Chess[pos_start.X, pos_start.Y + val].Color == color) break;// if ally -> can't move
                    else
                    {
                        if (Map_Chess[pos_start.X, pos_start.Y + val].Color != ChessColor.Die && type == ChessEnum.Pawn) break;// Pawn can't move
                        list.Add(new ChessPosition() { X = pos_start.X, Y = pos_start.Y + val });
                        if (Map_Chess[pos_start.X, pos_start.Y + val].Color != ChessColor.Die) break; // if enemy -> eat 
                    }
                    if (type == ChessEnum.King) break;  //king max 1 step
                    if (type == ChessEnum.Pawn)
                    {
                        if (val == 2 | val == -2) break;//Pawn max 2 step
                        int line = color == ChessColor.Black ? 1 : 6;
                        if (pos_start.Y != line) break;
                    }
                    val = val + maps_vertical_n_horizontal[index];
                }
            }
            return list;
        }

        protected static List<ChessPosition> horizontal(ChessPosition pos_start, ChessPiece[,] Map_Chess)
        {
            List<ChessPosition> list = new List<ChessPosition>();
            ChessColor color = Map_Chess[pos_start.X, pos_start.Y].Color;
            if (color == ChessColor.Die) return list;
            ChessEnum type = Map_Chess[pos_start.X, pos_start.Y].chessType;
            if (type == ChessEnum.Knight || type == ChessEnum.Bishop || type == ChessEnum.Pawn) return list;//Knight & Bishop & Pawn can't move horizontal
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
                    if (type == ChessEnum.King) break;  //king max 1 step
                    val = val + maps_vertical_n_horizontal[index];
                }
            }
            return list;
        }

        protected static List<ChessPosition> knight(ChessPosition pos_start, ChessPiece[,] Map_Chess)
        {
            List<ChessPosition> list = new List<ChessPosition>();
            ChessColor color = Map_Chess[pos_start.X, pos_start.Y].Color;
            if (color == ChessColor.Die) return list;
            ChessEnum type = Map_Chess[pos_start.X, pos_start.Y].chessType;
            if (type != ChessEnum.Knight) return list;
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

        #endregion
    }

}
