using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangaPrakashAPI.Administration.IDal
{
    public class ApplicationUserDto
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public String UserName { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public string Email { get; set; }

        public String ShortName { get; set; }

        public string MobileNo { get; set; }

        public Boolean IsDoctor { get; set; }

        public String ImagePath { get; set; }

        public Boolean IsActive { get; set; }

        public Int32 ErrorCount { get; set; }

        public String ErrorMessage { get; set; }

    }
}
