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
 public class ParamPK
 {
	private string _paramid;
	private string _paramcode;

     public ParamPK()
	{
	}
	
	public string  Paramid 
	{
	  get { return _paramid; }
	  set { _paramid = value; }				
	}
	public string  Paramcode 
	{
	  get { return _paramcode; }
	  set { _paramcode = value; }				
	}
		
	public override bool Equals(object obj) 
	{
	 if (this == obj) return true;
     if ((obj == null) || (obj.GetType() != this.GetType())) return false;
     ParamPK that = (ParamPK)obj;
	 if (that == null)
     {
       return false;
     }
     else
	 {
	  if (this._paramid != that._paramid) return false;
	  if (this._paramcode != that._paramcode) return false;
	  return true;
	 }			 
	}
	
	public override int GetHashCode()
	{
	 int hash = 57;
     hash = 27 * hash * _paramid.GetHashCode();
     hash = 27 * hash * _paramcode.GetHashCode();
	 return hash;
    }
 }

}	 


