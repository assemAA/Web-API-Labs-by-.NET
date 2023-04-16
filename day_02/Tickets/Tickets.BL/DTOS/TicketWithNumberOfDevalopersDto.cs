using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.BL.DTOS
{
    public class TicketWithNumberOfDevalopersDto
    {
        public int id { get; set; }

        public string description { get; set; }

        public int numberOfDevalopers { get; set; }

    }
}
