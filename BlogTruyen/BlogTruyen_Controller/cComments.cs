using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogTruyen_Controller.BaseController;
using BlogTruyen_ValueObjects;

namespace BlogTruyen_Controller
{
    public class cComments:BaseComment<Ocomments>
    {
        public override List<Ocomments> GetallPaging(int start, int length)
        {
            return model.GetallPaging(start, length);
        }
        public override Ocomments GetbyId(Guid id)
        {
            return model.GetbyId(id);
        }
        public override int Gettotal()
        {
            return model.Gettotal();
        }
        public override int Add(Ocomments comment)
        {
            return model.Add(comment);
        }
        public override int Update(Ocomments comment)
        {
            return model.Update(comment);
        }
        public override int Delete(Guid id)
        {
            return model.Delete(id);
        }
    }
}
