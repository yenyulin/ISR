/*
 * Copyright 2007-2009 Orgman Software
 * http://www.orgman.idv.tw
 * 
 */

using System.Collections;
using Tgpf.Isr.Model;

namespace Tgpf.Isr.Dao
{
    public interface INewsDao
    {

        News getNews(int obj);
        IList getNewsList();
        IList getNewsListById(int obj);
        void Save(News obj);
        void Delete(News obj);
    }
}

