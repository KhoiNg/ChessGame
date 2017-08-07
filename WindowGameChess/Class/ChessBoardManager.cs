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
        int ChessEdge = 57;
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

        private ChessPiece[,] map_Chess = new ChessPiece[8, 8];
        public ChessPiece[,] Map_Chess
        {
            get { return map_Chess; }
            set { map_Chess = value; }
        }

        private RichTextBox playerTurn;
        public RichTextBox PlayerTurn
        {
            get { return playerTurn; }
            set { playerTurn = value; }
        }
        private RichTextBox movehistory;
        public RichTextBox Movehistory
        {
            get { return movehistory; }
            set { movehistory = value; }
        }
        private RichTextBox deathhistory;
        public RichTextBox Deathhistory
        {
            get { return deathhistory; }
            set { deathhistory = value; }
        }
        #endregion

        #region Initialize 
        public ChessBoardManager(PictureBox chessBoard, RichTextBox playerTurn, RichTextBox movehistory, RichTextBox deathhistory)
        {
            this.ChessBoard = chessBoard;
            this.PlayerTurn = playerTurn;
            this.Movehistory = movehistory;
            this.Deathhistory = deathhistory;
        }


        #endregion

        #region Method
        public void DrawChessBoard()
        {
            for (int i = 0; i < 8; i++)
            {
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
        }
        // ham nameof
        public void CreateMapChessPosition()
        {
            Map_Chess = new ChessPiece[8, 8];
            ChessColor color;
            for (int y = 0; y < 8; y++)
            {
                if (y == 0 || y == 1) color = ChessColor.Black;
                else color = ChessColor.White;
                for (int x = 0; x < 8; x++)
                {
                    Map_Chess[x, y] = new PieceClass.None();
                    if (y == 2 || y == 3 || y == 4 || y == 5)
                    {
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
                        Map_Chess[x, y].IndexControl = ChessBoard.Controls.Count - 1;
                    }
                    else if (y == 1 || y == 6)
                    {
                        Map_Chess[x, y] = new PieceClass.Pawn(color);
                        PictureBox pic = LoadPic(color, ChessEnum.Pawn, new Point(x * ChessEdge, y * ChessEdge));
                        ChessBoard.Controls.Add(pic);
                        listchess.Add(pic);
                        pic.BringToFront();
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
                Image = Image.FromFile(FolderImage + color.ToString() + "\\" + chess.ToString() + ".png"),
                BackColor = DefaultColor,
                BorderStyle = BorderStyle.FixedSingle,
                Location = point
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
            listcanmove = Map_Chess[pos_chess.X, pos_chess.Y].ListCanMove(pos_chess, Map_Chess);
            foreach (ChessPosition pos in listcanmove)
            {
                foreach (PictureBox pic in GetPictureBoxFromPosChess(pos))
                {
                    pic.BackColor = canmove_color;
                }
            }
            if (Map_Chess[pos_chess.X,pos_chess.Y].ChessType == ChessEnum.King) castlecondition();
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
                        if (Map_Chess[pos.X / 57, pos.Y / 57].ChessType != ChessEnum.King)
                            CheckPieceDie(Map_Chess[pos.X / 57,pos.Y / 57]);
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
                if (Map_Chess[pos_map.X, pos_map.Y].ChessType == ChessEnum.Pawn)
                {
                    if (pos_map_.Y == 0 || pos_map_.Y == 7)
                    {
                        PawnUnderPromotion nform = new PawnUnderPromotion(Map_Chess[pos_map.X, pos_map.Y].Color);
                        nform.ShowDialog();
                        switch (nform.chess)
                        {
                            case ChessEnum.Bishop: map = new PieceClass.Bishop(Map_Chess[pos_map.X, pos_map.Y].Color); break;
                            case ChessEnum.Rook: map = new PieceClass.Rook(Map_Chess[pos_map.X, pos_map.Y].Color); break;
                            case ChessEnum.Knight: map = new PieceClass.Knight(Map_Chess[pos_map.X, pos_map.Y].Color); break;
                            case ChessEnum.Queen: map = new PieceClass.Queen(Map_Chess[pos_map.X, pos_map.Y].Color); break;
                        }
                        //map = new PieceClass.nform.chess;
                        ((PictureBox)sender).Image = Image.FromFile(FolderImage + Map_Chess[pos_map.X, pos_map.Y].Color.ToString() + "\\" + nform.chess.ToString() + ".png");
                        ((PictureBox)sender).BringToFront();
                    }
                }
                //overwrite new pos

                checkmoveforcastle(pos_map, map);
                Map_Chess[pos_map_.X, pos_map_.Y] = map;

                //clear old pos maps

                Map_Chess[pos_map.X, pos_map.Y] = new PieceClass.None();

                reportmove(pos_map.X, pos_map.Y, pos_map_.X, pos_map_.Y, map);

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
                if (pic.BackColor == canmove_color) pic.BackColor = ((pic.Location.X / 57) + (pic.Location.Y / 57)) % 2 == 0 ? Color.Gray : Color.DarkGray;
            }
            if (lose != ChessColor.Die)
            {
                MessageBox.Show(lose.ToString() + " lose.");
                MakeNewRound();
                Application.Exit();
                return;
            }
            playerturn();
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
            pos = new Point(((temp_pic.Location.X / 57) + _x) * 57, ((temp_pic.Location.Y / 57) + _y) * 57);
            foreach (ChessPosition pc in listcanmove)
            {
                if (pc.X == pos.X / 57 & pc.Y == pos.Y / 57) return true;
            }
            return false;
        }
        #endregion

        public void MakeNewRound()
        {
            for (int i = 0; i < listchess.Count; i++)
            {
                ChessBoard.Controls.Remove(listchess[0]);
                listchess.RemoveAt(0);
                i--;
            }
            CreateMapChessPosition();
            round = ChessColor.White;
            playerturn();
            Movehistory.Text = "";
        }

        public void playerturn()
        {
            PlayerTurn.Text = round.Equals(ChessColor.White) ? "Player 1 - White side " : "Player 2 - Black side";
        }
        public void reportmove(int firstx, int firsty, int x, int y, ChessPiece piece)
        {
            Movehistory.Text += piece.Color.ToString() + " " + piece.ChessType.ToString() + " : " + xtotext(firstx) +(8 - firsty) + " ==> " + xtotext(x) + (8 - y)  + "\n";
        }
        public char xtotext(int x)
        {
            switch (x)
            {
                case 0: return 'a';
                case 1: return 'b';
                case 2: return 'c';
                case 3: return 'd';
                case 4: return 'e';
                case 5: return 'f';
                case 6: return 'g';
                case 7: return 'h';
            }
            return ' ';
        }

        public static int[,] chessdie = new int[5, 2];

        public void CheckPieceDie (ChessPiece piece)
        {
            int i = -1, j = -1;
            switch (piece.ChessType)
            {
                case ChessEnum.Pawn: i = 0; break;
                case ChessEnum.Rook: i = 1; break;
                case ChessEnum.Knight: i = 2; break;
                case ChessEnum.Bishop: i = 3; break;
                case ChessEnum.Queen: i = 4; break;
                default: break;
            }
            switch (piece.Color)
            {
                case ChessColor.White: j = 0; break;
                case ChessColor.Black: j = 1; break;
                default: break;
            }
            MessageBox.Show(piece.ChessType.ToString());
            chessdie[i, j]++;
            deathhistory.Text = "Player 1 Death Piece \n";
            deathhistory.Text += "Pawn : " + chessdie[0, 0] + ", Rook : " + chessdie[1, 0] + ", Knight : " + chessdie[2, 0] + ", Bishop : " + chessdie[3, 0] + ",Queen : " + chessdie[4, 0] + "\n";
            deathhistory.Text += "Player 2 Death Piece \n";
            deathhistory.Text += "Pawn : " + chessdie[0, 1] + ", Rook : " + chessdie[1, 1] + ", Knight : " + chessdie[2, 1] + ", Bishop : " + chessdie[3, 1] + ",Queen : " + chessdie[4, 1] + "\n";
        }

        public static bool[,] castle = new bool[2, 2] { { false, false }, { false, false } };
        public static bool[,] isrookmove = new bool[2, 2] { { false, false }, { false, false } };
        public static bool[] iskingmove = new bool[2] { false, false };
        public void checkmoveforcastle (ChessPosition position, ChessPiece piece)
        {
            if (piece.ChessType == ChessEnum.Rook)
                if (piece.Color == ChessColor.White)
                {
                    if (position.X == 0 && position.Y == 7) isrookmove[0, 0] = true;
                    if (position.X == 7 && position.Y == 7) isrookmove[0, 1] = true;
                }
                else if (piece.Color == ChessColor.Black)
                {
                    if (position.X == 0 && position.Y == 0) isrookmove[1, 0] = true;
                    if (position.X == 7 && position.Y == 0) isrookmove[1, 1] = true;
                }
            if (piece.ChessType == ChessEnum.King)
            {
                MessageBox.Show(iskingmove[0].ToString());
                if (piece.Color == ChessColor.White) iskingmove[0] = true;
                else if (piece.Color == ChessColor.Black) iskingmove[1] = true;
            }
        }
        public void castlecondition()
        {
            Form castleform = new Form() { Width = 200, Height = 200 };
            int avai = 0;
            if (round == ChessColor.White)
            {
                if (iskingmove[0]) { castle[0, 0] = false; castle[0, 1] = false; }
                if (Map_Chess[1, 7].ChessType == ChessEnum.Empty && Map_Chess[2, 7].ChessType == ChessEnum.Empty
                    && Map_Chess[3, 7].ChessType == ChessEnum.Empty && !isrookmove[0, 0] && !iskingmove[0])
                    castle[0, 0] = true;
                else castle[0, 0] = false;
                if (Map_Chess[5, 7].ChessType == ChessEnum.Empty && Map_Chess[6, 7].ChessType == ChessEnum.Empty
                   && !isrookmove[0, 1] && !iskingmove[0])
                    castle[0, 1] = true;
                else castle[0, 1] = false;
                if (castle[0, 0])
                {
                    avai++;
                    Button shortcastle = new Button() { Text = " You can Long Castle ", Width = 150, Location = new Point(30, 30) };
                    shortcastle.Click += dolongcastle;
                    shortcastle.MouseClick += (s, args) => castleform.Close();
                    castleform.Controls.Add(shortcastle);
                }
                if (castle[0,1])
                {
                    avai++;
                    Button longcastle = new Button() { Text = " You can Short Castle ", Width = 150, Location = new Point(30, 60) };
                    longcastle.Click += doshortcastle;
                    longcastle.MouseClick += (s, args) => castleform.Close();
                    castleform.Controls.Add(longcastle);
                }
                if (avai > 0)
                {
                    Button cancel = new Button() { Text = " Cancel ", Location = new Point(50, 90) };
                    cancel.Click += (s, args) => castleform.Close();
                    castleform.Controls.Add(cancel);
                    castleform.Show();
                }
            }
            else
            {
                if (iskingmove[1]) { castle[1, 0] = false; castle[1, 1] = false; }
                if (Map_Chess[1, 0].ChessType == ChessEnum.Empty && Map_Chess[2, 0].ChessType == ChessEnum.Empty
                    && Map_Chess[3, 0].ChessType == ChessEnum.Empty && !isrookmove[1, 0] && !iskingmove[1])
                    castle[1, 0] = true;
                else castle[1, 0] = false;
                if (Map_Chess[5, 0].ChessType == ChessEnum.Empty && Map_Chess[6, 0].ChessType == ChessEnum.Empty
                   && !isrookmove[1, 1])
                    castle[1, 1] = true;
                else castle[1, 1] = false;
                if (castle[1, 0])
                {
                    avai++;
                    Button shortcastle = new Button() { Text = " You can Long Castle ", Width = 150, Location = new Point(30, 30) };
                    shortcastle.Click += doshortcastle;
                    shortcastle.MouseClick += (s, args) => castleform.Close();
                    castleform.Controls.Add(shortcastle);
                }
                if (castle[1, 1])
                {
                    avai++;
                    Button longcastle = new Button() { Text = " You can Short Castle ", Width = 150, Location = new Point(30, 60) };
                    longcastle.Click += dolongcastle;
                    longcastle.MouseClick += (s, args) => castleform.Close();
                    castleform.Controls.Add(longcastle);
                }
                if (avai > 0)
                {
                    Button cancel = new Button() { Text = " Cancel ", Location = new Point(50, 90) };
                    cancel.Click += (s, args) => castleform.Close();
                    castleform.Controls.Add(cancel);
                    castleform.Show();
                }
            }
        }
        public void doshortcastle(object sender, EventArgs e)
        {
            if (round == ChessColor.White)
            {

                PictureBox Pic = LoadPic(ChessColor.White, ChessEnum.King, new Point(6 * ChessEdge, 7 * ChessEdge));
                Map_Chess[6, 7] = new PieceClass.King(ChessColor.White);
                ChessBoard.Controls.Add(Pic);
                listchess.Add(Pic);
                Pic.BringToFront();

                Point test = new Point(5 * ChessEdge, 7 * ChessEdge);
                foreach (PictureBox pic in listchess)
                {
                    pic.GetChildAtPoint(test); 
                }
                ChessBoard.Controls.Remove(listchess[28]);
                listchess.RemoveAt(28);
                Map_Chess[4, 7] = new PieceClass.None();
                

                Pic = LoadPic(ChessColor.White, ChessEnum.Rook, new Point(5 * ChessEdge, 7 * ChessEdge));
                Map_Chess[5, 7] = new PieceClass.Rook(ChessColor.White);
                ChessBoard.Controls.Add(Pic);
                listchess.Add(Pic);
                Pic.BringToFront();

                //ChessBoard.Controls.Remove(listchess[30]);
                //listchess.RemoveAt(30);
                //Map_Chess[7, 7] = new PieceClass.None();

                ////Map_Chess[7, 7] = new PieceClass.None();

                //Pic = LoadPic(ChessColor.White, ChessEnum.Rook, new Point(7 * ChessEdge, 7 * ChessEdge), false);
                //Pic.Visible = false;
                //Pic.Dispose();
                //ChessBoard.Controls.Remove(Pic);
                //listchess.Remove(Pic);

                foreach (PictureBox pic in listchess)
                {
                    if (pic.BackColor == canmove_color) pic.BackColor = DefaultColor;
                }
                foreach (PictureBox pic in listBackground)
                {
                    if (pic.BackColor == canmove_color) pic.BackColor = ((pic.Location.X / 57) + (pic.Location.Y / 57)) % 2 == 0 ? Color.Gray : Color.DarkGray;
                }

                round = round == ChessColor.Black ? ChessColor.White : ChessColor.Black;
                Movehistory.Text += "White : O-O \n";


            }
            else
            {
                Map_Chess[6, 0] = new PieceClass.King(ChessColor.White);
                Map_Chess[4, 0] = new PieceClass.None();
                Map_Chess[5, 0] = new PieceClass.Rook(ChessColor.White);
                Map_Chess[7, 0] = new PieceClass.None();
                Movehistory.Text += "Black : O-O \n";
            }

        }
        public void dolongcastle(object sender, EventArgs e)
        {

        }
    }
}
