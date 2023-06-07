namespace ParseNationalCode
{
    public class ParseCode
    {
        private const string folderPath = @"..\..\..\..\CommonStoredData";
        private static string PATH = System.IO.Path.Combine(folderPath, "national_team_pick.txt");

        //private const string PATH = "national_team_pick.txt";
        private const char DEL = '(';

        public static string GetCode()
        {
            string[] details = File.ReadAllLines(PATH);
            string[] item = details[0].Split(DEL);

            string code = item[1];
            string countryCode = code.Substring(0, 3);

            return countryCode;
        }
    }

    public class ParseName
    {
        private const string folderPath = @"..\..\..\..\CommonStoredData";
        private static string PATH = System.IO.Path.Combine(folderPath, "national_team_pick.txt");

        //private const string PATH = "national_team_pick.txt";
        private const char DEL = ' ';

        public static string GetName()
        {
            string[] details = File.ReadAllLines(PATH);
            string[] item = details[0].Split(DEL);

            string name = item[0];

            return name;
        }
    }
}