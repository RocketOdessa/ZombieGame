using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

//12 страница пауза
namespace Zombie_Survival_2D
{
    class Bullet
    {
        bool schuss;
        private string direction;
        private int speed = 20;
        PictureBox bullet = new PictureBox();
        Timer tm = new Timer();

        private int bulletLeft;
        private int bulletTop;

        public string Direction { get => direction; set => direction = value; }
        public int Speed { get => speed; set => speed = value; }
        public PictureBox Bullet1 { get => bullet; set => bullet = value; }
        public Timer Tm { get => tm; set => tm = value; }
        public int BulletLeft { get => bulletLeft; set => bulletLeft = value; }
        public int BulletTop { get => bulletTop; set => bulletTop = value; }
        public bool Schuss { get => schuss; set => schuss = value; }

        public Bullet(bool schuss)
        {
            this.schuss = schuss;
        }

        public void MkBullet(Form form)
        {
            if (!schuss)
            {
                switch (direction)
                {
                    case "right":
                        Bullet1.Image = Properties.Resources.ammoR;
                        break;

                    case "left":
                        Bullet1.Image = Properties.Resources.ammoL;
                        break;
                    case "up":
                        Bullet1.Image = Properties.Resources.ammoUp;
                        break;
                    case "down":
                        Bullet1.Image = Properties.Resources.ammoD;
                        break;
                }
            }

            else
            {
                Bullet1.Image = Properties.Resources.Sqammo;
            }
            Bullet1.Tag = "bullet";
            Bullet1.Left = BulletLeft;
            Bullet1.Top = BulletTop;
            Bullet1.BringToFront();
            form.Controls.Add(Bullet1);

            Tm.Interval = Speed;
            Tm.Tick += new EventHandler(tm_Tick);
            Tm.Start();
        }

        public void tm_Tick(object sender, EventArgs e)
        {
                if (Direction == "left")
                {
                    Bullet1.Left -= Speed;
                }

                if (Direction == "right")
                {
                    Bullet1.Left += Speed;
                }

                if (Direction == "up")
                {
                    Bullet1.Top -= Speed;
                }

                if (Direction == "down")
                {
                    Bullet1.Top += Speed;
                }
         
            if (Bullet1.Left < 16 || Bullet1.Left > 900 || Bullet1.Top < 10 || Bullet1.Top > 616)
            {
                Tm.Stop();
                Tm.Dispose();
                Bullet1.Dispose();
                Tm = null;
                Bullet1 = null;
            }
        }
    }
}
