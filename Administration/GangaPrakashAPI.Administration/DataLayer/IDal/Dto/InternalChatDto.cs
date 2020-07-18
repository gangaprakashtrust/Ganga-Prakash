using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangaPrakashAPI.Administration.IDal
{
    public class InternalChatDto
    {
        public Guid Id { get; set; }

        public Guid ApplicationUserId { get; set; }

        public String Username { get; set; }

        public String Text { get; set; }

        public DateTime DateTime { get; set; }

        public Boolean IsReceiver { get; set; }

        public Boolean IsActive { get; set; }

        public Int32 ErrorCount { get; set; }

        public String ErrorMessage { get; set; }

    }
}
