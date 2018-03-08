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
    public class HibernateNewsDao : HibernateDaoSupport, INewsDao
    {
        public News getNews(int obj)
        {
            IList lists = HibernateTemplate.Find("from News where id=? ", obj);
            if (lists == null || lists.Count < 1)
            {
                return null;
            }
            else
            {
                return (News)lists[0];
            }
        }

        public IList getNewsList()
        {
            IList lists = HibernateTemplate.Find("from News  where Isonline <> 'D' order by Showdate desc ");
            if (lists == null || lists.Count < 1)
            {
                return null;
            }
            else
            {
                return lists;
            }
        }

        public IList getNewsListById(int obj)
        {
            IList lists = HibernateTemplate.Find("from News where id=? ", obj);
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
        public void Save(News obj)
        {
            HibernateTemplate.SaveOrUpdate(obj);
        }

        [Transaction(ReadOnly = false)]
        public void Delete(News obj)
        {
            HibernateTemplate.Delete(obj); ;
        }
    }
}

