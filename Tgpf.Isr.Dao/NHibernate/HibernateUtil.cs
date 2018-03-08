using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;

namespace Tgpf.Isr.Dao
{
    public class HibernateUtil
    {
        private static ISessionFactory sessionFactory;
        public static ISession session;

        public ISessionFactory SessionFactory
        {
            get { return sessionFactory; }
            set { sessionFactory = value; }
        }

        public static ISession OpenSession()
        {
            if (session == null || !session.IsOpen)
            {
                try
                {
                    session = (sessionFactory != null) ? sessionFactory.OpenSession() : null;
                }
                catch (Exception ex)
                {
                    throw new Exception("Could not create the NHibernate configuration", ex);
                }
            }
            return session;
        }

        public static void CloseSession()
        {
            if (session != null)
            {
                session.Close();
                session = null;
            }
        }

    }

}
