using System;
using Newtonsoft.Json;
namespace Trial.Modles
{

    public class LocationModel
    {
        [JsonProperty("distance")]
        public int distance { get; set; }

        [JsonProperty("woeid")]
        public int woeid { get; set; }

        [JsonProperty("title")]
        public String title { get; set; }

        [JsonProperty("location_type")]
        public String location_type { get; set; }

        [JsonProperty("latt_long")]
        public String latt_long { get; set; }
    }
}
