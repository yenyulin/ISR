/*
 * Copyright 2007-2009 Orgman Software
 * http://www.orgman.idv.tw
 * 
 */

using System.Collections;
using Tgpf.Isr.Model;

namespace Tgpf.Isr.Dao
{
    public interface ICaseDao
    {

        Case getCase(int obj);
        IList getCaseList();
        void Save(Case obj);
        void Delete(IList obj);
    }
}

