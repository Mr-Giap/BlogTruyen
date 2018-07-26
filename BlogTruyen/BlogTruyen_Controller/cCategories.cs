using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogTruyen_Controller.BaseController;
using BlogTruyen_ValueObjects;

namespace BlogTruyen_Controller
{
    public class cCategories:BaseCategories<Ocategories>
    {
        public override List<Ocategories> Getall(int start, int length)
        {
            return model.Getall(start, length);
        }
        public override Ocategories GetbyId(int id)
        {
            return model.GetbyId(id);
        }
        public override int Gettotal()
        {
            return model.Gettotal();
        }
        public override int Add(Ocategories category)
        {
            return model.Add(category);
        }
        public override int Update(Ocategories category)
        {
            return model.Update(category);
        }
        public override int Delete(int id)
        {
            return model.Delete(id);
        }
    }
}
