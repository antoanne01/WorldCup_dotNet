namespace WorldCup_WinForm
{
    partial class RankPlayers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RankPlayers));
            this.lbName = new System.Windows.Forms.Label();
            this.lbAppearance = new System.Windows.Forms.Label();
            this.lbScoredGoals = new System.Windows.Forms.Label();
            this.lbYellowCards = new System.Windows.Forms.Label();
            this.pbImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(123, 20);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(0, 20);
            this.lbName.TabIndex = 0;
            // 
            // lbAppearance
            // 
            this.lbAppearance.AutoSize = true;
            this.lbAppearance.Location = new System.Drawing.Point(319, 20);
            this.lbAppearance.Name = "lbAppearance";
            this.lbAppearance.Size = new System.Drawing.Size(0, 20);
            this.lbAppearance.TabIndex = 1;
            // 
            // lbScoredGoals
            // 
            this.lbScoredGoals.AutoSize = true;
            this.lbScoredGoals.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbScoredGoals.Location = new System.Drawing.Point(400, 20);
            this.lbScoredGoals.Name = "lbScoredGoals";
            this.lbScoredGoals.Size = new System.Drawing.Size(0, 20);
            this.lbScoredGoals.TabIndex = 2;
            // 
            // lbYellowCards
            // 
            this.lbYellowCards.AutoSize = true;
            this.lbYellowCards.Location = new System.Drawing.Point(511, 20);
            this.lbYellowCards.Name = "lbYellowCards";
            this.lbYellowCards.Size = new System.Drawing.Size(0, 20);
            this.lbYellowCards.TabIndex = 3;
            // 
            // pbImage
            // 
            this.pbImage.Image = ((System.Drawing.Image)(resources.GetObject("pbImage.Image")));
            this.pbImage.Location = new System.Drawing.Point(8, 3);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(75, 48);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImage.TabIndex = 4;
            this.pbImage.TabStop = false;
            this.pbImage.Visible = false;
            // 
            // RankPlayers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.lbYellowCards);
            this.Controls.Add(this.lbScoredGoals);
            this.Controls.Add(this.lbAppearance);
            this.Controls.Add(this.lbName);
            this.Name = "RankPlayers";
            this.Size = new System.Drawing.Size(839, 101);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbName;
        private Label lbAppearance;
        private Label lbScoredGoals;
        private Label lbYellowCards;
        private PictureBox pbImage;
    }
}
