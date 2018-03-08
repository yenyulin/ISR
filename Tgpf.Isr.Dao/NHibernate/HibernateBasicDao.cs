using System;
using System.Collections.Generic;
using System.Text;
using Tgpf.Isr.Dao;
using Spring.Data.NHibernate.Support;
using NHibernate;
using Spring.Transaction.Interceptor;
using System.Collections;

namespace Tgpf.Isr.Dao.NHibernate
{
    class HibernateBasicDao : HibernateDaoSupport, IBasicDao
    {
        protected ISession m_session;


        public IList GetByHQL(string hql, ArrayList lists)
        {
            try
            {
                ISession session = HibernateUtil.OpenSession();
                IQuery query = session.CreateQuery(hql);

                for (int i = 0; i < lists.Count; i++)
                {
                    query.SetParameter(i, lists[i]);
                }

                return query.List();


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                HibernateUtil.CloseSession();
            }

            return null;
        }

    }
}
