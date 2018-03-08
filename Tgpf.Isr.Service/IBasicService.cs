using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Tgpf.Isr.Service
{
    public interface IBasicService
    {
        IList GetByHQL(string hql, ArrayList lists);
    }
}
