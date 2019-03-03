using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Trial.Assets;
using Trial.Modles;
using Trial.Views;


namespace Trial.Presenters
{
    public class MetaWeatherPresenter
    {
        WebService mWebService;
        iMetaWeather m_iMetaWeahther;
        iMetaWeatherLocation m_iMetaWeatherLocation;
        public MetaWeatherPresenter(iMetaWeather M_iMetaWeahther)
        {
            mWebService = new WebService();
            m_iMetaWeahther = M_iMetaWeahther;
        }
        public MetaWeatherPresenter(iMetaWeatherLocation M_iMetaWeatherLocation)
        {
            mWebService = new WebService();
            m_iMetaWeatherLocation = M_iMetaWeatherLocation;
        }

        public async void Location(int woeid)
        {
            String mURL = GenerateLocationRequestURL(woeid);
            m_iMetaWeatherLocation.LocationStarted(mURL);
            String responce = await mWebService.GET_Task(mURL);
            if (responce != null)
            {
                var mData = JsonConvert.DeserializeObject<WeatherDataModel>(responce);
                m_iMetaWeatherLocation.LocationFineshed(mData);
            }
            else
            {
                m_iMetaWeatherLocation.LocationError();
            }
        }



        public async void SearchLocation(double Longitude, double Latitude)
        {
            String mURL = GenerateSearchLocationRequestUri(Longitude, Latitude);
            m_iMetaWeahther.SearchLocationStarted(mURL);
            String responce = await mWebService.GET_Task(mURL);
            if(responce != null)
            {
                var mList = JsonConvert.DeserializeObject<List<LocationModel>>(responce);
                m_iMetaWeahther.SearchLocationFineshed(mList);
            }
            else
            {
                m_iMetaWeahther.SearchLocationError();
            }
        }


        private String GenerateLocationRequestURL(int woeid)
        {
            String requestUri = Constants.META_WEATHER_END_POINT;
            requestUri += "location/" + woeid.ToString() ;
            return requestUri;
        }
        private String GenerateSearchLocationRequestUri(double Longitude, double Latitude)
        {
            String requestUri = Constants.META_WEATHER_END_POINT;
            requestUri += "location/search/?lattlong=" + Longitude.ToString() + "," + Latitude.ToString();
            return requestUri;
        }
    }
}
