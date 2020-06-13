using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangaPrakashAPI.Administration.IDal
{
    public class MenuDto
    {
        public Guid Id { get; set; }

        public String Name { get; set; }

        public String Controller { get; set; }

        public String Action { get; set; }

        public String Area { get; set; }

        public Int32 SequenceNo { get; set; }

        public Guid? ParentId { get; set; }

        public Guid ModuleId { get; set; }

        public Boolean IsActive { get; set; }

        public Int32 ErrorCount { get; set; }

        public String ErrorMessage { get; set; }

        //Extra Fields

        public String Module { get; set; }

        public String ParentMenu { get; set; }

    }
}
