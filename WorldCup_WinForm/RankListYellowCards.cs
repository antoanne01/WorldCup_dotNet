using CupInfo;
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
    public partial class RankListYellowCards : UserControl
    {
        public RankListYellowCards()
        {
            InitializeComponent();
        }

        public void SetYellowCardsDisplay(Player player)
        {
            // Set the text of the labels to display the player data
            pbImage.Visible = true;
            lbName.Text = player.Name;
            lbAppearance.Text = player.Appearances.ToString();
            lbScoredGoals.Text = player.Goals.ToString();
            lbYellowCards.Text = player.YellowCards.ToString();
        }
    }
}
