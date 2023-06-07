using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Net.Http;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using MiNET;
using static FavoritePlayersAPI.FavoritePlayersShow;
using RestSharp;
using NHibernate.Cfg.XmlHbmBinding;
using CupInfo;
using Jose;
using System.Net;

namespace FavoritePlayersAPI
{
    public class FavoritePlayersShow
    {

        public static async Task<List<SoccerMatch>> GetPlayers(string gender, string teamCode)
        {

            string API = $"https://worldcup-vua.nullbit.hr/{gender}/matches/country?fifa_code={teamCode}";

            var apiClient = new RestClient(API);
            var request = new RestRequest(API, Method.Get);
            var response = await apiClient.ExecuteAsync(request);

            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<List<SoccerMatch>>(response.Content);
            }
            else
            {
                throw new Exception($"error while fetching");
            }
        }
    }
}