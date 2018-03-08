/*
 * Copyright 2007-2009 Orgman Software
 * http://www.orgman.idv.tw
 * 
 */

using System.Collections;
using Tgpf.Isr.Model;

namespace Tgpf.Isr.Service
{
    public interface IExamplesService
    {

        Examples getExamples(ArrayList obj);
        IList getExamplesList();
        IList getExamplesListByYear(string year);
        void Save(Examples obj);
        void Delete(Examples obj);
    }
}

