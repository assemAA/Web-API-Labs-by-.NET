using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.DAL.Models;

namespace Tickets.BL.DTOS
{
    public class TicketToPostToDatabaseDto
    {
        public string description { get; set; }

        public string tittle { get; set; }

        public int dept_id { get; set; }

        public ICollection<Devaloper> devalopers { get; set; }
    }
}
