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
    public class HibernateReuseTechDao : HibernateDaoSupport, IReuseTechDao
    {
        public ReuseTech getReuseTech(int id)
        {
            IList lists = HibernateTemplate.Find("from ReuseTech where id=? ", id);
            if (lists == null || lists.Count < 1)
            {
                return null;
            }
            else
            {
                return (ReuseTech)lists[0];
            }
        }

        public ReuseTech getReuseTechByName(string obj)
        {
            IList lists = HibernateTemplate.Find("from ReuseTech where Username=? ", obj);
            if (lists == null || lists.Count < 1)
            {
                return null;
            }
            else
            {
                return (ReuseTech)lists[0];
            }
        }

        public IList getReuseTechList(object[] obj)
        {
            IList lists = HibernateTemplate.Find("from ReuseTech where Id=? and Username=?", obj);
            if (lists == null || lists.Count < 1)
            {
                return null;
            }
            else
            {
                return lists;
            }
        }

        public IList getReuseTechListAll(string obj)
        {
            IList lists = HibernateTemplate.Find("from ReuseTech where   Username=?", obj);
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
        public void Save(ReuseTech obj, IList matchList, UserProfiles up)
        {
            if (up != null)
            {
                HibernateTemplate.SaveOrUpdate(up);
            }
            if (obj != null)
            {
                HibernateTemplate.SaveOrUpdate(obj);

            }
            if (matchList != null)
            {
                foreach (Match item in matchList)
                {
                    if (obj.Type.Equals("1"))
                        item.Rid1 = obj.Id; // ReuseTech ½s¸¹
                    else
                        item.Rid2 = obj.Id; // ReuseTech ½s¸¹
                    HibernateTemplate.Save(item);
                }
            }


        }

        [Transaction(ReadOnly = false)]
        public void Delete(ReuseTech obj, UserProfiles up, IList matchList)
        {
            HibernateTemplate.Delete(obj);
            if (up != null)
            {
                HibernateTemplate.Delete(up);
            }
            if (matchList != null)
            {
                foreach (Match item in matchList)
                {                    
                    HibernateTemplate.Update(item);
                }
            }
        }

        [Transaction(ReadOnly = false)]
        public void DeleteAll(IList obj, UserProfiles up)
        {
            if (obj != null)
            {
                foreach (ReuseTech item in obj)
                {
                    HibernateTemplate.Delete(item);
                }
            }

            if (up != null)
            {
                HibernateTemplate.Delete(up);
            }
        }
    }
}

