using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.DAL.Models;

namespace Tickets.BL.Managers.TicketManager
{
    public interface ITicketManager
    {
        public IEnumerable<Ticket> getAll();

        public Ticket getById(int id);

        public void updateTicket (Ticket ticket);

        public void deleteTicket (int id );

        public void addTicket(Ticket ticket);

        public void saveChanges();
    }
}
