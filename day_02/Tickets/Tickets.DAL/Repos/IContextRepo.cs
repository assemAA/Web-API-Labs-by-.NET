using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.DAL.Repos
{
    public interface IContextRepo<TEntity>
    {
        public IEnumerable<TEntity> getAll();

        public TEntity? getItemByID(int id);

        public void addItem(TEntity item);
        public void deleteItem(int id);

        public void updateItem(TEntity item);


        public void saveChanges();
    }
}
