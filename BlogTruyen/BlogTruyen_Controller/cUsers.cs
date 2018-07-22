using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogTruyen_Controller.BaseController;
using BlogTruyen_ValueObjects;

namespace BlogTruyen_Controller
{
    public class cUsers:BaseUser<Ousers>
    {
        public override int Checklogin(string username, string password)
        {
            return model.Checklogin(username, password);
        }
    }
}
