using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.DAL.Models
{
    public  class Devaloper
    {
        [Key]
        public int id { get; set; }

        public string Name { get; set; }

        public ICollection<Ticket> tickets { get; set; }
    }
}
