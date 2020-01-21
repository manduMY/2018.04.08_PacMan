using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PacmanForm
{
    public partial class Pacman : Form
    {
        //않움직이게 하기 여부
        int OisSleep = 0;
        int PisSleep = 0;
        int BisSleep = 0;
        int RisSleep = 0;
        int startcnt = 0;
        int finishcnt = 0;
        //적 위치 생성
        static public int OGari = 10, OGarj = 12;
        static public int BGari = 19, BGarj = 12;
        static public int PGari = 19, PGarj = 19;
        static public int RGari = 10, RGarj = 19;
        private int OneBlockWidth = 15;            
        private int OneBlockHeight = 15;
        // 타일 하나의 width height
        int moveX = 15;
        int moveY = 15;
        Bitmap grayTile = new Bitmap(Properties.Resources.tile_gray_35x35);
        Bitmap blackTile = new Bitmap(Properties.Resources.tile_black_35x35);
        Bitmap smallitem = new Bitmap(Properties.Resources.tile_item);
        Bitmap bigitem_y = new Bitmap(Properties.Resources.tile_item_yellow);
        // Resource의 file을 이미지로 가져옴

        delegate void TimerEventFiredDelegate();
        // Thread Timer

        static public int EndingCnt = 30;
        public string RankingPath = "ranking.txt";
        static public string PlayerName = "O.om";

        static public int[,] MapTileArray = new int[,]{
                                      { 2, 2, 2, 2, 2,  2, 2, 2, 2, 2,  2, 2, 2, 2, 2,  2, 2, 2, 2, 2,  2, 2, 2, 2, 2,  2, 2, 2, 2, 2 },
                                      { 2, 1, 1, 1, 1,  1, 1, 1, 1, 1,  1, 1, 1, 1, 1,  1, 1, 1, 1, 1,  1, 1, 1, 1, 1,  1, 1, 1, 1, 2 },
                                      { 2, 1, 0, 0, 0,  0, 0, 0, 0, 0,  0, 0, 0, 0, 1,  1, 0, 0, 0, 0,  0, 0, 0, 0, 0,  0, 0, 0, 1, 2 },
                                      { 2, 1, 0, 1, 1,  1, 1, 0, 1, 1,  1, 1, 1, 0, 1,  1, 0, 1, 1, 1,  1, 1, 0, 1, 1,  1, 1, 0, 1, 2 },
                                      { 2, 1, 0, 1, 1,  1, 1, 0, 1, 1,  1, 1, 1, 0, 1,  1, 0, 1, 1, 1,  1, 1, 0, 1, 1,  1, 1, 0, 1, 2 },

                                      { 2, 1, 0, 1, 1,  1, 1, 0, 1, 1,  1, 1, 1, 0, 1,  1, 0, 1, 1, 1,  1, 1, 0, 1, 1,  1, 1, 0, 1, 2 },
                                      { 2, 1, 0, 0, 0,  0, 0, 3, 0, 0,  0, 0, 0, 0, 0,  0, 0, 0, 0, 0,  0, 0, 3, 0, 0,  0, 0, 0, 1, 2 },
                                      { 2, 1, 0, 1, 1,  1, 1, 0, 1, 1,  0, 1, 1, 1, 1,  1, 1, 1, 1, 0,  1, 1, 0, 1, 1,  1, 1, 0, 1, 2 },
                                      { 2, 1, 0, 1, 1,  1, 1, 0, 1, 1,  0, 1, 1, 1, 1,  1, 1, 1, 1, 0,  1, 1, 0, 1, 1,  1, 1, 0, 1, 2 },
                                      { 2, 1, 0, 0, 0,  0, 0, 0, 1, 1,  0, 0, 0, 0, 1,  1, 0, 0, 0, 0,  1, 1, 0, 0, 0,  0, 0, 0, 1, 2 },

                                      { 2, 1, 1, 1, 1,  1, 1, 0, 1, 1,  1, 1, 1, 0, 1,  1, 0, 1, 1, 1,  1, 1, 0, 1, 1,  1, 1, 1, 1, 2 },
                                      { 2, 1, 1, 1, 1,  1, 1, 0, 1, 1,  1, 1, 1, 0, 1,  1, 0, 1, 1, 1,  1, 1, 0, 1, 1,  1, 1, 1, 1, 2 },
                                      { 2, 1, 1, 1, 1,  1, 1, 0, 1, 1,  0, 0, 0, 0, 0,  0, 0, 0, 0, 0,  1, 1, 0, 1, 1,  1, 1, 1, 1, 2 },
                                      { 2, 1, 1, 1, 1,  1, 1, 0, 1, 1,  0, 1, 1, 1, 1,  1, 1, 1, 1, 0,  1, 1, 0, 1, 1,  1, 1, 1, 1, 2 },
                                      { 2, 1, 1, 1, 1,  1, 1, 0, 1, 1,  0, 1, 1, 1, 1,  1, 1, 1, 1, 0,  1, 1, 0, 1, 1,  1, 1, 1, 1, 2 },
                                      { 2, 1, 1, 1, 1,  1, 1, 0, 0, 0,  0, 2, 2, 2, 2,  2, 2, 2, 2, 0,  0, 0, 0, 1, 1,  1, 1, 1, 1, 2 },

                                      { 2, 1, 1, 1, 1,  1, 1, 0, 1, 1,  0, 1, 1, 2, 2,  2, 2, 1, 1, 0,  1, 1, 0, 1, 1,  1, 1, 1, 1, 2 },
                                      { 2, 1, 1, 1, 1,  1, 1, 0, 1, 1,  0, 1, 1, 1, 1,  1, 1, 1, 1, 0,  1, 1, 0, 1, 1,  1, 1, 1, 1, 2 },
                                      { 2, 1, 1, 1, 1,  1, 1, 0, 1, 1,  0, 1, 1, 1, 1,  1, 1, 1, 1, 0,  1, 1, 0, 1, 1,  1, 1, 1, 1, 2 },
                                      { 2, 1, 1, 1, 1,  1, 1, 0, 1, 1,  0, 0, 0, 0, 0,  0, 0, 0, 0, 0,  1, 1, 0, 1, 1,  1, 1, 1, 1, 2 },
                                      { 2, 1, 1, 1, 1,  1, 1, 0, 1, 1,  1, 1, 1, 0, 1,  1, 0, 1, 1, 1,  1, 1, 0, 1, 1,  1, 1, 1, 1, 2 },

                                      { 2, 1, 1, 1, 1,  1, 1, 0, 1, 1,  1, 1, 1, 0, 1,  1, 0, 1, 1, 1,  1, 1, 0, 1, 1,  1, 1, 1, 1, 2 },
                                      { 2, 1, 0, 0, 0,  0, 0, 0, 0, 0,  0, 0, 0, 0, 1,  1, 0, 0, 0, 0,  0, 0, 0, 0, 0,  0, 0, 0, 1, 2 },
                                      { 2, 1, 0, 1, 1,  1, 1, 0, 1, 1,  1, 1, 1, 0, 1,  1, 0, 1, 1, 1,  1, 0, 1, 1, 1,  1, 1, 0, 1, 2 },
                                      { 2, 1, 0, 1, 1,  1, 1, 0, 1, 1,  1, 1, 1, 0, 1,  1, 0, 1, 1, 1,  1, 0, 1, 1, 1,  1, 1, 0, 1, 2 },
                                      { 2, 1, 0, 0, 0,  1, 1, 0, 0, 0,  0, 0, 0, 0, 0,  0, 0, 0, 0, 0,  0, 0, 0, 1, 1,  0, 0, 0, 1, 2 },

                                      { 2, 1, 1, 1, 0,  1, 1, 0, 1, 1,  0, 1, 1, 1, 1,  1, 1, 1, 1, 0,  1, 1, 0, 1, 1,  0, 1, 1, 1, 2 },
                                      { 2, 1, 1, 1, 0,  1, 1, 0, 1, 1,  0, 1, 1, 1, 1,  1, 1, 1, 1, 0,  1, 1, 0, 1, 1,  0, 1, 1, 1, 2 },
                                      { 2, 1, 0, 0, 3,  0, 0, 0, 1, 1,  0, 0, 0, 0, 1,  1, 0, 0, 0, 0,  1, 1, 0, 0, 0,  3, 0, 0, 1, 2 },
                                      { 2, 1, 0, 1, 1,  1, 1, 1, 1, 1,  1, 1, 1, 0, 1,  1, 0, 1, 1, 1,  1, 1, 1, 1, 1,  1, 1, 0, 1, 2 },
                                      { 2, 1, 0, 1, 1,  1, 1, 1, 1, 1,  1, 1, 1, 0, 1,  1, 0, 1, 1, 1,  1, 1, 1, 1, 1,  1, 1, 0, 1, 2 },

                                      { 2, 1, 0, 0, 0,  0, 0, 0, 0, 0,  0, 0, 0, 0, 0,  0, 0, 0, 0, 0,  0, 0, 0, 0, 0,  0, 0, 0, 1, 2 },
                                      { 2, 1, 1, 1, 1,  1, 1, 1, 1, 1,  1, 1, 1, 1, 1,  1, 1, 1, 1, 1,  1, 1, 1, 1, 1,  1, 1, 1, 1, 2 },
                                      { 2, 2, 2, 2, 2,  2, 2, 2, 2, 2,  2, 2, 2, 2, 2,  2, 2, 2, 2, 2,  2, 2, 2, 2, 2,  2, 2, 2, 2, 2 }
            };
        static public int[,] MapTileArray2 = new int[,]{
                                      { 2, 2, 2, 2, 2,  2, 2, 2, 2, 2,  2, 2, 2, 2, 2,  2, 2, 2, 2, 2,  2, 2, 2, 2, 2,  2, 2, 2, 2, 2 },
                                      { 2, 1, 1, 1, 1,  1, 1, 1, 1, 1,  1, 1, 1, 1, 1,  1, 1, 1, 1, 1,  1, 1, 1, 1, 1,  1, 1, 1, 1, 2 },
                                      { 2, 1, 0, 0, 0,  0, 0, 0, 0, 0,  0, 0, 0, 0, 1,  1, 0, 0, 0, 0,  0, 0, 0, 0, 0,  0, 0, 0, 1, 2 },
                                      { 2, 1, 0, 1, 1,  1, 1, 0, 1, 1,  1, 1, 1, 0, 1,  1, 0, 1, 1, 1,  1, 1, 0, 1, 1,  1, 1, 0, 1, 2 },
                                      { 2, 1, 0, 1, 1,  1, 1, 0, 1, 1,  1, 1, 1, 0, 1,  1, 0, 1, 1, 1,  1, 1, 0, 1, 1,  1, 1, 0, 1, 2 },

                                      { 2, 1, 0, 1, 1,  1, 1, 0, 1, 1,  1, 1, 1, 0, 1,  1, 0, 1, 1, 1,  1, 1, 0, 1, 1,  1, 1, 0, 1, 2 },
                                      { 2, 1, 0, 0, 0,  0, 0, 3, 0, 0,  0, 0, 0, 0, 0,  0, 0, 0, 0, 0,  0, 0, 3, 0, 0,  0, 0, 0, 1, 2 },
                                      { 2, 1, 0, 1, 1,  1, 1, 0, 1, 1,  0, 1, 1, 1, 1,  1, 1, 1, 1, 0,  1, 1, 0, 1, 1,  1, 1, 0, 1, 2 },
                                      { 2, 1, 0, 1, 1,  1, 1, 0, 1, 1,  0, 1, 1, 1, 1,  1, 1, 1, 1, 0,  1, 1, 0, 1, 1,  1, 1, 0, 1, 2 },
                                      { 2, 1, 0, 0, 0,  0, 0, 0, 1, 1,  0, 0, 0, 0, 1,  1, 0, 0, 0, 0,  1, 1, 0, 0, 0,  0, 0, 0, 1, 2 },

                                      { 2, 1, 1, 1, 1,  1, 1, 0, 1, 1,  1, 1, 1, 0, 1,  1, 0, 1, 1, 1,  1, 1, 0, 1, 1,  1, 1, 1, 1, 2 },
                                      { 2, 1, 1, 1, 1,  1, 1, 0, 1, 1,  1, 1, 1, 0, 1,  1, 0, 1, 1, 1,  1, 1, 0, 1, 1,  1, 1, 1, 1, 2 },
                                      { 2, 1, 1, 1, 1,  1, 1, 0, 1, 1,  0, 0, 0, 0, 0,  0, 0, 0, 0, 0,  1, 1, 0, 1, 1,  1, 1, 1, 1, 2 },
                                      { 2, 1, 1, 1, 1,  1, 1, 0, 1, 1,  0, 1, 1, 1, 1,  1, 1, 1, 1, 0,  1, 1, 0, 1, 1,  1, 1, 1, 1, 2 },
                                      { 2, 1, 1, 1, 1,  1, 1, 0, 1, 1,  0, 1, 1, 1, 1,  1, 1, 1, 1, 0,  1, 1, 0, 1, 1,  1, 1, 1, 1, 2 },
                                      { 2, 1, 1, 1, 1,  1, 1, 0, 0, 0,  0, 2, 2, 2, 2,  2, 2, 2, 2, 0,  0, 0, 0, 1, 1,  1, 1, 1, 1, 2 },

                                      { 2, 1, 1, 1, 1,  1, 1, 0, 1, 1,  0, 1, 1, 2, 2,  2, 2, 1, 1, 0,  1, 1, 0, 1, 1,  1, 1, 1, 1, 2 },
                                      { 2, 1, 1, 1, 1,  1, 1, 0, 1, 1,  0, 1, 1, 1, 1,  1, 1, 1, 1, 0,  1, 1, 0, 1, 1,  1, 1, 1, 1, 2 },
                                      { 2, 1, 1, 1, 1,  1, 1, 0, 1, 1,  0, 1, 1, 1, 1,  1, 1, 1, 1, 0,  1, 1, 0, 1, 1,  1, 1, 1, 1, 2 },
                                      { 2, 1, 1, 1, 1,  1, 1, 0, 1, 1,  0, 0, 0, 0, 0,  0, 0, 0, 0, 0,  1, 1, 0, 1, 1,  1, 1, 1, 1, 2 },
                                      { 2, 1, 1, 1, 1,  1, 1, 0, 1, 1,  1, 1, 1, 0, 1,  1, 0, 1, 1, 1,  1, 1, 0, 1, 1,  1, 1, 1, 1, 2 },

                                      { 2, 1, 1, 1, 1,  1, 1, 0, 1, 1,  1, 1, 1, 0, 1,  1, 0, 1, 1, 1,  1, 1, 0, 1, 1,  1, 1, 1, 1, 2 },
                                      { 2, 1, 0, 0, 0,  0, 0, 0, 0, 0,  0, 0, 0, 0, 1,  1, 0, 0, 0, 0,  0, 0, 0, 0, 0,  0, 0, 0, 1, 2 },
                                      { 2, 1, 0, 1, 1,  1, 1, 0, 1, 1,  1, 1, 1, 0, 1,  1, 0, 1, 1, 1,  1, 0, 1, 1, 1,  1, 1, 0, 1, 2 },
                                      { 2, 1, 0, 1, 1,  1, 1, 0, 1, 1,  1, 1, 1, 0, 1,  1, 0, 1, 1, 1,  1, 0, 1, 1, 1,  1, 1, 0, 1, 2 },
                                      { 2, 1, 0, 0, 0,  1, 1, 0, 0, 0,  0, 0, 0, 0, 0,  0, 0, 0, 0, 0,  0, 0, 0, 1, 1,  0, 0, 0, 1, 2 },

                                      { 2, 1, 1, 1, 0,  1, 1, 0, 1, 1,  0, 1, 1, 1, 1,  1, 1, 1, 1, 0,  1, 1, 0, 1, 1,  0, 1, 1, 1, 2 },
                                      { 2, 1, 1, 1, 0,  1, 1, 0, 1, 1,  0, 1, 1, 1, 1,  1, 1, 1, 1, 0,  1, 1, 0, 1, 1,  0, 1, 1, 1, 2 },
                                      { 2, 1, 0, 0, 3,  0, 0, 0, 1, 1,  0, 0, 0, 0, 1,  1, 0, 0, 0, 0,  1, 1, 0, 0, 0,  3, 0, 0, 1, 2 },
                                      { 2, 1, 0, 1, 1,  1, 1, 1, 1, 1,  1, 1, 1, 0, 1,  1, 0, 1, 1, 1,  1, 1, 1, 1, 1,  1, 1, 0, 1, 2 },
                                      { 2, 1, 0, 1, 1,  1, 1, 1, 1, 1,  1, 1, 1, 0, 1,  1, 0, 1, 1, 1,  1, 1, 1, 1, 1,  1, 1, 0, 1, 2 },

                                      { 2, 1, 0, 0, 0,  0, 0, 0, 0, 0,  0, 0, 0, 0, 0,  0, 0, 0, 0, 0,  0, 0, 0, 0, 0,  0, 0, 0, 1, 2 },
                                      { 2, 1, 1, 1, 1,  1, 1, 1, 1, 1,  1, 1, 1, 1, 1,  1, 1, 1, 1, 1,  1, 1, 1, 1, 1,  1, 1, 1, 1, 2 },
                                      { 2, 2, 2, 2, 2,  2, 2, 2, 2, 2,  2, 2, 2, 2, 2,  2, 2, 2, 2, 2,  2, 2, 2, 2, 2,  2, 2, 2, 2, 2 }
            };
        // Map tile Array
        private int MapTileWidthMax = 30, MapTileHeightMax = 33;

        public Pacman()
        {
            InitializeComponent();
            // 생성자
            tileBoard.SendToBack();
          
            tileBoard.Dock = DockStyle.Fill;
            basicBoard.Dock = DockStyle.Fill;
            
            PMpanel.Location = new Point(15*2, 15*2);
            OGpanel.Location = new Point(15*10, 15*12);
            RGpanel.Location = new Point(15*10, 15*19);
            PGpanel.Location = new Point(15*19, 15*19);
            BGpanel.Location = new Point(15*19, 15*12);

        }

        protected override void OnPaint(PaintEventArgs e)
            //Drawing하기 위해 호출
        {
            DrawTile();
            
            
        }
        
        private void DrawTile()
        {
            
            Graphics v = tileBoard.CreateGraphics();

            
            for (var i = 0; i < MapTileHeightMax+1; i++)
            {
                for (var j = 0; j < MapTileWidthMax; j++)
                {
                    // 가로 = j, 세로 = i
                    if (MapTileArray[i, j] == 0)
                    {
                        v.DrawImage(smallitem, new Rectangle(j * OneBlockWidth, i * OneBlockHeight, 15, 15));
                        // DrawImage(그릴 이미지, 좌표 및 크기(x좌표, y좌표, width, height))
                    }
                    else if (MapTileArray[i, j] == 1)
                    {
                        v.DrawImage(grayTile, new Rectangle(j * OneBlockWidth, i * OneBlockHeight, 15, 15));
                    }
                    else if (MapTileArray[i, j] == 2)
                    {
                        v.DrawImage(blackTile, new Rectangle(j * OneBlockWidth, i * OneBlockHeight, 15, 15));
                    }
                    else if (MapTileArray[i, j] == 3)
                    {
                        v.DrawImage(bigitem_y, new Rectangle(j * OneBlockWidth, i * OneBlockHeight, 15, 15));
                    }
                }
            }
          
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

            // Opening Timer        
       

        private void mainLogo_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            basicBoard.SendToBack();//뒤로
            tileBoard.BringToFront();//앞으로
            

        }

        public void reset()
        {
            
           
            if (EndingCnt <= 0||Life == 0)
            {
                cnt = 0;
                Life = 3;
                PMpanel.Visible = false;
                PMpanel.SendToBack();
                OGpanel.Visible = false;
                OGpanel.SendToBack();
                PGpanel.Visible = false;
                PGpanel.SendToBack();
                RGpanel.Visible = false;
                RGpanel.SendToBack();
                BGpanel.Visible = false;
                BGpanel.SendToBack();
                OtimerR.Enabled = false;
                OtimerD.Enabled = false;
                OtimerL.Enabled = false;
                OtimerU.Enabled = false;
                RtimerD.Enabled = false;
                RtimerL.Enabled = false;
                RtimerU.Enabled = false;
                RtimerR.Enabled = false;
                BtimerD.Enabled = false;
                BtimerR.Enabled = false;
                BtimerU.Enabled = false;
                BtimerL.Enabled = false;
                PtimerL.Enabled = false;
                PtimerD.Enabled = false;
                PtimerU.Enabled = false;
                PtimerR.Enabled = false;
                MapTileArray = MapTileArray2;
                DrawTile();
                OGari = 10;
                OGarj = 12;
                BGari = 19;
                BGarj = 12;
                PGari = 19;
                PGarj = 19;
                RGari = 10;
                RGarj = 19;
                PPMari = 2;
                PPMarj = 2;
                BoNus = false;
                PMpanel.Location = new Point(15 * PPMari, 15 * PPMarj);
                OGpanel.Location = new Point(15 * OGari, 15 * OGarj);
                RGpanel.Location = new Point(15 * RGari, 15 * RGarj);
                PGpanel.Location = new Point(15 * PGari, 15 * PGarj);
                BGpanel.Location = new Point(15 * BGari, 15 * BGarj);
               
            }

        }


        static public int PPMari = 2, PPMarj = 2, cnt = 0;
        public int Life = 3;
        static public bool BoNus = false;
        private void Pacman_KeyDown(object sender, KeyEventArgs e)
        {
         
            if (e.KeyCode == Keys.Up)
            {

                PM.Image = Properties.Resources._1up;

                if ((MapTileArray[PPMarj - 1, PPMari]) == 0 || (MapTileArray[PPMarj - 1, PPMari]) == 2 || (MapTileArray[PPMarj - 1, PPMari]) == 3)
                {

                    int y = PMpanel.Location.Y - moveY;

                    if (MapTileArray[PPMarj, PPMari] == 0)
                    {
                        MapTileArray[PPMarj, PPMari] = 2;
                        cnt++;
                        currentScore.Text = cnt.ToString();
                    }
                    if (MapTileArray[PPMarj, PPMari] == 3)
                    {
                        MapTileArray[PPMarj, PPMari] = 2;
                        BoNus = true;
                    }
                    PMpanel.Top = y;

                    PPMarj--;

                }

            }
            else if (e.KeyCode == Keys.Left)
            {
                PM.Image = Properties.Resources._1sx;

                if ((MapTileArray[PPMarj, PPMari - 1]) == 0 || (MapTileArray[PPMarj, PPMari - 1]) == 2 || (MapTileArray[PPMarj, PPMari - 1]) == 3)
                {
                    PM.Image = Properties.Resources._1sx;
                    int x = PMpanel.Location.X - moveX;
                    if (MapTileArray[PPMarj, PPMari] == 0)
                    {
                        MapTileArray[PPMarj, PPMari] = 2;
                        cnt++;
                        currentScore.Text = cnt.ToString();
                    }
                    if (MapTileArray[PPMarj, PPMari] == 3)
                    {
                        MapTileArray[PPMarj, PPMari] = 2;
                        BoNus = true;
                    }
                    
                    PMpanel.Left = x;

                    PPMari--;
                }

            }
            else if ((e.KeyCode == Keys.Right))
            {
                PM.Image = Properties.Resources._1dx;

                if ((MapTileArray[PPMarj, PPMari + 1]) == 0 || (MapTileArray[PPMarj, PPMari + 1]) == 2 || (MapTileArray[PPMarj, PPMari + 1]) == 3)
                {

                    int x = PMpanel.Location.X + moveX;
                    if (MapTileArray[PPMarj, PPMari] == 0)
                    {
                        MapTileArray[PPMarj, PPMari] = 2;
                        cnt++;
                        currentScore.Text = cnt.ToString();
                    }
                    if (MapTileArray[PPMarj, PPMari] == 3)
                    {
                        MapTileArray[PPMarj, PPMari] = 2;
                        BoNus = true;
                    }
                    PMpanel.Left = x;

                    PPMari++;
                }
            }
            else if ((e.KeyCode == Keys.Down))
            {
                PM.Image = Properties.Resources._1down;
                if ((MapTileArray[PPMarj + 1, PPMari]) == 0 || (MapTileArray[PPMarj + 1, PPMari]) == 2 || (MapTileArray[PPMarj + 1, PPMari]) == 3)
                {
                    int y = PMpanel.Location.Y + moveY;
                    if (MapTileArray[PPMarj, PPMari] == 0)
                    {
                        MapTileArray[PPMarj, PPMari] = 2;
                        cnt++;
                        currentScore.Text = cnt.ToString();
                    }
                    if (MapTileArray[PPMarj, PPMari] == 3)
                    {
                        MapTileArray[PPMarj, PPMari] = 2;
                        BoNus = true;
                    }
                    PMpanel.Top = y;
                    PPMarj++;
                }
            }
            if ((PMpanel.Location == OGpanel.Location || PMpanel.Location == BGpanel.Location || PMpanel.Location == PGpanel.Location || PMpanel.Location == RGpanel.Location) && BoNus == false)
            {
                PMpanel.Location = new Point(30, 30);
                PPMarj = 2;
                PPMari = 2;
                Life--;
                currentLife.Text = Life.ToString();

            }
            else if (PMpanel.Location == OGpanel.Location && BoNus == true)
            {
                OGpanel.Location = new Point(15*13, 15*16);
                OGarj = 16;
                OGari = 13;
                OtimerR.Enabled = false;
                OtimerU.Enabled = true;
                
            }
            else if (PMpanel.Location == BGpanel.Location && BoNus == true)
            {
                BGpanel.Location = new Point(15*14, 15*16);
                BGarj = 16;
                BGari = 14;
                BtimerL.Enabled = false;
                BtimerU.Enabled = true;
            }
            else if (PMpanel.Location == PGpanel.Location && BoNus == true)
            {
                PGpanel.Location = new Point(15*15, 15*16);
                PGarj = 16;
                PGari = 15;
                PtimerL.Enabled = false;
                PtimerU.Enabled = true;


            }
               else if(PMpanel.Location == RGpanel.Location && BoNus == true)
            { 
                RGpanel.Location= new Point(15*16, 15*16);
                RGarj = 16;
                RGari = 16;
                RtimerR.Enabled = false;
                RtimerU.Enabled = true;

            }
                if (Life == 0)
            {
                MapTileArray = MapTileArray2;
                EndingConsole();
            }
            //목숨
        }





        /*유령 부분*/
        private void OtimerR_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            int random = r.Next(0, 3);
            bool moveDiscern = true;
            if (BoNus == false)
            {
                OG.Image = Properties.Resources.gdx;
                OisSleep = 0;
                startcnt = 0;
                finishcnt = 0;
            }
            else if (BoNus == true)
            {
                if (OisSleep == 0)
                {
                    Sleep.Enabled = true;
                    count.Enabled = true;
                    OisSleep++;
                }
            }
            if (Sleep.Enabled == false)
            {
                if (OGarj == RGarj && OGari + 1 == RGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) OG.Image = Properties.Resources.gdown;
                        else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                        OtimerD.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) OG.Image = Properties.Resources.gup;
                        else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                        OtimerU.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) OG.Image = Properties.Resources.gsx;
                        else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                        OtimerL.Enabled = true;
                    }
                }
                else if (OGarj == BGarj && OGari + 1 == BGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) OG.Image = Properties.Resources.gdown;
                        else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                        OtimerD.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) OG.Image = Properties.Resources.gup;
                        else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                        OtimerU.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) OG.Image = Properties.Resources.gsx;
                        else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                        OtimerL.Enabled = true;
                    }
                }
                else if (OGarj == PGarj && OGari + 1 == PGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) OG.Image = Properties.Resources.gdown;
                        else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                        OtimerD.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) OG.Image = Properties.Resources.gup;
                        else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                        OtimerU.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) OG.Image = Properties.Resources.gsx;
                        else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                        OtimerL.Enabled = true;
                    }
                }

                if (moveDiscern == true)
                {
                    if ((MapTileArray[OGarj, OGari + 1]) == 0 || (MapTileArray[OGarj, OGari + 1]) == 2 || (MapTileArray[OGarj, OGari + 1]) == 3)
                    {
                        OtimerD.Enabled = false;
                        OtimerU.Enabled = false;
                        OtimerL.Enabled = false;
                        int x = OGpanel.Location.X + moveX;
                        OGpanel.Left = x;
                        OGari++;
                    }
                    else
                    {
                        if (random == 0)
                        {
                            if (BoNus == false) OG.Image = Properties.Resources.gdown;
                            else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                            OtimerD.Enabled = true;
                        }
                        if (random == 1)
                        {
                            if (BoNus == false) OG.Image = Properties.Resources.gup;
                            else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                            OtimerU.Enabled = true;
                        }
                        if (random == 2)
                        {
                            if (BoNus == false) OG.Image = Properties.Resources.gsx;
                            else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                            OtimerL.Enabled = true;
                        }
                    }
                }
            }
        }

        private void OtimerL_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            int random = r.Next(0, 2);
            bool moveDiscern = true;
            if (BoNus == false)
            {
                OG.Image = Properties.Resources.gsx;
                OisSleep = 0;
                startcnt = 0;
                finishcnt = 0;
            }
            else if (BoNus == true)
            {
                if (OisSleep == 0)
                {
                    OG.Image = Properties.Resources.tempo;
                    Sleep.Enabled = true;
                    count.Enabled = true;
                    OisSleep++;
                }
            }
            if (Sleep.Enabled == false)
            {
                if (OGarj == RGarj && OGari - 1 == RGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) OG.Image = Properties.Resources.gdown;
                        else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                        OtimerD.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) OG.Image = Properties.Resources.gup;
                        else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                        OtimerU.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) OG.Image = Properties.Resources.gdx;
                        else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                        OtimerR.Enabled = true;
                    }
                }
                else if (OGarj == BGarj && OGari - 1 == BGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) OG.Image = Properties.Resources.gdown;
                        else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                        OtimerD.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) OG.Image = Properties.Resources.gup;
                        else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                        OtimerU.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) OG.Image = Properties.Resources.gdx;
                        else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                        OtimerR.Enabled = true;
                    }
                }
                else if (OGarj == PGarj && OGari - 1 == PGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) OG.Image = Properties.Resources.gdown;
                        else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                        OtimerD.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) OG.Image = Properties.Resources.gup;
                        else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                        OtimerU.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) OG.Image = Properties.Resources.gdx;
                        else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                        OtimerR.Enabled = true;
                    }
                }

                if (moveDiscern == true)
                {
                    if ((MapTileArray[OGarj, OGari - 1]) == 0 || (MapTileArray[OGarj, OGari - 1]) == 2 || (MapTileArray[OGarj, OGari - 1]) == 3)
                    {
                        OtimerD.Enabled = false;
                        OtimerU.Enabled = false;
                        OtimerR.Enabled = false;
                        int x = OGpanel.Location.X - moveX;
                        OGpanel.Left = x;
                        OGari--;
                    }
                    else
                    {
                        if (random == 0)
                        {
                            if (BoNus == false) OG.Image = Properties.Resources.gdown;
                            else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                            OtimerD.Enabled = true;
                        }
                        if (random == 1)
                        {
                            if (BoNus == false) OG.Image = Properties.Resources.gup;
                            else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                            OtimerU.Enabled = true;
                        }
                        if (random == 2)
                        {
                            if (BoNus == false) OG.Image = Properties.Resources.gdx;
                            else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                            OtimerR.Enabled = true;
                        }
                    }
                }
            }
        }

        private void OtimerD_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            int random = r.Next(0, 2);
            bool moveDiscern = true;
            if (BoNus == false)
            {
                OG.Image = Properties.Resources.gdown;
                OisSleep = 0;
                startcnt = 0;
                finishcnt = 0;
            }
            else if (BoNus == true)
            {
                if (OisSleep == 0)
                {
                    Sleep.Enabled = true;
                    count.Enabled = true;
                    OisSleep++;
                }
            }
            if (Sleep.Enabled == false)
            {
                if (OGarj + 1 == RGarj && OGari == RGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) OG.Image = Properties.Resources.gsx;
                        else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                        OtimerL.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) OG.Image = Properties.Resources.gup;
                        else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                        OtimerU.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) OG.Image = Properties.Resources.gdx;
                        else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                        OtimerR.Enabled = true;
                    }
                }
                else if (OGarj + 1 == BGarj && OGari == BGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) OG.Image = Properties.Resources.gsx;
                        else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                        OtimerL.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) OG.Image = Properties.Resources.gup;
                        else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                        OtimerU.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) OG.Image = Properties.Resources.gdx;
                        else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                        OtimerR.Enabled = true;
                    }
                }
                else if (OGarj + 1 == PGarj && OGari - 1 == PGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) OG.Image = Properties.Resources.gsx;
                        else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                        OtimerL.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) OG.Image = Properties.Resources.gup;
                        else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                        OtimerU.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) OG.Image = Properties.Resources.gdx;
                        else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                        OtimerR.Enabled = true;
                    }
                }

                if (moveDiscern == true)
                {
                    if ((MapTileArray[OGarj + 1, OGari]) == 0 || (MapTileArray[OGarj + 1, OGari]) == 2 || (MapTileArray[OGarj + 1, OGari]) == 3)
                    {
                        OtimerR.Enabled = false;
                        OtimerU.Enabled = false;
                        OtimerL.Enabled = false;
                        int y = OGpanel.Location.Y + moveY;
                        OGpanel.Top = y;
                        OGarj++;
                    }
                    else
                    {
                        if (random == 0)
                        {
                            if (BoNus == false) OG.Image = Properties.Resources.gdx;
                            else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                            OtimerR.Enabled = true;
                        }
                        if (random == 1)
                        {
                            if (BoNus == false) OG.Image = Properties.Resources.gup;
                            else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                            OtimerU.Enabled = true;
                        }
                        if (random == 2)
                        {
                            if (BoNus == false) OG.Image = Properties.Resources.gsx;
                            else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                            OtimerL.Enabled = true;
                        }
                    }
                }
            }
        }

        private void OtimerU_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            int random = r.Next(0, 2);
            bool moveDiscern = true;
            if (BoNus == false)
            {
                OG.Image = Properties.Resources.gup;
                OisSleep = 0;
                startcnt = 0;
                finishcnt = 0;
            }
            else if (BoNus == true)
            {
                if (OisSleep == 0)
                {
                    Sleep.Enabled = true;
                    count.Enabled = true;
                    OisSleep++;
                }
            }
            if (Sleep.Enabled == false)
            {
                if (OGarj - 1 == RGarj && OGari == RGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) OG.Image = Properties.Resources.gdown;
                        else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                        OtimerD.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) OG.Image = Properties.Resources.gsx;
                        else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                        OtimerL.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) OG.Image = Properties.Resources.gdx;
                        else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                        OtimerR.Enabled = true;
                    }
                }
                else if (OGarj - 1 == BGarj && OGari == BGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) OG.Image = Properties.Resources.gdown;
                        else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                        OtimerD.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) OG.Image = Properties.Resources.gsx;
                        else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                        OtimerL.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) OG.Image = Properties.Resources.gdx;
                        else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                        OtimerR.Enabled = true;
                    }
                }
                else if (OGarj - 1 == PGarj && OGari == PGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) OG.Image = Properties.Resources.gdown;
                        else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                        OtimerD.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) OG.Image = Properties.Resources.gsx;
                        else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                        OtimerL.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) OG.Image = Properties.Resources.gsx;
                        else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                        OtimerR.Enabled = true;
                    }
                }

                if (moveDiscern == true)
                {
                    if ((MapTileArray[OGarj - 1, OGari]) == 0 || (MapTileArray[OGarj - 1, OGari]) == 2 || (MapTileArray[OGarj - 1, OGari]) == 3)
                    {
                        OtimerD.Enabled = false;
                        OtimerR.Enabled = false;
                        OtimerL.Enabled = false;
                        int y = OGpanel.Location.Y - moveY;
                        OGpanel.Top = y;
                        OGarj--;
                    }
                    else
                    {
                        if (random == 0)
                        {
                            if (BoNus == false) OG.Image = Properties.Resources.gdown;
                            else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                            OtimerD.Enabled = true;
                        }
                        if (random == 1)
                        {
                            if (BoNus == false) OG.Image = Properties.Resources.gdx;
                            else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                            OtimerR.Enabled = true;
                        }
                        if (random == 2)
                        {
                            if (BoNus == false) OG.Image = Properties.Resources.gsx;
                            else if (BoNus == true) OG.Image = Properties.Resources.crazy;
                            OtimerL.Enabled = true;
                        }
                    }
                }
            }
        }
        /*빨간 유령*/
        private void RtimerL_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            int random = r.Next(0, 2);
            bool moveDiscern = true;
            if (BoNus == false)
            {
                RG.Image = Properties.Resources.rsx;
                RisSleep = 0;
                startcnt = 0;
                finishcnt = 0;
            }
            else if (BoNus == true)
            {
                if (RisSleep == 0)
                {
                    Sleep.Enabled = true;
                    count.Enabled = true;
                    RisSleep++;
                }
            }
            if (Sleep.Enabled == false)
            {
                if (RGarj == OGarj && RGari - 1 == OGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) RG.Image = Properties.Resources.rdown;
                        else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                        RtimerD.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) RG.Image = Properties.Resources.rup;
                        else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                        RtimerU.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) RG.Image = Properties.Resources.rdx;
                        else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                        RtimerR.Enabled = true;
                    }
                }
                else if (RGarj == BGarj && RGari - 1 == BGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) RG.Image = Properties.Resources.rdown;
                        else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                        RtimerD.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) RG.Image = Properties.Resources.rup;
                        else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                        RtimerU.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) RG.Image = Properties.Resources.rdx;
                        else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                        RtimerR.Enabled = true;
                    }
                }
                else if (RGarj == PGarj && RGari - 1 == PGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) RG.Image = Properties.Resources.rdown;
                        else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                        RtimerD.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) RG.Image = Properties.Resources.rup;
                        else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                        RtimerU.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) RG.Image = Properties.Resources.rdx;
                        else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                        RtimerR.Enabled = true;
                    }
                }

                if (moveDiscern == true)
                {
                    if ((MapTileArray[RGarj, RGari - 1]) == 0 || (MapTileArray[RGarj, RGari - 1]) == 2 || (MapTileArray[RGarj, RGari - 1]) == 3)
                    {
                        RtimerD.Enabled = false;
                        RtimerU.Enabled = false;
                        RtimerR.Enabled = false;
                        int x = RGpanel.Location.X - moveX;
                        RGpanel.Left = x;
                        RGari--;
                    }
                    else
                    {
                        if (random == 0)
                        {
                            if (BoNus == false) RG.Image = Properties.Resources.rdown;
                            else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                            RtimerD.Enabled = true;
                        }
                        if (random == 1)
                        {
                            if (BoNus == false) RG.Image = Properties.Resources.rup;
                            else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                            RtimerU.Enabled = true;
                        }
                        if (random == 2)
                        {
                            if (BoNus == false) RG.Image = Properties.Resources.rdx;
                            else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                            RtimerR.Enabled = true;
                        }
                    }
                }
            }
        }

        private void RtimerD_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            int random = r.Next(0, 2);
            bool moveDiscern = true;
            if (BoNus == false)
            {
                RG.Image = Properties.Resources.rdown;
                RisSleep = 0;
                startcnt = 0;
                finishcnt = 0;
            }
            else if (BoNus == true)
            {
                if (RisSleep == 0)
                {
                    Sleep.Enabled = true;
                    count.Enabled = true;
                    RisSleep++;
                }
            }
            if (Sleep.Enabled == false)
            {
                if (RGarj + 1 == OGarj && RGari == OGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) RG.Image = Properties.Resources.rsx;
                        else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                        RtimerL.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) RG.Image = Properties.Resources.rup;
                        else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                        RtimerU.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) RG.Image = Properties.Resources.rdx;
                        else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                        RtimerR.Enabled = true;
                    }
                }
                else if (RGarj + 1 == BGarj && RGari == BGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) RG.Image = Properties.Resources.rsx;
                        else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                        RtimerL.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) RG.Image = Properties.Resources.rup;
                        else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                        RtimerU.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) RG.Image = Properties.Resources.rdx;
                        else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                        RtimerR.Enabled = true;
                    }
                }
                else if (RGarj + 1 == PGarj && RGari == PGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) RG.Image = Properties.Resources.rsx;
                        else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                        RtimerL.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) RG.Image = Properties.Resources.rup;
                        else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                        RtimerU.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) RG.Image = Properties.Resources.rdx;
                        else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                        RtimerR.Enabled = true;
                    }
                }

                if (moveDiscern == true)
                {
                    if ((MapTileArray[RGarj + 1, RGari]) == 0 || (MapTileArray[RGarj + 1, RGari]) == 2 || (MapTileArray[RGarj + 1, RGari]) == 3)
                    {
                        RtimerR.Enabled = false;
                        RtimerU.Enabled = false;
                        RtimerL.Enabled = false;
                        int y = RGpanel.Location.Y + moveY;
                        RGpanel.Top = y;
                        RGarj++;
                    }
                    else
                    {
                        if (random == 0)
                        {
                            if (BoNus == false) RG.Image = Properties.Resources.rdx;
                            else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                            RtimerR.Enabled = true;
                        }
                        if (random == 1)
                        {
                            if (BoNus == false) RG.Image = Properties.Resources.rup;
                            else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                            RtimerU.Enabled = true;
                        }
                        if (random == 2)
                        {
                            if (BoNus == false) RG.Image = Properties.Resources.rsx;
                            else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                            RtimerL.Enabled = true;
                        }
                    }
                }
            }
        }

        private void RtimerR_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            int random = r.Next(0, 3);
            bool moveDiscern = true;
            if (BoNus == false)
            {
                RG.Image = Properties.Resources.rdx;
                RisSleep = 0;
                startcnt = 0;
                finishcnt = 0;
            }
            else if (BoNus == true)
            {
                if (RisSleep == 0)
                {
                    Sleep.Enabled = true;
                    count.Enabled = true;
                    RisSleep++;
                }
            }
            if (Sleep.Enabled == false)
            {
                if (RGarj == OGarj && RGari + 1 == OGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) RG.Image = Properties.Resources.rdown;
                        else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                        RtimerD.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) RG.Image = Properties.Resources.rup;
                        else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                        RtimerU.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) RG.Image = Properties.Resources.rsx;
                        else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                        RtimerL.Enabled = true;
                    }
                }
                else if (RGarj == BGarj && RGari + 1 == BGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) RG.Image = Properties.Resources.rdown;
                        else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                        RtimerD.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) RG.Image = Properties.Resources.rup;
                        else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                        RtimerU.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) RG.Image = Properties.Resources.rsx;
                        else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                        RtimerL.Enabled = true;
                    }
                }
                else if (RGarj == PGarj && RGari + 1 == PGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) RG.Image = Properties.Resources.rdown;
                        else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                        RtimerD.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) RG.Image = Properties.Resources.rup;
                        else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                        RtimerU.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) RG.Image = Properties.Resources.rsx;
                        else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                        RtimerL.Enabled = true;
                    }
                }

                if (moveDiscern == true)
                {
                    if ((MapTileArray[RGarj, RGari + 1]) == 0 || (MapTileArray[RGarj, RGari + 1]) == 2 || (MapTileArray[RGarj, RGari + 1]) == 3)
                    {
                        RtimerD.Enabled = false;
                        RtimerU.Enabled = false;
                        RtimerL.Enabled = false;
                        int x = RGpanel.Location.X + moveX;
                        RGpanel.Left = x;
                        RGari++;
                    }
                    else
                    {
                        if (random == 0)
                        {
                            if (BoNus == false) RG.Image = Properties.Resources.rdown;
                            else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                            RtimerD.Enabled = true;
                        }
                        if (random == 1)
                        {
                            if (BoNus == false) RG.Image = Properties.Resources.rup;
                            else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                            RtimerU.Enabled = true;
                        }
                        if (random == 2)
                        {
                            if (BoNus == false) RG.Image = Properties.Resources.rsx;
                            else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                            RtimerL.Enabled = true;
                        }
                    }
                }
            }
        }

        private void RtimerU_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            int random = r.Next(0, 2);
            bool moveDiscern = true;
            if (BoNus == false)
            {
                RG.Image = Properties.Resources.rup;
                RisSleep = 0;
                startcnt = 0;
                finishcnt = 0;
            }
            else if (BoNus == true)
            {
                if (RisSleep == 0)
                {
                    Sleep.Enabled = true;
                    count.Enabled = true;
                    RisSleep++;
                }
            }
            if (Sleep.Enabled == false)
            {
                if (RGarj - 1 == OGarj && RGari == OGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) RG.Image = Properties.Resources.rdown;
                        else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                        RtimerD.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) RG.Image = Properties.Resources.rsx;
                        else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                        RtimerL.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) RG.Image = Properties.Resources.rdx;
                        else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                        RtimerR.Enabled = true;
                    }
                }
                else if (RGarj - 1 == BGarj && RGari == BGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) RG.Image = Properties.Resources.rdown;
                        else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                        RtimerD.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) RG.Image = Properties.Resources.rsx;
                        else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                        RtimerL.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) RG.Image = Properties.Resources.rdx;
                        else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                        RtimerR.Enabled = true;
                    }
                }
                else if (RGarj - 1 == PGarj && RGari == PGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) RG.Image = Properties.Resources.rdown;
                        else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                        RtimerD.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) RG.Image = Properties.Resources.rsx;
                        else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                        RtimerL.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) RG.Image = Properties.Resources.rdx;
                        else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                        RtimerR.Enabled = true;
                    }
                }

                if (moveDiscern == true)
                {
                    if ((MapTileArray[RGarj - 1, RGari]) == 0 || (MapTileArray[RGarj - 1, RGari]) == 2 || (MapTileArray[RGarj - 1, RGari]) == 3)
                    {
                        RtimerD.Enabled = false;
                        RtimerR.Enabled = false;
                        RtimerL.Enabled = false;
                        int y = RGpanel.Location.Y - moveY;
                        RGpanel.Top = y;
                        RGarj--;
                    }
                    else
                    {
                        if (random == 0)
                        {
                            if (BoNus == false) RG.Image = Properties.Resources.rdown;
                            else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                            RtimerD.Enabled = true;
                        }
                        if (random == 1)
                        {
                            if (BoNus == false) RG.Image = Properties.Resources.rdx;
                            else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                            RtimerR.Enabled = true;
                        }
                        if (random == 2)
                        {
                            if (BoNus == false) RG.Image = Properties.Resources.rsx;
                            else if (BoNus == true) RG.Image = Properties.Resources.crazy;
                            RtimerL.Enabled = true;
                        }
                    }
                }
            }
        }
        /*파란 유령*/
        private void BtimerR_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            int random = r.Next(0, 3);
            bool moveDiscern = true;
            if (BoNus == false)
            {
                BG.Image = Properties.Resources.adx;
                BisSleep = 0;
                startcnt = 0;
                finishcnt = 0;
            }
            else if (BoNus == true)
            {
                if (BisSleep == 0)
                {
                    Sleep.Enabled = true;
                    count.Enabled = true;
                    BisSleep++;
                }
            }
            if (Sleep.Enabled == false)
            {
                if (BGarj == OGarj && BGari + 1 == OGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) BG.Image = Properties.Resources.adown;
                        else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                        BtimerD.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) BG.Image = Properties.Resources.aup;
                        else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                        BtimerU.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) BG.Image = Properties.Resources.asx;
                        else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                        BtimerL.Enabled = true;
                    }
                }
                else if (BGarj == RGarj && BGari + 1 == RGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) BG.Image = Properties.Resources.adown;
                        else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                        BtimerD.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) BG.Image = Properties.Resources.aup;
                        else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                        BtimerU.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) BG.Image = Properties.Resources.asx;
                        else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                        BtimerL.Enabled = true;
                    }
                }
                else if (BGarj == PGarj && BGari + 1 == PGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) BG.Image = Properties.Resources.adown;
                        else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                        BtimerD.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) BG.Image = Properties.Resources.aup;
                        else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                        BtimerU.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) BG.Image = Properties.Resources.asx;
                        else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                        BtimerL.Enabled = true;
                    }
                }

                if (moveDiscern == true)
                {
                    if ((MapTileArray[BGarj, BGari + 1]) == 0 || (MapTileArray[BGarj, BGari + 1]) == 2 || (MapTileArray[BGarj, BGari + 1]) == 3)
                    {
                        BtimerD.Enabled = false;
                        BtimerU.Enabled = false;
                        BtimerL.Enabled = false;
                        int x = BGpanel.Location.X + moveX;
                        BGpanel.Left = x;
                        BGari++;
                    }
                    else
                    {
                        if (random == 0)
                        {
                            if (BoNus == false) BG.Image = Properties.Resources.adown;
                            else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                            BtimerD.Enabled = true;
                        }
                        if (random == 1)
                        {
                            if (BoNus == false) BG.Image = Properties.Resources.aup;
                            else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                            BtimerU.Enabled = true;
                        }
                        if (random == 2)
                        {
                            if (BoNus == false) BG.Image = Properties.Resources.asx;
                            else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                            BtimerL.Enabled = true;
                        }
                    }
                }
            }
        }

        private void BtimerL_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            int random = r.Next(0, 2);
            bool moveDiscern = true;
            if (BoNus == false)
            {
                BG.Image = Properties.Resources.asx;
                BisSleep = 0;
                startcnt = 0;
                finishcnt = 0;
            }
            else if (BoNus == true)
            {
                if (BisSleep == 0)
                {
                    Sleep.Enabled = true;
                    count.Enabled = true;
                    BisSleep++;
                }
            }
            if (Sleep.Enabled == false)
            {
                if (BGarj == RGarj && BGari - 1 == RGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) BG.Image = Properties.Resources.adown;
                        else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                        BtimerD.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) BG.Image = Properties.Resources.aup;
                        else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                        BtimerU.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) BG.Image = Properties.Resources.asx;
                        else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                        BtimerR.Enabled = true;
                    }
                }
                else if (BGarj == OGarj && BGari - 1 == OGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) BG.Image = Properties.Resources.adown;
                        else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                        BtimerD.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) BG.Image = Properties.Resources.aup;
                        else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                        BtimerU.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) BG.Image = Properties.Resources.asx;
                        else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                        BtimerR.Enabled = true;
                    }
                }
                else if (BGarj == PGarj && BGari - 1 == PGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) BG.Image = Properties.Resources.adown;
                        else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                        BtimerD.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) BG.Image = Properties.Resources.aup;
                        else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                        BtimerU.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) BG.Image = Properties.Resources.asx;
                        else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                        BtimerR.Enabled = true;
                    }
                }

                if (moveDiscern == true)
                {
                    if ((MapTileArray[BGarj, BGari - 1]) == 0 || (MapTileArray[BGarj, BGari - 1]) == 2 || (MapTileArray[BGarj, BGari - 1]) == 3)
                    {
                        BtimerD.Enabled = false;
                        BtimerU.Enabled = false;
                        BtimerR.Enabled = false;
                        int x = BGpanel.Location.X - moveX;
                        BGpanel.Left = x;
                        BGari--;
                    }
                    else
                    {
                        if (random == 0)
                        {
                            if (BoNus == false) BG.Image = Properties.Resources.adown;
                            else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                            BtimerD.Enabled = true;
                        }
                        if (random == 1)
                        {
                            if (BoNus == false) BG.Image = Properties.Resources.aup;
                            else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                            BtimerU.Enabled = true;
                        }
                        if (random == 2)
                        {
                            if (BoNus == false) BG.Image = Properties.Resources.adx;
                            else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                            BtimerR.Enabled = true;
                        }
                    }
                }
            }
        }

        private void BtimerD_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            int random = r.Next(0, 2);
            bool moveDiscern = true;
            if (BoNus == false)
            {
                BG.Image = Properties.Resources.adown;
                BisSleep = 0;
                startcnt = 0;
                finishcnt = 0;
            }
            else if (BoNus == true)
            {
                if (BisSleep == 0)
                {
                    Sleep.Enabled = true;
                    count.Enabled = true;
                    BisSleep++;
                }
            }
            if (Sleep.Enabled == false)
            {
                if (BGarj + 1 == OGarj && BGari == OGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) BG.Image = Properties.Resources.adx;
                        else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                        BtimerR.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) BG.Image = Properties.Resources.aup;
                        else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                        BtimerU.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) BG.Image = Properties.Resources.asx;
                        else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                        BtimerL.Enabled = true;
                    }
                }
                else if (BGarj + 1 == RGarj && BGari == RGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) BG.Image = Properties.Resources.adx;
                        else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                        BtimerR.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) BG.Image = Properties.Resources.aup;
                        else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                        BtimerU.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) BG.Image = Properties.Resources.asx;
                        else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                        BtimerL.Enabled = true;
                    }
                }
                else if (BGarj + 1 == PGarj && BGari == PGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) BG.Image = Properties.Resources.adx;
                        else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                        BtimerR.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) BG.Image = Properties.Resources.aup;
                        else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                        BtimerU.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) BG.Image = Properties.Resources.asx;
                        else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                        BtimerL.Enabled = true;
                    }
                }

                if (moveDiscern == true)
                {
                    if ((MapTileArray[BGarj + 1, BGari]) == 0 || (MapTileArray[BGarj + 1, BGari]) == 2 || (MapTileArray[BGarj + 1, BGari]) == 3)
                    {
                        BtimerR.Enabled = false;
                        BtimerU.Enabled = false;
                        BtimerL.Enabled = false;
                        int y = BGpanel.Location.Y + moveY;
                        BGpanel.Top = y;
                        BGarj++;
                    }
                    else
                    {
                        if (random == 0)
                        {
                            if (BoNus == false) BG.Image = Properties.Resources.adx;
                            else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                            BtimerR.Enabled = true;
                        }
                        if (random == 1)
                        {
                            if (BoNus == false) BG.Image = Properties.Resources.aup;
                            else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                            BtimerU.Enabled = true;
                        }
                        if (random == 2)
                        {
                            if (BoNus == false) BG.Image = Properties.Resources.asx;
                            else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                            BtimerL.Enabled = true;
                        }
                    }
                }
            }
        }



        private void BtimerU_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            int random = r.Next(0, 2);
            bool moveDiscern = true;
            if (BoNus == false)
            {
                BG.Image = Properties.Resources.aup;
                BisSleep = 0;
                startcnt = 0;
                finishcnt = 0;
            }
            else if (BoNus == true)
            {
                if (BisSleep == 0)
                {
                    Sleep.Enabled = true;
                    count.Enabled = true;
                    BisSleep++;
                }
            }
            if (Sleep.Enabled == false)
            {
                if (BGarj - 1 == OGarj && BGari == OGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) BG.Image = Properties.Resources.adx;
                        else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                        BtimerR.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) BG.Image = Properties.Resources.adown;
                        else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                        BtimerD.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) BG.Image = Properties.Resources.asx;
                        else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                        BtimerL.Enabled = true;
                    }
                }
                else if (BGarj - 1 == RGarj && BGari == RGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) BG.Image = Properties.Resources.adx;
                        else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                        BtimerR.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) BG.Image = Properties.Resources.adown;
                        else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                        BtimerD.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) BG.Image = Properties.Resources.asx;
                        else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                        BtimerL.Enabled = true;
                    }
                }
                else if (BGarj - 1 == PGarj && BGari == PGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) BG.Image = Properties.Resources.adx;
                        else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                        BtimerR.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) BG.Image = Properties.Resources.adown;
                        else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                        BtimerD.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) BG.Image = Properties.Resources.asx;
                        else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                        BtimerL.Enabled = true;
                    }
                }

                if (moveDiscern == true)
                {
                    if ((MapTileArray[BGarj - 1, BGari]) == 0 || (MapTileArray[BGarj - 1, BGari + 1]) == 2 || (MapTileArray[BGarj - 1, BGari]) == 3)
                    {
                        BtimerD.Enabled = false;
                        BtimerR.Enabled = false;
                        BtimerL.Enabled = false;
                        int y = BGpanel.Location.Y - moveY;
                        BGpanel.Top = y;
                        BGarj--;
                    }
                    else
                    {
                        if (random == 0)
                        {
                            if (BoNus == false) BG.Image = Properties.Resources.adown;
                            else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                            BtimerD.Enabled = true;
                        }
                        if (random == 1)
                        {
                            if (BoNus == false) BG.Image = Properties.Resources.adx;
                            else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                            BtimerR.Enabled = true;
                        }
                        if (random == 2)
                        {
                            if (BoNus == false) BG.Image = Properties.Resources.asx;
                            else if (BoNus == true) BG.Image = Properties.Resources.crazy;
                            BtimerL.Enabled = true;
                        }
                    }
                }
            }
        }
        /*핑크 유령*/
        private void PtimerR_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            int random = r.Next(0, 3);
            bool moveDiscern = true;
            if (BoNus == false)
            {
                PG.Image = Properties.Resources.vdx;
                PisSleep = 0;
                startcnt = 0;
                finishcnt = 0;
            }
            else if (BoNus == true)
            {
                if (PisSleep == 0)
                {
                    Sleep.Enabled = true;
                    count.Enabled = true;
                    PisSleep++;
                }
            }
            if (Sleep.Enabled == false)
            {
                if (PGarj == OGarj && PGari + 1 == OGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) PG.Image = Properties.Resources.vdown;
                        else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                        PtimerD.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) PG.Image = Properties.Resources.vup;
                        else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                        PtimerU.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) PG.Image = Properties.Resources.vsx;
                        else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                        PtimerL.Enabled = true;
                    }
                }
                else if (PGarj == RGarj && PGari + 1 == RGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) PG.Image = Properties.Resources.vdown;
                        else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                        PtimerD.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) PG.Image = Properties.Resources.vup;
                        else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                        PtimerU.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) PG.Image = Properties.Resources.vsx;
                        else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                        PtimerL.Enabled = true;
                    }
                }
                else if (PGarj == BGarj && PGari + 1 == BGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) PG.Image = Properties.Resources.vdown;
                        else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                        PtimerD.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) PG.Image = Properties.Resources.vup;
                        else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                        PtimerU.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) PG.Image = Properties.Resources.vsx;
                        else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                        PtimerL.Enabled = true;
                    }
                }

                if (moveDiscern == true)
                {
                    if ((MapTileArray[PGarj, PGari + 1]) == 0 || (MapTileArray[PGarj, PGari + 1]) == 2 || (MapTileArray[PGarj, PGari + 1]) == 3)
                    {
                        PtimerD.Enabled = false;
                        PtimerU.Enabled = false;
                        PtimerL.Enabled = false;
                        int x = PGpanel.Location.X + moveX;
                        PGpanel.Left = x;
                        PGari++;
                    }
                    else
                    {
                        if (random == 0)
                        {
                            if (BoNus == false) PG.Image = Properties.Resources.vdown;
                            else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                            PtimerD.Enabled = true;
                        }
                        if (random == 1)
                        {
                            if (BoNus == false) PG.Image = Properties.Resources.vup;
                            else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                            PtimerU.Enabled = true;
                        }
                        if (random == 2)
                        {
                            if (BoNus == false) PG.Image = Properties.Resources.vsx;
                            else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                            PtimerL.Enabled = true;
                        }
                    }
                }
            }
        }

        private void PtimerL_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            int random = r.Next(0, 2);
            bool moveDiscern = true;
            if (BoNus == false)
            {
                PG.Image = Properties.Resources.vsx;
                PisSleep = 0;
                startcnt = 0;
                finishcnt = 0;
            }
            else if (BoNus == true)
            {
                if (PisSleep == 0)
                {
                    Sleep.Enabled = true;
                    count.Enabled = true;
                    PisSleep++;
                }
            }
            if (Sleep.Enabled == false)
            {
                if (PGarj == OGarj && PGari - 1 == OGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) PG.Image = Properties.Resources.vdown;
                        else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                        PtimerD.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) PG.Image = Properties.Resources.vup;
                        else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                        PtimerU.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) PG.Image = Properties.Resources.vdx;
                        else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                        PtimerR.Enabled = true;
                    }
                }
                else if (PGarj == RGarj && PGari - 1 == RGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) PG.Image = Properties.Resources.vdown;
                        else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                        PtimerD.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) PG.Image = Properties.Resources.vup;
                        else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                        PtimerU.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) PG.Image = Properties.Resources.vdx;
                        else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                        PtimerR.Enabled = true;
                    }
                }
                else if (PGarj == BGarj && PGari - 1 == BGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) PG.Image = Properties.Resources.vdown;
                        else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                        PtimerD.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) PG.Image = Properties.Resources.vup;
                        else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                        PtimerU.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) PG.Image = Properties.Resources.vdx;
                        else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                        PtimerR.Enabled = true;
                    }
                }

                if (moveDiscern == true)
                {
                    if ((MapTileArray[PGarj, PGari - 1]) == 0 || (MapTileArray[PGarj, PGari - 1]) == 2 || (MapTileArray[PGarj, PGari - 1]) == 3)
                    {
                        PtimerD.Enabled = false;
                        PtimerU.Enabled = false;
                        PtimerR.Enabled = false;
                        int x = PGpanel.Location.X - moveX;
                        PGpanel.Left = x;
                        PGari--;
                    }
                    else
                    {
                        if (random == 0)
                        {
                            if (BoNus == false) PG.Image = Properties.Resources.vdown;
                            else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                            PtimerD.Enabled = true;
                        }
                        if (random == 1)
                        {
                            if (BoNus == false) PG.Image = Properties.Resources.vup;
                            else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                            PtimerU.Enabled = true;
                        }
                        if (random == 2)
                        {
                            if (BoNus == false) PG.Image = Properties.Resources.vdx;
                            else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                            PtimerR.Enabled = true;
                        }
                    }
                }
            }
        }

        private void PtimerD_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            int random = r.Next(0, 2);
            bool moveDiscern = true;
            if (BoNus == false)
            {
                PG.Image = Properties.Resources.vdown;
                PisSleep = 0;
                startcnt = 0;
                finishcnt = 0;
            }
            else if (BoNus == true)
            {
                if (PisSleep == 0)
                {
                    Sleep.Enabled = true;
                    count.Enabled = true;
                    PisSleep++;
                }
            }
            if (Sleep.Enabled == false)
            {
                if (PGarj + 1 == OGarj && PGari == OGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) PG.Image = Properties.Resources.vdx;
                        else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                        PtimerR.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) PG.Image = Properties.Resources.vup;
                        else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                        PtimerU.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) PG.Image = Properties.Resources.vsx;
                        else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                        PtimerL.Enabled = true;
                    }
                }
                else if (PGarj + 1 == RGarj && PGari == RGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) PG.Image = Properties.Resources.vdx;
                        else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                        PtimerR.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) PG.Image = Properties.Resources.vup;
                        else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                        PtimerU.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) PG.Image = Properties.Resources.vsx;
                        else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                        PtimerL.Enabled = true;
                    }
                }
                else if (PGarj + 1 == BGarj && PGari == BGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) PG.Image = Properties.Resources.vdx;
                        else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                        PtimerR.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) PG.Image = Properties.Resources.vup;
                        else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                        PtimerU.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) PG.Image = Properties.Resources.vsx;
                        else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                        PtimerL.Enabled = true;
                    }
                }

                if (moveDiscern == true)
                {
                    if ((MapTileArray[PGarj + 1, PGari]) == 0 || (MapTileArray[PGarj + 1, PGari]) == 2 || (MapTileArray[PGarj + 1, PGari]) == 3)
                    {
                        PtimerR.Enabled = false;
                        PtimerU.Enabled = false;
                        PtimerL.Enabled = false;
                        int y = PGpanel.Location.Y + moveY;
                        PGpanel.Top = y;
                        PGarj++;
                    }
                    else
                    {
                        if (random == 0)
                        {
                            if (BoNus == false) PG.Image = Properties.Resources.vdx;
                            else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                            PtimerR.Enabled = true;
                        }
                        if (random == 1)
                        {
                            if (BoNus == false) PG.Image = Properties.Resources.vup;
                            else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                            PtimerU.Enabled = true;
                        }
                        if (random == 2)
                        {
                            if (BoNus == false) PG.Image = Properties.Resources.vsx;
                            else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                            PtimerL.Enabled = true;
                        }
                    }
                }
            }
        }

        private void PtimerU_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            int random = r.Next(0, 2);
            bool moveDiscern = true;
            if (BoNus == false)
            {
                PG.Image = Properties.Resources.vup;
                PisSleep = 0;
                startcnt = 0;
                finishcnt = 0;
            }
            else if (BoNus == true)
            {
                if (PisSleep == 0)
                {
                    Sleep.Enabled = true;
                    count.Enabled = true;
                    PisSleep++;
                }
            }
            if (Sleep.Enabled == false)
            {
                if (PGarj - 1 == OGarj && PGari == OGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) PG.Image = Properties.Resources.vdx;
                        else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                        PtimerR.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) PG.Image = Properties.Resources.vdown;
                        else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                        PtimerD.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) PG.Image = Properties.Resources.vsx;
                        else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                        PtimerL.Enabled = true;
                    }
                }
                else if (PGarj - 1 == RGarj && PGari == RGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) PG.Image = Properties.Resources.vdx;
                        else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                        PtimerR.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) PG.Image = Properties.Resources.vdown;
                        else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                        PtimerD.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) PG.Image = Properties.Resources.vsx;
                        else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                        PtimerL.Enabled = true;
                    }
                }
                else if (PGarj - 1 == BGarj && PGari == BGari)
                {
                    moveDiscern = false;
                    if (random == 0)
                    {
                        if (BoNus == false) PG.Image = Properties.Resources.vdx;
                        else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                        PtimerR.Enabled = true;
                    }
                    if (random == 1)
                    {
                        if (BoNus == false) PG.Image = Properties.Resources.vdown;
                        else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                        PtimerD.Enabled = true;
                    }
                    if (random == 2)
                    {
                        if (BoNus == false) PG.Image = Properties.Resources.vsx;
                        else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                        PtimerL.Enabled = true;
                    }
                }

                if (moveDiscern == true)
                {
                    if ((MapTileArray[PGarj - 1, PGari]) == 0 || (MapTileArray[PGarj - 1, PGari]) == 2 || (MapTileArray[PGarj - 1, PGari]) == 3)
                    {
                        PtimerD.Enabled = false;
                        PtimerR.Enabled = false;
                        PtimerL.Enabled = false;
                        int y = PGpanel.Location.Y - moveY;
                        PGpanel.Top = y;
                        PGarj--;
                    }
                    else
                    {
                        if (random == 0)
                        {
                            if (BoNus == false) PG.Image = Properties.Resources.vdown;
                            else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                            PtimerD.Enabled = true;
                        }
                        if (random == 1)
                        {
                            if (BoNus == false) PG.Image = Properties.Resources.vdx;
                            else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                            PtimerR.Enabled = true;
                        }
                        if (random == 2)
                        {
                            if (BoNus == false) PG.Image = Properties.Resources.vsx;
                            else if (BoNus == true) PG.Image = Properties.Resources.crazy;
                            PtimerL.Enabled = true;
                        }
                    }
                }
            }
        }

        private void Sleep_Tick(object sender, EventArgs e)
        {
            OG.Image = Properties.Resources.tempo;
            PG.Image = Properties.Resources.tempo;
            BG.Image = Properties.Resources.tempo;
            RG.Image = Properties.Resources.tempo;
            OtimerD.Enabled = false;
            OtimerL.Enabled = false;
            OtimerR.Enabled = false;
            OtimerU.Enabled = false;
            RtimerD.Enabled = false;
            RtimerL.Enabled = false;
            RtimerR.Enabled = false;
            RtimerU.Enabled = false;
            BtimerD.Enabled = false;
            BtimerL.Enabled = false;
            BtimerR.Enabled = false;
            BtimerU.Enabled = false;
            PtimerD.Enabled = false;
            PtimerL.Enabled = false;
            PtimerR.Enabled = false;
            PtimerU.Enabled = false;

        }

        private void basicBoard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void count_Tick(object sender, EventArgs e)
        {
            startcnt += 1;
            finishcnt += 1;
            if (startcnt == 5)
            {
                Sleep.Enabled = false;
                OtimerR.Enabled = true;
                RtimerR.Enabled = true;
                BtimerL.Enabled = true;
                PtimerL.Enabled = true;
            }
            if (finishcnt == 10)
            {
                BoNus = false;
                count.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            basicBoard.Dock = DockStyle.Fill;
            tileBoard.Dock = DockStyle.Fill;
            rankingBoard.Dock = DockStyle.Fill;                       
        }
        public int PMcnt = 0;

        void PMT(Object state)
       
        {
            BeginInvoke(new TimerEventFiredDelegate(Work));
        }

        private void label2_Click(object sender, EventArgs e)
        {
            reset();
            GameoverPanel.Visible = false;
            basicBoard.BringToFront();
        }

        private void Work()
        {
            reset();
            PMcnt++;   
        }

        private void PreviousMenu_Ranking_Click(object sender, EventArgs e)
        {
            basicBoard.BringToFront();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void playgameLabel_Click(object sender, EventArgs e)
        {
            GameStart();
        }

        private void rankingLabel_Click(object sender, EventArgs e)
        {
            RankingSystem();
            rankingBoard.BringToFront();
    }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        //Thread Timer
     

        void EndingConsole()
        {
            Ending_ScorePT.Text = cnt.ToString();
            Ending_lifePT.Text = Life.ToString();

            //Ranking
            StreamReader sr = new StreamReader(RankingPath);
            string ReadingAllString = "";

            while (!sr.EndOfStream)
            {
                ReadingAllString += sr.ReadLine();
            }
            string PlayerRanking = "/";

            string[] SplitByLine = ReadingAllString.Split(',');
            string[] Rank1Data, Rank2Data, Rank3Data, Rank4Data, Rank5Data;
            string[] ScoreList= { "0", "0", "0", "0", "0"};

            Rank1Data = SplitByLine[0].Split(' ');
            Rank2Data = SplitByLine[1].Split(' ');
            Rank3Data = SplitByLine[2].Split(' ');
            Rank4Data = SplitByLine[3].Split(' ');
            Rank5Data = SplitByLine[4].Split(' ');

            ScoreList[0] = Rank1Data[2];
            ScoreList[1] = Rank2Data[2];
            ScoreList[2] = Rank3Data[2];
            ScoreList[3] = Rank4Data[2];
            ScoreList[4] = Rank5Data[2];

            if (int.Parse(Rank5Data[2]) < cnt)
            {
                Rank5Data[0] = "5";
                Rank5Data[1] = PlayerName;
                Rank5Data[2] = cnt.ToString();
                PlayerRanking = "5";
            }
            if (int.Parse(Rank4Data[2]) < cnt){
                string tmp0 = Rank4Data[0];
                string tmp1 = Rank4Data[1];
                string tmp2 = Rank4Data[2];

                Rank4Data[0] = "4";
                Rank4Data[1] = PlayerName;
                Rank4Data[2] = cnt.ToString();

                Rank5Data[0] = "5";
                Rank5Data[1] = tmp1;
                Rank5Data[2] = tmp2;
                PlayerRanking = "4";
            }
            if (int.Parse(Rank3Data[2]) < cnt)
            {
                string tmp0 = Rank3Data[0];
                string tmp1 = Rank3Data[1];
                string tmp2 = Rank3Data[2];

                Rank3Data[0] = "3";
                Rank3Data[1] = PlayerName;
                Rank3Data[2] = cnt.ToString();

                Rank4Data[0] = "4";
                Rank4Data[1] = tmp1;
                Rank4Data[2] = tmp2;
                PlayerRanking = "3";
            }
            if (int.Parse(Rank2Data[2]) < cnt)
            {
                string tmp0 = Rank2Data[0];
                string tmp1 = Rank2Data[1];
                string tmp2 = Rank2Data[2];

                Rank2Data[0] = "2";
                Rank2Data[1] = PlayerName;
                Rank2Data[2] = cnt.ToString();

                Rank3Data[0] = "3";
                Rank3Data[1] = tmp1;
                Rank3Data[2] = tmp2;
                PlayerRanking = "2";
            }
            if (int.Parse(Rank1Data[2]) < cnt)
            {
                string tmp0 = Rank1Data[0];
                string tmp1 = Rank1Data[1];
                string tmp2 = Rank1Data[2];

                Rank1Data[0] = "1";
                Rank1Data[1] = PlayerName;
                Rank1Data[2] = cnt.ToString();

                Rank2Data[0] = "2";
                Rank2Data[1] = tmp1;
                Rank2Data[2] = tmp2;
                PlayerRanking = "1";
            }
           
            sr.Close();
            gameover_ranking_label.Text = PlayerRanking;
            GameoverPanel.Visible = true;
            TimerBlocker.Visible = true;

            StreamWriter sw = new StreamWriter(RankingPath);
            sw.WriteLine(Rank1Data[0] + " " + Rank1Data[1] + " " + Rank1Data[2] + ',');
            sw.WriteLine(Rank2Data[0] + " " + Rank2Data[1] + " " + Rank2Data[2] + ',');
            sw.WriteLine(Rank3Data[0] + " " + Rank3Data[1] + " " + Rank3Data[2] + ',');
            sw.WriteLine(Rank4Data[0] + " " + Rank4Data[1] + " " + Rank4Data[2] + ',');
            sw.WriteLine(Rank5Data[0] + " " + Rank5Data[1] + " " + Rank5Data[2] + ',');
            sw.Close();
            sw.Dispose();
            reset();
        }



        void GameStart()
        {
            tileBoard.BringToFront();
            PMpanel.Visible = true;
            PMpanel.BringToFront();
            OGpanel.Visible = true;
            OGpanel.BringToFront();
            PGpanel.Visible = true;
            PGpanel.BringToFront();
            RGpanel.Visible = true;
            RGpanel.BringToFront();
            BGpanel.Visible = true;
            BGpanel.BringToFront();
            OtimerR.Enabled = true;
            RtimerR.Enabled = true;
            BtimerL.Enabled = true;
            PtimerL.Enabled = true;
            OGari = 10;
            OGarj = 12;
            BGari = 19;
            BGarj = 12;
            PGari = 19;
            PGarj = 19;
            RGari = 10;
            RGarj = 19;
            PPMari = 2;
            PPMarj = 2;
            PPMarj = 2;
            PPMari = 2;
            TimerBlocker.Visible = false;
            Life = 3;
            System.Threading.Timer Timer30sec = new System.Threading.Timer(GameTimer);
            Timer30sec.Change(0, 3000);
            EndingCnt = 30;

            void GameTimer(Object state)
            {
                BeginInvoke(new TimerEventFiredDelegate(EndingTimer));
            }

            void EndingTimer()
            {
                EndingCnt--;
                currentTime.Text = EndingCnt.ToString();
                if (EndingCnt == 0)
                {
                    EndingConsole();
                    //Timer30sec.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
                    //Timer30sec.Dispose();
                    //System.Threading.Thread.Sleep(20000);
                }
            }
            
            
      }

        void RankingSystem()
        {
            StreamReader sr = new StreamReader(RankingPath);
            string ReadingAllString = "";

            while (!sr.EndOfStream)
            {
                ReadingAllString += sr.ReadLine();
            }

            string[] SplitByLine = ReadingAllString.Split(',');
            string[] Rank1Data, Rank2Data, Rank3Data, Rank4Data, Rank5Data;

            Rank1Data = SplitByLine[0].Split(' ');
            Rank2Data = SplitByLine[1].Split(' ');
            Rank3Data = SplitByLine[2].Split(' ');
            Rank4Data = SplitByLine[3].Split(' ');
            Rank5Data = SplitByLine[4].Split(' ');

            Rank1_label.Text = Rank1Data[0] + "    " + Rank1Data[1] + "   " + Rank1Data[2];
            Rank2_label.Text = Rank2Data[0] + "     " + Rank2Data[1] + "    " + Rank2Data[2];
            Rank3_label.Text = Rank3Data[0] + "      " + Rank3Data[1] + "      " + Rank3Data[2];
            Rank4_label.Text = Rank4Data[0] + "      " + Rank4Data[1] + "      " + Rank4Data[2];
            Rank5_label.Text = Rank5Data[0] + "      " + Rank5Data[1] + "      " + Rank5Data[2];

            sr.Close();


            //StreamWriter sw = new StreamWriter(RankingPath);
            //sw.Close();
            //MessageBox.Show(ReadingLine);
        }



    }
}
