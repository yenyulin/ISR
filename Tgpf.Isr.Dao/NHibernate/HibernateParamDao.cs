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
    public class HibernateParamDao : HibernateDaoSupport, IParamDao
    {
        public Param getParam(object[] obj)
        {
            IList lists = HibernateTemplate.Find("from Param p where p.Id.Paramid=? and p.Id.Paramcode=? ", obj);
            if (lists == null || lists.Count < 1)
            {
                return null;
            }
            else
            {
                return (Param)lists[0];
            }
        }

        public IList getParamList(ArrayList obj)
        {
            IList lists = HibernateTemplate.Find("from Param where id=? ", obj);
            if (lists == null || lists.Count < 1)
            {
                return null;
            }
            else
            {
                return lists;
            }
        }

        [Transaction(ReadOnly = false)]
        public void Save(Param obj)
        {
            HibernateTemplate.SaveOrUpdate(obj);
        }

        [Transaction(ReadOnly = false)]
        public void Delete(Param obj)
        {
            HibernateTemplate.Delete(obj); ;
        }
    }
}

