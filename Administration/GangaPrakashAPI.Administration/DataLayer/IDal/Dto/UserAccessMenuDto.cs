﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangaPrakashAPI.Administration.IDal
{
    public class UserAccessMenuDto
    {
        public Guid Id { get; set; }

        public String Action { get; set; }

        public String Controller { get; set; }

        public String Area { get; set; }

        public String Name { get; set; }

        public String Module { get; set; }

        public Guid ModuleId { get; set; }

        public Int32 SequenceNo { get; set; }

        public Guid ParentId { get; set; }

        public Boolean IsParent { get; set; }
    }
}
