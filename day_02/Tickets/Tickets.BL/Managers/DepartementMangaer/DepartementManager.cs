using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.BL.DTOS;
using Tickets.DAL.Models;
using Tickets.DAL.Repos;

namespace Tickets.BL.Managers.DepartementMangaer
{
    public class DepartementManager : IDepartementManager
    {
        private readonly IContextRepo<Departement> departementRepo;

        public DepartementManager(IContextRepo<Departement> departementRepo)
        {
            this.departementRepo = departementRepo;
        }

        public void addDepartement(Departement departement)
        {
            departementRepo.addItem(departement);
        }

        public IEnumerable<Departement> getAll()
        {
            return departementRepo.getAll();
        }

        public Departement getDepartementById(int id)
        {
            return departementRepo.getItemByID(id);
        }

        public DepartementWithTicketsDetailsDto getDepartementDetailsById(int id)
        {
            Departement departement = departementRepo.getItemByID(id);
            DepartementWithTicketsDetailsDto departementDetailsDto = new DepartementWithTicketsDetailsDto();
            departementDetailsDto.Id = departement.id;
            departementDetailsDto.Name = departement.Name;
            departementDetailsDto.tickets = departement.tickets.Select(ele => new TicketWithNumberOfDevalopersDto
            {
                id = ele.id,
                description = ele.description,
                numberOfDevalopers = ele.devalopers.Count(),
            }).ToList(); 

            return departementDetailsDto;

        }

        public void removeDepartementById(int id)
        {
            departementRepo.deleteItem(id);
        }

        public void updateDepartement(Departement departement)
        {
            departementRepo.updateItem(departement);
        }

        public void saveChanges()
        {
            departementRepo.saveChanges();
        }
    }
}
