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
    public class Case
    {
        protected int _Id;
        private string _casedesc;
        private DateTime _createdate;
        private string _helpdesc;
        private bool _isdeleted;
        private string _name;
        private string _techitem;
        private string _techname;
        private string _techother;
        private string _type;
        private string _wasteitem;
        private string _wastename;
        private string _wasteother;
        private string _datasource;

        public Case()
        {
        }

       
        public Case(int _Id
         , string _casedesc
         , DateTime _createdate
         , string _datasource
         , string _helpdesc
         , bool _isdeleted
         , string _name
         , string _techitem
         , string _techname
         , string _techother
         , string _type
         , string _wasteitem
         , string _wastename
         , string _wasteother
        )
        {
            this._Id = _Id;
            this._casedesc = _casedesc;
            this._createdate = _createdate;
            this._datasource = _datasource;
            this._helpdesc = _helpdesc;
            this._isdeleted = _isdeleted;
            this._name = _name;
            this._techitem = _techitem;
            this._techname = _techname;
            this._techother = _techother;
            this._type = _type;
            this._wasteitem = _wasteitem;
            this._wastename = _wastename;
            this._wasteother = _wasteother;
        }

        public virtual int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public virtual string Casedesc
        {
            get { return _casedesc; }
            set { _casedesc = value; }
        }

        public virtual DateTime Createdate
        {
            get { return _createdate; }
            set { _createdate = value; }
        }

        public virtual string Helpdesc
        {
            get { return _helpdesc; }
            set { _helpdesc = value; }
        }

        public virtual bool Isdeleted
        {
            get { return _isdeleted; }
            set { _isdeleted = value; }
        }

        public virtual string Name
        {
            get { return _name; }
            set { _name = value; }
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

        public virtual string Datasource
        {
            get { return _datasource; }
            set { _datasource = value; }
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if ((obj == null) || (obj.GetType() != this.GetType())) return false;
            Case castObj = (Case)obj;
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


