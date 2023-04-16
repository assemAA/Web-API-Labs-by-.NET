using Microsoft.AspNetCore.Mvc;
using Tickets.BL.DTOS;
using Tickets.BL.Managers.TicketManager;
using Tickets.DAL.Models;

namespace TicketsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : Controller
    {
        private readonly ITicketManager ticketManager;

        public TicketController(ITicketManager ticketManager)
        {
            this.ticketManager = ticketManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Ticket>> getAll()
        {
            return Ok(this.ticketManager.getAll());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Ticket> getTicket(int id) 
        {
            if (ticketManager.getById(id) == null)
            {
                return NotFound();
            }
            return Ok(ticketManager.getById(id));
        }

        [HttpPost]
        public ActionResult addTicket(TicketToPostToDatabaseDto ticket)
        {
            Ticket newTicket = new Ticket();
            try
            {
                newTicket.description= ticket.description;
                newTicket.dept_id = ticket.dept_id;
                newTicket.tittle = ticket.tittle;
                newTicket.devalopers = ticket.devalopers;
                ticketManager.addTicket(newTicket);
                ticketManager.saveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest("data not valid to enter database");
            }
        }
        [HttpPut]
        [Route("{id}")]
        public ActionResult updateTicket(Ticket ticket)
        {
           ticketManager.updateTicket(ticket);
            ticketManager.saveChanges();
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]

        public ActionResult deleteTicket(int id)
        {
            ticketManager.deleteTicket(id);
            ticketManager.saveChanges();
            return NoContent();
        }


    }
}
