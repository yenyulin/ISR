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
    public class HibernateCaseDao : HibernateDaoSupport, ICaseDao
    {
        public Case getCase(int obj)
        {
            IList lists = HibernateTemplate.Find("from Case where id=? ", obj);
            if (lists == null || lists.Count < 1)
            {
                return null;
            }
            else
            {
                return (Case)lists[0];
            }
        }

        public IList getCaseList()
        {
            IList lists = HibernateTemplate.Find("from Case where Isdeleted=false");
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
        public void Save(Case obj)
        {
            HibernateTemplate.SaveOrUpdate(obj);
        }

        [Transaction(ReadOnly = false)]
        public void Delete(IList obj)
        {
            if (obj != null)
            {
                foreach (Case item in obj)
                {
                    HibernateTemplate.Update(item);
                }
            }
            
        }
    }
}

