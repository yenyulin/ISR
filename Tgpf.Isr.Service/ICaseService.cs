/*
 * Copyright 2007-2009 Orgman Software
 * http://www.orgman.idv.tw
 * 
 */

using System.Collections;
using Tgpf.Isr.Model;

namespace Tgpf.Isr.Service
{
    public interface ICaseService
    {

        Case getCase(int obj);
        IList getCaseList();
        void Save(Case obj);
        void Delete(IList obj);
    }
}

