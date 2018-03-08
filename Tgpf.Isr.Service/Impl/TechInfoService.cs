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
    public class TechInfoService : ITechInfoService
    {
        private ITechInfoDao dao;

        public ITechInfoDao TechInfoDao
        {
            get { return dao; }
            set { dao = value; }
        }

        public TechInfo getTechInfo(int obj)
        {
            return dao.getTechInfo(obj);
        }

        public IList getTechInfoList(int obj)
        {
            return dao.getTechInfoList(obj);
        }

        public void Save(TechInfo obj)
        {
            dao.Save(obj);
        }

        public void Delete(TechInfo obj)
        {
            dao.Delete(obj);
        }
    }
}

