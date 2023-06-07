using FormatForFile;
using Parse_From_File_Library;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace WPF_WorldCup
{
    /// <summary>
    /// Interaction logic for InitialSettings.xaml
    /// </summary>
    public partial class InitialSettings : Window
    {

        private const string folderPath = @"..\..\..\..\CommonStoredData";
        private static string filePath = System.IO.Path.Combine(folderPath, @"initial_gender_language_setup.txt");
        private readonly string JsonFilePath = System.IO.Path.Combine(folderPath, @"NationalTeamsList.json");
        private const char DEL = '|';

        private string gender = Parse_From_File_Library.ParseGender.GetGender(filePath, DEL);
        private string language = Parse_From_File_Library.ParseGender.GetLanguage(filePath, DEL);
        private string screenSize;
        private string selectedGender;
        private string selectedLanguage;

        //string retreiveGender = "";
        //string retreiveLanguage = "";
        string retreiveScreenSize = Parse_From_File_Library.ParseGender.GetScreenSize(filePath, DEL);

        public InitialSettings()
        {
            InitializeComponent();

            SetUpInitialSettings();
        }

        private void SetUpInitialSettings()
        {

            if (language != null)
            {
                if (language == "croatian")
                {
                    rbCroatian.IsChecked = true;
                }
                else
                {
                    rbEnglish.IsChecked = true;
                }
            }

            if (gender != null)
            {
                if (gender == "men")
                {
                    rbMan.IsChecked = true;
                }
                else
                {
                    rbWoman.IsChecked = true;
                }
            }

            if(screenSize != null)
            {
                if(screenSize == "FullScreen")
                {
                    rbFullScreen.IsChecked = true;
                }
                else if(screenSize == "AdjustedScreen")
                {
                    rbAdjustedScreen.IsChecked = true;
                }
                else
                {
                    rbSmallScreen.IsChecked = true;
                }
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (rbCroatian.IsChecked == true)
            {
                selectedLanguage = "Croatian";
            }
            else if (rbEnglish.IsChecked == true)
            {
                selectedLanguage = "English";
            }

            if (rbMan.IsChecked == true)
            {
                selectedGender = "Men";
            }
            else if (rbWoman.IsChecked == true)
            {
                selectedGender = "Women";
            }

            if (rbFullScreen.IsChecked == true)
            {
                screenSize = "FullScreen";
            }
            else if (rbAdjustedScreen.IsChecked == true)
            {
                screenSize = "AdjustedScreen";
            }
            else if (rbSmallScreen.IsChecked == true)
            {
                screenSize = "SmallScreen";
            }

            // read data from file in order to delete it

            if (!string.IsNullOrEmpty(selectedGender) || !string.IsNullOrEmpty(selectedLanguage) || !string.IsNullOrEmpty(screenSize))
            {
                //string retreiveGender = ParseGender.GetGender(filePath, DEL);
                //string retreiveLanguage = ParseGender.GetLanguage(filePath, DEL);
                //string retreiveScreenSize = ParseGender.GetScreenSize(filePath, DEL);

                if (! string.Equals(selectedGender, gender, StringComparison.OrdinalIgnoreCase) || 
                    ! string.Equals(selectedLanguage, language, StringComparison.OrdinalIgnoreCase) || 
                    ! string.Equals(screenSize, retreiveScreenSize, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBoxResult result = MessageBox.Show("Do you want to save the changes?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if(result == MessageBoxResult.Yes)
                    {
                        try
                        {

                            SaveDataToFile.FormatForFile(folderPath, filePath, selectedGender, DEL, selectedLanguage, screenSize);

                            File.Delete(JsonFilePath);

                            NationalTeamPick teamPick = new();
                            teamPick.Show();
                            this.Close();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        
                    }
                }
            }

        }
    }
}
