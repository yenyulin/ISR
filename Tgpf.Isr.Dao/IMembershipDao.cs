/*
 * Copyright 2007-2009 Orgman Software
 * http://www.orgman.idv.tw
 * 
 */

using System.Collections;
using Tgpf.Isr.Model;

namespace Tgpf.Isr.Dao
{
    public interface IMembershipDao
    {

        AspnetMembership FindById(string id);
        void Update(AspnetMembership obj);

    }
}
