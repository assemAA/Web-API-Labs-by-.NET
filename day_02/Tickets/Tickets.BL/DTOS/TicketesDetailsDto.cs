using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.DAL.Models;

namespace Tickets.BL.DTOS
{
    public  class TicketesDetailsDto
    {
        public int id { get; set; }
        public string description { get; set; }

        public string tittle { get; set; }

        public int dept { get; set; }

        public ICollection<Devaloper> devalopers { get; set; }

    }
}
