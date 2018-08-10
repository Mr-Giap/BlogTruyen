using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogTruyen_Models.BaseModel;
using BlogTruyen_ValueObjects;

namespace BlogTruyen_Models
{
    public class mPosts:BasePost<Oposts>
    {
        public override List<Oposts> GetAllpaging(int start, int length)
        {
            List<Oposts> list = new List<Oposts>();
            var data = db.Post_Getallpaging(start, length);
            if(data != null)
            {
                foreach(var item in data)
                {
                    Oposts post = new Oposts();
                    post.IdPost = item.IdPost;
                    post.PostName = item.PostName;
                    post.NameAscii = item.NameAscii;
                    post.Introduction = item.Introduction;
                    post.Avatar = item.Avatar;
                    post.Length = item.Length;
                    post.DateCreate = item.DateCreate;
                    post.Note = item.Note;
                    post.IdUser = item.IdUser;
                    post.Source = item.Source;
                    post.Author = item.Author;
                    post.IsDelete = item.IsDelete;
                    post.IsFull = item.IsFull;
                    post.IdCategory = item.IdCategory;
                    post.Type = item.Type;
                    post.Child = item.Child;

                    list.Add(post);
                }
                return list;
            }
            return list;
        }
        public override Oposts GetbyId(Guid id)
        {
            Oposts post = new Oposts();
            var item = db.Post_GetbyId(id).FirstOrDefault();
            if(item != null)
            {
                post.IdPost = item.IdPost;
                post.PostName = item.PostName;
                post.NameAscii = item.NameAscii;
                post.Introduction = item.Introduction;
                post.Avatar = item.Avatar;
                post.Length = item.Length;
                post.DateCreate = item.DateCreate;
                post.Note = item.Note;
                post.IdUser = item.IdUser;
                post.Source = item.Source;
                post.Author = item.Author;
                post.IsDelete = item.IsDelete;
                post.IsFull = item.IsFull;
                post.IdCategory = item.IdCategory;
                post.Type = item.Type;
                post.Child = item.Child;

                return post;
            }
            return post;
        }
        public override int Gettotal()
        {
            int rs = 0;
            rs = int.Parse(db.Post_CountAll().FirstOrDefault().ToString());
            return rs;
        }
        public override int Add(Oposts post)
        {
            db.Post_Insert(post.IdPost,post.PostName,post.NameAscii,post.Introduction,post.Avatar,post.Length,post.DateCreate,post.Note,post.IdUser,post.Source,
                post.Author,post.IsDelete,post.IsFull,post.IdCategory,post.Type,post.Child);
            return 1;
        }
        public override int Update(Oposts post)
        {
            db.Post_Update(post.IdPost, post.PostName, post.NameAscii, post.Introduction, post.Avatar, post.Length, post.Note, post.IdUser, post.Source,
                post.Author, post.IsDelete, post.IsFull, post.IdCategory, post.Type, post.Child);
            return 1;
        }
        public override int Delete(Guid id)
        {
            db.Post_Delete(id);
            return 1;

        }
    }
}
