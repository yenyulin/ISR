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
    public class ReuseTechService : IReuseTechService
    {
        private IReuseTechDao dao;

        public IReuseTechDao ReuseTechDao
        {
            get { return dao; }
            set { dao = value; }
        }

        public ReuseTech getReuseTech(int id)
        {
            return dao.getReuseTech(id);
        }

        public ReuseTech getReuseTechByName(string obj)
        {
            return dao.getReuseTechByName(obj);
        }

        public IList getReuseTechList(object[] obj)
        {
            return dao.getReuseTechList(obj);
        }

        public IList getReuseTechListAll(string obj)
        {
            return dao.getReuseTechListAll(obj);
        }

        public void Save(ReuseTech obj, IList matchList, UserProfiles up)
        {
            dao.Save(obj, matchList, up);
        }

        public void Delete(ReuseTech obj, UserProfiles up, IList matchList)
        {
            dao.Delete(obj, up, matchList);
        }

        public void DeleteAll(IList obj, UserProfiles up)
        {
            dao.DeleteAll(obj, up);
        }
    }
}

