namespace WorldCup_WinForm
{
    partial class FavoriteNationalTeam
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
            this.btnConfirmNationalTeam = new System.Windows.Forms.Button();
            this.comboNationalTeam = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.userControlFavPlayers3 = new WorldCup_WinForm.UserControlFavPlayers();
            this.pnlAll = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlSelected = new System.Windows.Forms.FlowLayoutPanel();
            this.lbLoading = new System.Windows.Forms.Label();
            this.btnRankLists = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnConfirmNationalTeam
            // 
            this.btnConfirmNationalTeam.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnConfirmNationalTeam.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnConfirmNationalTeam.Location = new System.Drawing.Point(565, 131);
            this.btnConfirmNationalTeam.Name = "btnConfirmNationalTeam";
            this.btnConfirmNationalTeam.Size = new System.Drawing.Size(237, 43);
            this.btnConfirmNationalTeam.TabIndex = 5;
            this.btnConfirmNationalTeam.Text = "Confirm National Team";
            this.btnConfirmNationalTeam.UseVisualStyleBackColor = false;
            this.btnConfirmNationalTeam.Click += new System.EventHandler(this.btnConfirmNationalTeam_Click);
            // 
            // comboNationalTeam
            // 
            this.comboNationalTeam.FormattingEnabled = true;
            this.comboNationalTeam.Location = new System.Drawing.Point(550, 75);
            this.comboNationalTeam.Name = "comboNationalTeam";
            this.comboNationalTeam.Size = new System.Drawing.Size(267, 28);
            this.comboNationalTeam.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(465, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(436, 38);
            this.label1.TabIndex = 6;
            this.label1.Text = "Choose Favorite National Team";
            // 
            // userControlFavPlayers3
            // 
            this.userControlFavPlayers3.AllowDrop = true;
            this.userControlFavPlayers3.Location = new System.Drawing.Point(856, 213);
            this.userControlFavPlayers3.Name = "userControlFavPlayers3";
            this.userControlFavPlayers3.Size = new System.Drawing.Size(8, 8);
            this.userControlFavPlayers3.TabIndex = 8;
            // 
            // pnlAll
            // 
            this.pnlAll.AllowDrop = true;
            this.pnlAll.AutoScroll = true;
            this.pnlAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlAll.Location = new System.Drawing.Point(12, 240);
            this.pnlAll.Name = "pnlAll";
            this.pnlAll.Size = new System.Drawing.Size(574, 692);
            this.pnlAll.TabIndex = 9;
            this.pnlAll.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnlAll_DragEnter);
            this.pnlAll.DragOver += new System.Windows.Forms.DragEventHandler(this.pnlAll_DragOver);
            // 
            // pnlSelected
            // 
            this.pnlSelected.AllowDrop = true;
            this.pnlSelected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlSelected.Location = new System.Drawing.Point(872, 240);
            this.pnlSelected.Name = "pnlSelected";
            this.pnlSelected.Size = new System.Drawing.Size(483, 692);
            this.pnlSelected.TabIndex = 10;
            this.pnlSelected.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlSelected_DragDrop);
            this.pnlSelected.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnlSelected_DragEnter);
            // 
            // lbLoading
            // 
            this.lbLoading.AutoSize = true;
            this.lbLoading.Location = new System.Drawing.Point(702, 258);
            this.lbLoading.Name = "lbLoading";
            this.lbLoading.Size = new System.Drawing.Size(0, 20);
            this.lbLoading.TabIndex = 11;
            // 
            // btnRankLists
            // 
            this.btnRankLists.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRankLists.Location = new System.Drawing.Point(644, 528);
            this.btnRankLists.Name = "btnRankLists";
            this.btnRankLists.Size = new System.Drawing.Size(134, 69);
            this.btnRankLists.TabIndex = 12;
            this.btnRankLists.Text = "Rank List";
            this.btnRankLists.UseVisualStyleBackColor = true;
            this.btnRankLists.Click += new System.EventHandler(this.btnRankLists_Click);
            // 
            // FavoriteNationalTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1367, 1053);
            this.Controls.Add(this.btnRankLists);
            this.Controls.Add(this.lbLoading);
            this.Controls.Add(this.pnlSelected);
            this.Controls.Add(this.pnlAll);
            this.Controls.Add(this.userControlFavPlayers3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConfirmNationalTeam);
            this.Controls.Add(this.comboNationalTeam);
            this.Name = "FavoriteNationalTeam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FavoriteNationalTeam";
            this.Load += new System.EventHandler(this.FavoriteNationalTeam_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnConfirmNationalTeam;
        private ComboBox comboNationalTeam;
        private Label label1;
        private UserControlFavPlayers userControlFavPlayers1;
        private UserControlFavPlayers favPlayersudc1;
        private UserControlFavPlayers userControlFavPlayers3;
        private FlowLayoutPanel pnlAll;
        private FlowLayoutPanel pnlSelected;
        private Label lbLoading;
        private Button btnRankLists;
    }
}