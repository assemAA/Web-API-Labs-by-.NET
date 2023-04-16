using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.DAL.Context;
using Tickets.DAL.Models;

namespace Tickets.DAL.Repos
{
    public class DepartementRepo : IContextRepo<Departement>
    {
        public readonly TicketsContext ticketsContext;
        public DepartementRepo(TicketsContext _ticketsContext)
        {
            ticketsContext = _ticketsContext;
        }

        public void addItem(Departement item)
        {
            ticketsContext.Add(item);
            this.saveChanges();
        }

        public void deleteItem(int id)
        {
            Departement departement = ticketsContext.Departements.FirstOrDefault(ele => ele.id== id);
            ticketsContext.Departements.Remove(departement);
        }

        public IEnumerable<Departement> getAll()
        {
            return ticketsContext.Departements.ToList();
        }

        public Departement? getItemByID(int id)
        {
            Departement departement = ticketsContext.Departements.FirstOrDefault(ele => ele.id == id);
            return departement;
        }

        public void saveChanges()
        {
            this.ticketsContext.SaveChanges();
        }

        public void updateItem(Departement item)
        {
            Departement departement = ticketsContext.Departements.FirstOrDefault(ele => ele.id == item.id);
            if (departement != null)
            {
                departement.Name = item.Name;   
                departement.tickets = item.tickets;
            }
        }
    }
}
