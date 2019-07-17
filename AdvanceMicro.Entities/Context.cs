using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceMicro.Entities
{
    public class Context
    {
        public string AssemblyCode { get; set; }
        public UserInformation User { get; set; }
        public Message Request { get; set; }
        public Message Response { get; set; }
        public string RetCode
        {
            get => Response.Fields["RetCode"]?.ToString();
            set
            {
                Response.Fields["RetCode"] = value;
            }
        }
        public string Message
        {
            get => Response.Fields[nameof(Message)]?.ToString();
            set
            {
                Response.Fields[nameof(Message)] = value;
            }
        }
        public Context()
        {
            User = new UserInformation();
            Request = new Message();
            Response = new Message();
        }
    }
}
