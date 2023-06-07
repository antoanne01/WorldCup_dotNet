using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using CupInfo;
using System.Net.Http;
using FavoritePlayersAPI;
using NationalTeamAPI;
using FormatForFile;
using Parse_From_File_Library;

namespace WPF_WorldCup
{
    public partial class MainWindow : Window
    {
        private const string folderPath = @"..\..\..\..\CommonStoredData";
        private string NATIONAL_TEAM_PATH = System.IO.Path.Combine(folderPath, @"national_team_pick.txt");
        private static string GENDER_PATH = System.IO.Path.Combine(folderPath, @"initial_gender_language_setup.txt");
        private string DataFilePath = System.IO.Path.Combine(folderPath, @"NationalTeamsList.json");

        private const string apiConst = "https://worldcup-vua.nullbit.hr/";
        private const string apiDetailsPlayers = "/matches";
        private const string apiDetails = "/teams/results";
        private const string apiOther = "/matches/country?fifa_code=";

        private const char DEL = '|';
        private string screenSize;


        private readonly HttpClient httpClient;

        public MatchData matchData;

        private List<SoccerMatch> soccerMatch;
        private List<TeamEvent> teamEventInfo;
        private List<Countries> countriesInfo;
        private List<Countries> awayCountries;
        List<Team> teamInfo;

        Countries teamInfoData;
        Countries homeTeamCountry;
        Countries awayTeamCountry;

        string nationalTeamName = ParseNationalCode.ParseName.GetName();
        string nationalTeamCode = ParseNationalCode.ParseCode.GetCode();
        string gender = Parse_From_File_Library.ParseGender.GetGender(GENDER_PATH, DEL);
        string screenResolution = Parse_From_File_Library.ParseGender.GetScreenSize(GENDER_PATH, DEL);

        string retreiveLanguage = ParseGender.GetLanguage(GENDER_PATH, DEL);
        string retreiveScreenSize = ParseGender.GetScreenSize(GENDER_PATH, DEL);

        string choosenTeam = "";
        string oppTeam = "";
        string homeTeam = "";


        public MainWindow()
        {
            InitializeComponent();

            CheckForSettings();
            SetScreenSize();

            httpClient = new HttpClient();
            cbChooseOpponent.SelectionChanged += CbChooseOpponent_SelectionChanged;
            cbNationalTeam.SelectionChanged += cbNationalTeam_SelectionChanged;
            FavoriteNationalTeam_Load();
            CheckForFile();
        }

        private void SetScreenSize()
        {
            if (screenResolution == "FullScreen" || screenResolution == null)
            {
                Window window = System.Windows.Application.Current.MainWindow;
                window.WindowState = WindowState.Maximized;
            }
            else if (screenResolution == "AdjustedScreen")
            {
                mWindow.Height = 900;
                mWindow.Width = 800;
            }
            else if (screenResolution == "SmallScreen")
            {
                mWindow.Height =800;
                mWindow.Width = 700;
            }
        }

        private void CheckForSettings()
        {
            if (!File.Exists(GENDER_PATH))
            {
                InitialSettings settings = new InitialSettings();
                settings.Show();
                this.Close();
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
        }

        // Bellow choosen new home team, should update opponent
        // Currently not functional because file access is denied

        private void cbNationalTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbNationalTeam.SelectedItem != null)
            {
                choosenTeam = cbNationalTeam.SelectedItem.ToString();
                pickedTeam.Text = choosenTeam;
                pickedTeamScore.Text = "";
                opponentTeam.Text = "";
                opponentTeamScore.Text = "";

                SaveDataToFile.NationalTeamSave(NATIONAL_TEAM_PATH, choosenTeam);

                UpdateData(choosenTeam);
            }
        }

        private async void UpdateData(string? choosenTeam)
        {
            cbNationalTeam.Items.Clear();
            EraseFootballPitch();

            string choosenTeamCode = ParseNationalCode.ParseCode.GetCode();

            soccerMatch = await GenerateData(gender, choosenTeamCode);
            teamInfo = FindOpponentData(soccerMatch, choosenTeam);
            countriesInfo = await GetAllCountries(gender);

            FavoriteNationalTeam_Load();
        }

        private void CbChooseOpponent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (cbChooseOpponent.SelectedItem != null)
            {
                oppTeam = cbChooseOpponent.SelectedItem.ToString();
                opponentTeam.Text = oppTeam;

                // Update the scores here with the new teams
                List<int> results = setOpponentTeamResult(soccerMatch, oppTeam);
                //opponentTeamScore
                opponentTeamScore.Text = results[0].ToString();
                pickedTeamScore.Text = results[1].ToString();

                EraseFootballPitch();

                btnHomeTactics.IsEnabled = true;
            }
        }

        private void EraseFootballPitch()
        {
            spGoalkeeperHome.Children.Clear();
            spDefenderHome.Children.Clear();
            spMidfielderHome.Children.Clear();
            spForwardHome.Children.Clear();
            spGoalkeeperGuests.Children.Clear();
            spDefenderGuests.Children.Clear();
            spMidfielderGuests.Children.Clear();
            spForwardGuests.Children.Clear();
        }

        //when opponent team is choosen, set result 

        private List<int> setOpponentTeamResult(List<SoccerMatch> soccerMatch, string choosenTeam)
        {
            List<int> data = new List<int>();

            foreach (var match in soccerMatch)
            {
                if (match.HomeTeam.Country == choosenTeam)
                {
                    data.Add(match.HomeTeam.Goals);
                    data.Add(match.AwayTeam.Goals);
                }
                if (match.AwayTeam.Country == choosenTeam)
                {
                    data.Add(match.AwayTeam.Goals);
                    data.Add(match.HomeTeam.Goals);
                }
            }

            return data;
        }

        private void CheckForFile()
        {
            if (File.Exists(NATIONAL_TEAM_PATH))
            {
                using (StreamReader sr = new StreamReader(NATIONAL_TEAM_PATH))
                {
                    string team = sr.ReadLine();
                    cbNationalTeam.Text = team;
                }
            }
        }

        private async void FavoriteNationalTeam_Load()
        {
            // first try-catch block setting combo box with all possible national teams
            try
            {
                dynamic results = await RetreiveTeams.NationalTeams(folderPath, DataFilePath, apiConst, httpClient, gender);
                foreach (dynamic result in results)
                {
                    string teamName = result.country;
                    string teamCode = result.fifa_code;
                    cbNationalTeam.Items.Add(teamName + " (" + teamCode + ")");
                }
                //cbNationalTeam.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

            // Bellow try-catch is to display teams and results

            string nTeamName = ParseNationalCode.ParseName.GetName();
            string nTeamCode = ParseNationalCode.ParseCode.GetCode();

            try
            {
                pickedTeam.Text = nTeamName;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

            soccerMatch = await GenerateData(gender, nTeamCode);
            teamInfo = FindOpponentData(soccerMatch, nTeamName);
            countriesInfo = await GetAllCountries(gender);

            //Bellow is to set opponent into combo box
            //cbChooseOpponent
            cbChooseOpponent.Items.Clear();
            try
            {
                foreach (var item in teamInfo)
                {
                    cbChooseOpponent.Items.Add(item.Country);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            cbNationalTeam.SelectedValue = nTeamName;
        }

        //bellow methods for displaying data

        private async Task<List<Countries>> GetAllCountries(string gender)
        {
            StatsRepository.TeamStatsRepository repo = new();
            string apiCall = apiConst + gender + apiDetails;
            dynamic result = await repo.GetCountries(apiCall);

            return result;
        }

        // Retreive data from API to SoccerMatch
        private async Task<List<SoccerMatch>> GenerateData(string gender, string nationalTeamCode)
        {
            dynamic result = await FavoritePlayersShow.GetPlayers(gender, nationalTeamCode);
            return result;
        }

        // Find opponent data
        private List<Team> FindOpponentData(List<SoccerMatch> soccerMatch, string nationalTeamName)
        {
            List<Team> countryTeamData = new List<Team>();

            foreach (var match in soccerMatch)
            {
                if (match.HomeTeam.Country == nationalTeamName)
                {
                    countryTeamData.Add(match.AwayTeam);
                }
                if (match.AwayTeam.Country == nationalTeamName)
                {
                    countryTeamData.Add(match.HomeTeam);
                }
            }
            return countryTeamData;
        }

        private void btnHomeTeam_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                btnAwayTeam.IsEnabled = true;
                btnHomeTeam.IsEnabled = false;

                homeTeamCountry = GetCountry(pickedTeam.Text);
                TeamInfo teamInfo = GetTeamData(homeTeamCountry.Country);
                teamInfo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void btnAwayTeam_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                btnAwayTeam.IsEnabled = false;
                btnHomeTeam.IsEnabled = true;

                if (cbChooseOpponent.SelectedItem != null)
                {
                    awayTeamCountry = GetCountry(opponentTeam.Text);
                    TeamInfo teamInfo = GetTeamData(awayTeamCountry.Country);
                    teamInfo.Show();
                }
                else
                {
                    MessageBox.Show("Please choose opponent");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private Countries GetCountry(string countryName)
        {
            foreach (Countries country in countriesInfo)
            {
                if (country.Country == countryName)
                {
                    teamInfoData = country;
                }
            }
            return teamInfoData;
        }

        private TeamInfo GetTeamData(string country)
        {
            TeamInfo teamInfo = new TeamInfo();
            foreach (var team in countriesInfo)
            {
                if (team.Country == country)
                {
                    teamInfo.lblCountry.Content = team.Country;
                    teamInfo.lblWins.Content = team.Wins;
                    teamInfo.lblDraws.Content = team.Draws;
                    teamInfo.lblGamesPlayed.Content = team.GamesPlayed;
                    teamInfo.lblPoints.Content = team.Points;
                    teamInfo.lblGoalsScored.Content = team.GoalsFor;
                    teamInfo.lblGoalsReceived.Content = team.GoalsAgainst;
                    teamInfo.lblGoalsDifferences.Content = team.GoalDifferential;
                }
            }
            return teamInfo;
        }

        // Present HOME TEAM formations 

        private async void btnHomeTactics_Click(object sender, RoutedEventArgs e)
        {
            string nTeamName = ParseNationalCode.ParseName.GetName();
            string nTeamCode = ParseNationalCode.ParseCode.GetCode();

            lbLoading.Content = "Loading......";
            await Task.Delay(500);
            lbLoading.Visibility = Visibility.Visible;
            RetreiveData(nTeamName, nTeamCode);
            lbLoading.Visibility = Visibility.Collapsed;
            btnHomeTactics.IsEnabled = false;
        }

        private async void RetreiveData(string nationalTeamName, string nationalTeamCode)
        {
            //Retreive all info
            string api = apiConst + gender + apiOther + nationalTeamCode;
            try
            {
                //StatsRepository.TeamStatsRepository repo = new();
                //soccerMatch = await repo.GetStats(api);
                 
                matchData = RetreiveMatchData(soccerMatch, nationalTeamName);

                if (!string.IsNullOrEmpty(pickedTeam.Text) && !string.IsNullOrEmpty(opponentTeam.Text))
                {
                    string home = pickedTeam.Text;
                    string away = opponentTeam.Text;

                    GetTeamsFromMatch(matchData, home);
                    GetTeamsFromMatch(matchData, away);
                }
                else
                {
                    MessageBox.Show("Please choose booth teams to present players");
                }
                //GetHomeTeam(matchData, nationalTeamName);
                //homeTeam = nationalTeamName + $" (" + nationalTeamCode + $")";

                //GetAwayTeam(matchData, nationalTeamName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetTeamsFromMatch(MatchData matchData, string country)
        {
            foreach (var match in matchData.MatchPlayed)
            {
                if (match.AwayTeamCountry == country)
                {
                    foreach (var player in match.AwaysPlayers)
                    {
                        PlayerControl playerControl = new PlayerControl(new Player
                        {
                            Name = player.Name,
                            Captain = player.Captain,
                            ShirtNumber = player.ShirtNumber,
                            Position = player.Position,
                            Image = player.Image,
                            Goals = player.GoalsPerMatch,
                            YellowCards = player.YellowCardsPerMatch,
                        });
                        SetAwayPlayersToFiled(player, playerControl);
                    }
                    foreach (var player in match.HomePlayers)
                    {
                        PlayerControl playerControl = new PlayerControl(new Player
                        {
                            Name = player.Name,
                            Captain = player.Captain,
                            ShirtNumber = player.ShirtNumber,
                            Position = player.Position,
                            Image = player.Image,
                            Goals = player.GoalsPerMatch,
                            YellowCards = player.YellowCardsPerMatch
                        });

                        SetHomePlayersToFiled(player, playerControl);
                    }
                }
            }
        }

        private void SetHomePlayersToFiled(Player player, PlayerControl playerControl)
        {
            if (player.Position.Equals("Goalie"))
            {
                Grid.SetColumn(playerControl, 0);
                Grid.SetRow(playerControl, 2);
                spGoalkeeperHome.Children.Add(playerControl);
            }

            if (player.Position.Equals("Defender"))
            {
                Grid.SetColumn(playerControl, 1);
                Grid.SetRow(playerControl, 2);
                spDefenderHome.Children.Add(playerControl);
            }

            if (player.Position.Equals("Midfield"))
            {
                Grid.SetColumn(playerControl, 2);
                Grid.SetRow(playerControl, 2);
                spMidfielderHome.Children.Add(playerControl);
            }

            if (player.Position.Equals("Forward"))
            {
                Grid.SetColumn(playerControl, 3);
                Grid.SetRow(playerControl, 2);
                spForwardHome.Children.Add(playerControl);
            }
        }

        private void SetAwayPlayersToFiled(Player player, PlayerControl playerControl)
        {
            if (player.Position.Equals("Goalie"))
            {
                Grid.SetColumn(playerControl, 7);
                Grid.SetRow(playerControl, 2);
                spGoalkeeperGuests.Children.Add(playerControl);
            }

            if (player.Position.Equals("Defender"))
            {
                Grid.SetColumn(playerControl, 6);
                Grid.SetRow(playerControl, 2);
                spDefenderGuests.Children.Add(playerControl);
            }

            if (player.Position.Equals("Midfield"))
            {
                Grid.SetColumn(playerControl, 5);
                Grid.SetRow(playerControl, 2);
                spMidfielderGuests.Children.Add(playerControl);
            }

            if (player.Position.Equals("Forward"))
            {
                Grid.SetColumn(playerControl, 4);
                Grid.SetRow(playerControl, 2);
                spForwardGuests.Children.Add(playerControl);
            }
        }

        private MatchData RetreiveMatchData(List<SoccerMatch> soccerMatch, string nationalTeamName)
        {
            var singleMatchData = new MatchData
            {
                StartingEleven = soccerMatch[0].HomeTeamStatistics.StartingEleven.ToList(),
                MatchPlayed = new List<MatchPlayed>()
            };
            foreach (var game in soccerMatch)
            {
                var match = new MatchPlayed();

                if (game.HomeTeamCountry == nationalTeamName)
                {
                    match.HomeTeamCountry = game.HomeTeamCountry;
                    match.HomePlayers = GetPlayerData(game.HomeTeamStatistics.StartingEleven.ToList(), game.HomeTeamEvents);
                    match.HomesGoals = game.HomeTeam.Goals;

                    match.AwayTeamCountry = game.AwayTeamCountry;
                    match.AwaysPlayers = GetPlayerData(game.AwayTeamStatistics.StartingEleven.ToList(), game.AwayTeamEvents);
                    match.AwaysGoals = game.AwayTeam.Goals;
                }
                else
                {
                    match.HomeTeamCountry = game.AwayTeamCountry;
                    match.HomePlayers = GetPlayerData(game.AwayTeamStatistics.StartingEleven.ToList(), game.AwayTeamEvents);
                    match.HomesGoals = game.AwayTeam.Goals;

                    match.AwayTeamCountry = game.HomeTeamCountry;
                    match.AwaysPlayers = GetPlayerData(game.HomeTeamStatistics.StartingEleven.ToList(), game.HomeTeamEvents);
                    match.AwaysGoals = game.HomeTeam.Goals;
                }
                singleMatchData.MatchPlayed.Add(match);
            }
            return singleMatchData;
        }

        private List<Player> GetPlayerData(List<Player> players, List<TeamEvent> teamEvents)
        {
            var playerEvent = players;
            var team = teamEvents;
            var filteredEvents = teamEvents.Where(e => e.TypeOfEvent == "yellow-card" || e.TypeOfEvent == "goal-penalty" || e.TypeOfEvent == "goal").ToList();

            foreach (var teamEvent in filteredEvents)
            {
                var playerE = players.FirstOrDefault(player => player.Name == teamEvent.Player);
                if (playerE != null)
                {
                    if (teamEvent.TypeOfEvent == "yellow-card")
                    {
                        playerE.YellowCardsPerMatch++;
                    }
                    else if (teamEvent.TypeOfEvent == "goal-penalty" || teamEvent.TypeOfEvent == "goal")
                    {
                        playerE.GoalsPerMatch++;
                    }
                }
            }
            return playerEvent;
        }

        private void btnCloseDialog_Click(object sender, RoutedEventArgs e)
        {
            CloseApp closeApp = new CloseApp();
            closeApp.ShowDialog();

            if (closeApp.DialogResult == true)
            {
                this.Close();
            }
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            InitialSettings settings = new InitialSettings();
            this.Close();
            settings.ShowDialog();
        }
    }
}
