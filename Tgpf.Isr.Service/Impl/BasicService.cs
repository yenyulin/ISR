using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Tgpf.Isr.Dao;

namespace Tgpf.Isr.Service.Impl
{
    public class BasicService : IBasicService
    {


        private IBasicDao dao;



        public IBasicDao BasicDao
        {
            get { return dao; }
            set { dao = value; }
        }


        public IList GetByHQL(string hql, ArrayList lists)
        {
            return dao.GetByHQL(hql, lists);
        }


    }
}
