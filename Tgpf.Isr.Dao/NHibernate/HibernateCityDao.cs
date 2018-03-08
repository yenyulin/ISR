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
    public class HibernateCityDao : HibernateDaoSupport, ICityDao
    {
        public City getCity(string obj)
        {
            IList lists = HibernateTemplate.Find("from City where Id=? ", obj);
            if (lists == null || lists.Count < 1)
            {
                return null;
            }
            else
            {
                return (City)lists[0];
            }
        }

        public IList getCityList()
        {
            IList lists = HibernateTemplate.Find("from City ");
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
        public void Save(City obj)
        {
            HibernateTemplate.SaveOrUpdate(obj);
        }

        [Transaction(ReadOnly = false)]
        public void Delete(City obj)
        {
            HibernateTemplate.Delete(obj); ;
        }
    }
}

