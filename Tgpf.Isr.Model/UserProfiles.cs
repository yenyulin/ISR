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
public class UserProfiles 
{	 
	protected int _Id;
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
	private string _username;
	private string _zipcht;
		
	public UserProfiles()
	{
	}		
	
	public UserProfiles(int _Id
	 ,string _address
	 ,string _city
	 ,string _corp
	 ,string _fax
	 ,string _kind
	 ,string _name
	 ,string _owner
	 ,string _postcode
	 ,string _tel
	 ,string _type
	 ,string _username
	 ,string _zipcht
	)
	{
	 this._Id = _Id;
	 this._address = _address;
	 this._city = _city;
	 this._corp = _corp;
	 this._fax = _fax;
	 this._kind = _kind;
	 this._name = _name;
	 this._owner = _owner;
	 this._postcode = _postcode;
	 this._tel = _tel;
	 this._type = _type;
	 this._username = _username;
	 this._zipcht = _zipcht;
	}
	
	public virtual int Id {
	    get { return _Id; }
		set { _Id= value; }
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

	public virtual string Username
	{
	    get { return _username; }
        set { _username = value; }					
	}

	public virtual string Zipcht
	{
	    get { return _zipcht; }
        set { _zipcht = value; }					
	}
	
	public override bool Equals(object obj) 
	{
	  if (this == obj) return true;
      if ((obj == null) || (obj.GetType() != this.GetType())) return false;
	  UserProfiles castObj = (UserProfiles)obj;
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


