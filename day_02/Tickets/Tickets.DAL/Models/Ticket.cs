using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.DAL.Models
{
    public  class Ticket
    {
        [Key]
        public int id { get ; set; }

        public string description { get; set; }

        public string tittle { get; set; }

        [ForeignKey("departement")]
        public int dept_id { get; set; }

        public ICollection<Devaloper> devalopers { get ; set; }
        public virtual Departement? departement { get; set; }

        
    }
}
