﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogTruyen_Models.Database;
using BlogTruyen_ValueObjects;

namespace BlogTruyen_Models.BaseModel
{
    public class BasePost<T>
    {
        protected BlogTruyenEntities db = new BlogTruyenEntities();
        public virtual int Gettotal() { return 0; }
        public virtual List<T> GetAllpaging(int start, int length) { List<T> list = new List<T>(); return list; }
        public virtual List<T> Getall() { List<T> list = new List<T>(); return list; }
        public virtual T GetbyId(Guid id) { return default; }
        public virtual int Add(T post) { return 0; }
        public virtual int Update(T post) { return 0; }
        public virtual int Delete(Guid id) { return 0; }
    }
}
