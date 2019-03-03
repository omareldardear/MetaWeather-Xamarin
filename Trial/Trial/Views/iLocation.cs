using System;
using Plugin.Geolocator.Abstractions;

namespace Trial.Views
{
    public interface iLocation
    {
        void RequestStarted();
        void RequestFinished(Position pos);
        void RequestError(int errType);
    }
}
