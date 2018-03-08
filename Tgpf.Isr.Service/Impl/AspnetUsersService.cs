using System;
using System.Collections;
using Spring.Transaction.Interceptor;
using Tgpf.Isr.Dao;
using Tgpf.Isr.Model;

namespace Tgpf.Isr.Service.Impl
{
    public class AspnetUsersService : IAspnetUsersService
    {
        private IAspnetUsersDao dao;

        public IAspnetUsersDao AspnetUsersDao
        {
            get { return dao; }
            set { dao = value; }
        }

        public AspnetUsers FindById(string id)
        {
            return dao.FindById(id);
        }

        public AspnetUsers FindByProperty(string userName)
        {
            return dao.FindByProperty(userName);
        }

        public void Update(AspnetUsers obj)
        {
            dao.Update(obj);
        }

    }
}
