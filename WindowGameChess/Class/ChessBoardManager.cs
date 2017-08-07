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
        public static int ChessEdge = 55;

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
        #endregion

        #region Initialize 
        public ChessBoardManager(PictureBox chessBoard)
        {
            this.ChessBoard = chessBoard;
        }

        ChessEnum[] array_ChessEnum = { ChessEnum.Castle, ChessEnum.Knight, ChessEnum.Bishop, ChessEnum.King, ChessEnum.Queen, ChessEnum.Bishop, ChessEnum.Knight, ChessEnum.Castle };

        #endregion

        #region Method
        public void DrawChessBoard()
        {
            PictureBox oldPic = new PictureBox() { Width = 0, Location = new Point(0, 0) };
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    PictureBox Pic = new PictureBox()
                    { 
                        Width = ChessEdge,
                        Height = ChessEdge,
                        Location = new Point(oldPic.Location.X + oldPic.Width, oldPic.Location.Y),
                        BackgroundImageLayout = ImageLayout.Stretch,
                    };
                    if ((i + j) % 2 == 1) Pic.BackColor = Color.Gray;
                    else Pic.BackColor = Color.DarkGray;
                    Pic.BorderStyle = BorderStyle.FixedSingle;
                    ChessBoard.Controls.Add(Pic);
                    oldPic = Pic;
                }
                oldPic.Location = new Point(0, oldPic.Location.Y + ChessEdge);
                oldPic.Width = 0;
                oldPic.Height = 0;
            }

        }

        private void CreateMapChessPos()
        {
            Map_Chess = new ChessPiece[8, 8];
            ChessColor color;
            for (int y = 0; y < 8; y++)
            {
                if (y == 0 | y == 1) color = ChessColor.Black;
                else color = ChessColor.White;
                for (int x = 0; x < 8; x++)
                {
                    Map_Chess[x, y] = new();
                    if (y == 2 || y == 3 || y == 4 || y == 5) continue;

                    if (y == 0 | y == 7)
                    {
                        PictureBox pic = LoadPic(color, array_ChessEnum[x], new Point(x * ChessEdge, y * ChessEdge));
                        ChessBoard.Controls.Add(pic);
                        listchess.Add(pic);
                        pic.BringToFront();
                        Map_Chess[x, y].ChessType = array_ChessEnum[x];
                        Map_Chess[x, y].Color = color;
                        Map_Chess[x, y].IndexControl = this.Controls.Count - 1;
                    }
                    else
                    {
                        PictureBox pic = LoadPic(color, ChessEnum.Pawn, new Point(X * ChessEdge, Y * ChessEdge));
                        this.Controls.Add(pic);
                        listchess.Add(pic);
                        pic.BringToFront();
                        Map_Chess[x, y].chessType = ChessEnum.Pawn;
                        Map_Chess[x, y].Color = color;
                        Map_Chess[x, y].IndexControl = this.Controls.Count - 1;
                    }
                }
            }
        }
        #endregion




    }
}
