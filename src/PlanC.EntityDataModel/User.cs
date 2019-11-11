using PlanC.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanC.EntityDataModel
{
    public class User
    {
        public User()
        {
            Tuseravl = new HashSet<UserAvailability>();
            User_Roles = new HashSet<User_Role>();
        }

        public string Uid { get; set; }
        public int? DptmntId { get; set; }
        public string GvnNm { get; set; }
        public string Snm { get; set; }
        public DateTime? RcdCdttm { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<UserAvailability> Tuseravl { get; set; }
        public virtual ICollection<User_Role> User_Roles { get; set; }
    }
}
