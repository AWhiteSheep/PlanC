using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using PlanC.Client.Data;
using PlanC.EntityDataModel;

namespace PlanC.Client.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class ProgrammeController : Controller
    {
        public ProgrammeController(PCU001Context context) {
            db = new ProgrammesDataAccessLayer(context);
        }
        ProgrammesDataAccessLayer db;
        [HttpGet]
        public object Get()
        {

            IQueryable<Programmes> data = db.GetAllProgrammes().AsQueryable();
            return data;
        }
        [HttpPost]
        public void Post([FromBody]Programmes Programme)
        {
            db.AddProgramme(Programme);
        }
        [HttpPut]
        public object Put([FromBody]Programmes Order)
        {
            db.UpdateProgramme(Order);
            return Order;
        }
        [HttpDelete("{id}")]
        public void Delete(string id, string depId)
        {
            db.DeleteProgramme(id, depId);
        }
    }
}
