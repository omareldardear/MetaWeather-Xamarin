using System;
namespace Trial.Views
{
    public interface iPermission
    {
        void CheckingLocationFinished(bool status);
        void RequestingLocationFinished(bool status);
    }
}
