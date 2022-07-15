using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace icy_tower
{
    class Character : IImageControl
    {
        protected int x, y;
        protected int originalX, originalY;
        protected int width, height;
        protected int life;
        protected int originalLife;
        protected bool alive;
        protected bool visible;
        protected Color tracer;
        protected System.Windows.Forms.PictureBox figure;
        protected List<Bitmap> pictures;

        public Character() {
            tracer = new Color();

            alive = true;
            visible = true;
        }

        public Character(int l) : this(){
            life = l;
            originalLife = l;
        }
        public virtual void addImage(System.Windows.Forms.PictureBox figure)
        {
            this.figure = figure;
        }
        public virtual void removePictureBox()
        {
            figure = null;
        }

        public virtual void addImage(List<Bitmap> pictures)
        {
            this.pictures = pictures;
        }

        public virtual void addImage(Bitmap picture)
        {
            if (this.pictures == null)
            {
                this.pictures = new List<Bitmap>();
            }
            this.pictures.Add(picture);
        }
        public virtual void isHit(){
            life--;
            if (life <= 0) { 
                alive = false;
                setVisibility(false);
            }


        }

        public bool isDead()
        {
            if (alive) return false;
            return true;
        }
        
        public void revive() {
            if (!alive) {
                life = originalLife;
                alive = true;
                }
            setVisibility(true);
        }
        

         public void reset_position()
           {

            x = originalX;
            y = originalY;

            figure.Location = new Point(originalX, originalY);

            }
        public virtual void reset() {
            tracer = new Color();
            revive();
            reset_position();
                }
       
        public virtual void setVisibility(bool b)
        {
            
            visible = b;


            if (b == false) { figure.Location = new Point(-100, y); } else { figure.Location = new Point(x, y); }

        }
        protected virtual void copyFigureInformation()
        {
            x = figure.Location.X;
            y = figure.Location.Y;
            width = figure.Width;
            height = figure.Height;
            figure.Location = new Point(x, y);
        }
        public virtual int X
        {
            set { x = value; }
            get { return x; }
        }

        public virtual int Y
        {
            set { y = value; }
            get { return y; }
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
        public int Life
        {
            set { life = value; }
            get { return life; }
        }
        public bool Alive
        {
            set { alive = value; }
            get { return alive; }
        }

        public bool Visible 
        {
            set { visible = value; }
            get{ return visible;  }
        
        }
    }
}
