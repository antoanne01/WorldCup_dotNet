namespace WorldCup_WinForm
{
    partial class PlayerInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerInfo));
            this.btnPicture = new System.Windows.Forms.Button();
            this.pbCapitan = new System.Windows.Forms.PictureBox();
            this.pbStar = new System.Windows.Forms.PictureBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.pbShirt = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.pbPlayerImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCapitan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShirt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPicture
            // 
            this.btnPicture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(38)))), ((int)(((byte)(44)))));
            this.btnPicture.FlatAppearance.BorderSize = 0;
            this.btnPicture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPicture.ForeColor = System.Drawing.Color.White;
            this.btnPicture.Location = new System.Drawing.Point(165, 172);
            this.btnPicture.Name = "btnPicture";
            this.btnPicture.Size = new System.Drawing.Size(129, 29);
            this.btnPicture.TabIndex = 16;
            this.btnPicture.Text = "Dodaj sliku";
            this.btnPicture.UseVisualStyleBackColor = false;
            this.btnPicture.Click += new System.EventHandler(this.btnPicture_Click);
            // 
            // pbCapitan
            // 
            this.pbCapitan.Image = ((System.Drawing.Image)(resources.GetObject("pbCapitan.Image")));
            this.pbCapitan.Location = new System.Drawing.Point(414, 156);
            this.pbCapitan.Name = "pbCapitan";
            this.pbCapitan.Size = new System.Drawing.Size(66, 45);
            this.pbCapitan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCapitan.TabIndex = 15;
            this.pbCapitan.TabStop = false;
            // 
            // pbStar
            // 
            this.pbStar.Image = ((System.Drawing.Image)(resources.GetObject("pbStar.Image")));
            this.pbStar.Location = new System.Drawing.Point(435, 20);
            this.pbStar.Name = "pbStar";
            this.pbStar.Size = new System.Drawing.Size(45, 45);
            this.pbStar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbStar.TabIndex = 14;
            this.pbStar.TabStop = false;
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPosition.Location = new System.Drawing.Point(164, 119);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(77, 28);
            this.lblPosition.TabIndex = 13;
            this.lblPosition.Text = "Pozicija";
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNumber.Location = new System.Drawing.Point(208, 74);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(34, 28);
            this.lblNumber.TabIndex = 12;
            this.lblNumber.Text = "12";
            // 
            // pbShirt
            // 
            this.pbShirt.Image = ((System.Drawing.Image)(resources.GetObject("pbShirt.Image")));
            this.pbShirt.Location = new System.Drawing.Point(165, 74);
            this.pbShirt.Name = "pbShirt";
            this.pbShirt.Size = new System.Drawing.Size(37, 32);
            this.pbShirt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbShirt.TabIndex = 11;
            this.pbShirt.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblName.Location = new System.Drawing.Point(164, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(129, 28);
            this.lblName.TabIndex = 10;
            this.lblName.Text = "Ime i prezime";
            // 
            // pbPlayerImage
            // 
            this.pbPlayerImage.Image = ((System.Drawing.Image)(resources.GetObject("pbPlayerImage.Image")));
            this.pbPlayerImage.Location = new System.Drawing.Point(15, 20);
            this.pbPlayerImage.Name = "pbPlayerImage";
            this.pbPlayerImage.Size = new System.Drawing.Size(125, 181);
            this.pbPlayerImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPlayerImage.TabIndex = 17;
            this.pbPlayerImage.TabStop = false;
            // 
            // PlayerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbPlayerImage);
            this.Controls.Add(this.btnPicture);
            this.Controls.Add(this.pbCapitan);
            this.Controls.Add(this.pbStar);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.pbShirt);
            this.Controls.Add(this.lblName);
            this.Name = "PlayerInfo";
            this.Size = new System.Drawing.Size(505, 217);
            ((System.ComponentModel.ISupportInitialize)(this.pbCapitan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShirt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnPicture;
        private PictureBox pbCapitan;
        private PictureBox pbStar;
        private Label lblPosition;
        private Label lblNumber;
        private PictureBox pbShirt;
        private Label lblName;
        private PictureBox pbPlayerImage;
    }
}
