using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogTruyen_ValueObjects;
using BlogTruyen_Controller.BaseController;

namespace BlogTruyen_Controller
{
    public class cTypes:BaseType<Otypes>
    {
        public override List<Otypes> GetAllpaging(int start, int length)
        {
            return model.GetAllpaging(start,length);
        }
        public override int Gettotal()
        {
            return model.Gettotal();
        }
        public override Otypes GetbyId(int id)
        {
            return model.GetbyId(id);
        }
        public override int Add(Otypes type)
        {
            return model.Add(type);
        }
        public override int Update(Otypes type)
        {
            return model.Update(type);
        }
        public override int Delete(int id)
        {
            return model.Delete(id);
        }
    }
}
