using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangaPrakashAPI.Configuration.IDal
{
    public class DoctorDepartmentDto
    {
        public Guid Id { get; set; }

        public Guid DoctorId { get; set; }

        public Guid DepartmentId { get; set; }

        public Boolean IsActive { get; set; }

        public Int32 ErrorCount { get; set; }

        public String ErrorMessage { get; set; }

    }
}
