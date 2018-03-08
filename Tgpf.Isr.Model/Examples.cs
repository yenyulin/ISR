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
public class Examples 
{	 
	protected string _Year;
	private string _amt1;
	private string _amt2;
	private int _caseid;
	private string _name1a;
	private string _name1b;
	private string _name2a;
	private string _name2b;
	private string _project1;
	private string _project2;
	private string _title1;
	private string _title2;
		
	public Examples()
	{
	}		
	
	public Examples(string _Year
	 ,string _amt1
	 ,string _amt2
	 ,int _caseid
	 ,string _name1a
	 ,string _name1b
	 ,string _name2a
	 ,string _name2b
	 ,string _project1
	 ,string _project2
	 ,string _title1
	 ,string _title2
	)
	{
	 this._Year = _Year;
	 this._amt1 = _amt1;
	 this._amt2 = _amt2;
	 this._caseid = _caseid;
	 this._name1a = _name1a;
	 this._name1b = _name1b;
	 this._name2a = _name2a;
	 this._name2b = _name2b;
	 this._project1 = _project1;
	 this._project2 = _project2;
	 this._title1 = _title1;
	 this._title2 = _title2;
	}
	
	public virtual string Year {
	    get { return _Year; }
		set { _Year= value; }
    }
			
	public virtual string Amt1
	{
	    get { return _amt1; }
        set { _amt1 = value; }					
	}

	public virtual string Amt2
	{
	    get { return _amt2; }
        set { _amt2 = value; }					
	}

	public virtual int Caseid
	{
	    get { return _caseid; }
        set { _caseid = value; }					
	}

	public virtual string Name1a
	{
	    get { return _name1a; }
        set { _name1a = value; }					
	}

	public virtual string Name1b
	{
	    get { return _name1b; }
        set { _name1b = value; }					
	}

	public virtual string Name2a
	{
	    get { return _name2a; }
        set { _name2a = value; }					
	}

	public virtual string Name2b
	{
	    get { return _name2b; }
        set { _name2b = value; }					
	}

	public virtual string Project1
	{
	    get { return _project1; }
        set { _project1 = value; }					
	}

	public virtual string Project2
	{
	    get { return _project2; }
        set { _project2 = value; }					
	}

	public virtual string Title1
	{
	    get { return _title1; }
        set { _title1 = value; }					
	}

	public virtual string Title2
	{
	    get { return _title2; }
        set { _title2 = value; }					
	}
	
	public override bool Equals(object obj) 
	{
	  if (this == obj) return true;
      if ((obj == null) || (obj.GetType() != this.GetType())) return false;
	  Examples castObj = (Examples)obj;
      return (castObj != null) &&
        (this._Year == castObj.Year);
	   
    }
	
	public override int GetHashCode()
	{
	  int hash = 17;
      hash = 37 * hash * _Year.GetHashCode();
      return hash;
    }
		
 }
}	 


