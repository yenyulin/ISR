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
    public class ExamplesService : IExamplesService
    {
        private IExamplesDao dao;

        public IExamplesDao ExamplesDao
        {
            get { return dao; }
            set { dao = value; }
        }

        public Examples getExamples(ArrayList obj)
        {
            return dao.getExamples(obj);
        }

        public IList getExamplesList()
        {
            return dao.getExamplesList();
        }

        public IList getExamplesListByYear(string year)
        {
            return dao.getExamplesListByYear(year);
        }

        public void Save(Examples obj)
        {
            dao.Save(obj);
        }

        public void Delete(Examples obj)
        {
            dao.Delete(obj);
        }
    }
}

