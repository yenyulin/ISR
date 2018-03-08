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
    public class ReuseTech
    {
        protected int _Id;
        private DateTime _createdate;
        private bool _isapproved;
        private string _patent;
        private string _researchitem;
        private string _reusename;
        private string _techadv;
        private string _techdesc;
        private string _techitem;
        private string _techname;
        private string _techother;
        private string _type;
        private string _username;
        private string _wasteitem;
        private string _wastename;
        private string _wasteother;

        public ReuseTech()
        {
        }

        public ReuseTech(int _Id
         , DateTime _createdate
         , bool _isapproved
         , string _patent
         , string _researchitem
         , string _reusename
         , string _techadv
         , string _techdesc
         , string _techitem
         , string _techname
         , string _techother
         , string _type
         , string _username
         , string _wasteitem
         , string _wastename
         , string _wasteother
        )
        {
            this._Id = _Id;
            this._createdate = _createdate;
            this._isapproved = _isapproved;
            this._patent = _patent;
            this._researchitem = _researchitem;
            this._reusename = _reusename;
            this._techadv = _techadv;
            this._techdesc = _techdesc;
            this._techitem = _techitem;
            this._techname = _techname;
            this._techother = _techother;
            this._type = _type;
            this._username = _username;
            this._wasteitem = _wasteitem;
            this._wastename = _wastename;
            this._wasteother = _wasteother;
        }

        public virtual int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public virtual DateTime Createdate
        {
            get { return _createdate; }
            set { _createdate = value; }
        }

        public virtual bool Isapproved
        {
            get { return _isapproved; }
            set { _isapproved = value; }
        }

        public virtual string Patent
        {
            get { return _patent; }
            set { _patent = value; }
        }

        public virtual string Researchitem
        {
            get { return _researchitem; }
            set { _researchitem = value; }
        }

        public virtual string Reusename
        {
            get { return _reusename; }
            set { _reusename = value; }
        }

        public virtual string Techadv
        {
            get { return _techadv; }
            set { _techadv = value; }
        }

        public virtual string Techdesc
        {
            get { return _techdesc; }
            set { _techdesc = value; }
        }

        public virtual string Techitem
        {
            get { return _techitem; }
            set { _techitem = value; }
        }

        public virtual string Techname
        {
            get { return _techname; }
            set { _techname = value; }
        }

        public virtual string Techother
        {
            get { return _techother; }
            set { _techother = value; }
        }

        public virtual string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public virtual string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public virtual string Wasteitem
        {
            get { return _wasteitem; }
            set { _wasteitem = value; }
        }

        public virtual string Wastename
        {
            get { return _wastename; }
            set { _wastename = value; }
        }

        public virtual string Wasteother
        {
            get { return _wasteother; }
            set { _wasteother = value; }
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if ((obj == null) || (obj.GetType() != this.GetType())) return false;
            ReuseTech castObj = (ReuseTech)obj;
            return (castObj != null) &&
              (this._Id == castObj.Id);

        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = 37 * hash * _Id.GetHashCode();
            return hash;
        }

    }
}


