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
    public class HibernateUserProfilesDao : HibernateDaoSupport, IUserProfilesDao
    {
        public UserProfiles getUserProfiles(string obj)
        {
            IList lists = HibernateTemplate.Find("from UserProfiles where Username=? ", obj);
            if (lists == null || lists.Count < 1)
            {
                return null;
            }
            else
            {
                return (UserProfiles)lists[0];
            }
        }

        public IList getUserProfilesList(ArrayList obj)
        {
            IList lists = HibernateTemplate.Find("from UserProfiles where id=? ", obj);
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
        public void Save(UserProfiles obj)
        {
            HibernateTemplate.SaveOrUpdate(obj);
        }

        [Transaction(ReadOnly = false)]
        public void Delete(UserProfiles obj)
        {
            HibernateTemplate.Delete(obj); ;
        }
    }
}

