using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanC.DataAccessModel.Tables
{
    /// <summary>
    ///     A <see cref="ITable{TRecord}"/> adapter for an <see
    ///     cref="DbSet{TEntity}"/>.
    /// </summary>
    /// <typeparam name="TRecord">
    ///     The type of the record object holding the data of a record.
    /// </typeparam>
    internal class DefaultTable<TRecord> : ITable<TRecord>
        where TRecord : class, new()
    {
        private DbSet<TRecord> _dbSet;

        public DefaultTable(DbSet<TRecord> dbSet)
        {
            _dbSet = dbSet;
        }

        public void Add(params TRecord[] records)
        {
            _dbSet.AddRange(records);
        }

        public void Delete(params TRecord[] records)
        {
            _dbSet.RemoveRange(records);
        }

        public IQueryable<TRecord> Get()
        {
            return _dbSet;
        }

        public void Update(params TRecord[] updatedRecords)
        {
            //Attach all record to the context.
            //TODO: Should we detach matching entities that are already
            //present?
            foreach (var record in updatedRecords)
            {
                _dbSet.Attach(record).State = EntityState.Modified;
            }
        }
    }
}
