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
    public class ParamService : IParamService
    {
        private IParamDao dao;

        public IParamDao ParamDao
        {
            get { return dao; }
            set { dao = value; }
        }

        public Param getParam(object[] obj)
        {
            return dao.getParam(obj);
        }

        public IList getParamList(ArrayList obj)
        {
            return dao.getParamList(obj);
        }

        public void Save(Param obj)
        {
            dao.Save(obj);
        }

        public void Delete(Param obj)
        {
            dao.Delete(obj);
        }
    }
}

