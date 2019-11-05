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
            var D = new Department() { Title = "Informatique", Policy = "Voilà la galaxie qui nous ait offerte.", Id = 1111 };
            var C = new Department() { Title = "Science", Policy = "Et j'en ferai de celle ci ma gloire.", Id = 110 };
            var E = new Department() { Title = "Humaine", Policy = "Les corrections sont obligatoires.", Id = 111 };
            var F = new Department() { Title = "Génie", Policy = "Mais ils sont foux ces Gaulois.", Id = 1110 };

            D.Tpgm = new List<Tpgm>();
            C.Tpgm = new List<Tpgm>();
            F.Tpgm = new List<Tpgm>();
            E.Tpgm = new List<Tpgm>();

            Departments = new List<Department>() { D, C, E, F };

            Tpgm sculpture;
            Tpgm Dinocolor;
            Tpgm scolarie;
            Tpgm dentaire;
            Tpgm voo;

            programmes = new List<Tpgm>()
            {
                (sculpture= new Tpgm(){ PgmId="340.AA", PgmTitle="Sculpture"}),
                (Dinocolor =new Tpgm(){ PgmId="654.AB", PgmTitle="Dinocolor"}),
                (scolarie = new Tpgm(){ PgmId="456.DD", PgmTitle="Scolarie" }),
                (dentaire = new Tpgm(){ PgmId="456.DD", PgmTitle="Dentaire"}),
                (voo  = new Tpgm(){ PgmId="456.DD", PgmTitle="Voctuseraptor"}),
                new Tpgm(){ PgmId="456.DD", PgmTitle="Tinoculaire"},
                new Tpgm(){ PgmId="456.DD", PgmTitle="Vanitorinactirapeute"},
            };

            D.Tpgm.Add(sculpture);
            D.Tpgm.Add(Dinocolor);
            D.Tpgm.Add(scolarie);
            C.Tpgm.Add(dentaire);
            C.Tpgm.Add(voo);

           
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
