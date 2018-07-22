using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogTruyen_Models;

namespace BlogTruyen_Controller.BaseController
{
    public class BaseUser<T>
    {
        public mUsers model = new mUsers();
        public virtual int Checklogin(string username, string password) { return 0; }
        public virtual int CheckUsername(string username) { return 0; }
        public virtual int CheckActive(Guid id) { return 0; }
        public virtual List<T> Getall() { List<T> list = new List<T>(); return list; }
        public virtual T GetbyId(Guid id) { return default; }
        public virtual int Add(T user) { return 0; }
        public virtual int Update(T user) { return 0; }
        public virtual int Delete(T user) { return 0; }
    }
}
