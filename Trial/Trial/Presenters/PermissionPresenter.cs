using System;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Trial.Views;

namespace Trial.Presenters
{
    public class PermissionPresenter
    {
        iPermission m_iPermission;
        public PermissionPresenter(iPermission M_iPermission)
        {
            m_iPermission = M_iPermission;
        }

        public async void CheckLocation()
        {
            PermissionStatus LocationPermissionState = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
            if (LocationPermissionState == PermissionStatus.Granted)
                m_iPermission.CheckingLocationFinished(true);
            else
                m_iPermission.CheckingLocationFinished(false);
        }
        public async void RequestLocationPermission()
        {
            var responce = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
            if (responce[Permission.Location] == PermissionStatus.Granted)
                m_iPermission.RequestingLocationFinished(true);
            else
                m_iPermission.RequestingLocationFinished(false);

        }
    }
}
