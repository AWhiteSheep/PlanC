using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PlanC.WebClient.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            // listant tout les points d'entrez pour l'administration
            return View();
        }

        public IActionResult Programme()
        {
            // liste de tous les programmes offerts
            return View();
        }

        public IActionResult Departement()
        {
            // liste de tous les departements possibles
            return View();
        }
    }
}