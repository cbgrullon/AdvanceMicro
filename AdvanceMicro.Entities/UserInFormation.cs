using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceMicro.Entities
{
    public class UserInformation
    {
        public string UserName { get; set; }
        public bool IsAuthenticated { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime ExpiresOn { get; set; }
    }
}
