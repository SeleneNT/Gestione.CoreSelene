using System;
using System.Collections.Generic;
using System.Text;

namespace Gestione.Core.Repository
{
    public interface IRepository<TEntity>
    {
        //Servizi di CRUD comuni ad entrambi i Repository
        List<TEntity> Fetch();
        TEntity GetById(int id);
        bool Add(TEntity item);
        bool Update(TEntity item);
        bool Delete(TEntity item);
    }
}
