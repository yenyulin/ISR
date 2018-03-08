/*
 * Copyright 2007-2009 Orgman Software
 * http://www.orgman.idv.tw
 * 
 */

using System.Collections;
using Tgpf.Isr.Model;

namespace Tgpf.Isr.Dao
{
    public interface IZipDao
    {

        Zip getZip(string obj);
        IList getZipList(string obj);
        void Save(Zip obj);
        void Delete(Zip obj);
    }
}

