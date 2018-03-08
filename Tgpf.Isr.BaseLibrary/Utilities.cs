using System;
using System.Collections.Generic;
using log4net.Config;
using log4net;

namespace Tgpf.Isr.BaseLibrary
{
    public class Utilities
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Utilities));

        public static void LogError(Exception ex)
        {
            log.Error(ex.ToString());
        }
    }


}
