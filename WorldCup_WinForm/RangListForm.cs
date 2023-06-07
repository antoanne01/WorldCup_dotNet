using CupInfo;
using Parse_From_File_Library;
using System.Data;
using System.Diagnostics;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Drawing.Printing;
using System.Windows.Forms;
using PdfSharp;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using FluentNHibernate.Conventions.Inspections;
using System.Drawing.Imaging;
using FavoritePlayersAPI;
using WorldCup_WinForm.Events;

namespace WorldCup_WinForm
{
    public partial class RangListForm : Form
    {
        private const string folderPath = @"..\..\..\..\CommonStoredData";
        private static string PATH = System.IO.Path.Combine(folderPath, @"initial_gender_language_setup.txt");
        private const char DEL = '|';

        string gender = ParseGender.GetGender(PATH, DEL);
        string nationalTeamCode = ParseNationalCode.ParseCode.GetCode();
        string nationalTeamName = ParseNationalCode.ParseName.GetName();

        private const string apiConst = "https://worldcup-vua.nullbit.hr/";
        private const string apiDetails = "/matches";

        private const string SubstitutionIn = "substitution-in";
        private const string Goal = "goal";
        private const string GoalPenalty = "goal-penalty";
        private const string YellowCards = "yellow-card";

        private Dictionary<Player, Player> playerStats = new();
        List<SoccerMatch> soccerMatch;

        public RangListForm()
        {
            InitializeComponent();
        }

        private void btnShowIt_Click(object sender, EventArgs e)
        {
            FillTablesAscending(gender);
        }

        private async void FillTablesAscending(string gender)
        {
            btnShowIt.Enabled = false;
            lbLoading.Visible = true;
            lbLoading.Font = new System.Drawing.Font("Arial", 12);
            lbLoading.Text = "Loading...";

            await Task.Delay(500);

            try
            {
                StatsRepository.TeamStatsRepository repo = new();
                string apiCall = apiConst + gender + apiDetails;
                soccerMatch = await FavoritePlayersShow.GetPlayers(gender, nationalTeamCode);
                //soccerMatch = await repo.GetStats(apiCall);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            List<TeamEvent> teams = RetreiveCountryData(soccerMatch, nationalTeamName);
            List<Player> sEleven = RetreiveStartingElevenData(soccerMatch, nationalTeamName);
            CountPlayerEvents(teams, playerStats, sEleven);

            DisplayGoalScoredSortedPlayers();
            DisplayYelllowCardsSortedPlayers();
            DisplayVisitorsForSelectedGame();

            lbLoading.Visible = false;
        }

        private List<TeamEvent> RetreiveCountryData(List<SoccerMatch> soccerMatch, string nationalTeamName)
        {
            List<TeamEvent> countryTeamData = new List<TeamEvent>();

            foreach (var match in soccerMatch)
            {
                if (match.HomeTeam.Country == nationalTeamName)
                {
                    countryTeamData.AddRange(match.HomeTeamEvents);
                }
                if (match.AwayTeam.Country == nationalTeamName)
                {
                    countryTeamData.AddRange(match.AwayTeamEvents);
                }
            }
            return countryTeamData;
        }

        private List<Player> RetreiveStartingElevenData(List<SoccerMatch> soccerMatch, string nationalTeamName)
        {
            List<Player> startingEleven = new List<Player>();

            foreach (var match in soccerMatch)
            {
                if (match.HomeTeam.Country == nationalTeamName)
                {
                    startingEleven.AddRange(match.HomeTeamStatistics.StartingEleven);
                }
                if (match.AwayTeam.Country == nationalTeamName)
                {
                    startingEleven.AddRange(match.AwayTeamStatistics.StartingEleven);
                }
            }
            return startingEleven;
        }

        private void CountPlayerEvents(List<TeamEvent> events, Dictionary<Player, Player> playerStats, List<Player> startingEleven)
        {
            var startingElevenNames = startingEleven.Select(p => p.Name).ToList();
            var substitutesIn = events.Where(e => e.TypeOfEvent == SubstitutionIn).Select(e => e.Player).ToList();

            var playersCombined = startingElevenNames.Concat(substitutesIn);

            foreach (var playerName in playersCombined)
            {
                Player existingPlayer = playerStats.Keys.FirstOrDefault(p => p.Name == playerName);

                if (existingPlayer == null)
                {
                    Player newPlayer = CreateNewPlayer(playerName);
                    playerStats.Add(newPlayer, newPlayer);
                }
                else
                {
                    Player stats = playerStats[existingPlayer];
                    stats.Appearances++;
                }
            }

            var groupedEvents = events.GroupBy(e => e.Player);

            foreach (var group in groupedEvents)
            {
                string playerName = group.Key;

                int goals = group.Count(e => e.TypeOfEvent == Goal || e.TypeOfEvent == GoalPenalty);
                int yellowCards = group.Count(e => e.TypeOfEvent == YellowCards);

                Player existingPlayer = playerStats.Keys.FirstOrDefault(p => p.Name == playerName);

                if (existingPlayer != null)
                {
                    Player stats = playerStats[existingPlayer];
                    stats.Goals += goals;
                    stats.YellowCards += yellowCards;
                }
                else
                {
                    Player newPlayer = new Player
                    {
                        Name = playerName,
                        Goals = goals,
                        YellowCards = yellowCards,
                        Appearances = 0
                    };

                    playerStats.Add(newPlayer, newPlayer);
                }
            }
        }

        private Player CreateNewPlayer(string playerName)
        {
            return new Player
            {
                Name = playerName,
                Goals = 0,
                YellowCards = 0,
                Appearances = 0
            };
        }

        private void DisplayGoalScoredSortedPlayers()
        {
            Dictionary<Player, Player> sortedPlayers = playerStats.OrderByDescending(kv => kv.Value.Goals).ToDictionary(kv => kv.Key, kv => kv.Value);

            foreach (var item in sortedPlayers)
            {
                Player player = new Player
                {
                    Name = item.Key.Name,
                    Appearances = item.Value.Appearances,
                    Goals = item.Value.Goals,
                    YellowCards = item.Value.YellowCards
                };

                RankPlayers rankIt = new();
                rankIt.SetGoalDescendingDisplay(player);

                rankPlayers.Controls.Add(rankIt);

            }
        }

        private void DisplayYelllowCardsSortedPlayers()
        {
            Dictionary<Player, Player> sortedPlayers = playerStats.OrderByDescending(kv => kv.Value.YellowCards).ToDictionary(kv => kv.Key, kv => kv.Value);

            foreach (var item in sortedPlayers)
            {
                Player player = new Player
                {
                    Name = item.Key.Name,
                    Appearances = item.Value.Appearances,
                    Goals = item.Value.Goals,
                    YellowCards = item.Value.YellowCards
                };

                RankListYellowCards rankIt = new();
                rankIt.SetYellowCardsDisplay(player);

                rankListYellowCards.Controls.Add(rankIt);

            }
        }

        private void DisplayVisitorsForSelectedGame()
        {
            List<SoccerMatch> gameData = soccerMatch.OrderByDescending(kv => kv.Attendance).ToList();

            foreach (var match in gameData)
            {
                if(match.HomeTeamCountry == nationalTeamName || match.AwayTeamCountry == nationalTeamName)
                {
                    SoccerMatch data = new SoccerMatch
                    {
                        Location = match.Location,
                        Attendance = match.Attendance,
                        HomeTeam = match.HomeTeam,
                        AwayTeam = match.AwayTeam
                    };

                    RankListVisitors rankIt = new();
                    rankIt.SetVisitorsDisplay(data);

                    rankListVisitors.Controls.Add(rankIt);

                }
            }
        }

        Bitmap bmp;

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void btnPrintData_Click(object sender, EventArgs e)
        {
            Graphics graphics = this.CreateGraphics();
            bmp = new Bitmap(Size.Width, Size.Height, graphics);
            Graphics mg = Graphics.FromImage(bmp);

            mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            printPreviewDialog.ShowDialog();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Settings initialSettings = new Settings();
            this.Hide();
            initialSettings.ShowDialog();
            initialSettings.BringToFront();
        }
    }
}
