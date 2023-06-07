using Newtonsoft.Json;

namespace NationalTeamAPI
{
    public class RetreiveTeams
    {
        public static async Task<dynamic> NationalTeams(string folderPath, string DataFilePath, string Api, HttpClient httpClient, string gender)
        {
            string json;

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            if (File.Exists(DataFilePath))
            {
                using (StreamReader reader = new StreamReader(DataFilePath))
                {
                    json = await reader.ReadToEndAsync();
                }

                //json = File.ReadAllText(DataFilePath);
            }
            else
            {
                string ApiURLToSend = $"{Api}/{gender}/teams";
                json = await httpClient.GetStringAsync(ApiURLToSend);

                using (StreamWriter writer = new StreamWriter(DataFilePath, false))
                {
                    await writer.WriteAsync(json);
                }

                //File.WriteAllText(DataFilePath, json);
            }

            dynamic results = JsonConvert.DeserializeObject(json);
            return results;
        }
    }
}