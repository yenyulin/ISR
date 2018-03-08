/*
 * Copyright 2007-2009 Orgman Software
 * http://www.orgman.idv.tw
 * 
 */

using System.Collections;
using Tgpf.Isr.Model;
using System.Web.Security;

namespace Tgpf.Isr.Service
{
    public interface IMatchService
    {

        Match getMatch(int obj);
        IList getNotApprovedMatch(string obj);
        IList getMatchListForManager();
        IList getMatchListForUser1(string obj);
        IList getMatchListForUser2(string obj);
        void Save(IList matchList, MembershipUser user);
        void Update(IList obj);
        void Delete(Match obj);
    }
}

