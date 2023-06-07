using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Parse_From_File_Library;
using NationalTeamAPI;
using FormatForFile;
using System.Net.Http;
using System.Reflection;
using System.Drawing.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using FavoritePlayersAPI;
using WorldCup_WinForm.Events;
using CupInfo;
using System.Diagnostics.Metrics;
using System.Windows.Controls;
using ParseNationalCode;

namespace WorldCup_WinForm
{

    public partial class FavoriteNationalTeam : Form
    {
        private const string folderPath = @"..\..\..\..\CommonStoredData";
        private string filePath = System.IO.Path.Combine(folderPath, @"national_team_pick.txt");
        private readonly string DataFilePath = System.IO.Path.Combine(folderPath, @"NationalTeamsList.json");

        private string STORE_PLAYERS_PATH = System.IO.Path.Combine(folderPath, @"selected_players.txt");
        private string NATIONAL_TEAM_PATH = System.IO.Path.Combine(folderPath, @"national_team_pick.txt");
        private string PATH = System.IO.Path.Combine(folderPath, @"initial_gender_language_setup.txt");


        private readonly string Api = "https://worldcup-vua.nullbit.hr";
        //private const string PATH = "initial_gender_language_setup.txt";
        //private const string NATIONAL_TEAM_PATH = "national_team_pick.txt";
        private const char DEL = '|';
        //private const string STORE_PLAYERS_PATH = "selected_players.txt";

        private readonly HttpClient httpClient;

        private IList<Player> allPlayers;


        public FavoriteNationalTeam()
        {
            InitializeComponent();
            httpClient = new HttpClient();
            checkFile();

            comboNationalTeam.SelectedIndexChanged += ComboNationalTeam_SelectedIndexChanged;

        }

        private void ComboNationalTeam_SelectedIndexChanged(object? sender, EventArgs e)
        {
            btnConfirmNationalTeam.Enabled = true;
            ResetForm();
        }

        private void ResetForm()
        {
            pnlAll.Controls.Clear();
        }

        private void checkFile()
        {
            if (File.Exists(NATIONAL_TEAM_PATH))
            {
                using(StreamReader sr = new StreamReader(NATIONAL_TEAM_PATH))
                {
                    string team = sr.ReadLine();
                    comboNationalTeam.Text = team;
                }
            }
        }

        private async void FavoriteNationalTeam_Load(object sender, EventArgs e)
        {
            try
            {
                string gender = ParseGender.GetGender(PATH, DEL);

                dynamic results = await RetreiveTeams.NationalTeams(folderPath ,DataFilePath, Api, httpClient, gender);
                foreach (dynamic result in results)
                {
                    string teamName = result.country;
                    string teamCode = result.fifa_code;
                    comboNationalTeam.Items.Add(teamName + " (" + teamCode + ")");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private async void btnConfirmNationalTeam_Click(object sender, EventArgs e)
        {
            try
            {
                btnConfirmNationalTeam.Enabled = false;

                string comboTeam = null;
                string teamFullName = "";
                //bool btnDisplay = false;

                if (comboNationalTeam.SelectedItem != null)
                {
                    teamFullName = comboNationalTeam.SelectedItem.ToString();
                }

                if (!File.Exists(NATIONAL_TEAM_PATH))
                {
                    SaveDataToFile.NationalTeamSave(NATIONAL_TEAM_PATH, teamFullName);
                }
                else
                {
                    SaveDataToFile.NationalTeamSave(NATIONAL_TEAM_PATH, teamFullName);
                }

                //if (File.Exists(NATIONAL_TEAM_PATH))
                //{
                //    SaveDataToFile.NationalTeamSave(NATIONAL_TEAM_PATH, teamFullName);
                //    //btnDisplay = true;
                //}

                //if (btnDisplay)
                //{
                //    btnConfirmNationalTeam.Enabled = true;
                //}
                //else
                //{
                //    btnConfirmNationalTeam.Enabled = false;
                //}

                string gender = ParseGender.GetGender(PATH, DEL);
                string nationalTeamCode = ParseNationalCode.ParseCode.GetCode();

                string nationalTeamName = ParseNationalCode.ParseName.GetName();

                lbLoading.Visible = true;
                lbLoading.Font = new Font("Arial", 12);
                lbLoading.Text = "Loading...";

                List<SoccerMatch> soccerMatch = await FavoritePlayersShow.GetPlayers(gender, nationalTeamCode);


                allPlayers = GetAllPlayers(soccerMatch, nationalTeamName);

                foreach (var player in allPlayers)
                {
                    PlayerInfo pInfo = new PlayerInfo(new Player
                    {
                        Name = player.Name,
                        Captain = player.Captain,
                        ShirtNumber = player.ShirtNumber,
                        Position = player.Position
                    })
                    {
                        PlayerState = player
                    };


                    //BELLOW LINE ADDED TO CHECK DRAG & DROP
                    pInfo.Tag = player.ShirtNumber;
                    pInfo.RemoveStar();
                    pInfo.MouseMove += pInfo_MouseMove;

                    if (player.Captain == false)
                    {
                        pInfo.RemoveCaptMark();
                    }
                    else
                    {
                        pInfo.DisplayCaptMark();
                    }

                    pnlAll.Controls.Add(pInfo);

                }
                lbLoading.Visible = false;


                UserControlFavPlayers favPlayers = new();
                favPlayers.PopulateData(soccerMatch);

                //favPlayers.Location = new Point(0, (this.ClientSize.Height - favPlayers.Height));

                this.Controls.Add(favPlayers);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        

        // List all players in pnlAll
        private IList<Player> GetAllPlayers(List<SoccerMatch> soccerMatches, string country)
        {
            try
            {
                SoccerMatch soccerGame = soccerMatches.FirstOrDefault();
                if (soccerGame.HomeTeam.Country == country)
                {
                    return new List<Player>(soccerGame.HomeTeamStatistics.StartingEleven.Union(soccerGame.HomeTeamStatistics.Substitutes));
                }
                if (soccerGame.AwayTeam.Country == country)
                {
                    return new List<Player>(soccerGame.AwayTeamStatistics.StartingEleven.Union(soccerGame.AwayTeamStatistics.Substitutes));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }

            return new List<Player>();
        }

        // Bellow drag & drop code commence


        //BELLOW METHOD CHECK FOR DRAG & DROP
        private void pInfo_MouseMove(object? sender, MouseEventArgs e)
        {
            PlayerInfo pInfo = sender as PlayerInfo;
            pInfo.DoDragDrop(pInfo, DragDropEffects.Move);
        }

        private void pnlSelected_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void pnlSelected_DragDrop(object sender, DragEventArgs e)
        {

            if(pnlSelected.Controls.Count == 3)
            {
                return;
            }

            PlayerInfo player = (PlayerInfo)e.Data.GetData(typeof(PlayerInfo));
            pnlAll.Controls.Remove(player);
            pnlSelected.Controls.Add(player);
            player.DisplayStar();
        }


        private void pnlAll_DragDrop(object sender, DragEventArgs e)
        {
            //PlayerInfo player = (PlayerInfo)e.Data.GetData(typeof(PlayerInfo));
            //pnlAll.Controls.Add(player);
            //pnlSelected.Controls.Remove(player);



            //List<PlayerInfo> favPlayers = PickSelectedPlayers(pnlSelected);
            //MoveSelectedPlayers(favPlayers, pnlSelected, pnlAll, false);
        }

        private void pnlAll_DragOver(object sender, DragEventArgs e)
        {
            //e.Effect = DragDropEffects.Move;
        }

        private void pnlAll_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            //e.Effect = e.AllowedEffect;
        }


        private void pnlSelected_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        // Once players are choosen, press button to proceed to see ranked players as per various condition

        private void btnRankLists_Click(object sender, EventArgs e)
        {
            SaveSelectedPlayer();

            this.Hide();
            //RangListForm rangList = new RangListForm();
            var rangList = new RangListForm();
            rangList.ShowDialog();
            this.Close();
        }


        private void SaveSelectedPlayer()
        {
            List<Player> players = new List<Player>();

            foreach (PlayerInfo pInfo in pnlAll.Controls)
            {
                Player player = pInfo.PlayerState;
                player.FavouritePlayer = false;
                players.Add(player);
            }

            foreach (PlayerInfo pInfo in pnlSelected.Controls)
            {
                Player player = pInfo.PlayerState;
                player.FavouritePlayer = true;
                players.Add(player);
            }

            List<string> lines = new List<string>();
            foreach (var player in players)
            {
                try
                {
                    lines.Add(player.FormatPlayersForFile());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (!File.Exists(STORE_PLAYERS_PATH))
            {
                try
                {
                    File.WriteAllLines(STORE_PLAYERS_PATH, lines);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occured while creating file");
                }
            }
        }

        //private void MoveSelectedPlayers(List<PlayerInfo> favPlayers, FlowLayoutPanel source_pnlSelected, FlowLayoutPanel destination_pnlAll, bool added)
        //{
        //    foreach (PlayerInfo player in favPlayers)
        //    {
        //        player.Deselect();
        //        source_pnlSelected.Controls.Remove(player);
        //        destination_pnlAll.Controls.Add(player);
        //        if (added)
        //        {
        //            player.DisplayStar();
        //        }
        //        else
        //        {
        //            player.RemoveStar();
        //        }
        //    }
        //}

        //private List<PlayerInfo> PickSelectedPlayers(FlowLayoutPanel pnlSelected)
        //{
        //    List<PlayerInfo> players = new List<PlayerInfo>();
        //    foreach (PlayerInfo p in pnlSelected.Controls)
        //    {
        //        if (p.SelPlayer)
        //        {
        //            players.Add(p);
        //        }
        //    }
        //    return players;
        //}
    }
}
