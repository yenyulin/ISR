/*
 * Copyright 2007-2009 Orgman Software
 * http://www.orgman.idv.tw
 * 
 */

using System.Collections;
using Spring.Data.NHibernate.Support;
using Spring.Transaction.Interceptor;
using Tgpf.Isr.Model;
using System.Web.Security;

namespace Tgpf.Isr.Dao.NHibernate
{
    public class HibernateMatchDao : HibernateDaoSupport, IMatchDao
    {
        public Match getMatch(int obj)
        {
            IList lists = HibernateTemplate.Find("from Match where Id=? ", obj);
            if (lists == null || lists.Count < 1)
            {
                return null;
            }
            else
            {
                return (Match)lists[0];
            }
        }

        public IList getNotApprovedMatch(string obj)
        {
            IList lists = HibernateTemplate.Find("from Match where (Username1='" + obj + "' or  Username2='" + obj + "') and (Isapproved1=false  or Isapproved2=false)");
            if (lists == null || lists.Count < 1)
            {
                return null;
            }
            else
            {
                return lists;
            }
        }


        public IList getMatchListForManager()
        {
            IList lists = HibernateTemplate.Find("from Match where Ischecked<>'N' and Isapproved1=true and Isapproved2=true order by Matchdate ");
            if (lists == null || lists.Count < 1)
            {
                return null;
            }
            else
            {
                return lists;
            }
        }

        public IList getMatchListForUser1(string obj)
        {
            IList lists = HibernateTemplate.Find("from Match where  Username1=?  and Ischecked='Y' and  Isconfirm1<>'N' order by Matchdate ", obj);
            if (lists == null || lists.Count < 1)
            {
                return null;
            }
            else
            {
                return lists;
            }
        }

        public IList getMatchListForUser2(string obj)
        {
            IList lists = HibernateTemplate.Find("from Match where  Username2=? and Ischecked='Y' and Isconfirm2<>'N' order by Matchdate ", obj);
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
        public void Save(IList matchList, MembershipUser user)
        {
            /* ±b¸¹¼f®Ö */
            if (user != null)
            {
                Membership.UpdateUser(user);
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
        public void Delete(Match obj)
        {
            HibernateTemplate.Delete(obj); ;
        }

        [Transaction(ReadOnly = false)]
        public void Update(IList obj)
        {
            if (obj != null)
            {
                foreach (Match item in obj)
                {
                    HibernateTemplate.Update(item);
                }
            }
        }


    }
}

