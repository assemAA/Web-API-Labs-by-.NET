using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.DAL.Models;
using Tickets.DAL.Repos;

namespace Tickets.BL.Managers.TicketManager
{
    public class TicketManager : ITicketManager
    {
        private readonly IContextRepo<Ticket> ticketreprosatory;
        public TicketManager(IContextRepo<Ticket> _ticketreprosatory) 
        {
            ticketreprosatory = _ticketreprosatory;
        }
        public void addTicket(Ticket ticket)
        {
            ticketreprosatory.addItem(ticket);
        }

        public void deleteTicket(int id)
        {
            ticketreprosatory.deleteItem(id);
        }

        public IEnumerable<Ticket> getAll()
        {
            return ticketreprosatory.getAll();
        }

        public Ticket getById(int id)
        {
            return ticketreprosatory.getItemByID(id);
        }

        public void saveChanges()
        {
            ticketreprosatory.saveChanges();
        }

        public void updateTicket(Ticket ticket)
        {
            ticketreprosatory.saveChanges();
        }
    }
}
