using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogTruyen_Models.BaseModel;
using BlogTruyen_ValueObjects;

namespace BlogTruyen_Models
{
    public class mTypes:BaseType<Otypes>
    {
        public override List<Otypes> GetAllpaging(int start, int length)
        {
            List<Otypes> list = new List<Otypes>();
            var data = db.Type_Getallpaging(start, length);
            if(data != null)
            {
                foreach(var item in data)
                {
                    Otypes type = new Otypes();
                    type.IdType = item.IdType;
                    type.TypeName = item.TypeName;

                    list.Add(type);
                }
                return list;
            }
            return list;
        }
        public override Otypes GetbyId(int id)
        {
            Otypes type = new Otypes();
            var data = db.Types_GetbyId(id).FirstOrDefault();
            if(data != null)
            {
                type.IdType = data.IdType;
                type.TypeName = data.TypeName;
            }
            return type;
        }
        public override int Gettotal()
        {
            int rs = 0;
            rs = int.Parse(db.Type_CountAll().ToString());
            return rs;
        }
        public override int Add(Otypes type)
        {
            db.Types_Insert(type.TypeName);
            return 1;
        }
        public override int Update(Otypes type)
        {
            db.Types_Update(type.IdType, type.TypeName);
            return 1;
        }
        public override int Delete(int id)
        {
            db.Types_Delete(id);
            return 1;
        }
    }
}
