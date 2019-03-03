using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Geolocator;
using Trial.Views;
using Plugin.Geolocator.Abstractions;
using Trial.Presenters;
using Plugin.Permissions.Abstractions;
using Plugin.Permissions;
using Trial.Modles;
using System.Collections.ObjectModel;
using Plugin.Connectivity;

namespace Trial
{
    public partial class MasterPage : ContentPage, iLocation, iPermission, iMetaWeather
    {
        LocationPresenter mLocationPresenter;
        PermissionPresenter mPermissionPresenter;
        MetaWeatherPresenter mMetaWeatherPresenter;
        private IList<LocationModel> mLocationsList { get; set; }
        public MasterPage()
        {
            InitializeComponent();
            mLocationPresenter = new LocationPresenter(this);
            mPermissionPresenter = new PermissionPresenter(this);
            mMetaWeatherPresenter = new MetaWeatherPresenter(this);
            mIndicator.IsVisible = false;
            BindingContext = this;

        }



        void Clicked_GetLocation(object sender, System.EventArgs e)
        {
            StateTxt.Text = "State: Checking Location Permission";
            mPermissionPresenter.CheckLocation();
        }


        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new DetailsPage((Trial.Modles.LocationModel)e.Item));
            ((ListView)sender).SelectedItem = null;
        }





        //iLocation
        public void RequestError(int errType)
        {
            StateTxt.Text = "State: Error when Retrieving Device Location Please Open GPS";
            mIndicator.IsVisible = false;
            mIndicator.IsRunning = false;

        }

        public void RequestFinished(Position pos)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                StateTxt.Text = "State: Retrieving Locations from the API";
                mMetaWeatherPresenter.SearchLocation(pos.Latitude, pos.Longitude);
            }
            else
            {
                StateTxt.Text = "State:Error No Internet ";
                mIndicator.IsVisible = false;
                mIndicator.IsRunning = false;
            }
        }

        public void RequestStarted()
        {
            mIndicator.IsRunning = true;
            mIndicator.IsVisible = true;
        }

        //iPermission 

        public void CheckingLocationFinished(bool status)
        {
            if (status)
            {
                StateTxt.Text = "State: Retrieving Device Location";
                mLocationPresenter.RequestLocation();
            }
            else
            {
                StateTxt.Text = "State: Asking For Location Permission";
                mPermissionPresenter.RequestLocationPermission();

            }

        }

        public void RequestingLocationFinished(bool status)
        {
            if (status)
            {
                StateTxt.Text = "State: Device Location";
                mLocationPresenter.RequestLocation();
            }
            else
            {
                StateTxt.Text = "State: Error!! No Permission Please open the Location Permission";
            }

        }


        //iMetaWeather

        public void SearchLocationStarted(String mURL)
        {
            System.Diagnostics.Debug.WriteLine("Getting Locations from " + mURL);
        }

        public void SearchLocationFineshed(List<LocationModel> mList)
        {
            StateTxt.Text = "State: Locations Recieved !";
            mLocationsList = mList;
            LocationsList.ItemsSource = mLocationsList;
            mIndicator.IsVisible = false;
            mIndicator.IsRunning = false;

        }

        public void SearchLocationError()
        {
            StateTxt.Text = "State: API Error when Retrieving Locations ";
            mIndicator.IsVisible = false;
            mIndicator.IsRunning = false;
        }
    }
}
