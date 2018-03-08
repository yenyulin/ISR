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

    public class Param
    {
        private ParamPK _id;
        private string _paramname;

        public Param()
        {
        }

        public Param(ParamPK _id
         , string _paramname
        )
        {
            this._id = _id;
            this._paramname = _paramname;
        }

        public virtual ParamPK Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public virtual string Paramname
        {
            get { return _paramname; }
            set { _paramname = value; }
        }

    }



}


