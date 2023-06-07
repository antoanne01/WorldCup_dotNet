using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Reflection;

namespace Parse_From_File_Library
{
    public class ParseGender
    {
        //public static string GetGender(string PATH, char DEL)
        //{
        //    string gender = "";

        //    string[] details = File.ReadAllLines(PATH);
        //    string[] item = details[0].Split(DEL);

        //    gender = item[0];

        //    return gender.ToLower();
        //}

        public static string GetGender(string PATH, char DEL)
        {
            string gender = "";

            using (StreamReader reader = new StreamReader(PATH))
            {
                string[] details = reader.ReadLine().Split(DEL);
                gender = details[0];
            }

            return gender.ToLower();
        }

        public static string GetLanguage(string PATH, char DEL)
        {
            string teamName = "";

            using (StreamReader reader = new StreamReader(PATH))
            {
                string[] details = reader.ReadLine().Split(DEL);
                teamName = details[1];
            }

            //string[] details = File.ReadAllLines(PATH);
            //string[] item = details[0].Split(DEL);

            //teamName = item[1];

            return teamName.ToLower();
        }

        public static string GetScreenSize(string PATH, char DEL)
        {
            string screenSize = "";

            using (StreamReader reader = new StreamReader(PATH))
            {
                string[] details = reader.ReadLine().Split(DEL);
                screenSize = details[2];
            }

            //string[] details = File.ReadAllLines(PATH);
            //string[] item = details[0].Split(DEL);

            //screenSize = details[2];

            return screenSize;
        }
    }
}