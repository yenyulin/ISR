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
public class Marquee 
{	 
	protected string _Id;
	private string _msg;
		
	public Marquee()
	{
	}		
	
	public Marquee(string _Id
	 ,string _msg
	)
	{
	 this._Id = _Id;
	 this._msg = _msg;
	}
	
	public virtual string Id {
	    get { return _Id; }
		set { _Id= value; }
    }
			
	public virtual string Msg
	{
	    get { return _msg; }
        set { _msg = value; }					
	}
	
	public override bool Equals(object obj) 
	{
	  if (this == obj) return true;
      if ((obj == null) || (obj.GetType() != this.GetType())) return false;
	  Marquee castObj = (Marquee)obj;
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


