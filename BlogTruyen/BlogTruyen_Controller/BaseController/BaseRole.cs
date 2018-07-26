using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogTruyen_Models;

namespace BlogTruyen_Controller.BaseController
{
    public class BaseRole<T>
    {
        protected mRoles model = new mRoles();
        public virtual int Gettotal() { return 0; }
        public virtual List<T> GetAllpaging(int start, int length) { List<T> list = new List<T>(); return list; }
        public virtual T GetbyId(int id) { return default; }
        public virtual int Add(T Role) { return 0; }
        public virtual int Update(T role) { return 0; }
        public virtual int Delete(int id) { return 0; }
    }
}
