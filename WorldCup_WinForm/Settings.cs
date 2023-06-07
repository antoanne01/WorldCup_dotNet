using FormatForFile;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace WorldCup_WinForm
{
    public partial class Settings : Form
    {
        private const string folderPath = @"..\..\..\..\CommonStoredData";
        private string filePath = System.IO.Path.Combine(folderPath, @"initial_gender_language_setup.txt");
        private string nationalTeamPath = System.IO.Path.Combine(folderPath, @"national_team_pick.txt");
        private string jsonFile = System.IO.Path.Combine(folderPath, @"NationalTeamsList.json");
        string screenSize = "AdjustedScreen";

        private const char DEL = '|';
        

        public Settings()
        {
            InitializeComponent();
        }

        private bool formValid()
        {
            if (!(rbMale.Checked || rbFemale.Checked))
            {
                System.Windows.Forms.MessageBox.Show("Please choose gender");
                return false;
            }
            if (!(rbCroatian.Checked || rbEnglish.Checked))
            {
                System.Windows.Forms.MessageBox.Show("Please choose language");
                return false;
            }
            return true;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!formValid())
            {
                return;
            }

            MessageBoxResult result = System.Windows.MessageBox.Show("Do you want to save the changes?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    SaveData();

                    SaveDataToFile.EraseNationalTeamFile(folderPath, nationalTeamPath, jsonFile);

                    FavoriteNationalTeam favoriteTeam = new FavoriteNationalTeam();
                    favoriteTeam.Show();
                    favoriteTeam.BringToFront();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Do you raelly want to close the app?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void SaveData()
        {
            string gender = "";
            string language = "";

            try
            {
                if (rbMale.Checked)
                {
                    rbMale.Checked = true;
                    gender = "Men";
                }
                else if (rbFemale.Checked)
                {
                    rbFemale.Checked = true;
                    gender = "Women";
                }

                if (rbCroatian.Checked)
                {
                    rbCroatian.Checked = true;
                    language = "Croatian";
                }
                else if (rbEnglish.Checked)
                {
                    rbEnglish.Checked = true;
                    language = "English";
                }

                SaveDataToFile.FormatForFile(folderPath, filePath, gender, DEL, language, screenSize);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }        
    }
}
