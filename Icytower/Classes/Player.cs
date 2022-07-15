using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace icy_tower
{
    class Player : Character
    {
        private string name;
        private int score;
        private int jumpSpeed;
        private int force;
        private int figureSpeed;
        private bool offground;
        private bool goingLeft;
        private bool goingRight;
        private bool jumping;
        Bitmap image;
        int leftWalkFrameCounter;
        int rightWalkFrameCounter;
        Bitmap stand;
        List<Bitmap> leftWalks;
        List<Bitmap> rightWalks;
        ProjectilShotByPlayer projectil;
        public Player()
        {
            name = "Jojo";
            score = 0;
            jumpSpeed = 10;
            figureSpeed = 10;
            force = 8;
            goingLeft = false;
            goingRight = false;
            jumping = false;
            tracer = new Color();
            leftWalkFrameCounter = 0;
            rightWalkFrameCounter = 0;
            leftWalks = new List<Bitmap>();
            rightWalks = new List<Bitmap>();
            alive = true;
            projectil = new ProjectilShotByPlayer();
            life = 10;
            offground = false;
        }
        public void keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                goingLeft = true;
            }
            else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                goingRight = true;

            }
            else if ((e.KeyCode == Keys.Up || e.KeyCode == Keys.W) && !jumping)
            {
                jumping = true;
            }  
        }
        public void keyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                goingLeft = false;
            }
            else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                goingRight = false;

            }
            else if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                jumping = false;
            }  
        }
        internal void keyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'J' || e.KeyChar == 'j')
            {
                projectil.pucajlijevo(x, y);
            }

            else if (e.KeyChar == 'L' || e.KeyChar == 'l')
            {
                projectil.pucajdesno(x, y);
            }
        }
        public void Tick(object sender, EventArgs e, Form1 form)
        {
            projectil.Tick(sender, e, form);
            if (projectil.hasHit(form))
            {
                score += 2;
                form.bossIsHit();
            }

            if (figure.Location.Y > 500 || life <= 0)
            {
                Console.WriteLine("i died");
                alive = false;
            }
            figure.Top += jumpSpeed;
            if (jumping && force < 0)
            {
                jumping = false;
            }
            if (jumping)
            {
                force -= 1;
                jumpSpeed = -12;
            }
            else {
                jumpSpeed = 12;
            }
            if (goingLeft && figure.Left > 10)
            {
                figure.Left -= figureSpeed;
            }
            else if (goingRight && figure.Left + (figure.Width + 10) < form.ClientSize.Width)
            {
                figure.Left += figureSpeed;
            }

            foreach (Control c in form.Controls)
            {

                if ((string)c.Tag == "platform") 
                {
                   
                    if (figure.Bounds.IntersectsWith(c.Bounds) && !jumping && c.Top > figure.Top)//detekcija da li player stoji na platformi
                    {
                        force = 8;
                        figure.Top = c.Top - figure.Height + 26;
                        jumpSpeed = 0;
                        score++;
                    }
                }

                if ( (string)c.Tag == "ground" && !offground)
                {

                    if (figure.Bounds.IntersectsWith(c.Bounds) && !jumping && c.Top > figure.Top)//detekcija da li player stoji na platformi
                    {
                        force = 8;
                        figure.Top = c.Top - figure.Height + 26;
                        jumpSpeed = 0;
                        score++;
                    }
                }
                if ((string)c.Tag == "boss" && !form.bossIsDead() && form.bossIsVisible())
                {
                    if (figure.Bounds.IntersectsWith(c.Bounds) )
                    {
                        Console.WriteLine("contact with " + (string)c.Tag);
                        life--;
                    }
                }
                if ((string)c.Tag == "enemy" && !form.enemyIsDead() && form.EnemyIsVisible())
                {
                    if (figure.Bounds.IntersectsWith(c.Bounds))
                    {
                        Console.WriteLine("contact with " + (string)c.Tag);
                        life--;
                    }
                }
                if ((string)c.Tag == "bosscoin" && form.BossCoinDropped() && figure.Bounds.IntersectsWith(c.Bounds))
                {
                    Console.WriteLine("contact with " + (string)c.Tag);
                    score = score + form.BossCoinValue();
                    form.resetBossCoin();
                }
                if ((string)c.Tag == "enemycoin" && form.EnemyCoinDropped() && figure.Bounds.IntersectsWith(c.Bounds))
                {
                    Console.WriteLine("contact with " + (string)c.Tag);
                    score = score + form.EnemyCoinValue();
                    form.resetEnemyCoin();
                }
            }
            x = figure.Location.X;
            y = figure.Location.Y;
            width = figure.Width;
            height = figure.Height;
            
        }

        public void playerTickprojectil(object sender, EventArgs e, Form1 form)
        {
            projectil.Tick(sender, e, form);
            if (projectil.hasHit(form))
            {
                score += 2;
                form.bossIsHit();
            }

        }
        public void restart()
        {
            score = 0;
            jumpSpeed = 10;
            figureSpeed = 10;
            force = 8;
            goingLeft = false;
            goingRight = false;
            jumping = false;
            leftWalkFrameCounter = 0;
            rightWalkFrameCounter = 0;       
            alive = true;
            figure.Location = new Point(100, 350);
            life = 10;
            offground = false;
            projectil.reset();
            x = originalX;
            y = originalY;

        }
        public void paint(object sender, PaintEventArgs e)
        {
            Bitmap walkFrame = returnCurrentWalkFrame();

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            e.Graphics.DrawImage(walkFrame, x, y, width, height);

            projectil.paint(sender, e);

        }
        public override void addImage(Bitmap image)
        {
            this.image = image;
            tracer = image.GetPixel(1, 1);
            this.image.MakeTransparent(tracer);
            figure.Visible = false;

            x = figure.Location.X;
            y = figure.Location.Y;

            height = figure.Height;
            width = figure.Width;

            originalX = x;
            originalY = y;
        }
        public override void addImage(List<Bitmap> images)
        {
            stand = images[0];
            leftWalks.Add(images[1]);
            leftWalks.Add(images[2]);
            leftWalks.Add(images[3]);
            rightWalks.Add(images[4]);
            rightWalks.Add(images[5]);
            rightWalks.Add(images[6]);
        }
        private Bitmap returnCurrentWalkFrame()
        {
            Bitmap returnValue;
            if (goingLeft && leftWalkFrameCounter < leftWalks.Count)
            {
                returnValue = leftWalks[leftWalkFrameCounter];
                leftWalkFrameCounter++;
            }
            else if (goingLeft)
            {
                leftWalkFrameCounter = 0;
                returnValue = leftWalks[leftWalkFrameCounter];
            }
            else if (goingRight && rightWalkFrameCounter < rightWalks.Count)//analogno za hodanje udesno
            {
                returnValue = rightWalks[rightWalkFrameCounter];
                rightWalkFrameCounter++;
            }
            else if (goingRight)
            {
                rightWalkFrameCounter = 0;
                returnValue = rightWalks[rightWalkFrameCounter];
            }
            else
            {
                returnValue = stand;
            }
            tracer = returnValue.GetPixel(1, 1);
            returnValue.MakeTransparent(tracer);

            return returnValue;
        }
        public void addProjectilImage(Bitmap image)
        {
            projectil.addImage(image);
        }

        public void addProjectilImage(List<Bitmap> image)
        {
            projectil.addImage(image);
        }

        public void addProjectilPictureBox(PictureBox picturebox)
        {
            projectil.addImage(picturebox);
        }

        public void removeProjectilPictureBox()
        {
            projectil.removePictureBox();
        }

        public void PickUp(int coinvalue) {
            score += coinvalue;
        }
        public override int X
        {
            set { x = value; figure.Location = new Point(value, figure.Location.Y); }
            get { return x; }
        }

        public override int Y
        {
            set { y = value; figure.Location = new Point(figure.Location.X, value); }
            get { return y; }
        }

        public int Score
        {
            set { score = value; }
            get { return score; }
        }

        public int JumpSpeed
        {
            set { jumpSpeed = value; }
            get { return jumpSpeed; }
        }

        public int Force
        {
            set { force = value; }
            get { return force; }
        }

        public bool offGround 
        {
            set { offground = value; }
            get { return offground; }
        
        
        }

        public string Name
        {
            get { return name; }
        }

   
    }
}
