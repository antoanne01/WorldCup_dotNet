namespace WorldCup_WinForm
{
    partial class RankListVisitors
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
            this.lbLocation = new System.Windows.Forms.Label();
            this.lbVisitors = new System.Windows.Forms.Label();
            this.lbHomeTeam = new System.Windows.Forms.Label();
            this.lbAwayTeam = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbLocation
            // 
            this.lbLocation.AutoSize = true;
            this.lbLocation.Location = new System.Drawing.Point(12, 55);
            this.lbLocation.Name = "lbLocation";
            this.lbLocation.Size = new System.Drawing.Size(0, 20);
            this.lbLocation.TabIndex = 0;
            // 
            // lbVisitors
            // 
            this.lbVisitors.AutoSize = true;
            this.lbVisitors.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbVisitors.Location = new System.Drawing.Point(180, 55);
            this.lbVisitors.Name = "lbVisitors";
            this.lbVisitors.Size = new System.Drawing.Size(0, 20);
            this.lbVisitors.TabIndex = 1;
            // 
            // lbHomeTeam
            // 
            this.lbHomeTeam.AutoSize = true;
            this.lbHomeTeam.Location = new System.Drawing.Point(319, 55);
            this.lbHomeTeam.Name = "lbHomeTeam";
            this.lbHomeTeam.Size = new System.Drawing.Size(0, 20);
            this.lbHomeTeam.TabIndex = 2;
            // 
            // lbAwayTeam
            // 
            this.lbAwayTeam.AutoSize = true;
            this.lbAwayTeam.Location = new System.Drawing.Point(475, 55);
            this.lbAwayTeam.Name = "lbAwayTeam";
            this.lbAwayTeam.Size = new System.Drawing.Size(0, 20);
            this.lbAwayTeam.TabIndex = 3;
            // 
            // RankListVisitors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbAwayTeam);
            this.Controls.Add(this.lbHomeTeam);
            this.Controls.Add(this.lbVisitors);
            this.Controls.Add(this.lbLocation);
            this.Name = "RankListVisitors";
            this.Size = new System.Drawing.Size(617, 178);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbLocation;
        private Label lbVisitors;
        private Label lbHomeTeam;
        private Label lbAwayTeam;
    }
}
