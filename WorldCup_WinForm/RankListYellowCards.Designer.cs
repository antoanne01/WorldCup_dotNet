namespace WorldCup_WinForm
{
    partial class RankListYellowCards
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RankListYellowCards));
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.lbYellowCards = new System.Windows.Forms.Label();
            this.lbScoredGoals = new System.Windows.Forms.Label();
            this.lbAppearance = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pbImage
            // 
            this.pbImage.Image = ((System.Drawing.Image)(resources.GetObject("pbImage.Image")));
            this.pbImage.Location = new System.Drawing.Point(13, 13);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(66, 52);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImage.TabIndex = 9;
            this.pbImage.TabStop = false;
            this.pbImage.Visible = false;
            // 
            // lbYellowCards
            // 
            this.lbYellowCards.AutoSize = true;
            this.lbYellowCards.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbYellowCards.Location = new System.Drawing.Point(488, 25);
            this.lbYellowCards.Name = "lbYellowCards";
            this.lbYellowCards.Size = new System.Drawing.Size(0, 20);
            this.lbYellowCards.TabIndex = 8;
            // 
            // lbScoredGoals
            // 
            this.lbScoredGoals.AutoSize = true;
            this.lbScoredGoals.Location = new System.Drawing.Point(407, 25);
            this.lbScoredGoals.Name = "lbScoredGoals";
            this.lbScoredGoals.Size = new System.Drawing.Size(0, 20);
            this.lbScoredGoals.TabIndex = 7;
            // 
            // lbAppearance
            // 
            this.lbAppearance.AutoSize = true;
            this.lbAppearance.Location = new System.Drawing.Point(330, 25);
            this.lbAppearance.Name = "lbAppearance";
            this.lbAppearance.Size = new System.Drawing.Size(0, 20);
            this.lbAppearance.TabIndex = 6;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(111, 25);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(0, 20);
            this.lbName.TabIndex = 5;
            // 
            // RankListYellowCards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.lbYellowCards);
            this.Controls.Add(this.lbScoredGoals);
            this.Controls.Add(this.lbAppearance);
            this.Controls.Add(this.lbName);
            this.Name = "RankListYellowCards";
            this.Size = new System.Drawing.Size(531, 131);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pbImage;
        private Label lbYellowCards;
        private Label lbScoredGoals;
        private Label lbAppearance;
        private Label lbName;
    }
}
