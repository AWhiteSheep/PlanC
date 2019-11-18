using Microsoft.EntityFrameworkCore;
using PlanC.EntityDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanC.Client.Data
{
    public class ProgrammesDataAccessLayer
    {
        public ProgrammesDataAccessLayer(PCU001Context db) {
            this.db = db;
        }
        PCU001Context db;
        public DbSet<Programmes> GetAllProgrammes()
        {
            try
            {
                return db.Programmes;
            }
            catch
            {
                throw;
            }
        }
        public void AddProgramme(Programmes Programme)
        {
            try
            {
                db.Programmes.Add(Programme);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public void UpdateProgramme(Programmes Programme)
        {
            try
            {
                db.Entry(Programme).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public void DeleteProgramme(string progId, string departId)
        {
            try
            {
                Programmes ord = db.Programmes.Find(progId, departId);
                db.Programmes.Remove(ord);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}

