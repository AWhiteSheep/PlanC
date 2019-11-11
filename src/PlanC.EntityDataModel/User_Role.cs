using System;
using System.Collections.Generic;
using System.Text;

namespace PlanC.EntityDataModel
{
    public class User_Role
    {
        public string Uid { get; set; }
        public int RoleId { get; set; }
        //public DateTime? RcdCdttm { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
