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
using System.Xml.Linq;

namespace WorldCup_WinForm
{
    public partial class RankListVisitors : UserControl
    {
        public RankListVisitors()
        {
            InitializeComponent();
        }

        public void SetVisitorsDisplay(SoccerMatch data)
        {
            // Set the text of the labels to display the player data
            lbLocation.Text = data.Location;
            lbVisitors.Text = data.Attendance;
            lbHomeTeam.Text = data.HomeTeam.Country.ToString();
            lbAwayTeam.Text = data.AwayTeam.Country.ToString();
        }
    }
}
