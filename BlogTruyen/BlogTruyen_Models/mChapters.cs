using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogTruyen_Models.BaseModel;
using BlogTruyen_ValueObjects;

namespace BlogTruyen_Models
{
    public class mChapters:BaseChapter<Ochapters>
    {
        public override List<Ochapters> GetallPaging(int start, int length)
        {
            List<Ochapters> list = new List<Ochapters>();
            var data = db.Chapter_Getallpaging(start, length);
            if(data != null)
            {
                foreach(var item in data)
                {
                    Ochapters chap = new Ochapters();
                    chap.IdChapter = item.IdChapter;
                    chap.IdPost = item.IdPost;
                    chap.NameChap = item.NameChap;
                    chap.Title = item.Title;
                    chap.ChapContent = item.ChapContent;
                    chap.Note = item.Note;
                    chap.DateCreate = item.DateCreate;
                    chap.IsDelete = item.IsDelete;

                    list.Add(chap);
                }
                return list;
            }
            return list;
        }
        public override List<Ochapters> GetallPagingbypost(Guid id, int start, int length)
        {
            List<Ochapters> list = new List<Ochapters>();
            var data = db.Chapter_GetallpagingbyPost(id,start, length);
            if (data != null)
            {
                foreach (var item in data)
                {
                    Ochapters chap = new Ochapters();
                    chap.IdChapter = item.IdChapter;
                    chap.IdPost = item.IdPost;
                    chap.NameChap = item.NameChap;
                    chap.Title = item.Title;
                    chap.ChapContent = item.ChapContent;
                    chap.Note = item.Note;
                    chap.DateCreate = item.DateCreate;
                    chap.IsDelete = item.IsDelete;

                    list.Add(chap);
                }
                return list;
            }
            return list;
        }
        public override List<Ochapters> GetallbyPost(Guid id)
        {
            List<Ochapters> list = new List<Ochapters>();
            var data = db.Chapter_GetallbyPost(id);
            if (data != null)
            {
                foreach (var item in data)
                {
                    Ochapters chap = new Ochapters();
                    chap.IdChapter = item.IdChapter;
                    chap.IdPost = item.IdPost;
                    chap.NameChap = item.NameChap;
                    chap.Title = item.Title;
                    chap.ChapContent = item.ChapContent;
                    chap.Note = item.Note;
                    chap.DateCreate = item.DateCreate;
                    chap.IsDelete = item.IsDelete;

                    list.Add(chap);
                }
                return list;
            }
            return list;
        }
        public override List<Ochapters> Getall()
        {
            List<Ochapters> list = new List<Ochapters>();
            var data = db.Chapter_Getall();
            if (data != null)
            {
                foreach (var item in data)
                {
                    Ochapters chap = new Ochapters();
                    chap.IdChapter = item.IdChapter;
                    chap.IdPost = item.IdPost;
                    chap.NameChap = item.NameChap;
                    chap.Title = item.Title;
                    chap.ChapContent = item.ChapContent;
                    chap.Note = item.Note;
                    chap.DateCreate = item.DateCreate;
                    chap.IsDelete = item.IsDelete;

                    list.Add(chap);
                }
                return list;
            }
            return list;
        }
        public override Ochapters GetbyId(Guid id)
        {
            Ochapters chap = new Ochapters();
            var item = db.Chapter_GetbyId(id).FirstOrDefault();
            if(item != null)
            {
                chap.IdChapter = item.IdChapter;
                chap.IdPost = item.IdPost;
                chap.NameChap = item.NameChap;
                chap.Title = item.Title;
                chap.ChapContent = item.ChapContent;
                chap.Note = item.Note;
                chap.DateCreate = item.DateCreate;
                chap.IsDelete = item.IsDelete;

                return chap;
            }
            return chap;
        }
        public override int Gettotal()
        {
            int rs = 0;
            rs = int.Parse(db.Chapter_CountAll().FirstOrDefault().ToString());
            return rs;
        }
        public override int Add(Ochapters Chap)
        {
            db.Chapter_Insert(Chap.IdChapter, Chap.IdPost,Chap.NameChap, Chap.Title, Chap.ChapContent, Chap.Note, Chap.DateCreate, Chap.IsDelete);
            return 1;
        }
        public override int Update(Ochapters chap)
        {
            db.Chapter_Update(chap.IdChapter, chap.IdPost,chap.NameChap, chap.Title, chap.ChapContent, chap.Note, chap.IsDelete);
            return 1;
        }
        public override int Delete(Guid id)
        {
            db.Chapter_Delete(id);
            return 1;
        }
    }
}
