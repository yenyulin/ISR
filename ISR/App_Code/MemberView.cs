using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Tgpf.Isr.Base
{
    [Serializable]
    public class MemberView
    {
        public MemberView()
        {
        }

        private string _name;
        private string _username;

        public virtual string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public virtual string Username
        {
            get { return _username; }
            set { _username = value; }
        }
    }
}