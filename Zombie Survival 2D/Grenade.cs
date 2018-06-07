using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zombie_Survival_2D
{
    class Grenade
    {
        private string direction;
        private int speed = 20;
        PictureBox grenade = new PictureBox();
        Timer tm = new Timer();

        private int grenadeLeft;
        private int grenadeTop;


        public string Direction1 { get => direction; set => direction = value; }
        public int Speed1 { get => speed; set => speed = value; }
        public PictureBox Grenade1 { get => grenade; set => grenade = value; }
        public Timer Tm1 { get => tm; set => tm = value; }
        public int GrenadeLeft { get => grenadeLeft; set => grenadeLeft = value; }
        public int GrenadeTop { get => grenadeTop; set => grenadeTop = value; }

        public void MkGrenade(Form form)
        {
            Grenade1.Image = Properties.Resources.GrenadeThrow;
            Grenade1.Left =grenadeLeft;
            Grenade1.Top = grenadeTop;
            Grenade1.BringToFront();
            form.Controls.Add(Grenade1);

            Tm1.Interval = Speed1;
            Tm1.Tick += new EventHandler(tm1_Tick);
            Tm1.Start();
        }

        public void tm1_Tick(object sender, EventArgs e)
        {
            if (Direction1 == "left")
            {
                Grenade1.Left -= Speed1;
            }

            if (Direction1 == "right")
            {
                Grenade1.Left += Speed1;
            }

            if (Direction1 == "up")
            {
                Grenade1.Top -= Speed1;
            }

            if (Direction1 == "down")
            {
                Grenade1.Top += Speed1;
            }

            if (Grenade1.Left < 16 || Grenade1.Left > 860 || Grenade1.Top < 10 || Grenade1.Top > 616
                || GrenadeLeft - Grenade1.Left > 400 || Grenade1.Left - 400 > GrenadeLeft
                || GrenadeTop - Grenade1.Top > 400 || Grenade1.Top - 400 > GrenadeTop) 
            {
                Tm1.Stop();
                Tm1.Dispose();
                Grenade1.Dispose();
                Tm1 = null;
                Grenade1 = null;
            }
        }
    }
}
