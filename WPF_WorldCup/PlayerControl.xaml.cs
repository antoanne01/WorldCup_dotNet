using CupInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;

namespace WPF_WorldCup
{
    /// <summary>
    /// Interaction logic for PlayerControls.xaml
    /// </summary>
    public partial class PlayerControl : UserControl
    {
        private Player player;
        

        public PlayerControl(Player player)
        {
            InitializeComponent();

            this.player = player;
            lblPlayerName.Content = player.Name;
            lblShirtNumber.Content = player.ShirtNumber.ToString();
        }       

        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            PlayerInfo playerInfo = new PlayerInfo(player);
            playerInfo.Show();
        }
    }
}
