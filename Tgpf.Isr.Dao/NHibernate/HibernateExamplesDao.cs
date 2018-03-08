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
    public class HibernateExamplesDao : HibernateDaoSupport, IExamplesDao
    {
        public Examples getExamples(ArrayList obj)
        {
            IList lists = HibernateTemplate.Find("from Examples where id=? ", obj);
            if (lists == null || lists.Count < 1)
            {
                return null;
            }
            else
            {
                return (Examples)lists[0];
            }
        }

        public IList getExamplesList()
        {
            IList lists = HibernateTemplate.Find("from Examples order by Year desc ");
            if (lists == null || lists.Count < 1)
            {
                return null;
            }
            else
            {
                return lists;
            }
        }


        public IList getExamplesListByYear(string year)
        {
            IList lists = HibernateTemplate.Find("from Examples where Year = ? order by Year desc ", year);
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
        public void Save(Examples obj)
        {
            HibernateTemplate.SaveOrUpdate(obj);
        }

        [Transaction(ReadOnly = false)]
        public void Delete(Examples obj)
        {
            HibernateTemplate.Delete(obj); ;
        }
    }
}

