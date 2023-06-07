using System.Text;
using FormatForFile;
using System.IO;

namespace WorldCup_WinForm
{
    public partial class Form1 : Form
    {
        private const string folderPath = @"..\..\..\..\CommonStoredData";
        private string filePath = System.IO.Path.Combine(folderPath, @"initial_gender_language_setup.txt");
        string screenSize = "AdjustedScreen";

        //private const string FORM_SETUP_INITIAL = "initial_gender_language_setup.txt";
        private const char DEL = '|';
        FavoriteNationalTeam favoriteTeam = new FavoriteNationalTeam();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(filePath))
            {
                this.Hide();
                var favoriteTeam = new FavoriteNationalTeam();
                favoriteTeam.ShowDialog();
                this.Close();
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (!formValid())
            {
                return;
            }
            SaveData();
        }

        private bool formValid()
        {
            if(!(rbMale.Checked || rbFemale.Checked))
            {
                MessageBox.Show("Please choose gender");
                return false;
            }
            if (!(rbCroatian.Checked || rbEnglish.Checked))
            {
                MessageBox.Show("Please choose language");
                return false;
            }
            return true;
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
                MessageBox.Show(ex.Message);
            }

            this.Hide();
            favoriteTeam.Show();
            favoriteTeam.BringToFront();
        }

    }
}