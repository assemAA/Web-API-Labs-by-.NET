using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.DAL.Context;
using Tickets.DAL.Models;

namespace Tickets.DAL.Repos
{
    public class DevaloperRepo : IContextRepo<Devaloper>
    {
        public readonly TicketsContext ticketsContext;
        public DevaloperRepo(TicketsContext _ticketsContext) 
        {
            ticketsContext= _ticketsContext;
        }

        public void addItem(Devaloper item)
        {
            ticketsContext.Add(item);
        }

        public void deleteItem(int id)
        {
            Devaloper devaloper = ticketsContext.Devalopers.FirstOrDefault(ele => ele.id == id);
            ticketsContext.Devalopers.Remove(devaloper);
            this.saveChanges();
        }

        public IEnumerable<Devaloper> getAll()
        {
            return this.ticketsContext.Devalopers.ToList();
        }

        public Devaloper? getItemByID(int id)
        {
            Devaloper devaloper = ticketsContext.Devalopers.FirstOrDefault(ele => ele.id == id);
            return devaloper;
        }

        public void saveChanges()
        {
            this.ticketsContext.SaveChanges();
        }

        public void updateItem(Devaloper item)
        {
            Devaloper devaloper = ticketsContext.Devalopers.FirstOrDefault(ele => ele.id == item.id);
            if (devaloper != null)
            {
                devaloper.Name = item.Name;
                devaloper.tickets = item.tickets;
            }

        }
    }
}
