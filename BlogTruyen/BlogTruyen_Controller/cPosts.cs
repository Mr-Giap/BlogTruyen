using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogTruyen_Controller.BaseController;
using BlogTruyen_ValueObjects;

namespace BlogTruyen_Controller
{
    public class cPosts:BasePost<Oposts>
    {
        public override List<Oposts> GetAllpaging(int start, int length)
        {
            return model.GetAllpaging(start,length);
        }
        public override List<Oposts> Getall()
        {
            return model.Getall();
        }
        public override Oposts GetbyId(Guid id)
        {
            return model.GetbyId(id);
        }
        public override int Gettotal()
        {
            return model.Gettotal();
        }
        public override int Add(Oposts post)
        {
            return model.Add(post);
        }
        public override int Update(Oposts post)
        {
            return model.Update(post);
        }
        public override int Delete(Guid id)
        {
            return model.Delete(id);
        }
    }
}
