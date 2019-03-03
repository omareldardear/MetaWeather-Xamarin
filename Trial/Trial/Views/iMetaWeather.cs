using System;
using System.Collections.Generic;
using Trial.Modles;

namespace Trial.Views
{
    public interface iMetaWeather
    {
        void SearchLocationStarted(String mURL);
        void SearchLocationFineshed(List<LocationModel> mList);
        void SearchLocationError();
    }
}
