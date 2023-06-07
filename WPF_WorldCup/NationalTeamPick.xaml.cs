using FormatForFile;
using NationalTeamAPI;
using Parse_From_File_Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_WorldCup
{
    /// <summary>
    /// Interaction logic for NationalTeamPick.xaml
    /// </summary>
    public partial class NationalTeamPick : Window
    {
        private const string folderPath = @"..\..\..\..\CommonStoredData";
        private string PATH = System.IO.Path.Combine(folderPath, @"initial_gender_language_setup.txt");
        private string filePath = System.IO.Path.Combine(folderPath, @"national_team_pick.txt");
        private readonly string DataFilePath = System.IO.Path.Combine(folderPath, @"NationalTeamsList.json");
        private readonly string Api = "https://worldcup-vua.nullbit.hr";
        private const char DEL = '|';

        private readonly HttpClient httpClient;


        public NationalTeamPick()
        {
            InitializeComponent();
            httpClient = new HttpClient();

            NationalTeamPickLoad();
        }



        private async void NationalTeamPickLoad()
        {
            try
            {
                string gender = ParseGender.GetGender(PATH, DEL);

                dynamic results = await RetreiveTeams.NationalTeams(folderPath, DataFilePath, Api, httpClient, gender);
                foreach (dynamic result in results)
                {
                    string teamName = result.country;
                    string teamCode = result.fifa_code;
                    cbNationalTeam.Items.Add(teamName + " (" + teamCode + ")");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string comboTeam = null;
            string teamFullName = "";

            if (cbNationalTeam.SelectedItem != null)
            {
                teamFullName = cbNationalTeam.SelectedItem.ToString();
            }

            SaveDataToFile.NationalTeamSave(filePath, teamFullName);

            MainWindow window = new();
            window.Show();
            this.Close();
        }
    }
}
