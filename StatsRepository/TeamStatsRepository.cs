using CupInfo;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;
using System.Reflection;


namespace StatsRepository
{
    public class TeamStatsRepository : IRepository.IRepo
    {

        private async Task<List<T>> RetrieveData<T>(string api)
        {
            var apiClient = new RestClient(api);
            var request = new RestRequest();
            var response = apiClient.Execute(request);
            var content = response.Content;
            return JsonConvert.DeserializeObject<List<T>>(content);

        }

        //Bellow gather data for WPF TeamInfo file

        public async Task<List<Countries>> GetCountries(string url)
        {
            var apiClient = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            var response = await apiClient.ExecuteAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<List<Countries>>(response.Content);
            }
            else
            {
                throw new Exception($"Error while fetching countries");
            }
        }



        public Task<List<SoccerMatch>> GetPlayers(string fifa_code)
        {
            throw new NotImplementedException();
        }

        // After receiving api, call RetreiveData which returns api data
        public Task<List<SoccerMatch>> GetStats(string apiCode)
        {
            return RetrieveData<SoccerMatch>(apiCode);
        }

    }
}