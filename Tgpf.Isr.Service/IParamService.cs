/*
 * Copyright 2007-2009 Orgman Software
 * http://www.orgman.idv.tw
 * 
 */

using System.Collections;
using Tgpf.Isr.Model;

namespace Tgpf.Isr.Service
{
    public interface IParamService
    {

        Param getParam(object[] obj);
        IList getParamList(ArrayList obj);
        void Save(Param obj);
        void Delete(Param obj);
    }
}

