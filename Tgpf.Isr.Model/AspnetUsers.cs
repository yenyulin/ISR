/*
 * Copyright 2007-2009 Orgman Software
 * http://www.orgman.idv.tw
 * 
 */

using System;
using System.Collections;
using System.Collections.Generic;

namespace Tgpf.Isr.Model
{

    [Serializable]
    public class AspnetUsers
    {


        protected string _userid;
        protected string _username;
        protected string _mobilealias;
        protected bool _isanonymous;

        protected DateTime _lastactivitydate;




        public AspnetUsers() { }

        public AspnetUsers(string username, string mobilealias, bool isanonymous, DateTime lastactivitydate)
        {
            this._username = username;
            this._mobilealias = mobilealias;
            this._isanonymous = isanonymous;
            this._lastactivitydate = lastactivitydate;
        }

        public AspnetUsers(string username)
        {
            this._username = username;
        }




        public virtual string UserId
        {
            get { return _userid; }
            set { _userid = value; }
        }
        public virtual string UserName
        {
            get { return _username; }
            set { _username = value; }
        }
        public virtual string MobileAlias
        {
            get { return _mobilealias; }
            set { _mobilealias = value; }
        }
        public virtual bool IsAnonymous
        {
            get { return _isanonymous; }
            set { _isanonymous = value; }
        }
        public virtual DateTime LastActivityDate
        {
            get { return _lastactivitydate; }
            set { _lastactivitydate = value; }
        }



    }
}
