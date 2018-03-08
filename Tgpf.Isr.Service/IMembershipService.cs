/*
 * Copyright 2007-2009 Orgman Software
 * http://www.orgman.idv.tw
 * 
 */
using System.Collections;
using Tgpf.Isr.Model;

namespace Tgpf.Isr.Service
{
    public interface IMembershipService
    {

        AspnetMembership FindById(string id);
        void Update(AspnetMembership obj);
    }
}
