using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanC.DataAccessLayer
{
    public class PlanCDataAccess
    {
        static DataAccess.PCU001Context context;

        public static DataAccess.PCU001Context Context
        {
            get
            {
                if (context == null)
                {
                    return new DataAccess.PCU001Context();
                }
                else return context;
            }
        }
    }
}
