using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Business.ErrorNotifications
{
    public class ErrorNotification
    {
        public string Message { get; }
        public ErrorNotification(string message)
        {
            Message = message;
        }
    }
}
