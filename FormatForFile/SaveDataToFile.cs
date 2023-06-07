using System.Reflection;

namespace FormatForFile
{
    public class SaveDataToFile
    {
        public static void FormatForFile(string folderPath, string filePath, string gender, char del, string language, string screenSize)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            File.WriteAllText(filePath, $"{gender}{del}{language}{del}{screenSize}");

            //using (StreamWriter writer = new StreamWriter(filePath, false))
            //{
            //    string content = $"{gender}{del}{language}{del}{screenSize}";
            //    writer.WriteLine(content);
            //}
        }

        public static void NationalTeamSave(string NATIONAL_TEAM_PATH, string team)
        {
            using (StreamWriter writer = new StreamWriter(NATIONAL_TEAM_PATH, false))
            {
                writer.Write(team);
            }
        }

        public static void CheckInitialSettings(string folderPath, string filePath, string gender, char del, string language, string screenSize)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            if (!File.Exists(filePath))
            {
                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    string content = $"{gender}{del}{language}{del}{screenSize}";
                    writer.WriteLine(content);
                }
            }
        }

        public static void EraseNationalTeamFile(string folderPath, string filePath, string json)
        {

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            if (File.Exists(json))
            {
                File.Delete(json);
            }
        }

        public static void EraseInitialSetup(string folderPath, string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}