using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowGameChess.Class.PieceClass
{
    public class Pawn : ChessPiece
    { 
    //{
    //    private bool canEnPassantLeft;
    //    public bool CanEsPassantLeft
    //    {
    //        get { return canEnPassantLeft; }
    //        set { canEnPassantLeft = value; }
    //    }
    //    private bool canEnPassantRight;
    //    public bool CanEsPassantRight
    //    {
    //        get { return canEnPassantRight; }
    //        set { canEnPassantRight = value; }
    //    }
    //private bool canDoubleJump;
    //public bool CanDoubleJump
    //{
    //    get { return canDoubleJump; }
    //    set { canDoubleJump = value; }
    //}
        public Pawn(ChessColor color)
        {
            base.ChessType = ChessEnum.Pawn;
            base.Color = color;
            //this.CanDoubleJump = true;
            //CalculateMoves();
        }

        public override List<ChessPosition> ListCanMove(ChessPosition pos_start, ChessPiece[,] Map_Chess)
        {
            List<ChessPosition> list = new List<ChessPosition>();
            list.AddRange(Diagonal(pos_start, Map_Chess));
            list.AddRange(Vertical(pos_start, Map_Chess));
            return list;
        }
        //public Pawn(ChessColor color,bool doubleJump = true, bool enPassantLeft = false, bool enPassantRight = false)
        //{
        //    base.ChessType = ChessEnum.Pawn;
        //    base.Color = color;
        //    this.canDoubleJump = doubleJump;
        //    this.canEnPassantLeft = enPassantLeft;
        //    this.canEnPassantRight = enPassantRight;
        //    //CalculateMoves();
        //}

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
                    if ( (int)color == maps_diagonal[val, 1]) break; //Pawn can't move behind
                    if (Map_Chess[pos_start.X + _x, pos_start.Y + _y].Color == color) break;// if ally -> can't move
                    else if (Map_Chess[pos_start.X + _x, pos_start.Y + _y].Color != ChessColor.Die)
                        List.Add(new ChessPosition() { X = pos_start.X + _x, Y = pos_start.Y + _y });
                    break;
                }
            }
            return List;
        }

        protected override List<ChessPosition> Vertical(ChessPosition pos_start, ChessPiece[,] Map_Chess)
        {
            List<ChessPosition> list = new List<ChessPosition>();
            ChessColor color = Map_Chess[pos_start.X, pos_start.Y].Color;
            ChessEnum type = Map_Chess[pos_start.X, pos_start.Y].ChessType;
            if (color == ChessColor.Die) return list;
            for (int index = 0; index < 2; index++)
            {
                int val = maps_vertical_n_horizontal[index];
                while (pos_start.Y + val >= 0 & pos_start.Y + val <= 7)
                {
                    if ( (int)color == maps_vertical_n_horizontal[index]) break; //Pawn can't move behind
                    if (Map_Chess[pos_start.X, pos_start.Y + val].Color == color) break;// if ally -> can't move
                    else
                    {
                        if (Map_Chess[pos_start.X,pos_start.Y + val].Color != ChessColor.Die ) break;// Pawn can't move
                        list.Add(new ChessPosition() { X = pos_start.X, Y = pos_start.Y + val });
                        if (Map_Chess[pos_start.X, pos_start.Y + val].Color != ChessColor.Die) break; // if enemy -> eat 
                    }
                    if (val == 2 | val == -2) break;//Pawn max 2 step
                    int line = color == ChessColor.Black ? 1 : 6;
                    if (pos_start.Y != line) break;
                    val = val + maps_vertical_n_horizontal[index];
                }
            }
            return list;
        }
        //public override List<ChessPosition> CalculateMoves()
        //{
        //    Direction forward;
        //    DiagnalDirection forwardLeft, forwardRight;
        //    if (base.Color == ChessColor.White)
        //    {
        //        forward = Direction.BACKWARD;
        //        forwardLeft = DiagnalDirection.BACKWARD_LEFT;
        //        forwardRight = DiagnalDirection.BACKWARD_RIGHT;
        //    }
        //    else
        //    {
        //        forward = Direction.FORWARD;
        //        forwardLeft = DiagnalDirection.FORWARD_LEFT;
        //        forwardRight = DiagnalDirection.FORWARD_RIGHT;
        //    }

        //    availableMoves = new List<ChessPosition>();
        //    if ( this.canDoubleJump)
        //        GetMovementArray(2, forward);
        //    else
        //        GetMovementArray(1, forward);

        //    GetDiagnalMovementArray(1, forwardLeft);
        //    GetDiagnalMovementArray(1, forwardRight);

        //    return availableMoves;
        //}
    }
}
