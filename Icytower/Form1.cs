using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace icy_tower
{
    public partial class Form1 : Form
    {
        bool menuFlag;
        bool gameFlag;
        bool endgameFlag;
        Player player;
        Enemy enemy;
        Coin enemycoin;
        Boss boss;
        Coin bosscoin;
        List<Platform> allPlatforms;
        List<Platform> copyAllPlatforms;
        Platform ground;
        int platformSpeed;
        bool platformMoving;
        Menu menu;
        int bossScore;

        private string playerName;
        public Form1()
        {
            InitializeComponent();
            menuFlag = true;
            gameFlag = false;
            endgameFlag = false;
            bossScore = 250;
            menu = new Menu();
            player = new Player();
            enemy = new Enemy(1);
            boss = new Boss(2);
            enemycoin = new Coin();
            bosscoin = new Coin(2);
            ground = new Platform();
            platformSpeed = 2;
            platformMoving = false;
            allPlatforms = new List<Platform>();
            allPlatforms.Add(ground);
            allPlatforms.Add(new Platform(platform_1, Properties.Resources.b_fotfor_lush2));
            allPlatforms.Add(new Platform(platform_2, Properties.Resources.b_fotfor_lush2));
            allPlatforms.Add(new Platform(platform_3, Properties.Resources.b_fotfor_lush2));
            allPlatforms.Add(new Platform(platform_4, Properties.Resources.b_fotfor_lush2));
            allPlatforms.Add(new Platform(platform_5, Properties.Resources.b_fotfor_lush2));
            platform_6.Location = new Point(platform_6.Location.X, -110);
            platform_7.Location = new Point(platform_7.Location.X, -210);
            platform_8.Location = new Point(platform_8.Location.X, -310);
            platform_9.Location = new Point(platform_9.Location.X, -410);
            allPlatforms.Add(new Platform(platform_6, Properties.Resources.b_fotfor_lush2));
            allPlatforms.Add(new Platform(platform_7, Properties.Resources.b_fotfor_lush2));
            allPlatforms.Add(new Platform(platform_8, Properties.Resources.b_fotfor_lush2));
            allPlatforms.Add(new Platform(platform_9, Properties.Resources.b_fotfor_lush2));
            copyAllPlatforms = new List<Platform>(allPlatforms);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.BackColor = Color.Black;
            this.BackgroundImage = Properties.Resources.background;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            
            menu.addPictureBoxAndImage(menuButton_1, Properties.Resources.startImage3);
            menu.addPictureBoxAndImage(menuButton_2, Properties.Resources.quitImage3);
            //menu.addPictureBoxAndImage(menuButton_3, Properties.Resources.playerImage3);
            //menu.addPictureBoxAndImage(menuButton_4, Properties.Resources.highscoreImage3);
            
            ground.addImage(ground_1);
            ground.addImage(Properties.Resources.b_fotfor_lush2);
            List<Bitmap> playerImages = new List<Bitmap>();
            playerImages.Add(Properties.Resources.stand);
            playerImages.Add(Properties.Resources.walkLeft_1);
            playerImages.Add(Properties.Resources.walkLeft_2);
            playerImages.Add(Properties.Resources.walkLeft_3);
            playerImages.Add(Properties.Resources.walkRight_1);
            playerImages.Add(Properties.Resources.walkRight_2);
            playerImages.Add(Properties.Resources.walkRight_3);
            player.addImage(player_1);
            player.addImage(Properties.Resources.stand);
            player.addImage(playerImages);
            boss.addImage(boss_1);
            boss.addImage(Properties.Resources.bossPicture);
            enemy.addImage(enemy_1);
            enemy.addImage(Properties.Resources.enemy);
            bosscoin.addImage(bosscoinPictureBox);
            bosscoin.addImage(Properties.Resources.coin);
            enemycoin.addImage(enemycoinPictureBox);
            enemycoin.addImage(Properties.Resources.coin);
            player.addProjectilPictureBox(projectilPictureBox);

            player.addProjectilImage(Properties.Resources.projectil2_1);
            player.addProjectilImage(Properties.Resources.projectil2_2);
            player.addProjectilImage(Properties.Resources.projectil2_3);
            player.addProjectilImage(Properties.Resources.projectil2_4);
            boss.addProjectilPictureBox(bossProjectilPictureBox);

            boss.addProjectilImage(Properties.Resources.projectil2_1);
            boss.addProjectilImage(Properties.Resources.projectil2_2);
            boss.addProjectilImage(Properties.Resources.projectil2_3);
            boss.addProjectilImage(Properties.Resources.projectil2_4);
            player.X = 282;
            player.Y = 400;

            playerName = "default";
            allPlatforms[5].Add(boss, bosscoin);
            allPlatforms[8].Add(enemy, enemycoin);
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (menuFlag)
            {
                menu.menuPaint(sender, e);
            }
            else if (gameFlag)
            {
                player.paint(sender, e);
                foreach (Platform p in allPlatforms)
                {
                    p.platformPaint(sender, e);
                }
                if (boss.Visible && player.Score >= bossScore) boss.paint(sender, e);
                if (enemy.Visible) enemy.paint(sender, e);
                if (enemycoin.Dropped) enemycoin.paint(sender, e);
                if (bosscoin.Dropped) bosscoin.paint(sender, e);
            }
            else if (endgameFlag)
            {
                menu.menuPaint(sender, e);
            }

        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameFlag)
            {
                player.keyDown(sender, e);
            }

        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (gameFlag)
            {
                player.keyUp(sender, e);
            }

        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            player.keyPress(sender, e);
        }
        private void startClick(object sender, EventArgs e)
        {
           // highscoreUserControl.Visible = false;
            if (menuFlag)
            {
                menuFlag = false;
                gameFlag = true;
                endgameFlag = false;
                menu.Visible(false);
            }
        }
        private void quitClick(object sender, EventArgs e)
        {
            if (menuFlag)
            {
                this.Close();
            }
        }
        private void playerClick(object sender, EventArgs e)
        {
          //  highscoreUserControl.Visible = false;
            if (menuFlag)
            {
                playerName = Interaction.InputBox("Enter your name!", "Player name input", "Player", 100, 100);
            }
        }
        private void Form1_Click(object sender, EventArgs e)
        {

            if (gameFlag)
            {
            }

        }
        private void gameTick(object sender, EventArgs e)
        {

            if (!player.Alive)
            {
                setHighscore();
                endgameFlag = true;
                menuFlag = true;
                menu.Visible(true);
                gameFlag = false;
                restartGame();
                
            }

            if (gameFlag)
            {
                player.Tick(sender, e, this);
                platformTick(sender, e);
                if (player.Score >= bossScore && !boss.isDead()) { boss.setVisibility(true); } else { boss.setVisibility(false); }
                if (!enemy.isDead()) { enemy.setVisibility(true); } else { enemy.setVisibility(false); }

            }


            Invalidate();//poziva Form1_Paint metodu

        }

        private void setHighscore()
        {
            int x = player.Score;

            string[] lines = System.IO.File.ReadAllLines("highscoreList.txt");
            var map = new Dictionary<string, int>();

            foreach (string s in lines)
            {
                string tmpName = s.Split(',')[0];
                int tmpScore = Int32.Parse(s.Split(',')[1]);
                map.Add(tmpName, tmpScore);
            }

            if (map.ContainsKey(playerName))
            {
                int value;
                map.TryGetValue(playerName, out value);

                if (x > value)
                {
                    map.Remove(playerName);
                    map.Add(playerName, x);

                    var myList = map.ToList();
                    myList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));
                    writeInFile(myList);
                }
            }
            else 
            {
                map.Add(playerName, x);
                var myList = map.ToList();
                myList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));

                writeInFile(myList);
            }
        }


        private void writeInFile(List<KeyValuePair<string, int>> map)
        {
            List<string> lines = new List<string>();
            foreach (var item in map)
            {
                lines.Add(item.Key + "," + item.Value);
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter("highscoreList.txt"))
            {
                foreach (string line in lines)
                {
                    file.WriteLine(line);   
                }
            }
        }
        private void platformTick(object sender, EventArgs e)
        {
            if (player.offGround == true) {
                allPlatforms.Remove(ground);
            }
            foreach (Platform p in allPlatforms)
            {
                if (player.Y < 200 && !player.offGround)
                {
                    player.offGround = true;
                    platformMoving = true;
                }
                if (platformMoving)
                {
                    p.MoveDown(platformSpeed);
                }
                p.Tick_X(sender, e, this);
            }

        }
        private void restartGame()
        {
            player.restart();
            platformRestart();

        }
        private void platformRestart()
        {
            List<Platform> tmp = new List<Platform>();
            tmp.Add(ground);

            foreach (Platform p in allPlatforms)
            {
                tmp.Add(p);
            }

            allPlatforms = tmp;
            foreach (Platform p in allPlatforms)
            {
                p.restart();
            }
            platformMoving = false;
            player.offGround = false;
        }

        public void playerIsHit()
        {
            player.isHit();
        }

        public void bossIsHit()
        {
            boss.isHit();
        }

        public void enemyIsHit()
        {

            enemy.isHit();

        }

        public void hasPickedUp(int coinvalue)
        {
            player.PickUp(coinvalue);
        }
        private void highscoreClick(object sender, EventArgs e)
        {
            if (!menuFlag)
            {
                return;
            }

            string[] lines = System.IO.File.ReadAllLines("highscoreList.txt");
        /*
            highscoreUserControl.Label1 = "1. " + lines[0].Split(',')[0] + " " + lines[0].Split(',')[1];
            highscoreUserControl.Label2 = "2. " + lines[1].Split(',')[0] + " " + lines[1].Split(',')[1];
            highscoreUserControl.Label3 = "3. " + lines[2].Split(',')[0] + " " + lines[2].Split(',')[1];
            highscoreUserControl.Label4 = "4. " + lines[3].Split(',')[0] + " " + lines[3].Split(',')[1];
            highscoreUserControl.Label5 = "5. " + lines[4].Split(',')[0] + " " + lines[4].Split(',')[1];
            highscoreUserControl.Label6 = "6. " + lines[5].Split(',')[0] + " " + lines[5].Split(',')[1];
            highscoreUserControl.Label7 = "7. " + lines[6].Split(',')[0] + " " + lines[6].Split(',')[1];
            highscoreUserControl.Label8 = "8. " + lines[7].Split(',')[0] + " " + lines[7].Split(',')[1];
            highscoreUserControl.Label9 = "9. " + lines[8].Split(',')[0] + " " + lines[8].Split(',')[1];
            highscoreUserControl.Label10 = "10. " + lines[9].Split(',')[0] + " " + lines[9].Split(',')[1];

          
            highscoreUserControl.Visible = true;
        */
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public bool bossIsDead()
        {
            return boss.isDead();
        }

        public bool enemyIsDead()
        {
            return enemy.isDead();
        }

        public bool bossIsVisible()
        {
            return boss.Visible;
        }

        public bool EnemyIsVisible()
        {
            return enemy.Visible;
        }

        public bool EnemyCoinDropped()
        {
            return enemycoin.Dropped;
        }

        public bool BossCoinDropped()
        {
            return bosscoin.Dropped;
        }

        public int BossCoinValue()
        {
            return bosscoin.CoinValue;
        }

        public int EnemyCoinValue()
        {
            return enemycoin.CoinValue;
        }

        public void resetBossCoin()
        {
            bosscoin.reset();
        }

        public void resetEnemyCoin()
        {
            enemycoin.reset();
        }
    }
}


