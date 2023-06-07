using CupInfo;
using ImagesSetup;
using Microsoft.Win32;
using NHibernate.Hql.Ast;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldCup_WinForm
{
    public partial class PlayerInfo : UserControl
    {
        public bool SelPlayer { get; set; } = false;
        public Player PlayerState { get; set; }

        private bool isDragging = false;
        private Point lastLocation;

        public PlayerInfo()
        {
            InitializeComponent();
        }

        public PlayerInfo(Player player)
        {
            InitializeComponent();
            lblName.Text = player.Name;
            lblNumber.Text = player.ShirtNumber.ToString();
            lblPosition.Text = player.Position;
        }

        internal void Deselect()
        {
            BackColor= Color.White;
            SelPlayer= false;
        }

        internal void DisplayStar()
        {
            pbStar.Visible = true;
        }

        internal void RemoveStar()
        {
            pbStar.Visible = false;
        }

        internal void RemoveCaptMark()
        {
            pbCapitan.Visible = false;
        }

        internal void DisplayCaptMark()
        {
            pbCapitan.Visible = true;
        }

        private void btnPicture_Click(object sender, EventArgs e)
        {
            using (System.Windows.Forms.OpenFileDialog openDialog = new System.Windows.Forms.OpenFileDialog())
            {
                openDialog.Filter = "Image Files(*.bmp;*.jpg;*.jpeg;*.png)|*.bmp;*.jpg;*.jpeg;*.png";
                openDialog.Title = "Select image to upload";

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected file path
                    string imagePath = openDialog.FileName;

                    // Set the image to the PictureBox
                    Image image = Image.FromFile(imagePath);

                    // Save the image path to the player object
                    pbPlayerImage.Image = image;
                }
            }
        }

        //protected override void OnMouseDown(MouseEventArgs e)
        //{
        //    base.OnMouseDown(e);

        //    if (e.Button == MouseButtons.Left)
        //    {
        //        isDragging = true;
        //        lastLocation = e.Location;
        //    }
        //}

        //protected override void OnMouseMove(MouseEventArgs e)
        //{
        //    base.OnMouseMove(e);

        //    if (isDragging)
        //    {
        //        DoDragDrop(this, DragDropEffects.Move);
        //    }
        //}

    }
}
