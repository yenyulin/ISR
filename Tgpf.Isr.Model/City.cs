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
public class City 
{	 
	protected string _Id;
	private string _name;
		
	public City()
	{
	}		
	
	public City(string _Id
	 ,string _name
	)
	{
	 this._Id = _Id;
	 this._name = _name;
	}
	
	public virtual string Id {
	    get { return _Id; }
		set { _Id= value; }
    }
			
	public virtual string Name
	{
	    get { return _name; }
        set { _name = value; }					
	}
	
	public override bool Equals(object obj) 
	{
	  if (this == obj) return true;
      if ((obj == null) || (obj.GetType() != this.GetType())) return false;
	  City castObj = (City)obj;
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


