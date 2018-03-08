/*
 * Copyright 2007-2009 Orgman Software
 * http://www.orgman.idv.tw
 * 
 */

using System.Collections;
using Tgpf.Isr.Model;

namespace Tgpf.Isr.Service
{
    public interface ITechInfoService
    {

        TechInfo getTechInfo(int obj);
        IList getTechInfoList(int obj);
        void Save(TechInfo obj);
        void Delete(TechInfo obj);
    }
}

