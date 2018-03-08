/*
 * Copyright 2007-2009 Orgman Software
 * http://www.orgman.idv.tw
 * 
 */
using System.Collections;
using Spring.Data.NHibernate.Support;
using Tgpf.Isr.Model;

namespace Tgpf.Isr.Dao.NHibernate
{
    public class HibernateAspnetUsersDao : HibernateDaoSupport, IAspnetUsersDao
    {
        public AspnetUsers FindById(string id)
        {
            return HibernateTemplate.Load(typeof(AspnetUsers), id) as AspnetUsers;
        }

        public AspnetUsers FindByProperty(string userName)
        {
            IList lists = HibernateTemplate.Find("from AspnetUsers where UserName=? ", userName);
            if (lists == null || lists.Count < 1)
            {
                return null;
            }
            else
            {
                return (AspnetUsers)lists[0];
            }
        }


        public void Update(AspnetUsers obj)
        {
            HibernateTemplate.SaveOrUpdate(obj);

        }

    }
}
