using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace icy_tower
{
    class Coin : IImageControl
    {
        private int x, y;
        private int width, height;
        private int coinvalue;
        private bool dropped;
        Color tracer;
        protected System.Windows.Forms.PictureBox figure;
        Bitmap image;
        public Coin() {
            tracer = new Color();
            dropped = false;
            coinvalue = 1;

            x = -100;
            y = -100;
        }
        public Coin(int cv)
        {
            dropped = false;
            coinvalue = cv;

            x = -100;
           y = -100;
        }
        Coin(int x_wheretodrop, int y_wheretodrop) : this() {
            x = x_wheretodrop;
            y = y_wheretodrop;
        }



        public virtual void Tick(object sender, EventArgs e, Form1 form)
        {
        }
        public void drop(int x_wheretodrop, int y_wheretodrop) 
        {
            dropped = true;
            x = x_wheretodrop;
            y = y_wheretodrop;

            figure.Visible = false;
            figure.Location = new Point(x, y);
        }
        public void reset() {
            if (!dropped) return;
            dropped = false;
            figure.Visible = false;
            figure.Location = new Point(-100, y);
        }
        public void setLocation(int x_wheretodrop, int y_wheretodrop) 
        {
            x = x_wheretodrop;
            y = y_wheretodrop;
        }
        public void MoveDown(int PlatformSpeed)
        {
            Y += PlatformSpeed;

            if (Y > 490)
            {
               Y = -410;
                this.reset();
            }
        }
        public void paint(object sender, PaintEventArgs e)
        {
            tracer = image.GetPixel(1, 1);
            image.MakeTransparent(tracer);


            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            e.Graphics.DrawImage(image, x, y, width, height);
        }
        public void addImage(System.Windows.Forms.PictureBox figure)
        {
            this.figure = figure;
            copyFigureInformation();
        }
        public void removePictureBox()
        {
            figure = null;
        }

        public void addImage(Bitmap picture)
        {
            image=picture;
            copyFigureInformation();
        }
        protected void copyFigureInformation()
        {
            figure.Visible = false;
            x = figure.Location.X;
            y = figure.Location.Y;
            width = figure.Width;
            height = figure.Height;
            figure.Location = new Point(x, y);
        }
        public int X
        {
            get { return x; }
            set { x = value; figure.Location = new Point(value, y); }
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
        public int CoinValue
        {
            set { coinvalue = value; }
            get { return coinvalue; }
        }
        
        public bool Dropped
        {
            set { dropped = value; }
            get { return dropped; }
        }
        
    }
}
