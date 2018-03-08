/*
 * Copyright 2007-2009 Orgman Software
 * http://www.orgman.idv.tw
 * 
 */

using System.Collections;
using Tgpf.Isr.Model;

namespace Tgpf.Isr.Dao
{
    public interface IReuseTechDao
    {

        ReuseTech getReuseTech(int id);
        ReuseTech getReuseTechByName(string obj);
        IList getReuseTechList(object[] obj);
        IList getReuseTechListAll(string obj);
        void Save(ReuseTech obj, IList matchList,UserProfiles up);
        void Delete(ReuseTech obj, UserProfiles up, IList matchList);
        void DeleteAll(IList obj, UserProfiles up);
    }
}

