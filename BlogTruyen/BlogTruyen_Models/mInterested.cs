using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogTruyen_Models.BaseModel;
using BlogTruyen_ValueObjects;

namespace BlogTruyen_Models
{
    public class mInterested:BaseInterested<Ointeresteds>
    {
        public override List<Ointeresteds> GetAllpaging(int start, int lenght)
        {
            List<Ointeresteds> list = new List<Ointeresteds>();
            var data = db.Interested_Getallpaging(start,lenght);
            if(data != null)
            {
                foreach(var item in data)
                {
                    Ointeresteds inter = new Ointeresteds();
                    inter.Idinterested = item.Idinterested;
                    inter.Like = item.Like;
                    inter.Love = item.Love;
                    inter.Hate = item.Hate;
                    inter.IdPost = item.IdPost;
                    inter.IdUser = item.IdUser;

                    list.Add(inter);
                }
                return list;
            }
            return list;
        }
        public override Ointeresteds GetbyId(Guid id)
        {
            Ointeresteds inter = new Ointeresteds();
            var item = db.Interested_GetbyId(id).FirstOrDefault();
            if(item != null)
            {
                inter.Idinterested = item.Idinterested;
                inter.Like = item.Like;
                inter.Love = item.Love;
                inter.Hate = item.Hate;
                inter.IdPost = item.IdPost;
                inter.IdUser = item.IdUser;

                return inter;
            }
            return inter;
        }
        public override int Gettotal()
        {
            int rs = 0;
            rs = int.Parse(db.Interested_CountAll().ToString());
            return rs;
        }
        public override int Add(Ointeresteds Inter)
        {
            db.Interested_Insert(Inter.Idinterested, Inter.Like, Inter.Love, Inter.Hate, Inter.IdPost, Inter.IdUser);
            return 1;
        }
        public override int Update(Ointeresteds Inter)
        {
            db.Interested_Update(Inter.Idinterested, Inter.Like, Inter.Love, Inter.Hate, Inter.IdPost, Inter.IdUser);
            return 1;
        }
        public override int Delete(Guid id)
        {
            db.Interested_Delete(id);
            return 1;
        }
    }
}
