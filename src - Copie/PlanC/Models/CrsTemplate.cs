using PlanC.DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using PlanC.DataAccess;
using System.Threading.Tasks;

namespace PlanC.Models
{
    public class CrsTemplate
    {
        private CrsTemplateCollection Collection = new CrsTemplateCollection();

        public string CrsId { get; set; }
        public int? DptmntId { get; set; }
        public string CrsTitle { get; set; }
        public decimal? Units { get; set; }
        public string CrsDesc { get; set; }
        public string Intent { get; set; }
        public DateTime? DptmtApprvlDt { get; set; }
        public DateTime? CmteApprvlDt { get; set; }
        public DateTime? BoardApprovlDt { get; set; }
        public string TrackingUid { get; set; }
        public DateTime? RecordCdttm { get; set; }

        public List<Tsklelem> SkillElements = new List<Tsklelem>();

        public int Insert()
        {
            TcrsTmplt NewRow = new TcrsTmplt()
            {
                CrsId = this.CrsId,
                DptmntId = this.DptmntId,
                CrsTitle = this.CrsTitle,

            }
        }

        public int Delete()
        {
            throw new NotImplementedException();
        }

        public IQueryable<CrsTemplate> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Modify()
        {
            throw new NotImplementedException();
        }
    }
}
