namespace idea
{
    partial class MapaGER
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.Focu = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Lider = new System.Windows.Forms.PictureBox();
            this.Stability = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.Decisões = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.button1.Location = new System.Drawing.Point(969, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 56);
            this.button1.TabIndex = 0;
            this.button1.Text = "Turno: 0";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Focu
            // 
            this.Focu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(76)))), ((int)(((byte)(125)))));
            this.Focu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Focu.Location = new System.Drawing.Point(289, -2);
            this.Focu.Name = "Focu";
            this.Focu.Size = new System.Drawing.Size(497, 103);
            this.Focu.TabIndex = 2;
            this.Focu.Text = "Escolha um Fóco";
            this.Focu.UseVisualStyleBackColor = false;
            this.Focu.Click += new System.EventHandler(this.Focu_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.button2.Location = new System.Drawing.Point(1108, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(73, 86);
            this.button2.TabIndex = 4;
            this.button2.Text = "Sair";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.button3.Location = new System.Drawing.Point(969, 69);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(133, 24);
            this.button3.TabIndex = 5;
            this.button3.Text = ">>";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::idea.Properties.Resources.Captura_de_ecrã_2026_05_14_113639;
            this.pictureBox2.Location = new System.Drawing.Point(165, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(118, 71);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkGray;
            this.pictureBox1.Location = new System.Drawing.Point(-3, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1300, 103);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Lider
            // 
            this.Lider.Image = global::idea.Properties.Resources.GER_Leader;
            this.Lider.Location = new System.Drawing.Point(40, -2);
            this.Lider.Name = "Lider";
            this.Lider.Size = new System.Drawing.Size(80, 103);
            this.Lider.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Lider.TabIndex = 6;
            this.Lider.TabStop = false;
            // 
            // Stability
            // 
            this.Stability.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Stability.Location = new System.Drawing.Point(825, 56);
            this.Stability.Name = "Stability";
            this.Stability.Size = new System.Drawing.Size(111, 37);
            this.Stability.TabIndex = 7;
            this.Stability.Text = "100";
            this.Stability.UseVisualStyleBackColor = false;
            this.Stability.Click += new System.EventHandler(this.Manpower_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.SaddleBrown;
            this.pictureBox3.Location = new System.Drawing.Point(-3, 100);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(286, 36);
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(61)))), ((int)(((byte)(35)))));
            this.pictureBox4.Location = new System.Drawing.Point(-3, 136);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(286, 313);
            this.pictureBox4.TabIndex = 9;
            this.pictureBox4.TabStop = false;
            // 
            // Decisões
            // 
            this.Decisões.AutoSize = true;
            this.Decisões.BackColor = System.Drawing.Color.SaddleBrown;
            this.Decisões.Location = new System.Drawing.Point(37, 112);
            this.Decisões.Name = "Decisões";
            this.Decisões.Size = new System.Drawing.Size(51, 13);
            this.Decisões.TabIndex = 10;
            this.Decisões.Text = "Decisões";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(62)))), ((int)(((byte)(37)))));
            this.pictureBox5.Location = new System.Drawing.Point(-1, 136);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(273, 300);
            this.pictureBox5.TabIndex = 11;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(824, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 24);
            this.label1.TabIndex = 12;
            this.label1.Text = "Estabilidade";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(38, 156);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(207, 23);
            this.button5.TabIndex = 14;
            this.button5.Text = "Construir Infarstrutura";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(62)))), ((int)(((byte)(37)))));
            this.label2.Location = new System.Drawing.Point(20, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(237, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Construir Infarstrutura irá aumentar a Estabilidade";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(38, 267);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(207, 23);
            this.button4.TabIndex = 16;
            this.button4.Text = "Adicionar 2 Divisões";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // MapaGER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1182, 1061);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.Decisões);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.Stability);
            this.Controls.Add(this.Lider);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Focu);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MapaGER";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Focu;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox Lider;
        private System.Windows.Forms.Button Stability;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label Decisões;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
    }
}