using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace icy_tower
{
    class Platform : IImageControl
    {
        private System.Windows.Forms.PictureBox platform;
        private Color tracer;
        private Bitmap image;
        private int x, y;
        private int width, height;
        private int originalX, originalY;
        private int originalWidth, originalHeight;
        private int originalPlatformType;
       Enemy enemy;
       Boss boss;
        Coin coin;
        private int platformType;
        public Platform() {
            tracer = new Color();
            enemy = null;
            boss = null;
            coin = null;
           

            platformType = 0;
            originalPlatformType = 0;
            x = 0;
            y = 0;
            height = 1;
            width = 2;

        }
        public Platform(System.Windows.Forms.PictureBox figure, Bitmap image)
        {
            tracer = new Color();
            platform = figure;
            addImage(image);
            enemy = null;
            boss = null;
            coin = null;

            platformType = 0;
            originalPlatformType = 0;
        }
        public void Tick_X(object sender, EventArgs e, Form1 form)
        {
            if (platformType == 0) return;
            if (platformType == 1) {
                enemy.Tick(sender, e, form);
                if (enemy.isDead())
                {
                    enemy.setVisibility(false);
                    coin.drop(enemy.X, enemy.Y+30);
                    platformType = 3;
                }
            }
            if (platformType == 2)
            {
                boss.Tick(sender, e, form);
                if (boss.isDead())
                 {

                    coin.drop(boss.X, boss.Y+30);
                    platformType = 3;
                  }
            }
            if (platformType == 3) {
                coin.Tick(sender, e, form);
            };

        }
        public void MoveDown(int platformSpeed) {
            Y += platformSpeed;
            if (Y > 490)
            {
                Y = -410;
                platform_content_restart();
            }
                if (platformType == 0) return;
            if (platformType == 1)  enemy.MoveDown(platformSpeed);
            if (platformType ==2 ) boss.MoveDown(platformSpeed);
            if (platformType == 3 ) coin.MoveDown(platformSpeed);
        }
        public void restart()
        {
            x = originalX;
            y = originalY;
            width = originalWidth;
            height = originalHeight;
            platform.Location = new Point(originalX, originalY);
            platform_content_restart();

        }
        public void platform_content_restart()
        {
            platformType = originalPlatformType;

            if (originalPlatformType == 0) ClearPlatform();

            if (originalPlatformType == 1)
            {
                enemy.revive();
                enemy.setLocation(x,y,width);
                coin.reset();
            }

            if (originalPlatformType == 2)
            {
                boss.revive();
                boss.setLocation(x, y, width);
                boss.resetProjectile();
                coin.reset();
            }
        }
        public bool IsPlatformEmpty() {
            if (platformType==0) return true;
            return false;
        }
        public void Add(Enemy e, Coin c)
        {
            if (!this.IsPlatformEmpty()) return; 
           
            enemy = e;
            coin = c;
            platformType = 1;
            originalPlatformType = 1;
            enemy.setLocation(x, y, width);
        }
        public void Add(Boss b, Coin c) {
            if (!this.IsPlatformEmpty()) return;

            boss = b;
            coin = c;
            platformType = 2;
            originalPlatformType = 2;
            boss.setLocation(x, y, width);
        }
        public void ClearPlatform() {
            enemy = null;
            boss = null;
            coin = null;

            platformType = 0;
            originalPlatformType = 0;
        }
        public void addImage(System.Windows.Forms.PictureBox figure )
        {
            platform = figure;
        }
        public void removePictureBox()
        {
            platform = null;
        }
        public void platformPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            e.Graphics.DrawImage(image, x, y, width, height);
        }
        public void addImage(Bitmap image)
        {
            this.image = image;
            tracer = image.GetPixel(1, 1);
            this.image.MakeTransparent(tracer);
            platform.Visible = false;

            x = platform.Location.X;
            y = platform.Location.Y;

            height = 30;
            width = platform.Width;

            originalHeight = height;
            originalWidth = width;
            originalX = x;
            originalY = y;
        }

        public int X
        {
            get { return x; }
            set { x = value; platform.Location = new Point(value, y); }
        }

        public int Y
        {
            get { return y; }
            set { y = value; platform.Location = new Point(x, value); }
        }

        public int OriginalX
        {
            set { originalX = value; }
            get { return originalX; }
        }

        public int OriginalY
        {
            set { originalY = value; }
            get { return originalY; }
        }

        public int OriginalHeight
        {
            set { originalHeight = value; }
            get { return originalHeight; }
        }
        public int OriginalWidth
        {
            set { originalWidth= value; }
            get { return originalWidth; }
        }
    }
}
