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
 
    public class HqlReuse
    {
        protected int _Id;
        private string _patent;
        private string _researchitem;
        private string _reusename;
        private string _techitem;
        private string _techname;
        private string _techother;
        private string _username;
        private string _wasteitem;
        private string _wastename;
        private string _wasteother;
        private string _paramname;

        public HqlReuse(int _Id
         , string _patent
         , string _researchitem
         , string _reusename
         , string _techitem
         , string _techname
         , string _techother
         , string _username
         , string _wasteitem
         , string _wastename
         , string _wasteother
         , string _paramname
        )
        {
            this._Id = _Id;
            this._patent = _patent;
            this._researchitem = _researchitem;
            this._reusename = _reusename;
            this._techitem = _techitem;
            this._techname = _techname;
            this._techother = _techother;
            this._username = _username;
            this._wasteitem = _wasteitem;
            this._wastename = _wastename;
            this._wasteother = _wasteother;
            this._paramname = _paramname;
        }

        public HqlReuse(int _Id
         , string _patent
         , string _researchitem
         , string _reusename
         , string _techitem
         , string _techname
         , string _techother
         , string _username
         , string _wasteitem
         , string _wastename
         , string _wasteother
          
        )
        {
            this._Id = _Id;
            this._patent = _patent;
            this._researchitem = _researchitem;
            this._reusename = _reusename;
            this._techitem = _techitem;
            this._techname = _techname;
            this._techother = _techother;
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

        public virtual string Paramname
        {
            get { return _paramname; }
            set { _paramname = value; }
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
