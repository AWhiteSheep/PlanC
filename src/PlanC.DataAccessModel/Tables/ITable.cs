using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanC.DataAccessModel.Tables
{
    public interface ITable<TRecord> where TRecord : class, new()
    {
        IQueryable<TRecord> Get();

        void Add(params TRecord[] records);

        void Update(params TRecord[] updatedRecords);

        //Parameter should be the key for perf, but using record to satisfy EF.
        void Delete(params TRecord[] records);
    }
}
