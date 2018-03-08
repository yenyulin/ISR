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

namespace Tgpf.Isr.Service.Impl
{
    public class MembershipService : IMembershipService
    {
        private IMembershipDao dao;

        public IMembershipDao MembershipDao
        {
            get { return dao; }
            set { dao = value; }
        }

        public AspnetMembership FindById(string id)
        {
            return dao.FindById(id);
        }

        public void Update(AspnetMembership obj)
        {
            dao.Update(obj);
        }

    }
}
