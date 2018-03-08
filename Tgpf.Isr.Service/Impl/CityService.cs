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
    public class CityService : ICityService
    {
        private ICityDao dao;

        public ICityDao CityDao
        {
            get { return dao; }
            set { dao = value; }
        }

        public City getCity(string obj)
        {
            return dao.getCity(obj);
        }

        public IList getCityList()
        {
            return dao.getCityList();
        }

        public void Save(City obj)
        {
            dao.Save(obj);
        }

        public void Delete(City obj)
        {
            dao.Delete(obj);
        }
    }
}

