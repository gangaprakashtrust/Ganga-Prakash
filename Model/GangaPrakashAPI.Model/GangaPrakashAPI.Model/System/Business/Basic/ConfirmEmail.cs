using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangaPrakashAPI.Model
{
    public class ConfirmEmail
    {
        public String userId { get; set; }

        public String code { get; set; }
    }
}
