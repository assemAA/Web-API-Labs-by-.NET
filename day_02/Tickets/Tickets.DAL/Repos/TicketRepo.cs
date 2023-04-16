using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.DAL.Context;
using Tickets.DAL.Models;

namespace Tickets.DAL.Repos
{
    public class TicketRepo : IContextRepo<Ticket>
    {
        public readonly TicketsContext ticketsContext;
        public TicketRepo(TicketsContext _ticketsContext) 
        { 
            ticketsContext = _ticketsContext;
        }

        public void addItem(Ticket item)
        {
            ticketsContext.Add(item);
        }

        public void deleteItem(int id)
        {
            Ticket ticket = ticketsContext.Tickets.FirstOrDefault(ele => ele.id== id);
            ticketsContext.Tickets.Remove(ticket);
            this.saveChanges();
        }

        public IEnumerable<Ticket> getAll()
        {
            return ticketsContext.Tickets.ToList();
        }

        public Ticket? getItemByID(int id)
        {
            return ticketsContext.Tickets.FirstOrDefault(ele => ele.id == id);
        }

        public void saveChanges()
        {
            this.ticketsContext.SaveChanges();
        }

        public void updateItem(Ticket item)
        {
            Ticket ticket = ticketsContext.Tickets.FirstOrDefault(ele => ele.id == item.id);
            if (ticket != null) {
                ticket.tittle = item.tittle;
                ticket.description = item.description;
                ticket.dept_id = item.dept_id;
                ticket.devalopers = item.devalopers;
            
            }
        }
    }
}
