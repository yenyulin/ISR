using System.Collections;
using Tgpf.Isr.Model;

namespace Tgpf.Isr.Service
{
    public interface IAspnetUsersService
    {
        AspnetUsers FindById(string id);
        AspnetUsers FindByProperty(string userName);
        void Update(AspnetUsers obj);
    }
}
