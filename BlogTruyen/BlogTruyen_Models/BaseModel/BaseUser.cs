using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogTruyen_Models.Database;

namespace BlogTruyen_Models.BaseModel
{
    public class BaseUser<T>
    {
        public BlogTruyenEntities db = new BlogTruyenEntities();
        public virtual T Checklogin(string username, string password) { return default; }
        public virtual int CheckUsername(string username) { return 0; }
        public virtual int CheckActive(Guid id) { return 0; }
        public virtual List<T> Getallpaging(int start, int length) { List<T> list = new List<T>(); return list; }
        public virtual List<T> Getall() { List<T> list = new List<T>(); return list; }
        public virtual T GetbyId(Guid id) { return default; }
        public virtual int Add(T user) { return 0; }
        public virtual int Update(T user) { return 0; }
        public virtual int Delete(Guid id) { return 0; }
        public virtual int Gettotal() { return 0; }
    }
}
