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
    public class HibernateMarqueeDao : HibernateDaoSupport, IMarqueeDao
    {
        public Marquee getMarquee(string obj)
        {
            IList lists = HibernateTemplate.Find("from Marquee where Id=? ", obj);
            if (lists == null || lists.Count < 1)
            {
                return null;
            }
            else
            {
                return (Marquee)lists[0];
            }
        }

        public IList getMarqueeList(ArrayList obj)
        {
            IList lists = HibernateTemplate.Find("from Marquee where id=? ", obj);
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
        public void Save(Marquee obj)
        {
            HibernateTemplate.SaveOrUpdate(obj);
        }

        [Transaction(ReadOnly = false)]
        public void Delete(Marquee obj)
        {
            HibernateTemplate.Delete(obj); ;
        }
    }
}

