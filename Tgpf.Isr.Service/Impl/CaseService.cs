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
    public class CaseService : ICaseService
    {
        private ICaseDao dao;

        public ICaseDao CaseDao
        {
            get { return dao; }
            set { dao = value; }
        }

        public Case getCase(int obj)
        {
            return dao.getCase(obj);
        }

        public IList getCaseList()
        {
            return dao.getCaseList();
        }

        public void Save(Case obj)
        {
            dao.Save(obj);
        }

        public void Delete(IList obj)
        {
            dao.Delete(obj);
        }
    }
}

