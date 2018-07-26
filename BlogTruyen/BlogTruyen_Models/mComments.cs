using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogTruyen_Models.BaseModel;
using BlogTruyen_ValueObjects;

namespace BlogTruyen_Models
{
    public class mComments:BaseComment<Ocomments>
    {
        public override List<Ocomments> GetallPaging(int start, int length)
        {
            List<Ocomments> list = new List<Ocomments>();
            var data = db.Comment_Getallpaging(start, length);
            if(data != null)
            {
                foreach(var item in data)
                {
                    Ocomments comment = new Ocomments();
                    comment.IdComment = item.IdComment;
                    comment.IdPost = item.IdPost;
                    comment.IdUser = item.IdUser;
                    comment.ReplyToUser = item.ReplyToUser;
                    comment.Content = item.Content;
                    comment.DateCreate = item.DateCreate;

                    list.Add(comment);
                }
                return list;
            }
            return list;
        }
        public override Ocomments GetbyId(Guid id)
        {
            Ocomments comment = new Ocomments();
            var item = db.Comment_GetbyId(id).FirstOrDefault();
            if(item != null)
            {
                comment.IdComment = item.IdComment;
                comment.IdPost = item.IdPost;
                comment.IdUser = item.IdUser;
                comment.ReplyToUser = item.ReplyToUser;
                comment.Content = item.Content;
                comment.DateCreate = item.DateCreate;

                return comment;

            }
            return comment;
        }
        public override int Gettotal()
        {
            int rs = 0;
            rs = int.Parse(db.Comment_CountAll().ToString());
            return rs;
        }
        public override int Add(Ocomments comment)
        {
            db.Comment_Insert(comment.IdComment, comment.IdPost, comment.IdUser, comment.ReplyToUser, comment.Content, comment.DateCreate);
            return 1;
        }
        public override int Update(Ocomments comment)
        {
            db.Comment_Update(comment.IdComment, comment.IdPost, comment.IdUser, comment.ReplyToUser, comment.Content);
            return 1;
        }
        public override int Delete(Guid id)
        {
            db.Comment_Delete(id);
            return 1;
        }
    }
}
