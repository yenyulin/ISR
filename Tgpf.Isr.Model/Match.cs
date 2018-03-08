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
    public class Match
    {
        protected int _Id;
        private DateTime _approveddate;
        private DateTime _confirmdate1;
        private DateTime _confirmdate2;
        private string _corp1;
        private string _corp2;
        private DateTime _createdate1;
        private DateTime _createdate2;
        private DateTime _deletedate1;
        private DateTime _deletedate2;
        private bool _isapproved1;
        private bool _isapproved2;
        private string _ischecked;
        private string _isconfirm1;
        private string _isconfirm2;
        private bool _isdeleted;
        private bool _isdeleted1;
        private bool _isdeleted2;
        private string _isdroped1;
        private string _isdroped2;
        private DateTime _matchdate;
        private string _name1;
        private string _name2;
        private string _reusename1;
        private string _reusename2;
        private int _rid1;
        private int _rid2;
        private string _techadv;
        private string _techdesc;
        private string _techitem1;
        private string _techitem2;
        private string _techname1;
        private string _techname2;
        private string _tel1;
        private string _tel2;
        private string _username1;
        private string _username2;
        private string _wasteitem1;
        private string _wasteitem2;
        private string _wastename1;
        private string _wastename2;

        public Match()
        {
        }

        public Match(int _Id
         , DateTime _approveddate
         , DateTime _confirmdate1
         , DateTime _confirmdate2
         , string _corp1
         , string _corp2
         , DateTime _createdate1
         , DateTime _createdate2
         , DateTime _deletedate1
         , DateTime _deletedate2
         , bool _isapproved1
         , bool _isapproved2
         , string _ischecked
         , string _isconfirm1
         , string _isconfirm2
         , bool _isdeleted
         , bool _isdeleted1
         , bool _isdeleted2
         , string _isdroped1
         , string _isdroped2
         , DateTime _matchdate
         , string _name1
         , string _name2
         , string _reusename1
         , string _reusename2
         , int _rid1
         , int _rid2
         , string _techadv
         , string _techdesc
         , string _techitem1
         , string _techitem2
         , string _techname1
         , string _techname2
         , string _tel1
         , string _tel2
         , string _username1
         , string _username2
         , string _wasteitem1
         , string _wasteitem2
         , string _wastename1
         , string _wastename2
        )
        {
            this._Id = _Id;
            this._approveddate = _approveddate;
            this._confirmdate1 = _confirmdate1;
            this._confirmdate2 = _confirmdate2;
            this._corp1 = _corp1;
            this._corp2 = _corp2;
            this._createdate1 = _createdate1;
            this._createdate2 = _createdate2;
            this._deletedate1 = _deletedate1;
            this._deletedate2 = _deletedate2;
            this._isapproved1 = _isapproved1;
            this._isapproved2 = _isapproved2;
            this._ischecked = _ischecked;
            this._isconfirm1 = _isconfirm1;
            this._isconfirm2 = _isconfirm2;
            this._isdeleted = _isdeleted;
            this._isdeleted1 = _isdeleted1;
            this._isdeleted2 = _isdeleted2;
            this._isdroped1 = _isdroped1;
            this._isdroped2 = _isdroped2;
            this._matchdate = _matchdate;
            this._name1 = _name1;
            this._name2 = _name2;
            this._reusename1 = _reusename1;
            this._reusename2 = _reusename2;
            this._rid1 = _rid1;
            this._rid2 = _rid2;
            this._techadv = _techadv;
            this._techdesc = _techdesc;
            this._techitem1 = _techitem1;
            this._techitem2 = _techitem2;
            this._techname1 = _techname1;
            this._techname2 = _techname2;
            this._tel1 = _tel1;
            this._tel2 = _tel2;
            this._username1 = _username1;
            this._username2 = _username2;
            this._wasteitem1 = _wasteitem1;
            this._wasteitem2 = _wasteitem2;
            this._wastename1 = _wastename1;
            this._wastename2 = _wastename2;
        }

        public virtual int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public virtual DateTime Approveddate
        {
            get { return _approveddate; }
            set { _approveddate = value; }
        }

        public virtual DateTime Confirmdate1
        {
            get { return _confirmdate1; }
            set { _confirmdate1 = value; }
        }

        public virtual DateTime Confirmdate2
        {
            get { return _confirmdate2; }
            set { _confirmdate2 = value; }
        }

        public virtual string Corp1
        {
            get { return _corp1; }
            set { _corp1 = value; }
        }

        public virtual string Corp2
        {
            get { return _corp2; }
            set { _corp2 = value; }
        }

        public virtual DateTime Createdate1
        {
            get { return _createdate1; }
            set { _createdate1 = value; }
        }

        public virtual DateTime Createdate2
        {
            get { return _createdate2; }
            set { _createdate2 = value; }
        }

        public virtual DateTime Deletedate1
        {
            get { return _deletedate1; }
            set { _deletedate1 = value; }
        }

        public virtual DateTime Deletedate2
        {
            get { return _deletedate2; }
            set { _deletedate2 = value; }
        }

        public virtual bool Isapproved1
        {
            get { return _isapproved1; }
            set { _isapproved1 = value; }
        }

        public virtual bool Isapproved2
        {
            get { return _isapproved2; }
            set { _isapproved2 = value; }
        }

        public virtual string Ischecked
        {
            get { return _ischecked; }
            set { _ischecked = value; }
        }

        public virtual string Isconfirm1
        {
            get { return _isconfirm1; }
            set { _isconfirm1 = value; }
        }

        public virtual string Isconfirm2
        {
            get { return _isconfirm2; }
            set { _isconfirm2 = value; }
        }

        public virtual bool Isdeleted
        {
            get { return _isdeleted; }
            set { _isdeleted = value; }
        }

        public virtual bool Isdeleted1
        {
            get { return _isdeleted1; }
            set { _isdeleted1 = value; }
        }

        public virtual bool Isdeleted2
        {
            get { return _isdeleted2; }
            set { _isdeleted2 = value; }
        }

        public virtual string Isdroped1
        {
            get { return _isdroped1; }
            set { _isdroped1 = value; }
        }

        public virtual string Isdroped2
        {
            get { return _isdroped2; }
            set { _isdroped2 = value; }
        }

        public virtual DateTime Matchdate
        {
            get { return _matchdate; }
            set { _matchdate = value; }
        }

        public virtual string Name1
        {
            get { return _name1; }
            set { _name1 = value; }
        }

        public virtual string Name2
        {
            get { return _name2; }
            set { _name2 = value; }
        }

        public virtual string Reusename1
        {
            get { return _reusename1; }
            set { _reusename1 = value; }
        }

        public virtual string Reusename2
        {
            get { return _reusename2; }
            set { _reusename2 = value; }
        }

        public virtual int Rid1
        {
            get { return _rid1; }
            set { _rid1 = value; }
        }

        public virtual int Rid2
        {
            get { return _rid2; }
            set { _rid2 = value; }
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

        public virtual string Techitem1
        {
            get { return _techitem1; }
            set { _techitem1 = value; }
        }

        public virtual string Techitem2
        {
            get { return _techitem2; }
            set { _techitem2 = value; }
        }

        public virtual string Techname1
        {
            get { return _techname1; }
            set { _techname1 = value; }
        }

        public virtual string Techname2
        {
            get { return _techname2; }
            set { _techname2 = value; }
        }

        public virtual string Tel1
        {
            get { return _tel1; }
            set { _tel1 = value; }
        }

        public virtual string Tel2
        {
            get { return _tel2; }
            set { _tel2 = value; }
        }

        public virtual string Username1
        {
            get { return _username1; }
            set { _username1 = value; }
        }

        public virtual string Username2
        {
            get { return _username2; }
            set { _username2 = value; }
        }

        public virtual string Wasteitem1
        {
            get { return _wasteitem1; }
            set { _wasteitem1 = value; }
        }

        public virtual string Wasteitem2
        {
            get { return _wasteitem2; }
            set { _wasteitem2 = value; }
        }

        public virtual string Wastename1
        {
            get { return _wastename1; }
            set { _wastename1 = value; }
        }

        public virtual string Wastename2
        {
            get { return _wastename2; }
            set { _wastename2 = value; }
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if ((obj == null) || (obj.GetType() != this.GetType())) return false;
            Match castObj = (Match)obj;
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


