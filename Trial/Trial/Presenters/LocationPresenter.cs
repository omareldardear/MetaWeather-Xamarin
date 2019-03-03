using System;
using System.Threading;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Trial.Views;

namespace Trial.Presenters
{
    public class LocationPresenter
    {
        iLocation m_iLocation;
        public LocationPresenter(iLocation M_iLocation)
        {
            m_iLocation = M_iLocation;
        }

        public async void RequestLocation()
        {
            m_iLocation.RequestStarted();

            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 20;



            if (locator.IsGeolocationAvailable)
            {
                if (locator.IsGeolocationEnabled)
                {
                    try
                    {
                       
                        Position pos = await locator.GetPositionAsync(TimeSpan.FromSeconds(100));
                        m_iLocation.RequestFinished(pos);

                    }
                    catch (GeolocationException ex)
                    {
                        m_iLocation.RequestError(1);
                        //System.Diagnostics.Debug.WriteLine(ex.InnerException);
                        //await DisplayAlert("Error", "Unauthorized", "OK");
                    }
                    catch (Exception ex)
                    {
                        m_iLocation.RequestError(2);
                        //System.Diagnostics.Debug.WriteLine(ex.InnerException);
                    }
                }
                else
                {
                    //await DisplayAlert("Error", "Geo sensors is not turned on.\nPlease turn on it.", "OK");
                    m_iLocation.RequestError(3);
                }


            }
            else
            {
                //await DisplayAlert("Error", "This device does not have any geo sensors or enough permission to use it.", "OK");
                m_iLocation.RequestError(4);
            }
        }
    }
}


