using Microsoft.AspNetCore.Mvc;
using Tickets.BL.Managers.DepartementMangaer;
using Tickets.DAL.Models;

namespace TicketsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartementController : Controller
    {
        private readonly IDepartementManager departementManager;

        public DepartementController(IDepartementManager departementManager)
        {
            this.departementManager = departementManager;
        }

        [HttpGet]
        public ActionResult<IEnumerator<Departement>> getAll()
        {
            return Ok(this.departementManager.getAll());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Departement> getDepartementById(int id)
        {
            return Ok(this.departementManager.getDepartementDetailsById(id));
        }
    }
}
