using CupInfo;
using FluentNHibernate.Automapping;
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
    public partial class UserControlFavPlayers : UserControl
    {
        public UserControlFavPlayers()
        {
            InitializeComponent();
            pnlAllPlayers.Visible= false;
        }

        public void PopulateData(List<SoccerMatch> soccerMatch)
        {
            List<SoccerMatch> allPlayers = new();

            //foreach (var match in soccerMatch)
            //{
            //    PlayerInfo playerInfo = new PlayerInfo();
            //    playerInfo.PopulateData(match);

            //    flowLayoutPanel1.Controls.Add(playerInfo);
            //}

            pnlAllPlayers.Visible = true;
        }
    }
}
