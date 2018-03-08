/*
 * Copyright 2007-2009 Orgman Software
 * http://www.orgman.idv.tw
 * 
 */

using System.Collections;
using Tgpf.Isr.Model;

namespace Tgpf.Isr.Service
{
    public interface IMarqueeService
    {

        Marquee getMarquee(string obj);
        IList getMarqueeList(ArrayList obj);
        void Save(Marquee obj);
        void Delete(Marquee obj);
    }
}

