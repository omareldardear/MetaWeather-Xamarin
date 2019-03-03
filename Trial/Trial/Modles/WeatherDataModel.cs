using System;
using Newtonsoft.Json;

namespace Trial.Modles
{
    public class WeatherDataModel
    {
        [JsonProperty("consolidated_weather")]
        public ConsolidatedWeather[] consolidated_weather { get; set; }

        [JsonProperty("time")]
        public String time { get; set; }

        [JsonProperty("sun_rise")]
        public String sun_rise { get; set; }

        [JsonProperty("sun_set")]
        public String sun_set { get; set; }

        [JsonProperty("timezone_name")]
        public String timezone_name { get; set; }

        [JsonProperty("parent")]
        public Parent parent { get; set; }

        [JsonProperty("sources")]
        public Source[] sources { get; set; }


        [JsonProperty("woeid")]
        public int woeid { get; set; }

        [JsonProperty("title")]
        public String title { get; set; }

        [JsonProperty("location_type")]
        public String location_type { get; set; }

        [JsonProperty("latt_long")]
        public String latt_long { get; set; }

        [JsonProperty("timezone")]
        public String timezone { get; set; }
    }
    public class ConsolidatedWeather
    {

        [JsonProperty("wind_speed")]
        public float wind_speed { get; set; }

        [JsonProperty("wind_direction")]
        public float wind_direction { get; set; }

        [JsonProperty("air_pressure")]
        public float air_pressure { get; set; }

        [JsonProperty("humidity")]
        public float humidity { get; set; }

        [JsonProperty("visibility")]
        public float visibility { get; set; }


        [JsonProperty("id")]
        public long id { get; set; }

        [JsonProperty("min_temp")]
        public float min_temp { get; set; }

        [JsonProperty("max_temp")]
        public float max_temp { get; set; }

        //[JsonProperty("the_temp")]
        //public float the_temp { get; set; }

        [JsonProperty("predictability")]
        public int predictability { get; set; }


        [JsonProperty("applicable_date")]
        public String applicable_date { get; set; }

        [JsonProperty("weather_state_name")]
        public String weather_state_name { get; set; }

        [JsonProperty("weather_state_abbr")]
        public String weather_state_abbr { get; set; }

        [JsonProperty("wind_direction_compass")]
        public String timwind_direction_compassezone { get; set; }



    }
    public class Parent
    {
        [JsonProperty("woeid")]
        public int woeid { get; set; }

        [JsonProperty("title")]
        public String title { get; set; }

        [JsonProperty("location_type")]
        public String location_type { get; set; }

        [JsonProperty("latt_long")]
        public String latt_long { get; set; }
    }
    public class Source
    {
        [JsonProperty("crawl_rate")]
        public int crawl_rate { get; set; }

        [JsonProperty("title")]
        public String title { get; set; }

        [JsonProperty("slug")]
        public String slug { get; set; }

        [JsonProperty("url")]
        public String url { get; set; }

    }
}

