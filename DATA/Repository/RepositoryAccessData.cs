using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATA.Models;
using NHibernate;
using NHibernate.Linq;

namespace DATA.Repository
{
    public class RepositoryAccessData<T> : IRepoContract<T> where T : class
    {
        private readonly ISession Session = null;
        public RepositoryAccessData()
        {
            Session = NHSession.OpenSession();
        }
        public IList<T> GetAll()
        {
            IList<T> itemList;
            using (var session = Session)
            {
                using (var txn = session.BeginTransaction())
                {
                    //session.Query<T>().Fetch(o => o.)
                    Session.Flush();
                    var targetObjects = Session.CreateCriteria(typeof(T));
                    itemList = targetObjects.List<T>();
                    txn.Commit();
                }
            }
            
            return itemList;
        }
        /*  public virtual object GetByTheId(Type objType, object objId)
        {
            return Session.Load(objType, objId);
        }*/
        public object GetOne(Type entity, object objId)
        {
            Session.Flush();
            return Session.Load(entity, objId);

        }

        public void InsertOrUpdate(T entity)
        {
            using (ISession session = Session)
            {
                using (session.BeginTransaction())
                {
                    session.SaveOrUpdate(entity);
                    session.Transaction.Commit();
                }
            }
        }

       

        public void Delete(T entity)
        {
            using (var session = Session)
            {
                using (session.BeginTransaction())
                {
                    session.Delete(entity);
                    session.Transaction.Commit();
                }
            }
        }
        public void Delete(IList<T> itemsToDelete)
        {
            using (var session = Session)
            {
                foreach (var item in itemsToDelete)
                {
                    using (session.BeginTransaction())
                    {
                        session.Delete(item);
                        session.Transaction.Commit();
                    }
                }
            }
        }

        /*
         *
         *
*/
    }

}
