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
public class Zip 
{	 
	protected string _Id;
	private string _name;
	private string _pid;
    private string _city;

	public Zip()
	{
	}		
	
	public Zip(string _Id
	 ,string _name
	 ,string _pid
	)
	{
	 this._Id = _Id;
	 this._name = _name;
	 this._pid = _pid;
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

	public virtual string Pid
	{
	    get { return _pid; }
        set { _pid = value; }					
	}

    public virtual string City
    {
        get { return _city; }
        set { _city = value; }
    }

	public override bool Equals(object obj) 
	{
	  if (this == obj) return true;
      if ((obj == null) || (obj.GetType() != this.GetType())) return false;
	  Zip castObj = (Zip)obj;
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


