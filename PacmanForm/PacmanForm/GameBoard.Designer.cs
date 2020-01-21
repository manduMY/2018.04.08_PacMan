namespace PacmanForm
{
    partial class Pacman
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pacman));
            this.tileBoard = new System.Windows.Forms.Panel();
            this.GameoverPanel = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Endinglabel_life = new System.Windows.Forms.Label();
            this.Ending_lifePT = new System.Windows.Forms.Label();
            this.Ending_ScorePT = new System.Windows.Forms.Label();
            this.Endinglabel_score = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Endinglabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gameover_ranking_label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TimerBlocker = new System.Windows.Forms.Panel();
            this.currentScore = new System.Windows.Forms.Label();
            this.currentLife = new System.Windows.Forms.Label();
            this.currentTime = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.basicBoard = new System.Windows.Forms.Panel();
            this.mainGif = new System.Windows.Forms.PictureBox();
            this.rankingLabel = new System.Windows.Forms.Label();
            this.playgameLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PMpanel = new System.Windows.Forms.Panel();
            this.PM = new System.Windows.Forms.PictureBox();
            this.OGpanel = new System.Windows.Forms.Panel();
            this.OG = new System.Windows.Forms.PictureBox();
            this.BGpanel = new System.Windows.Forms.Panel();
            this.BG = new System.Windows.Forms.PictureBox();
            this.PGpanel = new System.Windows.Forms.Panel();
            this.PG = new System.Windows.Forms.PictureBox();
            this.RGpanel = new System.Windows.Forms.Panel();
            this.RG = new System.Windows.Forms.PictureBox();
            this.OtimerR = new System.Windows.Forms.Timer(this.components);
            this.OtimerL = new System.Windows.Forms.Timer(this.components);
            this.OtimerD = new System.Windows.Forms.Timer(this.components);
            this.OtimerU = new System.Windows.Forms.Timer(this.components);
            this.RtimerR = new System.Windows.Forms.Timer(this.components);
            this.RtimerL = new System.Windows.Forms.Timer(this.components);
            this.RtimerD = new System.Windows.Forms.Timer(this.components);
            this.RtimerU = new System.Windows.Forms.Timer(this.components);
            this.BtimerR = new System.Windows.Forms.Timer(this.components);
            this.BtimerL = new System.Windows.Forms.Timer(this.components);
            this.BtimerD = new System.Windows.Forms.Timer(this.components);
            this.BtimerU = new System.Windows.Forms.Timer(this.components);
            this.PtimerR = new System.Windows.Forms.Timer(this.components);
            this.PtimerL = new System.Windows.Forms.Timer(this.components);
            this.PtimerD = new System.Windows.Forms.Timer(this.components);
            this.PtimerU = new System.Windows.Forms.Timer(this.components);
            this.Sleep = new System.Windows.Forms.Timer(this.components);
            this.count = new System.Windows.Forms.Timer(this.components);
            this.rankingBoard = new System.Windows.Forms.Panel();
            this.PreviousMenu_Ranking = new System.Windows.Forms.Label();
            this.rankingGif = new System.Windows.Forms.PictureBox();
            this.Rank2_label = new System.Windows.Forms.Label();
            this.Rank5_label = new System.Windows.Forms.Label();
            this.Rank4_label = new System.Windows.Forms.Label();
            this.Rank3_label = new System.Windows.Forms.Label();
            this.Rank1_label = new System.Windows.Forms.Label();
            this.rankingLabelTitle = new System.Windows.Forms.Label();
            this.tileBoard.SuspendLayout();
            this.GameoverPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.basicBoard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainGif)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PMpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PM)).BeginInit();
            this.OGpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OG)).BeginInit();
            this.BGpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BG)).BeginInit();
            this.PGpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PG)).BeginInit();
            this.RGpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RG)).BeginInit();
            this.rankingBoard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rankingGif)).BeginInit();
            this.SuspendLayout();
            // 
            // tileBoard
            // 
            this.tileBoard.BackColor = System.Drawing.Color.Transparent;
            this.tileBoard.Controls.Add(this.GameoverPanel);
            this.tileBoard.Controls.Add(this.panel1);
            this.tileBoard.Location = new System.Drawing.Point(89, 84);
            this.tileBoard.Margin = new System.Windows.Forms.Padding(4);
            this.tileBoard.Name = "tileBoard";
            this.tileBoard.Size = new System.Drawing.Size(644, 822);
            this.tileBoard.TabIndex = 0;
            // 
            // GameoverPanel
            // 
            this.GameoverPanel.BackColor = System.Drawing.Color.Black;
            this.GameoverPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GameoverPanel.Controls.Add(this.textBox1);
            this.GameoverPanel.Controls.Add(this.Endinglabel_life);
            this.GameoverPanel.Controls.Add(this.Ending_lifePT);
            this.GameoverPanel.Controls.Add(this.Ending_ScorePT);
            this.GameoverPanel.Controls.Add(this.Endinglabel_score);
            this.GameoverPanel.Controls.Add(this.label3);
            this.GameoverPanel.Controls.Add(this.label2);
            this.GameoverPanel.Controls.Add(this.Endinglabel);
            this.GameoverPanel.Controls.Add(this.label1);
            this.GameoverPanel.Controls.Add(this.gameover_ranking_label);
            this.GameoverPanel.Location = new System.Drawing.Point(115, 114);
            this.GameoverPanel.Margin = new System.Windows.Forms.Padding(4);
            this.GameoverPanel.Name = "GameoverPanel";
            this.GameoverPanel.Size = new System.Drawing.Size(406, 522);
            this.GameoverPanel.TabIndex = 13;
            this.GameoverPanel.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(152, 397);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(106, 28);
            this.textBox1.TabIndex = 14;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Endinglabel_life
            // 
            this.Endinglabel_life.AutoSize = true;
            this.Endinglabel_life.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Endinglabel_life.ForeColor = System.Drawing.Color.White;
            this.Endinglabel_life.Location = new System.Drawing.Point(32, 350);
            this.Endinglabel_life.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Endinglabel_life.Name = "Endinglabel_life";
            this.Endinglabel_life.Size = new System.Drawing.Size(60, 25);
            this.Endinglabel_life.TabIndex = 3;
            this.Endinglabel_life.Text = "LIFE";
            this.Endinglabel_life.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Ending_lifePT
            // 
            this.Ending_lifePT.AutoSize = true;
            this.Ending_lifePT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ending_lifePT.ForeColor = System.Drawing.Color.White;
            this.Ending_lifePT.Location = new System.Drawing.Point(288, 350);
            this.Ending_lifePT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Ending_lifePT.Name = "Ending_lifePT";
            this.Ending_lifePT.Size = new System.Drawing.Size(51, 25);
            this.Ending_lifePT.TabIndex = 3;
            this.Ending_lifePT.Text = "999";
            this.Ending_lifePT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Ending_ScorePT
            // 
            this.Ending_ScorePT.AutoSize = true;
            this.Ending_ScorePT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ending_ScorePT.ForeColor = System.Drawing.Color.White;
            this.Ending_ScorePT.Location = new System.Drawing.Point(288, 320);
            this.Ending_ScorePT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Ending_ScorePT.Name = "Ending_ScorePT";
            this.Ending_ScorePT.Size = new System.Drawing.Size(51, 25);
            this.Ending_ScorePT.TabIndex = 3;
            this.Ending_ScorePT.Text = "999";
            this.Ending_ScorePT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Endinglabel_score
            // 
            this.Endinglabel_score.AutoSize = true;
            this.Endinglabel_score.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Endinglabel_score.ForeColor = System.Drawing.Color.White;
            this.Endinglabel_score.Location = new System.Drawing.Point(32, 320);
            this.Endinglabel_score.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Endinglabel_score.Name = "Endinglabel_score";
            this.Endinglabel_score.Size = new System.Drawing.Size(91, 25);
            this.Endinglabel_score.TabIndex = 3;
            this.Endinglabel_score.Text = "SCORE";
            this.Endinglabel_score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(255, 469);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "RE?";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(46, 469);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "MENU";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Endinglabel
            // 
            this.Endinglabel.AutoSize = true;
            this.Endinglabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Endinglabel.ForeColor = System.Drawing.Color.White;
            this.Endinglabel.Location = new System.Drawing.Point(91, 79);
            this.Endinglabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Endinglabel.Name = "Endinglabel";
            this.Endinglabel.Size = new System.Drawing.Size(175, 59);
            this.Endinglabel.TabIndex = 2;
            this.Endinglabel.Text = "RANK";
            this.Endinglabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 79);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // gameover_ranking_label
            // 
            this.gameover_ranking_label.AutoSize = true;
            this.gameover_ranking_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameover_ranking_label.ForeColor = System.Drawing.Color.White;
            this.gameover_ranking_label.Location = new System.Drawing.Point(108, 160);
            this.gameover_ranking_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gameover_ranking_label.Name = "gameover_ranking_label";
            this.gameover_ranking_label.Size = new System.Drawing.Size(150, 163);
            this.gameover_ranking_label.TabIndex = 0;
            this.gameover_ranking_label.Text = "0";
            this.gameover_ranking_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.TimerBlocker);
            this.panel1.Controls.Add(this.currentScore);
            this.panel1.Controls.Add(this.currentLife);
            this.panel1.Controls.Add(this.currentTime);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 759);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(644, 63);
            this.panel1.TabIndex = 12;
            // 
            // TimerBlocker
            // 
            this.TimerBlocker.Location = new System.Drawing.Point(248, 4);
            this.TimerBlocker.Margin = new System.Windows.Forms.Padding(4);
            this.TimerBlocker.Name = "TimerBlocker";
            this.TimerBlocker.Size = new System.Drawing.Size(144, 52);
            this.TimerBlocker.TabIndex = 12;
            this.TimerBlocker.Visible = false;
            // 
            // currentScore
            // 
            this.currentScore.AutoSize = true;
            this.currentScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentScore.ForeColor = System.Drawing.Color.White;
            this.currentScore.Location = new System.Drawing.Point(556, 22);
            this.currentScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.currentScore.Name = "currentScore";
            this.currentScore.Size = new System.Drawing.Size(36, 38);
            this.currentScore.TabIndex = 4;
            this.currentScore.Text = "0";
            this.currentScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentLife
            // 
            this.currentLife.AutoSize = true;
            this.currentLife.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentLife.ForeColor = System.Drawing.Color.White;
            this.currentLife.Location = new System.Drawing.Point(152, 23);
            this.currentLife.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.currentLife.Name = "currentLife";
            this.currentLife.Size = new System.Drawing.Size(36, 38);
            this.currentLife.TabIndex = 4;
            this.currentLife.Text = "0";
            this.currentLife.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentTime
            // 
            this.currentTime.AutoSize = true;
            this.currentTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentTime.ForeColor = System.Drawing.Color.White;
            this.currentTime.Location = new System.Drawing.Point(244, 8);
            this.currentTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.currentTime.Name = "currentTime";
            this.currentTime.Size = new System.Drawing.Size(80, 55);
            this.currentTime.TabIndex = 3;
            this.currentTime.Text = "30";
            this.currentTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(35, 23);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 32);
            this.label5.TabIndex = 4;
            this.label5.Text = "LIFE";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(400, 28);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 32);
            this.label4.TabIndex = 4;
            this.label4.Text = "SCORE";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // basicBoard
            // 
            this.basicBoard.BackColor = System.Drawing.Color.Black;
            this.basicBoard.Controls.Add(this.mainGif);
            this.basicBoard.Controls.Add(this.rankingLabel);
            this.basicBoard.Controls.Add(this.playgameLabel);
            this.basicBoard.Controls.Add(this.pictureBox1);
            this.basicBoard.Location = new System.Drawing.Point(275, 13);
            this.basicBoard.Margin = new System.Windows.Forms.Padding(4);
            this.basicBoard.Name = "basicBoard";
            this.basicBoard.Size = new System.Drawing.Size(644, 832);
            this.basicBoard.TabIndex = 1;
            this.basicBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.basicBoard_Paint);
            // 
            // mainGif
            // 
            this.mainGif.Image = global::PacmanForm.Properties.Resources.mainGif;
            this.mainGif.Location = new System.Drawing.Point(4, 715);
            this.mainGif.Margin = new System.Windows.Forms.Padding(4);
            this.mainGif.Name = "mainGif";
            this.mainGif.Size = new System.Drawing.Size(678, 82);
            this.mainGif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.mainGif.TabIndex = 7;
            this.mainGif.TabStop = false;
            // 
            // rankingLabel
            // 
            this.rankingLabel.AutoSize = true;
            this.rankingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rankingLabel.ForeColor = System.Drawing.Color.White;
            this.rankingLabel.Location = new System.Drawing.Point(161, 474);
            this.rankingLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rankingLabel.Name = "rankingLabel";
            this.rankingLabel.Size = new System.Drawing.Size(198, 29);
            this.rankingLabel.TabIndex = 6;
            this.rankingLabel.Text = "VIEW RANKING";
            this.rankingLabel.Click += new System.EventHandler(this.rankingLabel_Click);
            // 
            // playgameLabel
            // 
            this.playgameLabel.AutoSize = true;
            this.playgameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playgameLabel.ForeColor = System.Drawing.Color.White;
            this.playgameLabel.Location = new System.Drawing.Point(198, 403);
            this.playgameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.playgameLabel.Name = "playgameLabel";
            this.playgameLabel.Size = new System.Drawing.Size(157, 29);
            this.playgameLabel.TabIndex = 5;
            this.playgameLabel.Text = "PLAY GAME";
            this.playgameLabel.Click += new System.EventHandler(this.playgameLabel_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(15, 103);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(616, 162);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // PMpanel
            // 
            this.PMpanel.BackColor = System.Drawing.Color.Gray;
            this.PMpanel.Controls.Add(this.PM);
            this.PMpanel.Location = new System.Drawing.Point(30, 30);
            this.PMpanel.Margin = new System.Windows.Forms.Padding(2);
            this.PMpanel.Name = "PMpanel";
            this.PMpanel.Size = new System.Drawing.Size(22, 24);
            this.PMpanel.TabIndex = 3;
            this.PMpanel.Visible = false;
            // 
            // PM
            // 
            this.PM.Image = ((System.Drawing.Image)(resources.GetObject("PM.Image")));
            this.PM.Location = new System.Drawing.Point(0, 0);
            this.PM.Margin = new System.Windows.Forms.Padding(2);
            this.PM.Name = "PM";
            this.PM.Size = new System.Drawing.Size(22, 24);
            this.PM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PM.TabIndex = 2;
            this.PM.TabStop = false;
            // 
            // OGpanel
            // 
            this.OGpanel.BackColor = System.Drawing.Color.Black;
            this.OGpanel.Controls.Add(this.OG);
            this.OGpanel.Location = new System.Drawing.Point(69, 30);
            this.OGpanel.Margin = new System.Windows.Forms.Padding(2);
            this.OGpanel.Name = "OGpanel";
            this.OGpanel.Size = new System.Drawing.Size(22, 24);
            this.OGpanel.TabIndex = 4;
            this.OGpanel.Visible = false;
            // 
            // OG
            // 
            this.OG.Image = global::PacmanForm.Properties.Resources.gdx;
            this.OG.Location = new System.Drawing.Point(0, 0);
            this.OG.Margin = new System.Windows.Forms.Padding(2);
            this.OG.Name = "OG";
            this.OG.Size = new System.Drawing.Size(22, 24);
            this.OG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.OG.TabIndex = 0;
            this.OG.TabStop = false;
            // 
            // BGpanel
            // 
            this.BGpanel.BackColor = System.Drawing.Color.Black;
            this.BGpanel.Controls.Add(this.BG);
            this.BGpanel.Location = new System.Drawing.Point(105, 30);
            this.BGpanel.Margin = new System.Windows.Forms.Padding(2);
            this.BGpanel.Name = "BGpanel";
            this.BGpanel.Size = new System.Drawing.Size(22, 24);
            this.BGpanel.TabIndex = 5;
            this.BGpanel.Visible = false;
            // 
            // BG
            // 
            this.BG.Image = global::PacmanForm.Properties.Resources.asx;
            this.BG.Location = new System.Drawing.Point(0, 0);
            this.BG.Margin = new System.Windows.Forms.Padding(2);
            this.BG.Name = "BG";
            this.BG.Size = new System.Drawing.Size(22, 24);
            this.BG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BG.TabIndex = 0;
            this.BG.TabStop = false;
            // 
            // PGpanel
            // 
            this.PGpanel.BackColor = System.Drawing.Color.Black;
            this.PGpanel.Controls.Add(this.PG);
            this.PGpanel.Location = new System.Drawing.Point(145, 30);
            this.PGpanel.Margin = new System.Windows.Forms.Padding(2);
            this.PGpanel.Name = "PGpanel";
            this.PGpanel.Size = new System.Drawing.Size(22, 24);
            this.PGpanel.TabIndex = 6;
            this.PGpanel.Visible = false;
            // 
            // PG
            // 
            this.PG.Image = global::PacmanForm.Properties.Resources.vsx;
            this.PG.Location = new System.Drawing.Point(0, 0);
            this.PG.Margin = new System.Windows.Forms.Padding(2);
            this.PG.Name = "PG";
            this.PG.Size = new System.Drawing.Size(22, 24);
            this.PG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PG.TabIndex = 0;
            this.PG.TabStop = false;
            // 
            // RGpanel
            // 
            this.RGpanel.BackColor = System.Drawing.Color.Black;
            this.RGpanel.Controls.Add(this.RG);
            this.RGpanel.Location = new System.Drawing.Point(182, 30);
            this.RGpanel.Margin = new System.Windows.Forms.Padding(2);
            this.RGpanel.Name = "RGpanel";
            this.RGpanel.Size = new System.Drawing.Size(22, 24);
            this.RGpanel.TabIndex = 7;
            this.RGpanel.Visible = false;
            // 
            // RG
            // 
            this.RG.Image = global::PacmanForm.Properties.Resources.rdx;
            this.RG.Location = new System.Drawing.Point(0, 0);
            this.RG.Margin = new System.Windows.Forms.Padding(2);
            this.RG.Name = "RG";
            this.RG.Size = new System.Drawing.Size(22, 24);
            this.RG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RG.TabIndex = 0;
            this.RG.TabStop = false;
            // 
            // OtimerR
            // 
            this.OtimerR.Tick += new System.EventHandler(this.OtimerR_Tick);
            // 
            // OtimerL
            // 
            this.OtimerL.Tick += new System.EventHandler(this.OtimerL_Tick);
            // 
            // OtimerD
            // 
            this.OtimerD.Tick += new System.EventHandler(this.OtimerD_Tick);
            // 
            // OtimerU
            // 
            this.OtimerU.Tick += new System.EventHandler(this.OtimerU_Tick);
            // 
            // RtimerR
            // 
            this.RtimerR.Tick += new System.EventHandler(this.RtimerR_Tick);
            // 
            // RtimerL
            // 
            this.RtimerL.Tick += new System.EventHandler(this.RtimerL_Tick);
            // 
            // RtimerD
            // 
            this.RtimerD.Tick += new System.EventHandler(this.RtimerD_Tick);
            // 
            // RtimerU
            // 
            this.RtimerU.Tick += new System.EventHandler(this.RtimerU_Tick);
            // 
            // BtimerR
            // 
            this.BtimerR.Tick += new System.EventHandler(this.BtimerR_Tick);
            // 
            // BtimerL
            // 
            this.BtimerL.Tick += new System.EventHandler(this.BtimerL_Tick);
            // 
            // BtimerD
            // 
            this.BtimerD.Tick += new System.EventHandler(this.BtimerD_Tick);
            // 
            // BtimerU
            // 
            this.BtimerU.Tick += new System.EventHandler(this.BtimerU_Tick);
            // 
            // PtimerR
            // 
            this.PtimerR.Tick += new System.EventHandler(this.PtimerR_Tick);
            // 
            // PtimerL
            // 
            this.PtimerL.Tick += new System.EventHandler(this.PtimerL_Tick);
            // 
            // PtimerD
            // 
            this.PtimerD.Tick += new System.EventHandler(this.PtimerD_Tick);
            // 
            // PtimerU
            // 
            this.PtimerU.Tick += new System.EventHandler(this.PtimerU_Tick);
            // 
            // Sleep
            // 
            this.Sleep.Interval = 1000;
            this.Sleep.Tick += new System.EventHandler(this.Sleep_Tick);
            // 
            // count
            // 
            this.count.Interval = 1000;
            this.count.Tick += new System.EventHandler(this.count_Tick);
            // 
            // rankingBoard
            // 
            this.rankingBoard.BackColor = System.Drawing.Color.Black;
            this.rankingBoard.Controls.Add(this.PreviousMenu_Ranking);
            this.rankingBoard.Controls.Add(this.rankingGif);
            this.rankingBoard.Controls.Add(this.Rank2_label);
            this.rankingBoard.Controls.Add(this.Rank5_label);
            this.rankingBoard.Controls.Add(this.Rank4_label);
            this.rankingBoard.Controls.Add(this.Rank3_label);
            this.rankingBoard.Controls.Add(this.Rank1_label);
            this.rankingBoard.Controls.Add(this.rankingLabelTitle);
            this.rankingBoard.Location = new System.Drawing.Point(32, 317);
            this.rankingBoard.Margin = new System.Windows.Forms.Padding(4);
            this.rankingBoard.Name = "rankingBoard";
            this.rankingBoard.Size = new System.Drawing.Size(646, 822);
            this.rankingBoard.TabIndex = 9;
            // 
            // PreviousMenu_Ranking
            // 
            this.PreviousMenu_Ranking.AutoSize = true;
            this.PreviousMenu_Ranking.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PreviousMenu_Ranking.ForeColor = System.Drawing.Color.White;
            this.PreviousMenu_Ranking.Location = new System.Drawing.Point(289, 758);
            this.PreviousMenu_Ranking.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PreviousMenu_Ranking.Name = "PreviousMenu_Ranking";
            this.PreviousMenu_Ranking.Size = new System.Drawing.Size(134, 32);
            this.PreviousMenu_Ranking.TabIndex = 5;
            this.PreviousMenu_Ranking.Text = "Previous";
            this.PreviousMenu_Ranking.Click += new System.EventHandler(this.PreviousMenu_Ranking_Click);
            // 
            // rankingGif
            // 
            this.rankingGif.Image = global::PacmanForm.Properties.Resources.mainGif2;
            this.rankingGif.Location = new System.Drawing.Point(31, 119);
            this.rankingGif.Margin = new System.Windows.Forms.Padding(4);
            this.rankingGif.Name = "rankingGif";
            this.rankingGif.Size = new System.Drawing.Size(584, 79);
            this.rankingGif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.rankingGif.TabIndex = 4;
            this.rankingGif.TabStop = false;
            // 
            // Rank2_label
            // 
            this.Rank2_label.AutoSize = true;
            this.Rank2_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rank2_label.ForeColor = System.Drawing.Color.Blue;
            this.Rank2_label.Location = new System.Drawing.Point(64, 407);
            this.Rank2_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Rank2_label.Name = "Rank2_label";
            this.Rank2_label.Size = new System.Drawing.Size(197, 32);
            this.Rank2_label.TabIndex = 3;
            this.Rank2_label.Text = "1     TEST    1";
            // 
            // Rank5_label
            // 
            this.Rank5_label.AutoSize = true;
            this.Rank5_label.BackColor = System.Drawing.Color.Transparent;
            this.Rank5_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rank5_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Rank5_label.Location = new System.Drawing.Point(66, 673);
            this.Rank5_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Rank5_label.Name = "Rank5_label";
            this.Rank5_label.Size = new System.Drawing.Size(193, 29);
            this.Rank5_label.TabIndex = 2;
            this.Rank5_label.Text = "4      TEST      4";
            // 
            // Rank4_label
            // 
            this.Rank4_label.AutoSize = true;
            this.Rank4_label.BackColor = System.Drawing.Color.Transparent;
            this.Rank4_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rank4_label.ForeColor = System.Drawing.Color.Gray;
            this.Rank4_label.Location = new System.Drawing.Point(66, 593);
            this.Rank4_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Rank4_label.Name = "Rank4_label";
            this.Rank4_label.Size = new System.Drawing.Size(193, 29);
            this.Rank4_label.TabIndex = 2;
            this.Rank4_label.Text = "3      TEST      3";
            // 
            // Rank3_label
            // 
            this.Rank3_label.AutoSize = true;
            this.Rank3_label.BackColor = System.Drawing.Color.Transparent;
            this.Rank3_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rank3_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Rank3_label.Location = new System.Drawing.Point(66, 504);
            this.Rank3_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Rank3_label.Name = "Rank3_label";
            this.Rank3_label.Size = new System.Drawing.Size(193, 29);
            this.Rank3_label.TabIndex = 2;
            this.Rank3_label.Text = "2      TEST      2";
            // 
            // Rank1_label
            // 
            this.Rank1_label.AutoSize = true;
            this.Rank1_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rank1_label.ForeColor = System.Drawing.Color.Red;
            this.Rank1_label.Location = new System.Drawing.Point(61, 310);
            this.Rank1_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Rank1_label.Name = "Rank1_label";
            this.Rank1_label.Size = new System.Drawing.Size(213, 38);
            this.Rank1_label.TabIndex = 1;
            this.Rank1_label.Text = "0    TEST   0";
            // 
            // rankingLabelTitle
            // 
            this.rankingLabelTitle.AutoSize = true;
            this.rankingLabelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rankingLabelTitle.ForeColor = System.Drawing.Color.White;
            this.rankingLabelTitle.Location = new System.Drawing.Point(149, 70);
            this.rankingLabelTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rankingLabelTitle.Name = "rankingLabelTitle";
            this.rankingLabelTitle.Size = new System.Drawing.Size(237, 52);
            this.rankingLabelTitle.TabIndex = 0;
            this.rankingLabelTitle.Text = "RANKING";
            // 
            // Pacman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(646, 826);
            this.Controls.Add(this.RGpanel);
            this.Controls.Add(this.PGpanel);
            this.Controls.Add(this.BGpanel);
            this.Controls.Add(this.OGpanel);
            this.Controls.Add(this.PMpanel);
            this.Controls.Add(this.basicBoard);
            this.Controls.Add(this.rankingBoard);
            this.Controls.Add(this.tileBoard);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Pacman";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pacman";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Pacman_KeyDown);
            this.tileBoard.ResumeLayout(false);
            this.GameoverPanel.ResumeLayout(false);
            this.GameoverPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.basicBoard.ResumeLayout(false);
            this.basicBoard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainGif)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PMpanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PM)).EndInit();
            this.OGpanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OG)).EndInit();
            this.BGpanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BG)).EndInit();
            this.PGpanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PG)).EndInit();
            this.RGpanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RG)).EndInit();
            this.rankingBoard.ResumeLayout(false);
            this.rankingBoard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rankingGif)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel tileBoard;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel basicBoard;
        private System.Windows.Forms.PictureBox PM;
        private System.Windows.Forms.Panel PMpanel;
        private System.Windows.Forms.Panel OGpanel;
        private System.Windows.Forms.PictureBox OG;
        private System.Windows.Forms.Panel BGpanel;
        private System.Windows.Forms.Panel PGpanel;
        private System.Windows.Forms.PictureBox BG;
        private System.Windows.Forms.PictureBox PG;
        private System.Windows.Forms.Panel RGpanel;
        private System.Windows.Forms.PictureBox RG;
        private System.Windows.Forms.Timer OtimerR;
        private System.Windows.Forms.Timer OtimerL;
        private System.Windows.Forms.Timer OtimerD;
        private System.Windows.Forms.Timer OtimerU;
        private System.Windows.Forms.Timer RtimerR;
        private System.Windows.Forms.Timer RtimerL;
        private System.Windows.Forms.Timer RtimerD;
        private System.Windows.Forms.Timer RtimerU;
        private System.Windows.Forms.Timer BtimerR;
        private System.Windows.Forms.Timer BtimerL;
        private System.Windows.Forms.Timer BtimerD;
        private System.Windows.Forms.Timer BtimerU;
        private System.Windows.Forms.Timer PtimerR;
        private System.Windows.Forms.Timer PtimerL;
        private System.Windows.Forms.Timer PtimerD;
        private System.Windows.Forms.Timer PtimerU;
        private System.Windows.Forms.Label playgameLabel;
        private System.Windows.Forms.PictureBox mainGif;
        private System.Windows.Forms.Label rankingLabel;
        private System.Windows.Forms.Timer Sleep;
        private System.Windows.Forms.Timer count;
        private System.Windows.Forms.Panel GameoverPanel;
        private System.Windows.Forms.Label Endinglabel_life;
        private System.Windows.Forms.Label Ending_lifePT;
        private System.Windows.Forms.Label Ending_ScorePT;
        private System.Windows.Forms.Label Endinglabel_score;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Endinglabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label gameover_ranking_label;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel TimerBlocker;
        private System.Windows.Forms.Label currentScore;
        private System.Windows.Forms.Label currentLife;
        private System.Windows.Forms.Label currentTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel rankingBoard;
        private System.Windows.Forms.Label PreviousMenu_Ranking;
        private System.Windows.Forms.PictureBox rankingGif;
        private System.Windows.Forms.Label Rank2_label;
        private System.Windows.Forms.Label Rank5_label;
        private System.Windows.Forms.Label Rank4_label;
        private System.Windows.Forms.Label Rank3_label;
        private System.Windows.Forms.Label Rank1_label;
        private System.Windows.Forms.Label rankingLabelTitle;
        private System.Windows.Forms.TextBox textBox1;
    }
}

