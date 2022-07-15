using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace icy_tower
{


    class ProjectilShotByPlayer:Projectil
    {
        public ProjectilShotByPlayer() : base() {
            x = -100;
            y = -100;
        }
        public override bool hasHit(Form1 form)
        {
            if (!fired) return false;
            foreach (Control c in form.Controls)
            {
                if ((string)c.Tag == "boss" && !form.bossIsDead() && form.bossIsVisible())
                {
                    if (figure.Bounds.IntersectsWith(c.Bounds))
                    {
                        Console.WriteLine("I hit the " + (string)c.Tag);
                        form.bossIsHit();
                        this.reset();
                        return true;
                    }
                }

                if ((string)c.Tag == "enemy" && !form.enemyIsDead() && form.EnemyIsVisible())
                {
                    if (figure.Bounds.IntersectsWith(c.Bounds))
                    {
                        Console.WriteLine("I hit the " + (string)c.Tag);
                        form.enemyIsHit();
                        this.reset();
                        return true;
                    }
                }
                if (((string)c.Tag == "platform" || (string)c.Tag == "ground") && figure.Bounds.IntersectsWith(c.Bounds))
                {
                    this.reset();
                    return false;
                }

            }
            return false;
        }



    }
}
