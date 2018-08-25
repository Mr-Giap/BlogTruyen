using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogTruyen_Controller.BaseController;
using BlogTruyen_ValueObjects;

namespace BlogTruyen_Controller
{
    public class cChapters:BaseChapter<Ochapters>
    {
        public override List<Ochapters> GetallPaging(int start, int length)
        {
            return model.GetallPaging(start, length);
        }
        public override List<Ochapters> Getallbypost(Guid id)
        {
            return model.GetallbyPost(id);
        }
        public override List<Ochapters> GetallPagingbypost(Guid id, int start, int length)
        {
            return model.GetallPagingbypost(id, start, length);
        }
        public override List<Ochapters> Getall()
        {
            return model.Getall();
        }
        public override Ochapters GetbyId(Guid id)
        {
            return model.GetbyId(id);
        }
        public override int Gettotal()
        {
            return model.Gettotal();
        }
        public override int Add(Ochapters Chap)
        {
            return model.Add(Chap);
        }
        public override int Update(Ochapters chap)
        {
            return model.Update(chap);
        }
        public override int Delete(Guid id)
        {
            return model.Delete(id);
        }
    }
}
