using System;
using System.Collections.Generic;
using System.Text;

namespace DATA.Repository
{
    public interface IRepoContract<T> where T: class
    {
        IList<T> GetAll();
        object GetOne(Type entity, object id);
        void InsertOrUpdate(T entity);
        
        void Delete(T entity);
        void Delete(IList<T> itemsToDelete);
    }
}
