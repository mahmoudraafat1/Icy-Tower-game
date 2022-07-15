using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace icy_tower
{
    class Enemy : Character
    {
        protected Bitmap image;
        protected int leftlimit_x;
        protected int rightlimit_x;
        public Enemy() : base() {
            leftlimit_x = 50;
            rightlimit_x = 670;
        }
        public Enemy(int l) : base(l) {
            leftlimit_x = 50;
            rightlimit_x = 670;
        }
        public virtual void MoveDown(int PlatformSpeed) {
            Y += PlatformSpeed;

            if (Y > 490) { 
                Y = -410;
                this.revive();
            }
        }


        public virtual void Tick(object sender, EventArgs e, Form1 form)
        {
        }


        public virtual void restart()
        {
            revive();

        }

        public virtual void setLocation(int platform_x, int platform_y, int platform_width) {
            x = platform_x+platform_width/2-60;
            y = platform_y-70;

            figure.Location = new Point(x, y);

            leftlimit_x = platform_x-100;
            rightlimit_x = platform_x + platform_width+200;
            /*
            if(leftlimit_x > 310)
            {
                y+=50;
                
            }
            */
          

            originalX = X;
            originalY = Y;

        }
        public virtual void paint(object sender, PaintEventArgs e)
        {
            figure.Visible = false;
            tracer = image.GetPixel(1, 1);
            image.MakeTransparent(tracer);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            e.Graphics.DrawImage(image, x, y, width, height);
        }
        public override void addImage(Bitmap image)
        {
            this.image = image;
            copyFigureInformation();
        }
        public override int X
        {
            get { return x; }
            set { x = value; figure.Location = new Point(value, y); }
        }
        public override int Y
        {
            get { return y; }
            set { y = value; figure.Location = new Point(x, value); }
        }


    }
}
