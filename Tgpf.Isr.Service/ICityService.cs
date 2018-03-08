/*
 * Copyright 2007-2009 Orgman Software
 * http://www.orgman.idv.tw
 * 
 */

using System.Collections;
using Tgpf.Isr.Model;

namespace Tgpf.Isr.Service
{
    public interface ICityService
    {

        City getCity(string obj);
        IList getCityList();
        void Save(City obj);
        void Delete(City obj);
    }
}

