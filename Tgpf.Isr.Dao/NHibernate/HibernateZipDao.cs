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
    public class HibernateZipDao : HibernateDaoSupport, IZipDao
    {
        public Zip getZip(string obj)
        {
            IList lists = HibernateTemplate.Find("from Zip where Id=? ", obj);
            if (lists == null || lists.Count < 1)
            {
                return null;
            }
            else
            {
                return (Zip)lists[0];
            }
        }

        public IList getZipList(string obj)
        {
            IList lists = HibernateTemplate.Find("from Zip where pid=? ", obj);
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
        public void Save(Zip obj)
        {
            HibernateTemplate.SaveOrUpdate(obj);
        }

        [Transaction(ReadOnly = false)]
        public void Delete(Zip obj)
        {
            HibernateTemplate.Delete(obj); ;
        }
    }
}

