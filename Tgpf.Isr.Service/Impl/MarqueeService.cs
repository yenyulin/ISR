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
    public class MarqueeService : IMarqueeService
    {
        private IMarqueeDao dao;

        public IMarqueeDao MarqueeDao
        {
            get { return dao; }
            set { dao = value; }
        }

        public Marquee getMarquee(string obj)
        {
            return dao.getMarquee(obj);
        }

        public IList getMarqueeList(ArrayList obj)
        {
            return dao.getMarqueeList(obj);
        }

        public void Save(Marquee obj)
        {
            dao.Save(obj);
        }

        public void Delete(Marquee obj)
        {
            dao.Delete(obj);
        }
    }
}

