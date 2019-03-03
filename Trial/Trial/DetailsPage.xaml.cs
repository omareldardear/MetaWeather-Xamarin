using System;
using System.Collections.Generic;
using Plugin.Connectivity;
using Trial.Modles;
using Trial.Presenters;
using Trial.Views;
using Xamarin.Forms;

namespace Trial
{
    public partial class DetailsPage : ContentPage, iMetaWeatherLocation
    {
        LocationModel m_Location;
        MetaWeatherPresenter m_MetaWeatherPresenter;

        public DetailsPage(LocationModel M_Location)
        {
            InitializeComponent();
            m_Location = M_Location;
            Title = m_Location.title;
            m_MetaWeatherPresenter = new MetaWeatherPresenter(this);
            mIndicator.IsVisible = false;
            mIndicator.IsRunning = false;
            if (CrossConnectivity.Current.IsConnected)
            {
                m_MetaWeatherPresenter.Location(m_Location.woeid);
            }
            else
            {
                mStatusLabel.Text = "Status: Error No Internet";
            }

        }

        public void LocationError()
        {
            mStatusLabel.Text = "Status: Error in API  ";
            mIndicator.IsVisible = false;
            mIndicator.IsRunning = false;
        }

        public void LocationFineshed(WeatherDataModel mData)
        {
            mStatusLabel.Text = "Status: Retrived Data !! ";
            Today_AD.Text = "Applicable Date : "+ mData.consolidated_weather[0].applicable_date;
            Today_MinT.Text = "Min. Temp. :" + mData.consolidated_weather[0].min_temp.ToString();
            Today_MaxT.Text = "Min. Temp. :" + mData.consolidated_weather[0].max_temp.ToString();
            Today_WSN.Text = "Weather State Name: " + mData.consolidated_weather[0].weather_state_name;


            Tomorrow_AD.Text = "Applicable Date : " + mData.consolidated_weather[1].applicable_date;
            Tomorrow_MinT.Text = "Min. Temp. :" + mData.consolidated_weather[1].min_temp.ToString();
            Tomorrow_MaxT.Text = "Min. Temp. :" + mData.consolidated_weather[1].max_temp.ToString();
            Tomorrow_WSN.Text = "Weather State Name: " + mData.consolidated_weather[1].weather_state_name;
            mIndicator.IsVisible = false;
            mIndicator.IsRunning = false;
        }

        public void LocationStarted(string mURL)
        {
            mStatusLabel.Text = "Status: Retriving Data";
            mIndicator.IsVisible = true;
            mIndicator.IsRunning = true;
        }
    }
}
