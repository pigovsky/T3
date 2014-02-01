using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectorsSeminarsDataAccessLayer
{
    public class SessionWraperFactory
    {
        private ISessionFactory sessionFactory;

        public SessionWraperFactory(bool updateSchema)
        {
            var cfg = new Configuration();
            cfg.Configure();
            if (updateSchema)
            {
                SchemaUpdate updater = new SchemaUpdate(cfg);
                updater.Execute(true, true);
            }
            sessionFactory = cfg.BuildSessionFactory();
        }

        public ISessionWraper OpenSessionAdapter()
        {
            return new SessionWraper(
                sessionFactory.OpenSession());
        }
    }
}
