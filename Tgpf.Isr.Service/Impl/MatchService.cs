/*
 * Copyright 2007-2009 Orgman Software
 * http://www.orgman.idv.tw
 * 
 */

using System;
using System.Collections;
using Spring.Transaction.Interceptor;
using Tgpf.Isr.Dao;
using Tgpf.Isr.Model;
using System.Web.Security;

namespace Tgpf.Isr.Service.Impl
{
    public class MatchService : IMatchService
    {
        private IMatchDao dao;

        public IMatchDao MatchDao
        {
            get { return dao; }
            set { dao = value; }
        }

        public Match getMatch(int obj)
        {
            return dao.getMatch(obj);
        }

        public IList getNotApprovedMatch(string obj)
        {
            return dao.getNotApprovedMatch(obj);
        }

        public IList getMatchListForManager()
        {
            return dao.getMatchListForManager();
        }

        public IList getMatchListForUser1(string obj)
        {
            return dao.getMatchListForUser1(obj);
        }

        public IList getMatchListForUser2(string obj)
        {
            return dao.getMatchListForUser2(obj);
        }

        public void Save(IList matchList, MembershipUser user)
        {
            dao.Save(matchList, user);
        }

        public void Delete(Match obj)
        {
            dao.Delete(obj);
        }

        
        public void Update(IList obj)
        {
            dao.Update(obj);
        }
    }
}

