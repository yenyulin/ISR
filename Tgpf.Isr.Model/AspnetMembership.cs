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
    public class AspnetMembership
    {

        protected string _userid;
        protected string _password;
        protected int _passwordformat;
        protected string _mobilepin;
        protected string _email;
        protected string _passwordquestion;
        protected string _passwordanswer;
        protected bool _isapproved;
        protected DateTime _createdate;
        protected DateTime _lastlogindate;
        protected DateTime _lastpasswordchangeddate;
        protected string _comment;
        protected string _passwordsalt;




        public AspnetMembership() { }

        public AspnetMembership(string userid, string password, int passwordformat, string mobilepin, string email, string passwordquestion, string passwordanswer, bool isapproved, DateTime createdate, DateTime lastlogindate, DateTime lastpasswordchangeddate, string comment, string passwordsalt)
        {
            this._userid = userid;
            this._password = password;
            this._passwordformat = passwordformat;
            this._mobilepin = mobilepin;
            this._email = email;
            this._passwordquestion = passwordquestion;
            this._passwordanswer = passwordanswer;
            this._isapproved = isapproved;
            this._createdate = createdate;
            this._lastlogindate = lastlogindate;
            this._lastpasswordchangeddate = lastpasswordchangeddate;
            this._comment = comment;
            this._passwordsalt = passwordsalt;
        }

        public AspnetMembership(string password, string email)
        {
            this._password = password;
            this._email = email;
        }



        public virtual string UserId
        {
            get { return _userid; }
            set { _userid = value; }
        }
        public virtual string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public virtual int PasswordFormat
        {
            get { return _passwordformat; }
            set { _passwordformat = value; }
        }
        public virtual string Mobilepin
        {
            get { return _mobilepin; }
            set { _mobilepin = value; }
        }
        public virtual string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public virtual string PasswordQuestion
        {
            get { return _passwordquestion; }
            set { _passwordquestion = value; }
        }
        public virtual string PasswordAnswer
        {
            get { return _passwordanswer; }
            set { _passwordanswer = value; }
        }
        public virtual bool IsApproved
        {
            get { return _isapproved; }
            set { _isapproved = value; }
        }
        public virtual DateTime CreateDate
        {
            get { return _createdate; }
            set { _createdate = value; }
        }
        public virtual DateTime LastLoginDate
        {
            get { return _lastlogindate; }
            set { _lastlogindate = value; }
        }
        public virtual DateTime LastPasswordChangedDate
        {
            get { return _lastpasswordchangeddate; }
            set { _lastpasswordchangeddate = value; }
        }
        public virtual string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }
        public virtual string PasswordSalt
        {
            get { return _passwordsalt; }
            set { _passwordsalt = value; }
        }


        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if ((obj == null) || (obj.GetType() != this.GetType())) return false;
            AspnetMembership castObj = (AspnetMembership)obj;
            return (castObj != null) &&
                (this._userid == castObj.UserId);
        }

        public override int GetHashCode()
        {
            int hash = 57;
            hash = 27 * hash * _userid.GetHashCode();
            return hash;
        }


    }
}
