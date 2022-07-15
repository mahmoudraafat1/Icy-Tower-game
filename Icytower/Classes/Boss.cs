using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace icy_tower
{
    class Boss : Enemy
    {
        private int bossSpeed;
        ProjectilShotByBoss projectil;
        private bool left;
        public Boss():base()
        {
            projectil = new ProjectilShotByBoss();
            bossSpeed = 3;
            left = true;
        }
        public Boss(int l) : base(l)
        {
            projectil = new ProjectilShotByBoss();
            bossSpeed = 3;
            left = true;
        }
        public override void MoveDown(int PlatformSpeed)
        {
            Y += PlatformSpeed;
            projectil.MoveDown(PlatformSpeed);

            if (Y > 490)
            {
                Y = -410;
                this.revive();
                this.resetProjectile();
            }
        }
    

    public override void Tick(object sender, EventArgs e, Form1 form)
        {
            projectil.Tick(sender, e, form);
            if (projectil.hasHit(form))
            {
                form.playerIsHit();
            }
            if (left)
            {
                figure.Left -= bossSpeed;
                X -= bossSpeed;
            }
            else {
                figure.Left += bossSpeed;
                X += bossSpeed;
            }

            if (X > rightlimit_x)
            {
                left = true;

                projectil.pucajlijevo(X, Y);      
            }

            if (X < leftlimit_x)
            {
                left = false;

                projectil.pucajdesno(X, Y);
            }

        }
        public override void restart()
        {
            bossSpeed = 3;
            left = true;
            resetProjectile();
            resetProjectile();

            tracer = new Color();
            revive();
            reset_position();

            figure.Visible = false;
        }


        public void resetProjectile() {
            projectil.reset();

        }

        public override void paint(object sender, PaintEventArgs e)
        {
            figure.Visible = false;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            e.Graphics.DrawImage(image, x, y, width, height);

            projectil.paint(sender, e);

        }
        public override void addImage(Bitmap image)
        {
            this.image = image;
            copyFigureInformation();
        }
        protected override void copyFigureInformation()
        {

            x = figure.Location.X;
            y = figure.Location.Y + 20;

            height = figure.Height;
            width = figure.Width;

            originalX = figure.Location.X;
            originalY = figure.Location.Y + 20;

            figure.Location = new Point(x, originalY);
        }

        public override void isHit()
        {
            life--;
            if (life <= 0)
            {
                alive = false;
                setVisibility(false);
                resetProjectile();
            }


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


    }
}
