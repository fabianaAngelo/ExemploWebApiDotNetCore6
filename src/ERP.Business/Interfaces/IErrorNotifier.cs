using ERP.Business.ErrorNotifications;

namespace ERP.Business.Interfaces
{
    public interface IErrorNotifier
    {
        bool HasErrorNotification();
        List<ErrorNotification> GetErrorNotifications();
        void Handle(ErrorNotification errorNotification);
    }
}
