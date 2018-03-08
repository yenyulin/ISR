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
    public class ZipService : IZipService
    {
        private IZipDao dao;

        public IZipDao ZipDao
        {
            get { return dao; }
            set { dao = value; }
        }

        public Zip getZip(string obj)
        {
            return dao.getZip(obj);
        }

        public IList getZipList(string obj)
        {
            return dao.getZipList(obj);
        }

        public void Save(Zip obj)
        {
            dao.Save(obj);
        }

        public void Delete(Zip obj)
        {
            dao.Delete(obj);
        }
    }
}

