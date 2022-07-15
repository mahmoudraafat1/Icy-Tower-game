using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace icy_tower
{
    class Projectil : IImageControl
    {
        protected PictureBox figure;
        protected int x, y;
        protected int width, height;
        protected int projectilSpeed;
        protected Color tracer;
        protected List<Bitmap> images;
        protected int frameCounter;
        protected bool fired;
        protected bool left, right;
        private bool visible;
        public Projectil()
        {
            images = new List<Bitmap>();
            tracer = new Color();
            projectilSpeed = 15;
            frameCounter = 0;
            fired = false;
            left = false;
            right = false;
            x = -100;
            y = -100;
            visible = false;
        }
        public virtual void MoveDown(int PlatformSpeed)
        {
            Y += PlatformSpeed;


            if (Y > 490)
            {
                Y = -410;
                this.reset();
            }
        }

        public void Tick(object sender, EventArgs e, Form1 form)
        {
            if (!Fired) { X = -100; setVisibility(false);  return; }
            if (right)
            {
                figure.Left += projectilSpeed;
            }
            else if (left)
            {
                figure.Left -= projectilSpeed;
            }
            if (x + width > form.ClientSize.Width || x < 0 || y + height > form.ClientSize.Height || y < 0)
            {
                this.reset();
                return;
            };
            x = figure.Location.X;
            y = figure.Location.Y;
            width = figure.Width;
            height = figure.Height;

        }
        public void pucajlijevo(int shooter_x, int shooter_y)
        {
            left = true;
            right = false;
            setVisibility(true);

            figure.Location = new Point(shooter_x, shooter_y + 10);

            x = shooter_x;
            y = shooter_y + 10;
        }
        public void pucajdesno(int shooter_x, int shooter_y)
        {
            right = true;
            left = false;
            setVisibility(true);
            

            figure.Location = new Point(shooter_x, shooter_y + 10);

            x = shooter_x;
            y = shooter_y + 10;
        }
        public void pucaj(int shooter_x, int shooter_y) {
            setVisibility(true);


            figure.Location = new Point(shooter_x, shooter_y + 10);

            x = shooter_x;
            y = shooter_y + 10;

        }
        public void reset() {
            frameCounter = 0;
            setVisibility(false);
            left = false;
            right = false;
            X = -100;
            Y = -100;
        }
        public virtual bool hasHit(Form1 form)
        {
            return false;
        }
        public void addImage(PictureBox figure)
        {
            this.figure = figure;
            


        }
        public void removePictureBox()
        {
            this.figure = null;

        }
        public void paint(object sender, PaintEventArgs e)
        {
            if (!Fired)  return;

            Bitmap frame = returnNewFrame();
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            e.Graphics.DrawImage(frame, x, y, width, height);
        }

        public void addImage(List<Bitmap> images)
        {
            this.images = images;
            copyFigureInformation();
            
        }

        public void addImage(Bitmap image)
        {
            this.images.Add(image);
            copyFigureInformation();
        }

        private void copyFigureInformation()
        {

            setVisibility(false);
            height = figure.Height + 70;
            width = figure.Width + 70;
        }

        public virtual void setVisibility(bool b)
        {
            Fired = b;
            if (b = true) { figure.Visible = false; visible = true; } else { figure.Visible = false; }
        }
        public Bitmap returnNewFrame()
        {
            Bitmap returnValue = images[0];

            if(frameCounter < images.Count)
            {
                returnValue = images[frameCounter];
                frameCounter++;
            }

            if (frameCounter == images.Count)
            {
                frameCounter = 0;
            }

            tracer = returnValue.GetPixel(1, 1);
            returnValue.MakeTransparent(tracer);

            return returnValue;
        
        }
        public int X
        {
            get { return x; }
            set { x = value; figure.Location = new Point(value, figure.Location.Y); }
        }

        public int Y
        {
            get { return y; }
            set { y = value; figure.Location = new Point(x, value); }
        }

        public int Width
        {
            set { width = value; }
            get { return width; }
        }
        public int Height
        {
            set { height = value; }
            get { return height; }
        }

        public int ProjectilSpeed
        {
            set { projectilSpeed = value; }
            get { return ProjectilSpeed; }
        }

        public bool Fired
        {
            set { fired = value; }
            get { return fired; }
        }

        public bool Left
        {
            set { left = value; }
            get { return left; }
        }

        public bool Right
        {
            set { right = value; }
            get { return right; }
        }
    }
}
