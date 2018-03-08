using System;
using System.Collections.Generic;
using System.Text;
using Spring.Data.Core;
using Spring.Data.Common;

namespace Tgpf.Isr.BaseLibrary
{
    public class SpringUtil
    {
        public static AdoTemplate adoTemplate;
        public static DbProvider dbProvider;

        public AdoTemplate AdoTemplate
        {
            get { return adoTemplate; }
            set { adoTemplate = value; }
        }

        public DbProvider DbProvider
        {
            get { return dbProvider; }
            set { dbProvider = value; }
        }

        public static AdoTemplate at()
        {
            if (adoTemplate == null)
            {
                adoTemplate = new AdoTemplate(dbProvider);
            }
            return adoTemplate;
        }
    }
}
