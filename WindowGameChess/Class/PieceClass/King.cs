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
            //this.canCastle = true;
        }
        public King(ChessColor color, bool castle)
        {
            base.ChessType = ChessEnum.King;
            base.Color = color;
            //this.canCastle = castle;
        }

        public override List<ChessPosition> ListCanMove(ChessPosition pos_start, ChessPiece[,] Map_Chess)
        {
            List<ChessPosition> list = new List<ChessPosition>();
            list.AddRange(Diagonal(pos_start, Map_Chess));
            list.AddRange(Horizontal(pos_start, Map_Chess));
            list.AddRange(Vertical(pos_start, Map_Chess));
            return list;
        }

        protected override List<ChessPosition> Diagonal(ChessPosition pos_start, ChessPiece[,] Map_Chess)
        {
            List<ChessPosition> List = new List<ChessPosition>();
            ChessColor color = Map_Chess[pos_start.X, pos_start.Y].Color;
            if (color == ChessColor.Die) return List;
            ChessEnum type = Map_Chess[pos_start.X, pos_start.Y].ChessType;
            for (int val = 0; val < 4; val++)
            {
                int _x = maps_diagonal[val, 0];
                int _y = maps_diagonal[val, 1];
                while (pos_start.X + _x >= 0 && pos_start.X + _x <= 7 & pos_start.Y + _y >= 0 && pos_start.Y + _y <= 7)
                {
                    if (Map_Chess[pos_start.X + _x, pos_start.Y + _y].Color == color) break;// if ally -> can't move
                    else
                    {
                        List.Add(new ChessPosition() { X = pos_start.X + _x, Y = pos_start.Y + _y });
                        if (Map_Chess[pos_start.X + _x, pos_start.Y + _y].Color != ChessColor.Die) break; // if enemy -> eat
                    }
                    break;
                }
            }
            return List;
        }
        protected override List<ChessPosition> Vertical(ChessPosition pos_start, ChessPiece[,] Map_Chess)
        {
            List<ChessPosition> list = new List<ChessPosition>();
            ChessColor color = Map_Chess[pos_start.X, pos_start.Y].Color;
            if (color == ChessColor.Die) return list;
            ChessEnum type = Map_Chess[pos_start.X, pos_start.Y].ChessType;
            for (int index = 0; index < 2; index++)
            {
                int val = maps_vertical_n_horizontal[index];
                while (pos_start.Y + val >= 0 & pos_start.Y + val <= 7)
                {
                    if (Map_Chess[pos_start.X, pos_start.Y + val].Color == color) break;// if ally -> can't move
                    else
                    {
                        list.Add(new ChessPosition() { X = pos_start.X, Y = pos_start.Y + val });
                        if (Map_Chess[pos_start.X, pos_start.Y + val].Color != ChessColor.Die) break; // if enemy -> eat 
                    }
                    break;
                }
            }
            return list;
        }

        protected override List<ChessPosition> Horizontal(ChessPosition pos_start, ChessPiece[,] Map_Chess)
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
                    break;
                }
            }
            return list;
        }
        //public override List<ChessPosition> CalculateMoves()
        //{
        //    availableMoves = new List<ChessPosition>();
        //    GetMovementArray(1, Direction.FORWARD);
        //    GetMovementArray(1, Direction.BACKWARD);
        //    GetMovementArray(1, Direction.LEFT);
        //    GetMovementArray(1, Direction.RIGHT);
        //    GetDiagnalMovementArray(1, DiagnalDirection.FORWARD_LEFT);
        //    GetDiagnalMovementArray(1, DiagnalDirection.FORWARD_RIGHT);
        //    GetDiagnalMovementArray(1, DiagnalDirection.BACKWARD_LEFT);
        //    GetDiagnalMovementArray(1, DiagnalDirection.BACKWARD_RIGHT);
        //    if (this.canCastle)
        //    {
        //        availableMoves.Add(new ChessPosition() { X = 2, Y = 0 });
        //        availableMoves.Add(new ChessPosition() { X = -2, Y = 0 });
        //    }
        //    return availableMoves;
        //}
    }
}
