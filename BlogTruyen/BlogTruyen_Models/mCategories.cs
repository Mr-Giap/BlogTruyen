using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogTruyen_ValueObjects;
using BlogTruyen_Models.BaseModel;

namespace BlogTruyen_Models
{
    public class mCategories:BaseCategories<Ocategories>
    {
        public override List<Ocategories> Getall(int start, int length)
        {
            List<Ocategories> list = new List<Ocategories>();
            var data = db.Categories_Getallpaging(start, length);
            if(data != null)
            {
                foreach(var item in data)
                {
                    Ocategories category = new Ocategories();
                    category.IdCategory = item.IdCategory;
                    category.CategoryName = item.CategoryName;

                    list.Add(category);
                }
                return list;
            }
            return list;
        }
        public override Ocategories GetbyId(int id)
        {
            Ocategories category = new Ocategories();
            var item = db.Categories_GetbyId(id).FirstOrDefault();
            if(item != null)
            {
                category.IdCategory = item.IdCategory;
                category.CategoryName = item.CategoryName;
                return category;
            }
            return category;
        }
        public override int Gettotal()
        {
            int rs = 0;
            rs = int.Parse(db.Categories_CountAll().ToString());
            return rs;
        }
        public override int Add(Ocategories category)
        {
            db.Categories_Insert(category.CategoryName);
            return 1;
        }
        public override int Update(Ocategories category)
        {
            db.Categories_Update(category.IdCategory, category.CategoryName);
            return 1;
        }
        public override int Delete(int id)
        {
            db.Categories_Delete(id);
            return 1;
        }
    }
}
