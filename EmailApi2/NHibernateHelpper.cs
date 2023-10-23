using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate;

namespace EmailApi2
{
    public class NHibernateHelpper
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {                    
                    string conStr = @"Data Source=.; Initial Catalog=Rayvarz; integrated security=true;";
                    _sessionFactory = Fluently.Configure()                        
                        .Database(MsSqlConfiguration.MsSql2012.ConnectionString(conStr))
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
                        .BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }
        public static ISession GetSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
