namespace WorldCup_WinForm
{
    partial class UserControlFavPlayers
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
            this.pnlAllPlayers = new System.Windows.Forms.Panel();
            this.pnlSelectedPlayers = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlAllPlayers
            // 
            this.pnlAllPlayers.AllowDrop = true;
            this.pnlAllPlayers.AutoScroll = true;
            this.pnlAllPlayers.Location = new System.Drawing.Point(3, 3);
            this.pnlAllPlayers.Name = "pnlAllPlayers";
            this.pnlAllPlayers.Size = new System.Drawing.Size(547, 791);
            this.pnlAllPlayers.TabIndex = 0;
            // 
            // pnlSelectedPlayers
            // 
            this.pnlSelectedPlayers.AllowDrop = true;
            this.pnlSelectedPlayers.AutoScroll = true;
            this.pnlSelectedPlayers.Location = new System.Drawing.Point(708, 3);
            this.pnlSelectedPlayers.Name = "pnlSelectedPlayers";
            this.pnlSelectedPlayers.Size = new System.Drawing.Size(491, 794);
            this.pnlSelectedPlayers.TabIndex = 1;
            // 
            // UserControlFavPlayers
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlSelectedPlayers);
            this.Controls.Add(this.pnlAllPlayers);
            this.Name = "UserControlFavPlayers";
            this.Size = new System.Drawing.Size(1202, 797);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlAllPlayers;
        private Panel pnlSelectedPlayers;
    }
}
