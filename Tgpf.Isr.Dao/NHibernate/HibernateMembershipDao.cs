/*
 * Copyright 2007-2009 Orgman Software
 * http://www.orgman.idv.tw
 * 
 */

using System.Collections;
using Spring.Data.NHibernate.Support;
using Spring.Transaction.Interceptor;
using Tgpf.Isr.Model;

namespace Tgpf.Isr.Dao.NHibernate
{
    public class HibernateMembershipDao : HibernateDaoSupport, IMembershipDao
    {
        public AspnetMembership FindById(string id)
        {
            return HibernateTemplate.Load(typeof(AspnetMembership), id) as AspnetMembership;
        }



        [Transaction(ReadOnly = false)]
        public void Update(AspnetMembership obj)
        {
            HibernateTemplate.SaveOrUpdate(obj);

        }

    }
}
