using System;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Spring.Context.Support;
using Spring.Context;
using NHibernate;

namespace Tgpf.Isr.BaseLibrary
{
    public class BaseAction
    {
        private static IApplicationContext context;
        private static bool isInit = false;       
        
        public BaseAction()
        {

        }              

        public static void init()
        {
            context = ContextRegistry.GetContext();
            isInit = true;
        }

        public static IApplicationContext Context
        {
            get
            {
                if (!isInit)
                {
                    init();
                }
                return context;
            }
        }
    }
}
