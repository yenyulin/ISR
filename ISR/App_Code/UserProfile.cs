/*
 * Copyright 2007-2009 Orgman Software
 * http://www.orgman.idv.tw
 * 
 */

using System;
using System.Collections;
using System.Collections.Generic;

namespace Tgpf.Isr.Base
{

    [Serializable]
    public class UserProfile
    {

        private string _address;
        private string _city;
        private string _corp;
        private string _fax;
        private string _kind;
        private string _name;
        private string _owner;
        private string _postcode;
        private string _tel;
        private string _type;
        private string _zipcht;

        public UserProfile()
        {
        }

        public virtual string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public virtual string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public virtual string Corp
        {
            get { return _corp; }
            set { _corp = value; }
        }

        public virtual string Fax
        {
            get { return _fax; }
            set { _fax = value; }
        }

        public virtual string Kind
        {
            get { return _kind; }
            set { _kind = value; }
        }

        public virtual string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public virtual string Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        public virtual string Postcode
        {
            get { return _postcode; }
            set { _postcode = value; }
        }

        public virtual string Tel
        {
            get { return _tel; }
            set { _tel = value; }
        }

        public virtual string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public virtual string Zipcht
        {
            get { return _zipcht; }
            set { _zipcht = value; }
        }
        /*public override bool Equals(object obj) 
        {
          if (this == obj) return true;
          if ((obj == null) || (obj.GetType() != this.GetType())) return false;
          UserProfile castObj = (UserProfile)obj;
          return (castObj != null) &&
            (this._Id == castObj.Id);
	   
        }
	
        public override int GetHashCode()
        {
          int hash = 17;
          hash = 37 * hash * _Id.GetHashCode();
          return hash;
        }*/

    }
}


