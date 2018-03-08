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
    public class HibernateTechInfoDao : HibernateDaoSupport, ITechInfoDao
    {
        public TechInfo getTechInfo(int obj)
        {
            IList lists = HibernateTemplate.Find("from TechInfo where id=? ", obj);
            if (lists == null || lists.Count < 1)
            {
                return null;
            }
            else
            {
                return (TechInfo)lists[0];
            }
        }

        public IList getTechInfoList(int obj)
        {
            IList lists = HibernateTemplate.Find("from TechInfo where id=? ", obj);
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
        public void Save(TechInfo obj)
        {
            HibernateTemplate.SaveOrUpdate(obj);
        }

        [Transaction(ReadOnly = false)]
        public void Delete(TechInfo obj)
        {
            HibernateTemplate.Delete(obj); ;
        }
    }
}

