namespace icy_tower
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.platform_1 = new System.Windows.Forms.PictureBox();
            this.ground_1 = new System.Windows.Forms.PictureBox();
            this.player_1 = new System.Windows.Forms.PictureBox();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.platform_2 = new System.Windows.Forms.PictureBox();
            this.platform_3 = new System.Windows.Forms.PictureBox();
            this.platform_4 = new System.Windows.Forms.PictureBox();
            this.platform_5 = new System.Windows.Forms.PictureBox();
            this.platform_6 = new System.Windows.Forms.PictureBox();
            this.platform_7 = new System.Windows.Forms.PictureBox();
            this.platform_8 = new System.Windows.Forms.PictureBox();
            this.platform_9 = new System.Windows.Forms.PictureBox();
            this.menuButton_1 = new System.Windows.Forms.PictureBox();
            this.menuButton_2 = new System.Windows.Forms.PictureBox();
            this.projectilPictureBox = new System.Windows.Forms.PictureBox();
            this.bossTickMovement = new System.Windows.Forms.Timer(this.components);
            this.boss_1 = new System.Windows.Forms.PictureBox();
            this.bossProjectilPictureBox = new System.Windows.Forms.PictureBox();
            this.bosscoinPictureBox = new System.Windows.Forms.PictureBox();
            this.enemy_1 = new System.Windows.Forms.PictureBox();
            this.enemycoinPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.platform_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ground_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.platform_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.platform_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.platform_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.platform_5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.platform_6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.platform_7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.platform_8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.platform_9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuButton_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuButton_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectilPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boss_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bossProjectilPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bosscoinPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemycoinPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // platform_1
            // 
            this.platform_1.Location = new System.Drawing.Point(207, 336);
            this.platform_1.Margin = new System.Windows.Forms.Padding(2);
            this.platform_1.Name = "platform_1";
            this.platform_1.Size = new System.Drawing.Size(115, 52);
            this.platform_1.TabIndex = 2;
            this.platform_1.TabStop = false;
            this.platform_1.Tag = "platform";
            // 
            // ground_1
            // 
            this.ground_1.Location = new System.Drawing.Point(-10, 483);
            this.ground_1.Margin = new System.Windows.Forms.Padding(2);
            this.ground_1.Name = "ground_1";
            this.ground_1.Size = new System.Drawing.Size(770, 72);
            this.ground_1.TabIndex = 1;
            this.ground_1.TabStop = false;
            this.ground_1.Tag = "ground";
            // 
            // player_1
            // 
            this.player_1.BackColor = System.Drawing.Color.Black;
            this.player_1.Location = new System.Drawing.Point(86, 388);
            this.player_1.Margin = new System.Windows.Forms.Padding(2);
            this.player_1.Name = "player_1";
            this.player_1.Size = new System.Drawing.Size(60, 91);
            this.player_1.TabIndex = 0;
            this.player_1.TabStop = false;
            this.player_1.Tag = "player";
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTick);
            // 
            // platform_2
            // 
            this.platform_2.Location = new System.Drawing.Point(495, 254);
            this.platform_2.Margin = new System.Windows.Forms.Padding(2);
            this.platform_2.Name = "platform_2";
            this.platform_2.Size = new System.Drawing.Size(115, 52);
            this.platform_2.TabIndex = 3;
            this.platform_2.TabStop = false;
            this.platform_2.Tag = "platform";
            // 
            // platform_3
            // 
            this.platform_3.Location = new System.Drawing.Point(262, 169);
            this.platform_3.Margin = new System.Windows.Forms.Padding(2);
            this.platform_3.Name = "platform_3";
            this.platform_3.Size = new System.Drawing.Size(115, 52);
            this.platform_3.TabIndex = 4;
            this.platform_3.TabStop = false;
            this.platform_3.Tag = "platform";
            // 
            // platform_4
            // 
            this.platform_4.Location = new System.Drawing.Point(114, 38);
            this.platform_4.Margin = new System.Windows.Forms.Padding(2);
            this.platform_4.Name = "platform_4";
            this.platform_4.Size = new System.Drawing.Size(115, 52);
            this.platform_4.TabIndex = 5;
            this.platform_4.TabStop = false;
            this.platform_4.Tag = "platform";
            // 
            // platform_5
            // 
            this.platform_5.Location = new System.Drawing.Point(430, -31);
            this.platform_5.Margin = new System.Windows.Forms.Padding(2);
            this.platform_5.Name = "platform_5";
            this.platform_5.Size = new System.Drawing.Size(115, 52);
            this.platform_5.TabIndex = 6;
            this.platform_5.TabStop = false;
            this.platform_5.Tag = "platform";
            // 
            // platform_6
            // 
            this.platform_6.Location = new System.Drawing.Point(154, 245);
            this.platform_6.Margin = new System.Windows.Forms.Padding(2);
            this.platform_6.Name = "platform_6";
            this.platform_6.Size = new System.Drawing.Size(115, 52);
            this.platform_6.TabIndex = 7;
            this.platform_6.TabStop = false;
            this.platform_6.Tag = "platform";
            // 
            // platform_7
            // 
            this.platform_7.Location = new System.Drawing.Point(416, 103);
            this.platform_7.Margin = new System.Windows.Forms.Padding(2);
            this.platform_7.Name = "platform_7";
            this.platform_7.Size = new System.Drawing.Size(115, 52);
            this.platform_7.TabIndex = 8;
            this.platform_7.TabStop = false;
            this.platform_7.Tag = "platform";
            // 
            // platform_8
            // 
            this.platform_8.Location = new System.Drawing.Point(187, 38);
            this.platform_8.Margin = new System.Windows.Forms.Padding(2);
            this.platform_8.Name = "platform_8";
            this.platform_8.Size = new System.Drawing.Size(115, 52);
            this.platform_8.TabIndex = 9;
            this.platform_8.TabStop = false;
            this.platform_8.Tag = "platform";
            // 
            // platform_9
            // 
            this.platform_9.Location = new System.Drawing.Point(416, -1);
            this.platform_9.Margin = new System.Windows.Forms.Padding(2);
            this.platform_9.Name = "platform_9";
            this.platform_9.Size = new System.Drawing.Size(115, 52);
            this.platform_9.TabIndex = 10;
            this.platform_9.TabStop = false;
            this.platform_9.Tag = "platform";
            // 
            // menuButton_1
            // 
            this.menuButton_1.Location = new System.Drawing.Point(29, 230);
            this.menuButton_1.Margin = new System.Windows.Forms.Padding(2);
            this.menuButton_1.Name = "menuButton_1";
            this.menuButton_1.Size = new System.Drawing.Size(75, 41);
            this.menuButton_1.TabIndex = 11;
            this.menuButton_1.TabStop = false;
            this.menuButton_1.Tag = "button";
            this.menuButton_1.Click += new System.EventHandler(this.startClick);
            // 
            // menuButton_2
            // 
            this.menuButton_2.Location = new System.Drawing.Point(29, 303);
            this.menuButton_2.Margin = new System.Windows.Forms.Padding(2);
            this.menuButton_2.Name = "menuButton_2";
            this.menuButton_2.Size = new System.Drawing.Size(75, 41);
            this.menuButton_2.TabIndex = 12;
            this.menuButton_2.TabStop = false;
            this.menuButton_2.Tag = "button";
            this.menuButton_2.Click += new System.EventHandler(this.quitClick);
            // 
            // projectilPictureBox
            // 
            this.projectilPictureBox.Location = new System.Drawing.Point(-100, -100);
            this.projectilPictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.projectilPictureBox.Name = "projectilPictureBox";
            this.projectilPictureBox.Size = new System.Drawing.Size(45, 37);
            this.projectilPictureBox.TabIndex = 13;
            this.projectilPictureBox.TabStop = false;
            this.projectilPictureBox.Tag = "playerprojectil";
            // 
            // boss_1
            // 
            this.boss_1.Location = new System.Drawing.Point(549, 386);
            this.boss_1.Margin = new System.Windows.Forms.Padding(2);
            this.boss_1.Name = "boss_1";
            this.boss_1.Size = new System.Drawing.Size(61, 93);
            this.boss_1.TabIndex = 14;
            this.boss_1.TabStop = false;
            this.boss_1.Tag = "boss";
            // 
            // bossProjectilPictureBox
            // 
            this.bossProjectilPictureBox.Location = new System.Drawing.Point(-100, -100);
            this.bossProjectilPictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.bossProjectilPictureBox.Name = "bossProjectilPictureBox";
            this.bossProjectilPictureBox.Size = new System.Drawing.Size(33, 40);
            this.bossProjectilPictureBox.TabIndex = 15;
            this.bossProjectilPictureBox.TabStop = false;
            this.bossProjectilPictureBox.Tag = "bossprojectil";
            // 
            // bosscoinPictureBox
            // 
            this.bosscoinPictureBox.Location = new System.Drawing.Point(669, 483);
            this.bosscoinPictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.bosscoinPictureBox.Name = "bosscoinPictureBox";
            this.bosscoinPictureBox.Size = new System.Drawing.Size(60, 60);
            this.bosscoinPictureBox.TabIndex = 16;
            this.bosscoinPictureBox.TabStop = false;
            this.bosscoinPictureBox.Tag = "bosscoin";
            // 
            // enemy_1
            // 
            this.enemy_1.Location = new System.Drawing.Point(549, 386);
            this.enemy_1.Margin = new System.Windows.Forms.Padding(2);
            this.enemy_1.Name = "enemy_1";
            this.enemy_1.Size = new System.Drawing.Size(61, 93);
            this.enemy_1.TabIndex = 17;
            this.enemy_1.TabStop = false;
            this.enemy_1.Tag = "enemy";
            // 
            // enemycoinPictureBox
            // 
            this.enemycoinPictureBox.Location = new System.Drawing.Point(669, 483);
            this.enemycoinPictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.enemycoinPictureBox.Name = "enemycoinPictureBox";
            this.enemycoinPictureBox.Size = new System.Drawing.Size(60, 60);
            this.enemycoinPictureBox.TabIndex = 18;
            this.enemycoinPictureBox.TabStop = false;
            this.enemycoinPictureBox.Tag = "enemycoin";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 541);
            this.Controls.Add(this.bossProjectilPictureBox);
            this.Controls.Add(this.boss_1);
            this.Controls.Add(this.projectilPictureBox);
            this.Controls.Add(this.menuButton_2);
            this.Controls.Add(this.menuButton_1);
            this.Controls.Add(this.platform_9);
            this.Controls.Add(this.platform_8);
            this.Controls.Add(this.platform_7);
            this.Controls.Add(this.platform_6);
            this.Controls.Add(this.platform_5);
            this.Controls.Add(this.platform_4);
            this.Controls.Add(this.platform_3);
            this.Controls.Add(this.platform_2);
            this.Controls.Add(this.platform_1);
            this.Controls.Add(this.ground_1);
            this.Controls.Add(this.player_1);
            this.Controls.Add(this.enemy_1);
            this.Controls.Add(this.bosscoinPictureBox);
            this.Controls.Add(this.enemycoinPictureBox);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.platform_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ground_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.platform_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.platform_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.platform_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.platform_5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.platform_6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.platform_7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.platform_8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.platform_9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuButton_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuButton_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectilPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boss_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bossProjectilPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bosscoinPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemycoinPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox player_1;
        private System.Windows.Forms.PictureBox ground_1;
        private System.Windows.Forms.PictureBox platform_1;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.PictureBox platform_2;
        private System.Windows.Forms.PictureBox platform_3;
        private System.Windows.Forms.PictureBox platform_4;
        private System.Windows.Forms.PictureBox platform_5;
        private System.Windows.Forms.PictureBox platform_6;
        private System.Windows.Forms.PictureBox platform_7;
        private System.Windows.Forms.PictureBox platform_8;
        private System.Windows.Forms.PictureBox platform_9;
        private System.Windows.Forms.PictureBox menuButton_1;
        private System.Windows.Forms.PictureBox menuButton_2;
        private System.Windows.Forms.PictureBox projectilPictureBox;
        private System.Windows.Forms.Timer bossTickMovement;
        private System.Windows.Forms.PictureBox boss_1;
        private System.Windows.Forms.PictureBox bossProjectilPictureBox;
        private System.Windows.Forms.PictureBox bosscoinPictureBox;
        private System.Windows.Forms.PictureBox enemy_1;
        private System.Windows.Forms.PictureBox enemycoinPictureBox;
    }
}

