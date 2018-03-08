/*
 * Copyright 2007-2009 Orgman Software
 * http://www.orgman.idv.tw
 * 
 */

using System.Collections;
using Tgpf.Isr.Model;

namespace Tgpf.Isr.Service
{
    public interface IUserProfilesService
    {

        UserProfiles getUserProfiles(string obj);
        IList getUserProfilesList(ArrayList obj);
        void Save(UserProfiles obj);
        void Delete(UserProfiles obj);
    }
}

