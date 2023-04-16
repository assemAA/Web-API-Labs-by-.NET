using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.BL.DTOS;
using Tickets.DAL.Models;

namespace Tickets.BL.Managers.DepartementMangaer
{
    public interface IDepartementManager
    {
        public IEnumerable<Departement> getAll();
        public Departement getDepartementById(int id);

        public void addDepartement(Departement departement);

        public void removeDepartementById(int id);

        public void updateDepartement(Departement departement);

        public DepartementWithTicketsDetailsDto getDepartementDetailsById(int id);

        public void saveChanges();
    }
}
