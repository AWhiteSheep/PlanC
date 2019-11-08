using Microsoft.EntityFrameworkCore;
using PlanC.WebApi.Models;
using PlanC.WebApi.Server.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanC.Web.Client.Data
{
    public class PCU001DataAccessLayer
    {
        PCU001Context db;

        public PCU001DataAccessLayer(PCU001Context db)
        {
            this.db = db;
        }

        public DbSet<Department> GetAllDepartment()
        {
            try
            {
                return db.Departments;
            }
            catch
            {
                throw;
            }
        }

        public void UpdateDepartment(Department department)
        {
            try
            {
                //db.Departments.Where(e => e.Id)
            }
            catch
            {
                throw;
            }
        }

        public DbSet<Department> AddDepartment(Department department)
        {
            try
            {
                return db.Departments;
            }
            catch
            {
                throw;
            }
        }
    }
}
