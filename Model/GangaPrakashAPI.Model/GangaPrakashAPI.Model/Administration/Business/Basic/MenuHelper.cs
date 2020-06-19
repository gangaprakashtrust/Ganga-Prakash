using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GangaPrakashAPI.Model
{
    public class MenuHelper : BaseModel
    {
        public String Name { get; set; }

        public Guid? ParentId { get; set; }

        public Guid ModuleId { get; set; }

        //Extra Fields

        public String Module { get; set; }

        public Boolean IsParent { get; set; }

    }
}
