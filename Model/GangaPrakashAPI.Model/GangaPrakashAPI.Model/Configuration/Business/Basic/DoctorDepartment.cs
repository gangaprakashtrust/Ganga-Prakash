using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GangaPrakashAPI.Model
{
    public class DoctorDepartment : BaseModel
    {
        public Guid DoctorId { get; set; }

        public Guid DepartmentId { get; set; }

    }
}
