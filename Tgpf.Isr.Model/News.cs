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
public class News 
{	 
	protected int _Id;
	private DateTime _createdate;
	private string _isonline;
	private bool _isshow;
	private string _link;
	private DateTime _showdate;
	private string _summary;
	private string _title;
		
	public News()
	{
	}		
	
	public News(int _Id
	 ,DateTime _createdate
	 ,string _isonline
	 ,bool _isshow
	 ,string _link
	 ,DateTime _showdate
	 ,string _summary
	 ,string _title
	)
	{
	 this._Id = _Id;
	 this._createdate = _createdate;
	 this._isonline = _isonline;
	 this._isshow = _isshow;
	 this._link = _link;
	 this._showdate = _showdate;
	 this._summary = _summary;
	 this._title = _title;
	}
	
	public virtual int Id {
	    get { return _Id; }
		set { _Id= value; }
    }
			
	public virtual DateTime Createdate
	{
	    get { return _createdate; }
        set { _createdate = value; }					
	}

	public virtual string Isonline
	{
	    get { return _isonline; }
        set { _isonline = value; }					
	}

	public virtual bool Isshow
	{
	    get { return _isshow; }
        set { _isshow = value; }					
	}

	public virtual string Link
	{
	    get { return _link; }
        set { _link = value; }					
	}

	public virtual DateTime Showdate
	{
	    get { return _showdate; }
        set { _showdate = value; }					
	}

	public virtual string Summary
	{
	    get { return _summary; }
        set { _summary = value; }					
	}

	public virtual string Title
	{
	    get { return _title; }
        set { _title = value; }					
	}
	
	public override bool Equals(object obj) 
	{
	  if (this == obj) return true;
      if ((obj == null) || (obj.GetType() != this.GetType())) return false;
	  News castObj = (News)obj;
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


