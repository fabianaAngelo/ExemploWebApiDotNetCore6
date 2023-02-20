using ERP.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Business.ErrorNotifications
{
    public class ErrorNotifier : IErrorNotifier
    {
        private List<ErrorNotification> _errorNotifications;
        public ErrorNotifier()
        {
            _errorNotifications = new List<ErrorNotification>();
        }
        public List<ErrorNotification> GetErrorNotifications()
        {
            return _errorNotifications;
        }

        public void Handle(ErrorNotification errorNotification)
        {
            _errorNotifications.Add(errorNotification);
        }

        public bool HasErrorNotification()
        {
            return _errorNotifications.Any();
        }
    }
}
