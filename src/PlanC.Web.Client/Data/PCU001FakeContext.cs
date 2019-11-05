using PlanC.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanC.Web.Client.Data
{
    public class PCU001FakeContext
    {
        static PCU001FakeContext()
        {
            var D = new Department() { Title = "Informatique", Policy = "Retour de livre.", Id = 1111 };
            var C = new Department() { Title = "Science", Policy = "Retour de livre.", Id = 110 };
            var E = new Department() { Title = "Humaine", Policy = "Les corrections sont obligatoires.", Id = 111 };
            var F = new Department() { Title = "Génie", Policy = "Mais ils sont foux ces Gaulois.", Id = 1110 };

            D.Tpgm = new List<Tpgm>();
            C.Tpgm = new List<Tpgm>();
            F.Tpgm = new List<Tpgm>();
            E.Tpgm = new List<Tpgm>();

            Departments = new List<Department>() { D, C, E, F };

            programmes = new List<Tpgm>()
            {
                new Tpgm(){ PgmId="340.AA", PgmTitle="Sculpture", Dptmnt = D },
                new Tpgm(){ PgmId="654.AB", PgmTitle="Dinocolor", Dptmnt = C  },
                new Tpgm(){ PgmId="456.DD", PgmTitle="Scolarie", Dptmnt = C  },
                new Tpgm(){ PgmId="456.DD", PgmTitle="Dentaire", Dptmnt = D  },
                new Tpgm(){ PgmId="456.DD", PgmTitle="Voctuseraptor", Dptmnt = D },
                new Tpgm(){ PgmId="456.DD", PgmTitle="Tinoculaire",Dptmnt = F },
                new Tpgm(){ PgmId="456.DD", PgmTitle="Vanitorinactirapeute" ,Dptmnt = D  },
            };
        }

        public static List<Department> Departments;
        // définition des programmes
        public static List<Tpgm> programmes;

        public List<Department> ListDéparment()
        {
            return Departments;
        }

        public List<Tpgm> ListPrograms() 
        {
            return programmes;
        }

        public Tpgm SelectProgram(string id) 
        {
            return programmes.First(e => e.PgmId == id);
        }

    }
}
