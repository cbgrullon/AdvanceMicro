using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceMicro.Services
{
    public static class Load
    {
        private static string coreDbCString;
        public static string CoreDbCString
        {
            get
            {
                if (string.IsNullOrEmpty(coreDbCString))
                    throw new Exception($"{nameof(CoreDbCString)} not have a Value.");
                return coreDbCString;
            }
            set
            {
                coreDbCString = value;
            }
        }
    }
}
