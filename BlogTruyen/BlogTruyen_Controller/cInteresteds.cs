using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogTruyen_Controller.BaseController;
using BlogTruyen_ValueObjects;

namespace BlogTruyen_Controller
{
    public class cInteresteds:BaseInterested<Ointeresteds>
    {
        public override List<Ointeresteds> GetAllpaging(int start, int length)
        {
            return model.GetAllpaging(start,length);
        }
        public override List<Ointeresteds> Getall()
        {
            return model.Getall();
        }
        public override Ointeresteds GetbyId(Guid id)
        {
            return model.GetbyId(id);
        }
        public override int Gettotal()
        {
            return model.Gettotal();
        }
        public override int Add(Ointeresteds Inter)
        {
            return model.Add(Inter);
        }
        public override int Update(Ointeresteds Inter)
        {
            return model.Update(Inter);
        }
        public override int Delete(Guid id)
        {
            return model.Delete(id);
        }
    }
}
