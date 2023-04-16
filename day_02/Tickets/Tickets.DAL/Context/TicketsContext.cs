using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.DAL.Models;

namespace Tickets.DAL.Context
{
    public class TicketsContext : DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Devaloper> Devalopers { get; set; }

        public DbSet<Departement> Departements { get; set; }
        public TicketsContext(DbContextOptions<TicketsContext> options):base(options) 
        {
        
        }


        
    }
}
