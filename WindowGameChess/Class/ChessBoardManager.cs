using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowGameChess.Class
{
    public class ChessBoardManager
    {
        #region Properties
        protected static string FolderImage = Application.StartupPath + "\\Resources\\";
        public static Color DefaultColor = Color.BurlyWood;
        public static Color canmove_color = Color.Fuchsia;
        public static int ChessEdge = 50;
        public ChessEnum[] array_ChessEnum = { ChessEnum.Rook, ChessEnum.Knight, ChessEnum.Bishop, ChessEnum.Queen, ChessEnum.King, ChessEnum.Bishop, ChessEnum.Knight, ChessEnum.Rook };
        public ChessColor round = ChessColor.White;
        public bool isMove = false;
        public int index_control = -1;

        public Point temp_p;
        PictureBox temp_pic = new PictureBox();
        List<ChessPosition> listcanmove = new List<ChessPosition>();
        List<PictureBox> listchess = new List<PictureBox>();
        List<PictureBox> listBackground = new List<PictureBox>();


        private PictureBox chessBoard;
        public PictureBox ChessBoard
        {
            get { return chessBoard; }
            set { chessBoard = value; }
        }

        private List<PictureBox> chessBoardBackGround;
        public List<PictureBox> ChessBoardBackGround
        {
            get { return chessBoardBackGround; }
            set { chessBoardBackGround = value; }
        }

        private ChessPiece[,] map_Chess = new ChessPiece[8, 8];
        public ChessPiece[,] Map_Chess
        {
            get { return map_Chess; }
            set { map_Chess = value; }
        }
        #endregion

        #region Initialize 
        public ChessBoardManager(PictureBox chessBoard)
        {
            this.ChessBoard = chessBoard;
        }


        #endregion

        #region Method
        public void DrawChessBoard()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    PictureBox Pic = new PictureBox()
                    {
                        Width = ChessEdge,
                        Height = ChessEdge,
                        Location = new Point(i * ChessEdge, j * ChessEdge),
                        BorderStyle = BorderStyle.FixedSingle
                    };
                    Pic.BackColor = (i + j) % 2 == 0 ? Color.Gray : Color.DarkGray;

                    Pic.SendToBack();
                    listBackground.Add(Pic);
                    ChessBoard.Controls.Add(Pic);
                }
        }
        // ham nameof
        public void CreateMapChessPosition()
        {
            Map_Chess = new ChessPiece[8, 8];
            ChessColor color;
            for (int y = 0; y < 8; y++)
            {
                if (y == 0 | y == 1) color = ChessColor.Black;
                else color = ChessColor.White;
                for (int x = 0; x < 8; x++)
                {
                    if (y == 2 || y == 3 || y == 4 || y == 5)
                    {
                        Map_Chess[x, y] = new PieceClass.None();
                        continue;
                    }
                    if (y == 0 || y == 7)
                    {
                        switch (x)
                        {
                            case 0:
                            case 7:
                                Map_Chess[x, y] = new PieceClass.Rook(color); break;

                            case 1:
                            case 6:
                                Map_Chess[x, y] = new PieceClass.Knight(color); break;
                            case 2:
                            case 5:
                                Map_Chess[x, y] = new PieceClass.Bishop(color); break;
                            case 3:
                                Map_Chess[x, y] = new PieceClass.Queen(color); break;
                            case 4:
                                Map_Chess[x, y] = new PieceClass.King(color); break;
                            default: break;
                        }
                        PictureBox pic = LoadPic(color, array_ChessEnum[x], new Point(x * ChessEdge, y * ChessEdge));
                        ChessBoard.Controls.Add(pic);
                        listchess.Add(pic);
                        pic.BringToFront();
                        Map_Chess[x, y].ChessType = array_ChessEnum[x];
                        Map_Chess[x, y].Color = color;
                        Map_Chess[x, y].IndexControl = ChessBoard.Controls.Count - 1;
                    }
                    else if ( y == 1 || y == 6 )
                    {
                        Map_Chess[x, y] = new PieceClass.Pawn(color); 
                        PictureBox pic = LoadPic(color, ChessEnum.Pawn, new Point(x * ChessEdge, y * ChessEdge));
                        ChessBoard.Controls.Add(pic);
                        listchess.Add(pic);
                        pic.BringToFront();
                        Map_Chess[x, y].ChessType = ChessEnum.Pawn;
                        Map_Chess[x, y].Color = color;
                        Map_Chess[x, y].IndexControl = ChessBoard.Controls.Count - 1;
                    }
                }
            }
        }

        private PictureBox LoadPic(ChessColor color, ChessEnum chess, Point point, bool CreateEvent = true)
        {
            PictureBox Pic = new PictureBox()
            {
                Width = ChessEdge,
                Height = ChessEdge,
                Location = point,
                BackColor = DefaultColor,
                Image = Image.FromFile(FolderImage + color.ToString() + "\\" + chess.ToString() + ".png"),
                BorderStyle = BorderStyle.FixedSingle
            };
            if (CreateEvent)
            { 
                Pic.MouseMove += Pic_MouseMove;
                Pic.MouseUp += Pic_MouseUp;
                Pic.MouseDown += Pic_MouseDown;
            }
            return Pic;
        }
        private void Pic_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            temp_p = e.Location;
            index_control = ChessBoard.Controls.IndexOf((PictureBox)sender);
            ChessPosition pos_chess = GetPosMapsChess(((PictureBox)sender).Location);
            if (round != Map_Chess[pos_chess.X, pos_chess.Y].Color) { isMove = false; return; }
            ((PictureBox)sender).Visible = false;
            temp_pic = LoadPic(Map_Chess[pos_chess.X, pos_chess.Y].Color, Map_Chess[pos_chess.X, pos_chess.Y].ChessType, ((PictureBox)sender).Location, false);
            ChessBoard.Controls.Add(temp_pic);
            temp_pic.BringToFront();
            listcanmove = new List<ChessPosition>();
            //listcanmove = Map_Chess[pos_chess.X, pos_chess.Y].CalculateMoves();
            listcanmove = Map_Chess[pos_chess.X, pos_chess.Y].ListCanMove(pos_chess, Map_Chess);
            foreach (ChessPosition pos in listcanmove)
            {
                foreach (PictureBox pic in GetPictureBoxFromPosChess(pos))
                {
                    pic.BackColor = canmove_color;
                }
            }
        }

        private ChessPosition GetPosMapsChess(Point p)
        {
            return new ChessPosition() { X = p.X / ChessEdge, Y = p.Y / ChessEdge };
        }
        private List<PictureBox> GetPictureBoxFromPosChess(ChessPosition pos)
        {
            List<PictureBox> list = new List<PictureBox>();
            foreach (PictureBox pic in listchess)
            {
                if (pic.Location == new Point(pos.X * ChessEdge, pos.Y * ChessEdge)) list.Add(pic);
            }
            foreach (PictureBox pic in listBackground)
            {
                if (pic.Location == new Point(pos.X * ChessEdge, pos.Y * ChessEdge)) list.Add(pic);
            }
            return list;
        }

        private void Pic_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMove)
            {
                temp_pic.Location = GetPixelLocationPic();
            }
        }
        private Point GetPixelLocationPic()
        {
            Point p = ChessBoard.PointToClient(Cursor.Position);
            p.X -= temp_p.X + 1;
            p.Y -= temp_p.Y + 1;
            return p;
        }

        private void Pic_MouseUp(object sender, MouseEventArgs e)
        {
            if (isMove) isMove = false;
            else return;
            int _x = 0, _y = 0;
            Point pos = new Point();
            ChessColor lose = ChessColor.Die;
            if (CheckDropTrueSquare(ref _x, ref _y) && CheckDropTruePosAllow(_x, _y, ref pos))
            {
                //if eat
                foreach (PictureBox pic in listchess)
                {
                    if (pic.Location == pos)
                    {
                        pic.Visible = false;
                        pic.Dispose();
                        ChessBoard.Controls.Remove(pic);
                        listchess.Remove(pic);
                        break;
                    }
                }
                ChessPosition pos_map = GetPosMapsChess(((PictureBox)sender).Location);
                ChessPiece map = Map_Chess[pos_map.X, pos_map.Y];
                ((PictureBox)sender).Location = pos;
                ChessPosition pos_map_ = GetPosMapsChess(((PictureBox)sender).Location);
                //check king
                if (Map_Chess[pos_map_.X, pos_map_.Y].ChessType == ChessEnum.King)
                {
                    lose = Map_Chess[pos_map_.X, pos_map_.Y].Color;
                }
                //check pawn
                //if (Map_Chess[pos_map.X, pos_map.Y].ChessType == ChessEnum.Pawn)
                //{
                //    if (pos_map_.Y == 0 | pos_map_.Y == 7)
                //    {
                //        PawnForm nform = new PawnForm(Map_Chess[pos_map.X, pos_map.Y].Color);
                //        nform.ShowDialog();
                //        map.chessType = nform.chess;
                //        ((PictureBox)sender).Image = Image.FromFile(FolderImg + Map_Chess[pos_map.X, pos_map.Y].Color.ToString() + "\\" + nform.chess.ToString() + ".png");
                //        ((PictureBox)sender).BringToFront();
                //    }
                //}
                //overwrite new pos
                Map_Chess[pos_map_.X, pos_map_.Y].ChessType = map.ChessType;
                Map_Chess[pos_map_.X, pos_map_.Y].Color = map.Color;
                //clear old pos maps
                Map_Chess[pos_map.X, pos_map.Y].ChessType = ChessEnum.Empty;
                Map_Chess[pos_map.X, pos_map.Y].Color = ChessColor.Die;
                //change round
                round = round == ChessColor.Black ? ChessColor.White : ChessColor.Black;
            }
            //clean
            ((PictureBox)sender).Visible = true;
            ChessBoard.Controls.Remove(temp_pic);
            temp_pic.Dispose();
            temp_pic = null;
            foreach (PictureBox pic in listchess)
            {
                if (pic.BackColor == canmove_color) pic.BackColor = DefaultColor;
            }
            foreach (PictureBox pic in listBackground)
            {
                if (pic.BackColor == canmove_color) pic.BackColor = ((pic.Location.X / 50) + (pic.Location.Y / 50)) % 2 == 0 ? Color.Gray : Color.DarkGray;
            }
            if (lose != ChessColor.Die)
            {
                MessageBox.Show(lose.ToString() + " lose.");
                //MakeNewRound();
                Application.Exit();
                return;
            }
            GC.Collect();
        }

        private bool CheckDropTrueSquare(ref int _x_, ref int _y_, int px = 15)
        {
            Point p = temp_pic.Location;
            int _x = p.X % ChessEdge;
            int _y = p.Y % ChessEdge;
            if (_x >= ChessEdge - px) _x_ += 1;
            if (_y >= ChessEdge - px) _y_ += 1;
            if ((_x <= px | _x >= ChessEdge - px) & (_y <= px | _y >= ChessEdge - px)) return true;
            return false;
        }

        private bool CheckDropTruePosAllow(int _x, int _y, ref Point pos)
        {
            pos = new Point(((temp_pic.Location.X / 50) + _x) * 50, ((temp_pic.Location.Y / 50) + _y) * 50);
            foreach (ChessPosition pc in listcanmove)
            {
                if (pc.X == pos.X / 50 & pc.Y == pos.Y / 50) return true;
            }
            return false;
        }
        #endregion




    }
}
 