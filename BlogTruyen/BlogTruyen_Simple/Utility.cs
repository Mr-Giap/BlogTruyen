using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Configuration;
using System.Xml;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BlogTruyen_Simple.Utility 
{
    /// <summary>
    /// Class chứa những phương thức dùng chung cho các project khác không bao gồm hàm thao tác tới Database.
    /// Class được khai báo static để có thể gọi luôn mà không cần khởi tạo.
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// Mảng khai báo bảng chữ cái tiếng Việt
        /// Author      Date        Action
        /// Unknow      Unknow      Create
        /// TuNT13      1/12/2014   Add comment
        /// </summary>
        private static readonly string[] VietnameseSigns = new string[]

        {

        "aAeEoOuUiIdDyY",

        "áàạảãâấầậẩẫăắằặẳẵ",

        "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",

        "éèẹẻẽêếềệểễ",

        "ÉÈẸẺẼÊẾỀỆỂỄ",

        "óòọỏõôốồộổỗơớờợởỡ",

        "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",

        "úùụủũưứừựửữ",

        "ÚÙỤỦŨƯỨỪỰỬỮ",

        "íìịỉĩ",

        "ÍÌỊỈĨ",

        "đ",

        "Đ",

        "ýỳỵỷỹ",

        "ÝỲỴỶỸ"

        };

        /// <summary>
        /// Hàm chuyển chuỗi có dấu --> chuỗi không dấu
        /// Author      Date        Action
        /// Unknow      Unknow      Create
        /// TuNT13      1/12/2014   Add comment
        /// </summary>
        /// <param name="str">Chuỗi truyền vào</param>
        /// <returns>Chuỗi không dấu</returns>
        public static string RemoveSign4VietnameseString(this string str)
        {

            //Tiến hành thay thế , lọc bỏ dấu cho chuỗi

            for (int i = 1; i < VietnameseSigns.Length; i++)
            {

                for (int j = 0; j < VietnameseSigns[i].Length; j++)

                    str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);

            }

            return str;

        }

        /// <summary>
        /// get original picture by picture url
        /// Author      Date        Action
        /// HungDC3     21/12/2013   Add function
        /// TuNT13      1/12/2014   Edit comment string
        /// </summary>
        /// <param name="pictureName">URL ảnh gốc truyền vào</param>
        /// <returns>Full URL ảnh gốc</returns>
        //public static string GetUrlOriginalPicture(string pictureName)
        //{
        //    return c ConfigurationManager.AppSettings["URLOriginalImage"] + pictureName;
        //}
        /// <summary>
        /// Hàm lấy thông tin đường dẫn tuyệt đối của ảnh đại diện
        /// Author      Date        Action
        /// BienLV2     2/12/2013   Add function
        /// TuNT13      1/12/2014   Edit comment
        /// </summary>
        /// <param name="pictureName">name of picture</param>
        /// <returns>Full url ảnh đại diện</returns>
        //public static string GetUrlOriginalPictureOldProduct(string pictureName)
        //{
        //    return ConfigurationManager.AppSettings["URLOriginalImageOldProduct"] + pictureName;
        //}
        /// <summary>
        /// get picture mediums(size 640) by url
        /// Author      Date        Action
        /// HungDC3     21/12/2013   Add function
        /// TuNT13      1/12/2014   Edit comment string
        /// </summary>
        /// <param name="pictureName">URL ảnh được cắt hiển thị slider</param>
        /// <returns>Full URL ảnh được cắt hiển thị slider</returns>
        //public static string GetUrlPictureMediums(string pictureName)
        //{
        //    return ConfigurationManager.AppSettings["URLImagePromotion"] + pictureName;

        //}

        /// <summary>
        /// Hàm lấy thông tin đường dẫn tuyệt đối của ảnh đại diện
        /// Author      Date        Action
        /// BienLV2     2/12/2013   Add function
        /// TuNT13      1/12/2014   Edit comment
        /// </summary>
        /// <param name="pictureName">name of picture</param>
        /// <returns>Full url ảnh đại diện</returns>
        //public static string GetUrlPicture(string pictureName)
        //{
        //    return ConfigurationManager.AppSettings["URLImage"] + pictureName;
        //}
        /// <summary>
        /// Hàm lấy thông tin đường dẫn tuyệt đối của ảnh đại diện
        /// Author      Date        Action
        /// BienLV2     2/12/2013   Add function
        /// TuNT13      1/12/2014   Edit comment
        /// </summary>
        /// <param name="pictureName">name of picture</param>
        /// <returns>Full url ảnh đại diện</returns>
        //public static string GetUrlPictureOldProduct(string pictureName)
        //{
        //    return ConfigurationManager.AppSettings["URLImageOldProduct"] + pictureName;
        //}

        /// <summary>
        /// Hàm format giá dạng 1.000.000
        /// Author      Date        Action
        /// Unknow      Unknow      Add function
        /// TuNT13      1/12/2014   Edit comment
        /// </summary>
        /// <param name="price">Giá truyền vào kiểu decimal</param>
        /// <returns>Chuỗi giá sau khi được format</returns>
        public static string FormatPrice(decimal? price)
        {
            if (price.HasValue && price != 0)
            {
                string result = price.Value.ToString("#,#");
                if (result.Contains(","))
                    result = result.Replace(',', '.');
                return result;
            }
            return "0";
        }

        /// <summary>
        /// Hàm format giá dạng 1.000.000
        /// Author      Date        Action
        /// Unknow      Unknow      Add function
        /// TuNT13      1/12/2014   Edit comment
        /// </summary>
        /// <param name="price">Giá truyền vào kiểu double</param>
        /// <returns>Chuỗi giá sau khi được format</returns>
        public static string FormatPrice(double? price)
        {
            if (price.HasValue && price != 0)
            {
                string result = price.Value.ToString("#,#");
                if (result.Contains(","))
                    result = result.Replace(',', '.');
                return result;
            }
            return "0";
        }

        /// <summary>
        /// Hàm cắt chuỗi hiển thị theo max length
        /// Author      Date        Action
        /// Unknow      Unknow      Add function
        /// TuNT13      1/12/2014   Edit comment
        /// </summary>
        /// <param name="input">Chuỗi cần cắt</param>
        /// <param name="maxLength">Ký tự tối đa của chuỗi</param>
        /// <returns>Chuỗi sau khi cắt tới ký tự tối đa + ...</returns>
        public static string TrimLength(string input, int maxLength)
        {
            if (input.Length > maxLength)
            {
                maxLength -= "...".Length;
                maxLength = input.Length < maxLength ? input.Length : maxLength;
                bool isLastSpace = input[maxLength] == ' ';
                string part = input.Substring(0, maxLength);
                if (isLastSpace)
                    return part + "...";
                int lastSpaceIndexBeforeMax = part.LastIndexOf(' ');
                if (lastSpaceIndexBeforeMax == -1)
                    return part + "...";
                else
                    return input.Substring(0, lastSpaceIndexBeforeMax) + "...";
            }
            else
                return input;
        }

        /// <summary>
        /// Hàm kiểm tra comment có chậm hay không (KPI trả lời trong 15")
        /// Author      Date        Action
        /// TuamTM23    Unknow      Add function
        /// TuNT13      1/12/2014   Edit comment
        /// </summary>
        /// <param name="NgayGuiComment">Thời gian khách hàng comment</param>
        /// <param name="NgayTraLoi">Thời gian quản trị viên trả lời</param>
        /// <returns>True: không đạt KPI / False: Đạt KPI</returns>
        public static bool CheckChamTraLoiComment(DateTime NgayGuiComment, DateTime? NgayTraLoi)
        {
            //if(NgayTraLoi.HasValue)
            //{
            //    var minute = (NgayTraLoi.Value - NgayGuiComment).Minutes;
            //    var day = (NgayTraLoi.Value - NgayGuiComment).Days;
            //    var hour = (NgayTraLoi.Value - NgayGuiComment).Hours;


            //    if (minute > 15 || hour > 0 || day > 0) //minute > 15 --> TuNT13: Yêu cầu chuyển số 15 vào web.config/appSetting
            //        return true;
            //    else
            //        return false;
            //}
            //else
            //{
            //    var minute = (DateTime.Now - NgayGuiComment).Minutes;
            //    var day = (DateTime.Now - NgayGuiComment).Days;
            //    var hour = (DateTime.Now - NgayGuiComment).Hours;
            //    if (minute > 15 || hour > 0 || day > 0)
            //        return true;
            //    else
            //        return false;
            //}

            //TuNT13    Hàm này có thể viết thành như sau để tránh trùng lặp block code
            var dateTimeCheck = DateTime.Now;
            if (NgayTraLoi.HasValue)
                dateTimeCheck = NgayTraLoi.Value;
            var minute = (dateTimeCheck - NgayGuiComment).Minutes;
            var day = (dateTimeCheck - NgayGuiComment).Days;
            var hour = (dateTimeCheck - NgayGuiComment).Hours;

            if (minute > 15 || hour > 0 || day > 0) //minute > 15 --> TuNT13: Yêu cầu chuyển số 15 vào web.config/appSetting
                return true;
            else
                return false;
        }

        /// <summary>
        /// Đếm thời gian ?? thời gian trước thời điểm hiện tại
        /// Author      Date        Action
        /// BienLV2     12/12/2013  Add function
        /// TuNT13      1/12/2014   Edit comment
        /// </summary>
        /// <param name="date">Thời gian cần đếm</param>
        /// <returns>Chuỗi thời gian sau khi đếm</returns>
        public static string GetBackDate(DateTime date)
        {
            //TuNT13: Đề nghị đặt tên biến đủ ngữ nghĩa, không chung chung
            var result = string.Empty;

            var day = (DateTime.Now - date).Days;
            var hour = (DateTime.Now - date).Hours;
            var minute = (DateTime.Now - date).Minutes;
            var second = (DateTime.Now - date).Seconds;

            result = second + " giây trước";

            if (minute > 0)
            {
                result = minute + " phút trước";
            }

            if (hour > 0)
            {
                result = hour + " giờ trước";
            }

            if (day > 0)
            {
                result = day + " ngày trước";
            }

            if (day > 30)
            {
                result = "vào ngày " + date.ToString("dd/MM/yyyy");
            }

            return result;
        }

        /// <summary>
        /// Hàm lấy ra class hiển thị nhãn product
        /// Author      Date        Action
        /// BienLV2     Unknow      Add function
        /// TuNT13      1/12/2014   Edit comment
        /// </summary>
        /// <param name="labelId">ID của nhãn</param>
        /// <returns>Class theo ID tương ứng</returns>
        public static string GetClassHTMLProduct(int labelId)
        {
            var classResult = string.Empty;
            switch (labelId)
            {
                case 1:
                    classResult = "gift";
                    break;
                case 2:
                    classResult = "preorder";
                    break;
                case 3:
                    classResult = "hot";
                    break;
                default:
                    break;
            }
            return classResult;
        }

        /// <summary>
        /// Hàm lấy địa chỉ IP public của khách hàng
        /// Author      Date        Action
        /// HieuNV16    Unknow      Add function
        /// TuNT13      1/12/2014   Edit comment
        /// </summary>
        /// <returns>Chuỗi địa chỉ IP khách hàng</returns>
        public static string GetPublicIP()
        {
            try
            {
                var direction = string.Empty;
                var request = WebRequest.Create("http://checkip.dyndns.org/");
                using (var response = request.GetResponse())
                using (var stream = new StreamReader(response.GetResponseStream()))
                {
                    direction = stream.ReadToEnd();
                }

                //Search for the ip in the html
                var first = direction.IndexOf("Address: ") + 9;
                var last = direction.LastIndexOf("</body>");
                direction = direction.Substring(first, last - first);

                return direction;
            }
            catch (Exception)
            {
                return "";
            }

        }

        /// <summary>
        /// Hàm lấy ra địa chỉ truy cập từ IP của khách hàng
        /// Author      Date        Action
        /// HieuNV16    Unknow      Add function
        /// TuNT13      1/12/2014   Edit comment
        /// </summary>
        /// <param name="Ip">IP Public của khách hàng</param>
        /// <returns>Địa chỉ khách</returns>
        //public static string GetRegion(string Ip)
        //{
        //    try
        //    {
        //        HtmlWeb web = new HtmlWeb();
        //        string urlLoad = "http://whatismyipaddress.com/ip/" + Ip;
        //        HtmlDocument docParent = web.Load(urlLoad);
        //        HtmlNode region = docParent.DocumentNode.SelectSingleNode(ConfigCache.HTMLRegion);
        //        return region.InnerText;
        //    }
        //    catch (Exception)
        //    {
        //        return "Ha Noi";
        //    }

        //}

        /// <summary>
        /// Get app setting form webconfig
        /// Author      Date        Action
        /// BienLV2     26/12/2013  Add function
        /// TuNT13      1/12/2014   Edit comment
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        //public static string GetAppSettings(string name)
        //{
        //    return ConfigurationManager.AppSettings[name];
        //}

        /// <summary>
        /// Hàm gửi email thông báo tạo tài khoản cho khách hàng
        /// --> TuNT13: Đề nghị chuyển gửi qua email templates!
        /// Author      Date        Action
        /// NghiaTC2    26/12/2013  Add function
        /// TuNT13      1/12/2014   Edit comment
        /// </summary>
        /// <param name="emailToAddress">Địa chỉ nhận email</param>
        /// <param name="userName">Tên đăng ký tài khoản trên hệ thống FPTShop</param>
        /// <param name="providerName">Dịch vụ FPTShop</param>
        /// <param name="password">Pass mặc định của accout</param>
        //public static void SendEmail(string emailToAddress, string userName, string providerName, string password)
        //{
        //    try
        //    {
        //        var emailSubject = "Tài khoản và mật khẩu từ FPTShop";

        //        var emailBody = "Xin chào bạn " + userName + " ,\n Bạn vừa đăng nhập vào FptShop bằng dịch vụ " + providerName + ",\n Chúng tôi đã tạo cho bạn một tài khoản mặc " +
        //                                 "định với username:" + emailToAddress + ",password:" + password + ".\n" +
        //                                 "Bạn có thể đăng nhập vào tài khoản được cấp để thay đổi thông tin cá nhân.\n Xin chân thành cảm ơn.";

        //        new FPTShopVer2.ExecuteStore.ExecStore().CallStoreSendMailOut(1, emailToAddress, string.Empty, string.Empty, emailSubject, emailBody, "HIGH");
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //}

        /// <summary>
        /// Hàm gửi email thông báo reset mật khẩu tài khoản cho khách hàng
        /// --> TuNT13: Đề nghị chuyển gửi qua email templates!
        /// Author      Date        Action
        /// NghiaTC2    Unknow      Add function
        /// TuNT13      1/12/2014   Edit comment
        /// </summary>
        /// <param name="email">Địa chỉ nhận email</param>
        /// <param name="userName">Tên tài khoản</param>
        /// <param name="pass">Mật khẩu reset</param>
        //public static void SendEmail(string email, string userName, string pass)
        //{
        //    try
        //    {
        //        var emailSubject = "Tài khoản và mật khẩu từ FptShop";

        //        var emailBody = "Xin chào bạn " + userName + ".\nEmail của bạn dường như chưa tồn tại trong hệ thống tài khoản của chúng tôi." +
        //                        "Để thuận lợi cho việc đăng nhập chúng tôi đã tạo cho bạn một tài khoản mặc định với email của bạn.\n" +
        //                        "Username:" + email + ",Password:" + pass + ".\n" +
        //                        "Bạn có thể đăng nhập vào tài khoản được cấp để thay đổi thông tin cá nhân.\nXin chân thành cảm ơn.";

        //        new FPTShopVer2.ExecuteStore.ExecStore().CallStoreSendMailOut(1, email, string.Empty, string.Empty, emailSubject, emailBody, "HIGH");
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }

        //}

        /// <summary>
        /// Hàm tạo chuỗi ngẫu nhiên
        /// Author      Date        Action
        /// Unknow      Unknow      Add function
        /// TuNT13      1/12/2014   Edit comment
        /// </summary>
        /// <returns>Chuỗi ngẫu nhiên</returns>
        public static string CreateRandomKey()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[15];
            var random = new Random();

            for (var i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            // Has 18 character.
            var tickOfTime = DateTime.Now.Ticks.ToString();

            // Has 2 character.
            var date = string.Format("{0:ss}", DateTime.Now);

            date = date.Replace(":", String.Empty);

            // Has 35 character.
            var key = finalString + date + tickOfTime;
            return key;
        }

        /// <summary>
        /// Hàm cắt ký tự đặc biệt trong số điện thoại
        /// Author      Date        Action
        /// NghiaTC2    Unknow      Add function
        /// TuNT13      1/12/2014   Edit comment
        /// </summary>
        /// <param name="numberPhone">Số điện thoại</param>
        /// <returns>Số điện thoại sau khi remove ký tự đặc biệt</returns>
        public static string TrimSpecialCharacterPhone(string numberPhone)
        {
            var returnStringNumber = numberPhone.Select((t, i) => numberPhone.ElementAt(i)).Where(c => c != '-').Aggregate("", (current, c) => current + c);
            return returnStringNumber;
        }

        /// <summary>
        /// Overload function CreateRandomKey.
        /// Create Pass.
        /// Author      Date        Action
        /// NghiaTC2    Unknow      Add function
        /// TuNT13      1/12/2014   Edit comment
        /// </summary>
        /// <param name="email">Email truyền vào</param>
        /// <returns>Pass sinh ra theo email</returns>
        public static string CreateRandomKey(string email)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[3];
            var emailChars = new char[3];
            var random = new Random();

            for (var i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            email = email.Replace("@", string.Empty);
            email = email.Replace(".", string.Empty);

            for (var e = 0; e < emailChars.Length; e++)
            {
                emailChars[e] = email[random.Next(email.Length)];
            }

            var emailArrayNews = new String(emailChars);

            var pass = emailArrayNews + finalString + string.Format("{0:mm:ss}", DateTime.Now);

            pass = pass.Replace(":", string.Empty);

            return pass;
        }

        /// <summary>
        /// Round down price.
        /// Author      Date        Action
        /// NghiaTC2    Unknow      Add function
        /// TuNT13      1/12/2014   Edit comment
        /// </summary>
        /// <param name="priceMarket">Giá thị trường</param>
        /// <param name="priceOnline">Giá bán FPTShop</param>
        /// <returns>Phần trăm giảm giá</returns>
        public static int RoundPrice(int priceMarket, int priceOnline)
        {
            var roundDownPrice = Convert.ToInt32(((priceOnline - priceMarket) / priceMarket) * 100);

            if (roundDownPrice == 0)
            {
                roundDownPrice = -1;
            }

            return roundDownPrice;

        }

        /// <summary>
        /// Hàm tính bước nhảy giá
        /// Áp dụng cho landing cung mua cung vui
        /// Author      Date        Action
        /// Unknow      Unknow      Add function
        /// TuNT13      1/12/2014   Edit comment
        /// </summary>
        /// <param name="stepprice">Bước giá</param>
        /// <param name="sort">Sắp xếp</param>
        /// <returns>Số tiền mỗi bước nhảy giá</returns>
        //public static Decimal GetStepPrice(string stepprice, int sort)
        //{

        //    string[] s;
        //    s = stepprice.Replace(";#", "-").Split('-');
        //    try
        //    {
        //        return ConvertUtil.ToDecimal(s[sort - 1].ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        return 0;
        //    }
        //}

        /// <summary>
        /// Nhóm hàm sinh mã SHA256
        /// Author      Date        Action
        /// Unknow      Unknow      Add function
        /// TuNT13      1/12/2014   Edit comment
        /// </summary>
        /// <param name="value">Chuỗi truyền vào</param>
        /// <returns>Chuỗi mã hoá</returns>
        #region Hàm sinh mã Sha256
        public static String Sha256Hash(String value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }

        /// <summary>
        /// Hàm sinh mã theo key salt
        /// Author      Date        Action
        /// Unknow      Unknow      Add function
        /// TuNT13      1/12/2014   Edit comment
        /// </summary>
        /// <param name="original">Chuỗi gốc</param>
        /// <returns>Chuỗi mã hoá</returns>
        public static string EncryptIntranet(string original)
        {
            return Encrypt(original, "1qaz2wsx0okm9ijn");
        }

        /// <summary>
        /// Hàm mã hoá mật khẩu theo key salt
        /// Author      Date        Action
        /// Unknow      Unknow      Add function
        /// TuNT13      1/12/2014   Edit comment
        /// </summary>
        /// <param name="original">Chuỗi gốc</param>
        /// <returns>Chuỗi mã hoá</returns>
        public static string EncryptPassword(string original)
        {
            return Encrypt(original, "!@#$%^&*()~_+|");
        }

        /// <summary>
        /// Hàm mã hoá mật khẩu (main function)
        /// Author      Date        Action
        /// Unknow      Unknow      Add function
        /// TuNT13      1/12/2014   Edit comment
        /// </summary>
        /// <param name="original">Chuỗi gốc</param>
        /// <param name="key">Mã salt</param>
        /// <returns>Chuỗi sau khi mã hoá</returns>
        public static string Encrypt(string original, string key)
        {
            TripleDESCryptoServiceProvider objDESProvider;
            MD5CryptoServiceProvider objHashMD5Provider;
            byte[] keyhash;
            byte[] buffer;
            try
            {
                objHashMD5Provider = new MD5CryptoServiceProvider();
                keyhash = objHashMD5Provider.ComputeHash(UnicodeEncoding.Unicode.GetBytes(key));
                objHashMD5Provider = null;

                objDESProvider = new TripleDESCryptoServiceProvider();
                objDESProvider.Key = keyhash;
                objDESProvider.Mode = CipherMode.ECB;

                buffer = UnicodeEncoding.Unicode.GetBytes(original);
                return Convert.ToBase64String(objDESProvider.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length));
            }
            catch
            {
                return string.Empty;
            }
        }
        #endregion

        /// <summary>
        /// <para>Hàm có chức năng chuyển một danh sách kiểu int sang chuổi string</para>
        /// <para>Chuổi phân chia giữa các ký tự bỏi dấu ,</para>
        /// <para>Người tạo : Nghiatc2.</para>
        /// <para>Ngày tạo : 21/3/2015.</para>
        /// </summary>
        /// <param name="listConvert">Danh sach chứa các thành phần kiểu int</param>
        /// <returns>string</returns>
        public static string ConvertListIntToString(IEnumerable<int> listConvert)
        {
            var appendTemp = new StringBuilder();

            if (listConvert.Any())
            {
                foreach (var item in listConvert)
                {
                    appendTemp.Append(item + ",");
                }
                //appendTemp = appendTemp.Replace(",",string.Empty,(appendTemp.Length + 1),1);

                return appendTemp.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        //public static bool GetApprovedComment()
        //{
        //    try
        //    {
        //        var xdoc = new XmlDocument();
        //        xdoc.Load(ConfigurationManager.AppSettings["lstWebConfig"] + "\\CommentApproved.xml");
        //        var xnodes = xdoc.SelectSingleNode("/configuration/appSettings");

        //        foreach (XmlNode xnn in xnodes.ChildNodes)
        //        {
        //            if (xnn.Attributes[0].Value != "IsApprovedCM") continue;
        //            return xnn.Attributes[1].Value.Equals("true");
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //    return false;
        //}

        /// <summary>
        /// <para>User Created : Nghiatc2.</para>
        /// <para>Date Created : 19/11/2015.</para>
        /// </summary>
        /// <param name="agent"></param>
        /// <returns></returns>
        public static bool IsRequestMobile(string agent)
        {
            try
            {
                var b = new Regex(@"(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od|ad)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows ce|xda|xiino", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                var v = new Regex(@"1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                var isMobile = (b.IsMatch(agent) || v.IsMatch(agent.Substring(0, 4)));
                return isMobile;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static IEnumerable<string> GetListLinkImg(string htmlCode)
        {
            var list = new List<string>();

            if (string.IsNullOrEmpty(htmlCode)) return list;

            var regex = new Regex("<img.+?src=[\x5c\x22\x27]+(?<value>.+?)[\x5c\x22\x27]+.+>");

            if (regex.IsMatch(htmlCode))
            {
                var matches = regex.Matches(htmlCode);

                list.AddRange(from Match match in matches select match.Groups["value"].Value);
            }

            return list;
        }

        public static string ConvertStringToNameAscii(string unicode)
        {
            unicode = Regex.Replace(unicode, "[á|à|ả|ã|ạ|â|ă|ấ|ầ|ẩ|ẫ|ậ|ắ|ằ|ẳ|ẵ|ặ]", "a", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[é|è|ẻ|ẽ|ẹ|ê|ế|ề|ể|ễ|ệ]", "e", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[ú|ù|ủ|ũ|ụ|ư|ứ|ừ|ử|ữ|ự]", "u", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[í|ì|ỉ|ĩ|ị]", "i", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[ó|ò|ỏ|õ|ọ|ô|ơ|ố|ồ|ổ|ỗ|ộ|ớ|ờ|ở|ỡ|ợ]", "o", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[đ|Đ]", "d", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[ý|ỳ|ỷ|ỹ|ỵ|Ý|Ỳ|Ỷ|Ỹ|Ỵ]", "y", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[,|~|@|/|.|:|?|#|$|%|&|*|(|)|+|”|“|'|\"|!|`|–]", "", RegexOptions.IgnoreCase);

            unicode = Regex.Replace(unicode, "[,|~|@|/|.|:|?|#|$|%|&|*|(|)|+|”|“|'|\"|!|`|–| |]", "-",
                RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, @"-+-","-", RegexOptions.IgnoreCase);

            return unicode;
        }

        public static string GetMD5(string str)
        {

            var md5 = new MD5CryptoServiceProvider();

            byte[] bHash = md5.ComputeHash(Encoding.UTF8.GetBytes(str));

            var sbHash = new StringBuilder();

            foreach (byte b in bHash)
            {

                sbHash.Append(String.Format("{0:x2}", b));

            }

            return sbHash.ToString();

        }

        public static string DayOfWeek(DateTime date)
        {
            int dayI = ((int)date.DayOfWeek);
            string day = "";
            switch (dayI)
            {
                case 0:
                    day = "Chủ nhật";
                    break;
                case 1:
                    day = "Thứ hai";
                    break;
                case 2:
                    day = "Thứ ba";
                    break;
                case 3:
                    day = "Thứ tư";
                    break;
                case 4:
                    day = "Thứ năm";
                    break;
                case 5:
                    day = "Thứ sáu";
                    break;
                case 6:
                    day = "Thứ bảy";
                    break;
                default:
                    day ="";
                    break;
            }
            return day;
        }

        public static string RemoveStyleInHTMLTag(string source)
        {

            if (!string.IsNullOrEmpty(source))
            {
                return Regex.Replace(source,
                    @"style\s*\x3D\x5c?(\x27|\x22)[a-zA-Z0-9\x3A\x3B\s\x2D\x2C\x2E\x28\x29\x25\x23\x40\x21]+\x5c?(\x27|\x22)", "",
                    RegexOptions.IgnoreCase | RegexOptions.Singleline);

            }
            return string.Empty;
        }
    }
}