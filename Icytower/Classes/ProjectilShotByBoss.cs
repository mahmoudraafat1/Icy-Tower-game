using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace icy_tower
{
    class ProjectilShotByBoss:Projectil
    {
        public ProjectilShotByBoss() :base () {
            x = -100;
            y = -100;
        }

        public override bool hasHit(Form1 form)
        {
            if (!fired)  return false;
            foreach (Control c in form.Controls)
            {
                if (((string)c.Tag == "platform" || (string)c.Tag == "ground") && figure.Bounds.IntersectsWith(c.Bounds))
                {

                        this.reset();
                        return false;
                }
                if ((string)c.Tag == "player" && figure.Bounds.IntersectsWith(c.Bounds))
                {
                        this.reset();
                        return true;
                }

            }
            return false;
        }

    }
}
