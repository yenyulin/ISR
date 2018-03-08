/*
 * Copyright 2007-2009 Orgman Software
 * http://www.orgman.idv.tw
 * 
 */

using System;
using System.Collections;
using Spring.Transaction.Interceptor;
using Tgpf.Isr.Dao;
using Tgpf.Isr.Model;

namespace Tgpf.Isr.Service.Impl
{
    public class UserProfilesService : IUserProfilesService
    {
        private IUserProfilesDao dao;

        public IUserProfilesDao UserProfilesDao
        {
            get { return dao; }
            set { dao = value; }
        }

        public UserProfiles getUserProfiles(string obj)
        {
            return dao.getUserProfiles(obj);
        }

        public IList getUserProfilesList(ArrayList obj)
        {
            return dao.getUserProfilesList(obj);
        }

        public void Save(UserProfiles obj)
        {
            dao.Save(obj);
        }

        public void Delete(UserProfiles obj)
        {
            dao.Delete(obj);
        }
    }
}

