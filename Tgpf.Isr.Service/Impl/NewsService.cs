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
    public class NewsService : INewsService
    {
        private INewsDao dao;

        public INewsDao NewsDao
        {
            get { return dao; }
            set { dao = value; }
        }

        public News getNews(int obj)
        {
            return dao.getNews(obj);
        }

        public IList getNewsListById(int obj)
        {
            return dao.getNewsListById(obj);
        }

        public IList getNewsList()
        {
            return dao.getNewsList();
        }

        public void Save(News obj)
        {
            dao.Save(obj);
        }

        public void Delete(News obj)
        {
            dao.Delete(obj);
        }
    }
}

