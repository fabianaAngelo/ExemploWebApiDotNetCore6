using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Api.Extensions
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int ExpiryHours { get; set; }
        public int FinalExpiration { get; set; }
        public string Emitter { get; set; }
        public string ValidIn { get; set; }
    }
}
