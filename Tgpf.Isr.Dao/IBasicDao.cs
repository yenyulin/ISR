using System;
using System.Collections;
using System.Text;

namespace Tgpf.Isr.Dao
{
    public interface IBasicDao
    {
        IList GetByHQL(string hql, ArrayList lists);
    }
}
