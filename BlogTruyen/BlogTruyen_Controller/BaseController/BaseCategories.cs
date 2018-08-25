using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogTruyen_Models;

namespace BlogTruyen_Controller.BaseController
{
    public class BaseCategories<T>
    {
        protected mCategories model = new mCategories();
        public virtual int Gettotal() { return 0; }
        public virtual List<T> Getallpaging(int start, int length) { List<T> list = new List<T>(); return list; }
        public virtual List<T> Getall() { List<T> list = new List<T>(); return list; }
        public virtual T GetbyId(int id) { return default; }
        public virtual int Add(T category) { return 0; }
        public virtual int Update(T category) { return 0; }
        public virtual int Delete(int id) { return 0; }
    }
}
