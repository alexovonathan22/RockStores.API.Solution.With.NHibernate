using System;
using System.Collections.Generic;
using System.Text;
using DATA.Models;
using NHibernate;
using NHibernate.Cfg;

namespace DATA.Repository
{
    public static class NHSession
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory != null) return _sessionFactory;
                var nhConf = new Configuration().Configure();
                //added this line cos i think it will solve the auto-mapping issue
                nhConf.AddAssembly(typeof(Customer).Assembly);
                _sessionFactory = nhConf.BuildSessionFactory();

                return _sessionFactory;
            }

        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
