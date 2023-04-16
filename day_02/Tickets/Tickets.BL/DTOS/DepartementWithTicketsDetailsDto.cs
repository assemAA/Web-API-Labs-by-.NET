using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.BL.DTOS
{
    public class DepartementWithTicketsDetailsDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<TicketWithNumberOfDevalopersDto> tickets { get; set; }
    }
}
