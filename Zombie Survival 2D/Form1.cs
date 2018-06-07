using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Zombie_Survival_2D
{
    public partial class Form1 : Form
    {
        int time = 1;
        int sg = 0;
        int Ak = 0;
        bool shotgun;
        bool ak = false;
        bool Gren = false;
        bool goup;
        bool godown;
        bool goleft;
        bool goright;
        string facing = "up";
        double playerHealth = 100;
        bool boom = false;
        int Left;
        int Top;
        int heal = 0;
        int speed = 10;
        int ammo = 10;
        int zombieSpeed = 3;
        int score = 0;
        int grenade = 2;
        bool gameOver = false;
        Random rnd = new Random();
        SoundPlayer sd;

        public Form1()
        {
            InitializeComponent();
            shotgun = false;
            ToStart.Enabled = true;
            ToStart.Visible = false;
            DropPlayerAndZombie();
            timer1.Start();
            timer2.Start();
            Hide();
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (gameOver)
                return;


            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
                facing = "left";
                playerPB.Image = Properties.Resources.left;
            }

            if (e.KeyCode == Keys.Right)
            {
                goright = true;
                facing = "right";
                playerPB.Image = Properties.Resources.right;
            }

            if (e.KeyCode == Keys.Up)
            {
                goup = true;
                facing = "up";
                playerPB.Image = Properties.Resources.up;
            }

            if (e.KeyCode == Keys.Down)
            {
                godown = true;
                facing = "down";
                playerPB.Image = Properties.Resources.down;
            }

            if (e.KeyCode == Keys.G && grenade > 0)
            {
                grenade--;
                Grenade gr = new Grenade();
                ThrowGrenade(facing);
                boom = true;
                if (facing == "left")
                {
                    Left = playerPB.Left - 200;
                    Top = playerPB.Top;
                    time = Left / 20;
                }
                if (facing == "right")
                {
                    Left = playerPB.Left + 200;
                    Top = playerPB.Top;
                    time = Left / 20;
                }
                if (facing == "down")
                {
                    Top = playerPB.Top + 200;
                    Left = playerPB.Left;
                    time = Top / 20;
                }
                if (facing == "up")
                {
                    Top = playerPB.Top - 200;
                    Left = playerPB.Left;
                    time = Top / 20;
                }
            }
            if (ammo == 0 && e.KeyCode == Keys.Space)
            {
                backgroundWorker3.RunWorkerAsync();
            }

            if (e.KeyCode == Keys.Space && ammo <= 30 && ammo != 0 && !shotgun)
                backgroundWorker1.RunWorkerAsync();

        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (gameOver)
                return;

            if (grenade > 0)
                Gren = true;

            else
                Gren = false;


            if (e.KeyCode == Keys.Left)
                goleft = false;

            if (e.KeyCode == Keys.Right)
                goright = false;

            if (e.KeyCode == Keys.Up)
                goup = false;

            if (e.KeyCode == Keys.Down)
                godown = false;

            if (e.KeyCode == Keys.Space && ammo > 0)
            {
                if (!shotgun && !ak)
                {
                    ammo--;
                }
                else if (shotgun)
                {
                    ammo -= 3;
                    SoundPlayer player = new SoundPlayer(@"Drob.wav");
                    player.Play();
                }
                else
                {
                    ammo -= 3;
                    backgroundWorker1.RunWorkerAsync();
                }
                Shoot(facing);

                if (ammo < 1)
                    DropAmmo();
            }
        }

        private void gameEngine(object sender, EventArgs e)
        {
            ToStart.Enabled = false;

            if (time > 0)
                time--;

            if (time <= 0 && boom)
            {
                Boom("up");
                Boom("down");
                Boom("left");
                Boom("right");
                time = 1;
                boom = false;
                backgroundWorker4.RunWorkerAsync();
            }

            if (playerHealth > 0)
            {
                healthProgressBar.Value = Convert.ToInt32(playerHealth);
                healthProgressBar.ForeColor = Color.Green;
            }
            else
            {
                ToStart.Enabled = true;
                ToStart.Visible = true;
                playerPB.Image = Properties.Resources.dead;
                backgroundWorker2.RunWorkerAsync();
                timer1.Stop();
                timer2.Stop();
                gameOver = true;
            }

            ammoLabel.Text = "   Ammo:   " + ammo;
            killsLabel.Text = "Kills: " + score;
            lblGrenades.Text = "Grenades: " + grenade;

            if (score == 2 && sg == 0)
            {
                DropShotGun();
                sg++;
            }

            if (score == 5 && Ak == 0)
            {
                DropAk();
                Ak++;
            }

            foreach (Control item in this.Controls)
            {
                if (item is PictureBox && Convert.ToString(item.Tag) == "shotgun" ||
                    item is PictureBox && Convert.ToString(item.Tag) == "ak")
                {
                    if (((PictureBox)item).Bounds.IntersectsWith(playerPB.Bounds))
                    {
                        this.Controls.Remove(((PictureBox)item));

                        ((PictureBox)item).Dispose();

                        shotgun = true;
                        if (!ak)
                        {
                            ammo = 9;
                        }

                        if (Convert.ToString(item.Tag) == "ak")
                        {
                            shotgun = false;
                            ak = true;
                            ammo = 30;
                        }
                    }
                }
            }

            if (healthProgressBar.Value < 30)
            {
                healthProgressBar.ForeColor = Color.Red;
            }

            if (goleft && playerPB.Left > 0)
            {
                playerPB.Left -= speed;
            }

            if (goright && playerPB.Left + playerPB.Width < 930)
            {
                playerPB.Left += speed;
            }

            if (goup && playerPB.Top > 60)
            {
                playerPB.Top -= speed;
            }

            if (godown && playerPB.Top + playerPB.Width < 700)
            {
                playerPB.Top += speed;
            }

            foreach (Control item in this.Controls)
            {
                if (item is PictureBox && Convert.ToString(item.Tag) == "ammo")
                {
                    if (((PictureBox)item).Bounds.IntersectsWith(playerPB.Bounds))
                    {
                        this.Controls.Remove(((PictureBox)item));

                        ((PictureBox)item).Dispose();

                        if (!shotgun && !ak)
                        {
                            ammo += 5;
                        }

                        else if (!ak)
                        {
                            ammo += 12;
                        }

                        else
                        {
                            ammo += 30;
                        }
                    }
                }

                if (item is PictureBox && Convert.ToString(item.Tag) == "Heal")
                {
                    if (playerPB.Bounds.IntersectsWith(item.Bounds))
                    {
                        healthProgressBar.Value += 5;
                        playerHealth += 5;
                        this.Controls.Remove(item);
                        item.Dispose();
                    }
                    if (playerHealth == 100)
                    {
                        this.Controls.Remove(item);
                    }
                    else if (playerHealth >= 90 && healthProgressBar.Value < 100)
                    {
                        healthProgressBar.Value += 1;
                        playerHealth += 1;
                        this.Controls.Remove(item);
                    }
                }

                if (item is PictureBox && Convert.ToString(item.Tag) == "grenade")
                {
                    if (((PictureBox)item).Bounds.IntersectsWith(playerPB.Bounds))
                    {
                        this.Controls.Remove(((PictureBox)item));

                        ((PictureBox)item).Dispose();
                        grenade++;
                    }
                }

                if (item is PictureBox && Convert.ToString(item.Tag) == "bullet")
                {
                    if (((PictureBox)item).Left < 1 || ((PictureBox)item).Left > 930 || ((PictureBox)item).Top < 10 || ((PictureBox)item).Top > 700)
                    {
                        this.Controls.Remove(((PictureBox)item));
                        ((PictureBox)item).Dispose();
                    }
                }

                if (item is PictureBox && Convert.ToString(item.Tag) == "zombie")
                {
                    if (((PictureBox)item).Bounds.IntersectsWith(playerPB.Bounds))
                    {
                        playerHealth -= 1;
                    }

                    if (((PictureBox)item).Left > playerPB.Left)
                    {
                        ((PictureBox)item).Left -= zombieSpeed;
                        ((PictureBox)item).Image = Properties.Resources.zleft;
                    }

                    if (((PictureBox)item).Top > playerPB.Top)
                    {
                        ((PictureBox)item).Top -= zombieSpeed;
                        ((PictureBox)item).Image = Properties.Resources.zup;
                    }

                    if (((PictureBox)item).Left < playerPB.Left)
                    {
                        ((PictureBox)item).Left += zombieSpeed;
                        ((PictureBox)item).Image = Properties.Resources.zright;
                    }

                    if (((PictureBox)item).Top < playerPB.Top)
                    {
                        ((PictureBox)item).Top += zombieSpeed;
                        ((PictureBox)item).Image = Properties.Resources.zdown;
                    }



                    foreach (Control item1 in this.Controls)
                    {
                        if (item1 is PictureBox && Convert.ToString(item1.Tag) == "bullet")
                        {
                            if (item is PictureBox && Convert.ToString(item.Tag) == "playerPb")
                            {
                                if (item.Bounds.IntersectsWith(item1.Bounds))
                                {
                                    playerHealth -= 5;
                                    this.Controls.Remove(item1);
                                    item1.Dispose();

                                }
                            }

                            if (item is PictureBox && Convert.ToString(item.Tag) == "zombie")
                            {
                                if (item.Bounds.IntersectsWith(item1.Bounds))
                                {
                                    SoundPlayer player = new System.Media.SoundPlayer(@"kill.wav");
                                    player.Play();
                                    score++;
                                    this.Controls.Remove(item1);
                                    item1.Dispose();
                                    DropZombie((PictureBox)item);

                                }
                            }
                        }
                    }
                }
            }
        }

        private void ThrowGrenade(string direct)
        {
            Grenade gr = new Grenade();
            gr.Direction1 = direct;
            gr.GrenadeLeft = playerPB.Left + (playerPB.Width / 2);
            gr.GrenadeTop = playerPB.Top + (playerPB.Width / 2);
            gr.MkGrenade(this);
        }

        private void DropAmmo()
        {
            PictureBox ammo = new PictureBox();

            if (!shotgun && !ak)
            {
                ammo.Image = Properties.Resources.ammo_Image;
            }

            else if (shotgun)
            {
                ammo.Image = Properties.Resources.ammoSg;
            }

            else
            {
                ammo.Image = Properties.Resources.ammoAk;
            }
            ammo.SizeMode = PictureBoxSizeMode.AutoSize;
            ammo.Left = rnd.Next(10, 890);
            ammo.Top = rnd.Next(50, 600);
            ammo.Tag = "ammo";
            this.Controls.Add(ammo);
            ammo.BringToFront();
            playerPB.BringToFront();
        }

        private void DropHeal()
        {
            heal++;
            PictureBox HealBox = new PictureBox();
            switch (heal)
            {
                case 1:
                    HealBox.Image = Properties.Resources.HealBox;
                    HealBox.SizeMode = PictureBoxSizeMode.AutoSize;
                    break;

                case 2:
                    HealBox.Image = Properties.Resources.HealBox1;
                    HealBox.SizeMode = PictureBoxSizeMode.AutoSize;
                    break;

                case 3:
                    HealBox.Image = Properties.Resources.HealBox2;
                    HealBox.SizeMode = PictureBoxSizeMode.AutoSize;
                    break;
            }
            if (heal == 3)
            {
                heal = 0;
            }
            HealBox.Left = rnd.Next(10, 890);
            HealBox.Top = rnd.Next(50, 600);
            HealBox.Tag = "Heal";
            this.Controls.Add(HealBox);
            HealBox.BringToFront();
            playerPB.BringToFront();

        }

        private void DropGrenade()
        {
            PictureBox Grenade = new PictureBox();
            Grenade.Image = Properties.Resources.GrenadeThrow;
            Grenade.SizeMode = PictureBoxSizeMode.AutoSize;
            Grenade.Left = rnd.Next(10, 890);
            Grenade.Top = rnd.Next(50, 600);
            Grenade.Tag = "grenade";
            this.Controls.Add(Grenade);
            Grenade.BringToFront();
            playerPB.BringToFront();
        }

        private void DropZombie(PictureBox e)
        {
            e.Left = rnd.Next(10, 890);
            e.Top = rnd.Next(50, 600);
        }

        private void DropPlayerAndZombie()
        {
            playerPB.Left = rnd.Next(10, 890);
            playerPB.Top = rnd.Next(50, 600);
            zombie1PB.Left = rnd.Next(10, 890);
            zombie1PB.Top = rnd.Next(50, 600);
            zombie2PB.Left = rnd.Next(10, 890);
            zombie2PB.Top = rnd.Next(50, 600);
            zombie3PB.Left = rnd.Next(10, 890);
            zombie3PB.Top = rnd.Next(50, 600);
        }

        private void Boom(string direct)
        {
            if (direct == "up" || direct == "down")
            {
                Bullet shoot = new Bullet(true);
                shoot.Direction = direct;
                shoot.BulletLeft = Left + 50;
                shoot.BulletTop = Top;
                shoot.MkBullet(this);

                Bullet shoot1 = new Bullet(true);
                shoot1.Direction = direct;
                shoot1.BulletLeft = Left;
                shoot1.BulletTop = Top;
                shoot1.MkBullet(this);

                Bullet shoot2 = new Bullet(true);
                shoot2.Direction = direct;
                shoot2.BulletLeft = Left - 50;
                shoot2.BulletTop = Top;
                shoot2.MkBullet(this);
            }

            else
            {
                Bullet shoot = new Bullet(true);
                shoot.Direction = direct;
                shoot.BulletLeft = Left;
                shoot.BulletTop = Top + 50;
                shoot.MkBullet(this);

                Bullet shoot1 = new Bullet(true);
                shoot1.Direction = direct;
                shoot1.BulletLeft = Left;
                shoot1.BulletTop = Top;
                shoot1.MkBullet(this);

                Bullet shoot2 = new Bullet(true);
                shoot2.Direction = direct;
                shoot2.BulletLeft = Left;
                shoot2.BulletTop = Top - 50;
                shoot2.MkBullet(this);
            }
        }

        private void Shoot(string direct)
        {
            if (!shotgun && !ak)
            {
                Bullet shoot = new Bullet(false);
                shoot.Direction = direct;
                shoot.BulletLeft = playerPB.Left + (playerPB.Width / 2);
                shoot.BulletTop = playerPB.Top + (playerPB.Width / 2);
                shoot.MkBullet(this);
            }

            if (shotgun)
            {
                if (direct == "up" || direct == "down")
                {
                    Bullet shoot = new Bullet(true);
                    shoot.Direction = direct;
                    shoot.BulletLeft = playerPB.Left + (playerPB.Width / 2);
                    shoot.BulletTop = playerPB.Top + (playerPB.Width / 2);
                    shoot.MkBullet(this);

                    Bullet shoot1 = new Bullet(true);
                    shoot1.Direction = direct;
                    shoot1.BulletLeft = playerPB.Left + (playerPB.Width);
                    shoot1.BulletTop = playerPB.Top + (playerPB.Width / 2);
                    shoot1.MkBullet(this);

                    Bullet shoot2 = new Bullet(true);
                    shoot2.Direction = direct;
                    shoot2.BulletLeft = playerPB.Left;
                    shoot2.BulletTop = playerPB.Top + (playerPB.Width / 2);
                    shoot2.MkBullet(this);
                }

                else
                {
                    Bullet shoot = new Bullet(true);
                    shoot.Direction = direct;
                    shoot.BulletLeft = playerPB.Left + (playerPB.Width / 2);
                    shoot.BulletTop = playerPB.Top + (playerPB.Width / 2);
                    shoot.MkBullet(this);

                    Bullet shoot1 = new Bullet(true);
                    shoot1.Direction = direct;
                    shoot1.BulletLeft = playerPB.Left + (playerPB.Width / 2);
                    shoot1.BulletTop = playerPB.Top + (playerPB.Width);
                    shoot1.MkBullet(this);

                    Bullet shoot2 = new Bullet(true);
                    shoot2.Direction = direct;
                    shoot2.BulletLeft = playerPB.Left + (playerPB.Width / 2);
                    shoot2.BulletTop = playerPB.Top;
                    shoot2.MkBullet(this);
                }
            }

            if (ak)
            {
                if (direct == "up" || direct == "down")
                {
                    Bullet shoot = new Bullet(false);
                    shoot.Direction = direct;
                    shoot.BulletLeft = playerPB.Left + (playerPB.Width / 2);
                    shoot.BulletTop = playerPB.Top + (playerPB.Height / 2);
                    shoot.MkBullet(this);

                    Bullet shoot1 = new Bullet(false);
                    shoot1.Direction = direct;
                    shoot1.BulletLeft = playerPB.Left + (playerPB.Width / 2);
                    shoot1.BulletTop = playerPB.Top + (playerPB.Height) + 5;
                    shoot1.MkBullet(this);

                    Bullet shoot2 = new Bullet(false);
                    shoot2.Direction = direct;
                    shoot2.BulletLeft = playerPB.Left + (playerPB.Width / 2);
                    shoot2.BulletTop = playerPB.Top + 5;
                    shoot2.MkBullet(this);
                }

                else
                {
                    Bullet shoot = new Bullet(false);
                    shoot.Direction = direct;
                    shoot.BulletLeft = playerPB.Left + (playerPB.Width / 2) + 9;
                    shoot.BulletTop = playerPB.Top + (playerPB.Height / 2);
                    shoot.MkBullet(this);

                    Bullet shoot1 = new Bullet(false);
                    shoot1.Direction = direct;
                    shoot1.BulletLeft = playerPB.Left + (playerPB.Width) + 9;
                    shoot1.BulletTop = playerPB.Top + (playerPB.Height / 2);
                    shoot1.MkBullet(this);

                    Bullet shoot2 = new Bullet(false);
                    shoot2.Direction = direct;
                    shoot2.BulletLeft = playerPB.Left + 9;
                    shoot2.BulletTop = playerPB.Top + (playerPB.Height / 2);
                    shoot2.MkBullet(this);
                }
            }
        }

        private void DropHealAndGrenade(object sender, EventArgs e)
        {
            DropHeal();
            if (grenade < 4)
            {
                DropGrenade();
            }
        }

        private void DropShotGun()
        {
            PictureBox ShotGun = new PictureBox();
            ShotGun.Image = Properties.Resources.ShotGun;
            ShotGun.SizeMode = PictureBoxSizeMode.AutoSize;
            ShotGun.Left = rnd.Next(10, 890);
            ShotGun.Top = rnd.Next(50, 600);
            ShotGun.Tag = "shotgun";
            this.Controls.Add(ShotGun);
            ShotGun.BringToFront();
            playerPB.BringToFront();
        }

        private void DropAk()
        {
            PictureBox Ak = new PictureBox();
            Ak.Image = Properties.Resources.AK;
            Ak.SizeMode = PictureBoxSizeMode.AutoSize;
            Ak.Left = rnd.Next(10, 890);
            Ak.Top = rnd.Next(50, 600);
            Ak.Tag = "ak";
            this.Controls.Add(Ak);
            Ak.BringToFront();
            playerPB.BringToFront();
        }

        private void Clear()
        {
            foreach (Control item in this.Controls)
            {
                if ((item is PictureBox && Convert.ToString(item.Tag) == "Heal") ||
                    (item is PictureBox && Convert.ToString(item.Tag) == "ammo") ||
                    (item is PictureBox && Convert.ToString(item.Tag) == "grenade") ||
                    (item is PictureBox && Convert.ToString(item.Tag) == "ak") ||
                    (item is PictureBox && Convert.ToString(item.Tag) == "shotgun"))
                {
                    item.Dispose();
                }
            }
        }

        private void ToStart_Click(object sender, EventArgs e)
        {
            speed = 10;
            ammo = 10;
            zombieSpeed = 3;
            score = 0;
            playerHealth = 100;
            grenade = 2;
            heal = 0;
            facing = "up";
            ak = false;
            shotgun = false;
            gameOver = false;
            goleft = false;
            goright = false;
            goup = false;
            godown = false;
            playerPB.Image = Properties.Resources.up;
            Clear();
            ToStart.Enabled = false;
            ToStart.Visible = false;
            Form1.ActiveForm.Focus();
            DropPlayerAndZombie();
            timer1.Start();
            timer2.Start();
            Form1.ActiveForm.Focus();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            SoundPlayer sound = new System.Media.SoundPlayer(@"AK-47.wav");
            sound.Play();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            SoundPlayer soundPlayer = new SoundPlayer(@"DIED.wav");
            soundPlayer.Play();
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            SoundPlayer player = new SoundPlayer(@"KUR.wav");
            player.Play();
        }

        private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
        {
            SoundPlayer sound = new SoundPlayer(@"boom.wav");
            sound.Play();
        }
    }
}
