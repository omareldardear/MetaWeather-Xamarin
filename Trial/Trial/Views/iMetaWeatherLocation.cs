using System;
using Trial.Modles;

namespace Trial.Views
{
    public interface iMetaWeatherLocation
    {
        void LocationStarted(String mURL);
        void LocationFineshed(WeatherDataModel mData);
        void LocationError();
    }
}
