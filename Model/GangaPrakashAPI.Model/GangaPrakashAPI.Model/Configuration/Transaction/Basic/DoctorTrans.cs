using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GangaPrakashAPI.Model
{
    public class DoctorTrans : BaseModel
    {
        public Doctor Doctor { get; set; }

        public Address Address { get; set; }

        public DoctorIdentity DoctorIdentity { get; set; }

        public DoctorQualification DoctorQualification { get; set; }

        public List<Department> DepartmentList { get; set; }

        public List<DoctorIdentity> DoctorIdentityList { get; set; }

        public List<DoctorQualification> DoctorQualificationList { get; set; }

        public List<KeyValuePair<Guid, String>> GenderNVList { get; set; }


    }
}
