namespace Zombie_Survival_2D
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ammoLabel = new System.Windows.Forms.Label();
            this.killsLabel = new System.Windows.Forms.Label();
            this.healthLabel = new System.Windows.Forms.Label();
            this.healthProgressBar = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.lblGrenades = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker4 = new System.ComponentModel.BackgroundWorker();
            this.ToStart = new System.Windows.Forms.Button();
            this.zombie3PB = new System.Windows.Forms.PictureBox();
            this.playerPB = new System.Windows.Forms.PictureBox();
            this.zombie2PB = new System.Windows.Forms.PictureBox();
            this.zombie1PB = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.zombie3PB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zombie2PB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zombie1PB)).BeginInit();
            this.SuspendLayout();
            // 
            // ammoLabel
            // 
            this.ammoLabel.AutoSize = true;
            this.ammoLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ammoLabel.ForeColor = System.Drawing.Color.White;
            this.ammoLabel.Location = new System.Drawing.Point(29, 9);
            this.ammoLabel.Name = "ammoLabel";
            this.ammoLabel.Size = new System.Drawing.Size(48, 13);
            this.ammoLabel.TabIndex = 0;
            this.ammoLabel.Text = "Ammo: 0";
            // 
            // killsLabel
            // 
            this.killsLabel.AutoSize = true;
            this.killsLabel.ForeColor = System.Drawing.Color.White;
            this.killsLabel.Location = new System.Drawing.Point(234, 8);
            this.killsLabel.Name = "killsLabel";
            this.killsLabel.Size = new System.Drawing.Size(37, 13);
            this.killsLabel.TabIndex = 1;
            this.killsLabel.Text = "Kills: 0";
            // 
            // healthLabel
            // 
            this.healthLabel.AutoSize = true;
            this.healthLabel.ForeColor = System.Drawing.Color.White;
            this.healthLabel.Location = new System.Drawing.Point(601, 9);
            this.healthLabel.Name = "healthLabel";
            this.healthLabel.Size = new System.Drawing.Size(44, 13);
            this.healthLabel.TabIndex = 2;
            this.healthLabel.Text = "Health: ";
            // 
            // healthProgressBar
            // 
            this.healthProgressBar.BackColor = System.Drawing.Color.Black;
            this.healthProgressBar.ForeColor = System.Drawing.Color.Brown;
            this.healthProgressBar.Location = new System.Drawing.Point(651, 9);
            this.healthProgressBar.Name = "healthProgressBar";
            this.healthProgressBar.Size = new System.Drawing.Size(133, 12);
            this.healthProgressBar.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.gameEngine);
            // 
            // timer2
            // 
            this.timer2.Interval = 10000;
            this.timer2.Tick += new System.EventHandler(this.DropHealAndGrenade);
            // 
            // lblGrenades
            // 
            this.lblGrenades.AutoSize = true;
            this.lblGrenades.ForeColor = System.Drawing.Color.White;
            this.lblGrenades.Location = new System.Drawing.Point(421, 9);
            this.lblGrenades.Name = "lblGrenades";
            this.lblGrenades.Size = new System.Drawing.Size(65, 13);
            this.lblGrenades.TabIndex = 9;
            this.lblGrenades.Text = "Grenades: 0";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // backgroundWorker3
            // 
            this.backgroundWorker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker3_DoWork);
            // 
            // backgroundWorker4
            // 
            this.backgroundWorker4.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker4_DoWork);
            // 
            // ToStart
            // 
            this.ToStart.Font = new System.Drawing.Font("Showcard Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToStart.ForeColor = System.Drawing.Color.Brown;
            this.ToStart.Image = ((System.Drawing.Image)(resources.GetObject("ToStart.Image")));
            this.ToStart.Location = new System.Drawing.Point(808, 4);
            this.ToStart.Name = "ToStart";
            this.ToStart.Size = new System.Drawing.Size(103, 23);
            this.ToStart.TabIndex = 8;
            this.ToStart.Text = "DIE";
            this.ToStart.UseVisualStyleBackColor = true;
            this.ToStart.Click += new System.EventHandler(this.ToStart_Click);
            // 
            // zombie3PB
            // 
            this.zombie3PB.Image = global::Zombie_Survival_2D.Properties.Resources.zup;
            this.zombie3PB.Location = new System.Drawing.Point(352, 553);
            this.zombie3PB.Name = "zombie3PB";
            this.zombie3PB.Size = new System.Drawing.Size(71, 71);
            this.zombie3PB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.zombie3PB.TabIndex = 7;
            this.zombie3PB.TabStop = false;
            this.zombie3PB.Tag = "zombie";
            // 
            // playerPB
            // 
            this.playerPB.Image = global::Zombie_Survival_2D.Properties.Resources.up;
            this.playerPB.Location = new System.Drawing.Point(352, 292);
            this.playerPB.Name = "playerPB";
            this.playerPB.Size = new System.Drawing.Size(71, 100);
            this.playerPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.playerPB.TabIndex = 6;
            this.playerPB.TabStop = false;
            this.playerPB.Tag = "playerPb";
            // 
            // zombie2PB
            // 
            this.zombie2PB.Image = global::Zombie_Survival_2D.Properties.Resources.zdown;
            this.zombie2PB.Location = new System.Drawing.Point(604, 77);
            this.zombie2PB.Name = "zombie2PB";
            this.zombie2PB.Size = new System.Drawing.Size(71, 71);
            this.zombie2PB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.zombie2PB.TabIndex = 5;
            this.zombie2PB.TabStop = false;
            this.zombie2PB.Tag = "zombie";
            // 
            // zombie1PB
            // 
            this.zombie1PB.Image = global::Zombie_Survival_2D.Properties.Resources.zdown;
            this.zombie1PB.Location = new System.Drawing.Point(127, 77);
            this.zombie1PB.Name = "zombie1PB";
            this.zombie1PB.Size = new System.Drawing.Size(71, 71);
            this.zombie1PB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.zombie1PB.TabIndex = 4;
            this.zombie1PB.TabStop = false;
            this.zombie1PB.Tag = "zombie";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(923, 666);
            this.Controls.Add(this.lblGrenades);
            this.Controls.Add(this.ToStart);
            this.Controls.Add(this.zombie3PB);
            this.Controls.Add(this.playerPB);
            this.Controls.Add(this.zombie2PB);
            this.Controls.Add(this.zombie1PB);
            this.Controls.Add(this.healthProgressBar);
            this.Controls.Add(this.healthLabel);
            this.Controls.Add(this.killsLabel);
            this.Controls.Add(this.ammoLabel);
            this.Name = "Form1";
            this.Text = "Zombie Shooter 2D";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyisdown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyisup);
            ((System.ComponentModel.ISupportInitialize)(this.zombie3PB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zombie2PB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zombie1PB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ammoLabel;
        private System.Windows.Forms.Label killsLabel;
        private System.Windows.Forms.Label healthLabel;
        private System.Windows.Forms.PictureBox zombie1PB;
        private System.Windows.Forms.PictureBox zombie2PB;
        private System.Windows.Forms.PictureBox playerPB;
        private System.Windows.Forms.PictureBox zombie3PB;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button ToStart;
        public System.Windows.Forms.ProgressBar healthProgressBar;
        private System.Windows.Forms.PictureBox ShotGun;
        private System.Windows.Forms.Label lblGrenades;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.ComponentModel.BackgroundWorker backgroundWorker4;
    }
}

