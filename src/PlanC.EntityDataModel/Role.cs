using System;
using System.Collections.Generic;
using System.Text;

namespace PlanC.EntityDataModel
{
    public class Role
    {
        public Role()
        {
            Tuserrole = new HashSet<User_Role>();
        }

        public int RoleId { get; set; }
        public string RoleNm { get; set; }
        //public DateTime? RcdCdttm { get; set; }

        public virtual ICollection<User_Role> Tuserrole { get; set; }
    }
}
