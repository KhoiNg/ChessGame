using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowGameChess.Class
{
    public class Moving
    {
        private static int[,] Diagonal = new int [4,2] { { -1, -1 }, { -1, 1 }, { 1, -1 }, { 1, 1 } };
        private static int[] VerticalandHorizontal = new int[2] { +1, -1 };

        public static List<ChessPosition> ListCanMove(ChessPosition pos_start, ChessPiece[,] Map_Chess)
        {
            List<ChessPosition> list = new List<ChessPosition>();
            list.AddRange(diagonal(pos_start, Map_Chess));
            list.AddRange(vertical(pos_start, Map_Chess));
            list.AddRange(horizontal(pos_start, Map_Chess));
            return list;
        }
        private static List<ChessPosition> diagonal(ChessPosition pos_start, ChessPiece[,] Map_Chess)
        {
            List<ChessPosition> list = new List<ChessPosition>();
            ChessColor color = Map_Chess[pos_start.X, pos_start.Y].Color;
            if (color == ChessColor.Die) return list;
            ChessEnum type = Map_Chess[pos_start.X, pos_start.Y].ChessType;
            if (type == ChessEnum.Knight | type == ChessEnum.Castle) return list;//Knight & Castle can't move diagonal
            for (int val = 0; val < 4; val++)
            {
                int _x = Diagonal[val, 0];
                int _y = Diagonal[val, 1];
                while (pos_start.X + _x >= 0 & pos_start.X + _x <= 7 & pos_start.Y + _y >= 0 & pos_start.Y + _y <= 7)
                {
                    if (type == ChessEnum.Pawn && (int)color == Diagonal[val, 1]) break; //Pawn can't move behind
                    if (Map_Chess[pos_start.X + _x, pos_start.Y + _y].Color == color) break;// if ally -> can't move
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
                    if (type == ChessEnum.King | type == ChessEnum.Pawn) break; //King & Pawn max 1 step
                    _x = _x + Diagonal[val, 0];
                    _y = _y + Diagonal[val, 1];
                }
            }
            return list;
        }

        private static List<ChessPosition> vertical(ChessPosition pos_start, ChessPiece[,] Map_Chess)
        {
            List<ChessPosition> list = new List<ChessPosition>();
            ChessColor color = Map_Chess[pos_start.X, pos_start.Y].Color;
            ChessEnum type = Map_Chess[pos_start.X, pos_start.Y].ChessType;
            if (color == ChessColor.Die) return list;
            if (type == ChessEnum.Knight | type == ChessEnum.Bishop) return list;//Knight & Bishop can't move vertical
            for (int index = 0; index < 2; index++)
            {
                int val = VerticalandHorizontal[index];
                while (pos_start.Y + val >= 0 & pos_start.Y + val <= 7)
                {
                    if (type == ChessEnum.Pawn && (int)color == VerticalandHorizontal[index]) break; //Pawn can't move behind
                    if (Map_Chess[pos_start.X, pos_start.Y + val].Color == color) break;// if ally -> can't move
                    else
                    {
                        if (Map_Chess[pos_start.X, pos_start.Y + val].Color != ChessColor.Die & type == ChessEnum.Pawn) break;// Pawn can't move
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
                    val = val + VerticalandHorizontal[index];
                }
            }
            return list;
        }

        private static List<ChessPosition> horizontal(ChessPosition pos_start, ChessPiece[,] Map_Chess)
        {
            List<ChessPosition> list = new List<ChessPosition>();
            ChessColor color = Map_Chess[pos_start.X, pos_start.Y].Color;
            if (color == ChessColor.Die) return list;
            ChessEnum type = Map_Chess[pos_start.X, pos_start.Y].ChessType;
            if (type == ChessEnum.Knight | type == ChessEnum.Bishop | type == ChessEnum.Pawn) return list;//Knight & Bishop & Pawn can't move horizontal
            for (int index = 0; index < 2; index++)
            {
                int val = VerticalandHorizontal[index];
                while (pos_start.X + val >= 0 & pos_start.X + val <= 7)
                {
                    if (Map_Chess[pos_start.X + val, pos_start.Y].Color == color) break;// if ally -> can't move
                    else
                    {
                        list.Add(new ChessPosition() { X = pos_start.X + val, Y = pos_start.Y });
                        if (Map_Chess[pos_start.X + val, pos_start.Y].Color != ChessColor.Die) break;// if enemy -> eat 
                    }
                    if (type == ChessEnum.King) break;  //king max 1 step
                    val = val + VerticalandHorizontal[index];
                }
            }
            return list;
        }

    }
}
