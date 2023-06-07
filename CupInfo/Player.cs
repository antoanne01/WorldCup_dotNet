using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CupInfo
{
    public class Player
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("captain")]
        public bool Captain { get; set; }

        [JsonProperty("shirt_number")]
        public long ShirtNumber { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

        [JsonProperty("goals")]
        public int Goals { get; set; }

        [JsonProperty("yellow_cards")]
        public int YellowCards { get; set; }

        public int GoalsPerMatch { get; set; }

        public int YellowCardsPerMatch { get; set; }

        public bool FavouritePlayer { get; set; }

        public string Image { get; set; }

        public int Appearances { get; set; }

        public bool IsSelected { get; set; }

        private const char Del = '|';


        // Bellow method store players into the .txt file

        public string FormatPlayersForFile()
        {
            return $"{Name}{Del}{Captain}{Del}{ShirtNumber}{Del}{Position}{Del}{Goals}{Del}{YellowCards}{Del}{GoalsPerMatch}{Del}{YellowCardsPerMatch}{Del}{FavouritePlayer}{Del}{Image}";
        }

        public int CompareTo(Player other) => -Goals.CompareTo(other.Goals);
        public int CompareToYellowCard(Player other) => -YellowCards.CompareTo(other.YellowCards);

        public override bool Equals(object obj) => obj is Player other ? Name == other.Name : false;
        public override int GetHashCode() => Name.GetHashCode();
    }
}
