using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.DAL.Models;

namespace Tickets.BL.DTOS
{
    public  class DepartementDetailsDto
    {
        public int id { get; set; }

        public string name { get; set; }

        public ICollection<Ticket> tickets { get; set; }

    }
}
