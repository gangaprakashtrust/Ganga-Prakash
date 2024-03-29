﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangaPrakashAPI.Model
{
    public class BaseModel
    {
        public Guid Id { get; set; }

        public Boolean IsActive { get; set; }

        public Boolean IsError { get; set; }

        public String ErrorMessageFor { get; set; }

        public String ErrorMessage { get; set; }

        public Guid TransactedBy { get; set; }

        public Boolean IsChecked { get; set; }
    }
}
