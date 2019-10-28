using PlanC.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanC.DataAccessObject
{
    interface IPlanCDao<TEntity, TModel>
    {

        IQueryable<TModel> GetAll();

        int Insert(TModel NewRow);
        int Modify(TModel NewData);

        int Delete(TModel TargetRow);

        TModel ParseEntity(TEntity RawData);

        TEntity ParseModel(TModel ApplicationData);
    }
}
