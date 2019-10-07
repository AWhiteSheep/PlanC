using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlanC.DataAccess;
using PlanC.DataAccessLayer;
using PlanC.Models;

namespace PlanC.DataAccessObject
{
    public class CrsTemplateCollection : IPlanCDao<TcrsTmplt,CrsTemplate>
    {
        public int Insert(CrsTemplate NewRow)
        {
            throw new NotImplementedException();
        }

        public int Delete(CrsTemplate TargetRow)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CrsTemplate> GetAll()
        {
            IEnumerable<TcrsTmplt> raw = PlanCDataAccess.Context.TcrsTmplt;
        }

        public int Modify(CrsTemplate NewData)
        {
            throw new NotImplementedException();
        }

        public CrsTemplate ParseEntity(TcrsTmplt RawData)
        {
            return new CrsTemplate()
            {
                CrsId = RawData.CrsId,

            }
        }
    }
}
