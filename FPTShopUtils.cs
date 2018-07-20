using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Net.Mail;
using System.Net;
using Nop.Services.SMS;
using smsPortTypeClient = FPTShop.Utils.SMSService.smsPortTypeClient;


namespace FPTShop.Utils
{

    public class ProductDetailItem
    {
        public int ProductID { get; set; }
        public int ContentID { get; set; }
        public int LabelID { get; set; }
    }

    public static class FPTShopUtils
    {
        private static readonly Random _r = new Random();

        public static List<ProductDetailItem> getValuesContentArray(string LtsSourceValues)
        {
            var ltsValues = new List<ProductDetailItem>();
            if (!string.IsNullOrEmpty(LtsSourceValues))
            {
                if (LtsSourceValues.Contains(","))
                {
                    ltsValues.AddRange(LtsSourceValues.Split(',').Select(keyValue => new ProductDetailItem()
                    {
                        LabelID = Convert.ToInt32(keyValue.Split('_')[0]),
                        ContentID = Convert.ToInt32(keyValue.Split('_')[1]),
                    }));
                }
                else
                {
                    ltsValues.Add(new ProductDetailItem()
                    {
                        LabelID = Convert.ToInt32(LtsSourceValues.Split('_')[0]),
                        ContentID = Convert.ToInt32(LtsSourceValues.Split('_')[1]),
                    });
                }
            }
            return ltsValues;
        }

        public static List<int> getEditValuesArrayTag(string ltsSourceValues)
        {
            var ltsValues = new List<string>();
            if (!string.IsNullOrEmpty(ltsSourceValues))
            {
                if (ltsSourceValues.Contains(",") || ltsSourceValues.Contains(" "))
                    ltsValues = Regex.Split(ltsSourceValues, ",").ToList();
                else
                    ltsValues.Add(Convert.ToString(ltsSourceValues));
            }
            var newListInt = new List<int>();
            ltsValues.ForEach(f =>
            {
                var temp = Convert.ToInt32(f);
                if (!newListInt.Contains(temp))
                    newListInt.Add(temp);
            });
            return newListInt;
        }

        public static List<int> getEditValuesArrayTagNews(string ltsSourceValues)
        {
            var ltsValues = new List<string>();
            if (!string.IsNullOrEmpty(ltsSourceValues))
            {
                if (ltsSourceValues.Contains(","))
                    ltsValues = Regex.Split(ltsSourceValues, ",").ToList();
                else
                    ltsValues.Add(Convert.ToString(ltsSourceValues));
            }
            var newListInt = new List<int>();
            ltsValues.ForEach(f =>
            {
                var temp = Convert.ToInt32(f);
                if (!newListInt.Contains(temp))
                    newListInt.Add(temp);
            });
            return newListInt;
        }

        /// <summary>
        /// hungdc3 09/04/2014
        /// sửa cắt khoảng trắng cho refference
        /// </summary>
        /// <param name="ltsSourceValues"></param>
        /// <returns></returns>
        public static List<string> getValuesArrayTag(string ltsSourceValues)
        {
            var ltsValues = new List<string>();
            if (string.IsNullOrEmpty(ltsSourceValues)) return ltsValues;
            var lts = ltsSourceValues.Replace(", ", ",");
            if (lts.Contains(","))
            {
                ltsValues = Regex.Split(lts, ",").ToList();
            }
            else
                ltsValues.Add(Convert.ToString(ltsSourceValues));
            return ltsValues;
        }

        /// <summary>
        /// hungdc3 9/12/2013
        /// </summary>
        /// <param name="LtsSourceValues"></param>
        /// <returns></returns>
        public static List<int> getValuesArray(string LtsSourceValues)
        {
            var ltsValues = new List<int>();
            if (!string.IsNullOrEmpty(LtsSourceValues))
            {
                if (LtsSourceValues.Contains(","))
                    ltsValues = LtsSourceValues.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(o => Convert.ToInt32(o)).ToList();
                else
                    ltsValues.Add(Convert.ToInt32(LtsSourceValues));
            }
            return ltsValues;
        }

        /// <summary>
        /// Tran Xuan Linh
        /// 09-Dec-2013
        /// system tag: convert string -> List<String>
        /// </summary>
        /// <param name="ltsSourceValues">string</param>
        /// <returns>list<string></returns>
        public static List<string> getValuesArrayForTag(string ltsSourceValues)
        {
            var ltsValues = new List<string>();
            if (string.IsNullOrEmpty(ltsSourceValues)) return ltsValues;
            if (ltsSourceValues.Contains(",") && ltsSourceValues.Contains(" "))
                ltsValues = Regex.Split(ltsSourceValues, ", ").Select(Convert.ToString).ToList();
            else
                ltsValues.Add(Convert.ToString(ltsSourceValues));
            return ltsValues;
        }

        public static string FormatBytes(int bytes)
        {
            const int scale = 1024;
            var orders = new string[] { "GB", "MB", "KB", "Bytes" };
            long max = (long)Math.Pow(scale, orders.Length - 1);

            foreach (string order in orders)
            {
                if (bytes > max)
                    return string.Format("{0:##.##} {1}", decimal.Divide(bytes, max), order);

                max /= scale;
            }
            return "0 Bytes";
        }

        public static string getYoutubeID(string source)
        {
            if (source.IndexOf("?v=") < 0)
                return string.Empty;
            else
            {
                int start = source.IndexOf("?v=") + 3;
                int end;
                if (source.IndexOf("&") < 0)
                    end = source.Length;
                else
                    end = source.IndexOf("&");

                return source.Substring(start, end - start);
            }
        }

        public static string getYoutubeLink(string source)
        {
            if (source.IndexOf("?v=") < 0)
                return string.Empty;
            else
            {
                string temp = "http://www.youtube.com/v/";
                return temp + getYoutubeID(source);
            }
        }


        public static string getDataVotePercent(int VoteCount, int TotalVote)
        {
            try
            {
                double value = ((double)VoteCount / TotalVote);
                return (value.ToString("0.0%") == "NaN") ? "0" : value.ToString("0.0%");
            }
            catch { return string.Empty; }
        }

        public static string getDataVoteWidthCss(int VoteCount, int TotalVote)
        {
            try
            {
                double value = ((double)VoteCount / TotalVote);
                return (value.ToString("0.0%") == "NaN") ? "0" : value.ToString("0.0%").Replace("%", "");
            }
            catch { return string.Empty; }
        }
        // huyvq add substring product name
        public static string GetSubstringName(string name)
        {
            var lengthName = 30;
            try
            {
                ConvertUtil.ToInt32(ConfigurationManager.AppSettings["LengNameConfig"]);
            }
            catch (Exception)
            {

            }
            return name.Length < lengthName ? name : name.Substring(0, lengthName);
        }

        /// <summary>
        /// Lấy về danh sách ID
        /// </summary>
        /// <param name="arrID"></param>
        /// <returns></returns>
        public static List<int> GetDanhSachIDsQuaFormPost(string arrID)
        {
            var dsID = new List<int>();
            if (!string.IsNullOrEmpty(arrID)) // Nếu không rỗng
            {
                if (arrID.IndexOf(',') > 0) //nếu nhiều hơn 1
                {
                    string[] tempIDs = arrID.Split(',');
                    dsID.AddRange(tempIDs.Select(idConvert => Convert.ToInt32(idConvert)));
                }
                else
                    dsID.Add(Convert.ToInt32(arrID));
            }
            return dsID;
        }

        public static byte[] ReadFile(string filePath)
        {
            byte[] buffer;
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                int length = (int)fileStream.Length;  // get file length
                buffer = new byte[length];            // create buffer
                int count;                            // actual number of bytes read
                int sum = 0;                          // total number of bytes read

                // read until Read method returns 0 (end of the stream has been reached)
                while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                    sum += count;  // sum is a buffer offset for next reading
            }
            finally
            {
                fileStream.Close();
            }
            return buffer;
        }

        /// <summary>
        /// Hàm chuyển một chuỗi tiếng việt có dấu thành tiếng việt không dấu
        /// </summary>
        /// <param name="Unicode">xâu tiếng việt có dấu</param>
        /// <Modified>        
        ///	Name		Date		    Comment 
        /// TuNT        13/09/2013      Tạo mới
        /// </Modified>
        public static string UnicodeToAscii(string Unicode)
        {
            Unicode = Regex.Replace(Unicode, "[á|à|ả|ã|ạ|â|ă|ấ|ầ|ẩ|ẫ|ậ|ắ|ằ|ẳ|ẵ|ặ]", "a", RegexOptions.IgnoreCase);
            Unicode = Regex.Replace(Unicode, "[é|è|ẻ|ẽ|ẹ|ê|ế|ề|ể|ễ|ệ]", "e", RegexOptions.IgnoreCase);
            Unicode = Regex.Replace(Unicode, "[ú|ù|ủ|ũ|ụ|ư|ứ|ừ|ử|ữ|ự]", "u", RegexOptions.IgnoreCase);
            Unicode = Regex.Replace(Unicode, "[í|ì|ỉ|ĩ|ị]", "i", RegexOptions.IgnoreCase);
            Unicode = Regex.Replace(Unicode, "[ó|ò|ỏ|õ|ọ|ô|ơ|ố|ồ|ổ|ỗ|ộ|ớ|ờ|ở|ỡ|ợ]", "o", RegexOptions.IgnoreCase);
            Unicode = Regex.Replace(Unicode, "[đ|Đ]", "d", RegexOptions.IgnoreCase);
            Unicode = Regex.Replace(Unicode, "[ý|ỳ|ỷ|ỹ|ỵ|Ý|Ỳ|Ỷ|Ỹ|Ỵ]", "y", RegexOptions.IgnoreCase);
            Unicode = Regex.Replace(Unicode, "[,|~|@|/|.|:|?|#|$|%|&|*|(|)|+]", "", RegexOptions.IgnoreCase);
            Unicode = Regex.Replace(Unicode, "[^A-Za-z0-9-]", "");

            return Unicode;
        }

        /// <summary>
        /// create by BienLV 02-04-2014
        /// remove special character 
        /// </summary>
        /// <param name="unicode"></param>
        /// <returns></returns>
        public static string NewUnicodeToAscii(string unicode)
        {
            unicode = Regex.Replace(unicode, "[á|à|ả|ã|ạ|â|ă|ấ|ầ|ẩ|ẫ|ậ|ắ|ằ|ẳ|ẵ|ặ]", "a", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[é|è|ẻ|ẽ|ẹ|ê|ế|ề|ể|ễ|ệ]", "e", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[ú|ù|ủ|ũ|ụ|ư|ứ|ừ|ử|ữ|ự]", "u", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[í|ì|ỉ|ĩ|ị]", "i", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[ó|ò|ỏ|õ|ọ|ô|ơ|ố|ồ|ổ|ỗ|ộ|ớ|ờ|ở|ỡ|ợ]", "o", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[đ|Đ]", "d", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[ý|ỳ|ỷ|ỹ|ỵ|Ý|Ỳ|Ỷ|Ỹ|Ỵ]", "y", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[,|~|@|/|.|:|?|#|$|%|&|*|(|)|+|”|“|'|\"|!|`|–]", "", RegexOptions.IgnoreCase);

            return unicode;
        }

        /// <summary>
        /// create by BienLV 00-04-2014
        /// change special character to "-"
        /// </summary>
        /// <param name="unicode"></param>
        /// <returns></returns>
        public static string RemoveSpecialCharacter(string unicode)
        {
            unicode = Regex.Replace(unicode, "[,|~|@|/|.|:|?|#|$|%|&|*|(|)|+|”|“|'|\"|!|`|–]", "-", RegexOptions.IgnoreCase);

            return unicode;
        }

        /// <summary>
        /// Hàm chuyển một chuỗi tiếng việt có dấu thành tiếng việt không dấu (không bỏ dấu cách)
        /// </summary>
        /// <param name="Unicode">xâu tiếng việt có dấu</param>
        /// <Modified>        
        ///	Name		Date		    Comment 
        /// TuNT        13/09/2013      Tạo mới
        /// </Modified>
        public static string UnicodeToEng(string Unicode)
        {
            Unicode = Regex.Replace(Unicode, "[á|à|ả|ã|ạ|â|ă|ấ|ầ|ẩ|ẫ|ậ|ắ|ằ|ẳ|ẵ|ặ]", "a", RegexOptions.IgnoreCase);
            Unicode = Regex.Replace(Unicode, "[é|è|ẻ|ẽ|ẹ|ê|ế|ề|ể|ễ|ệ]", "e", RegexOptions.IgnoreCase);
            Unicode = Regex.Replace(Unicode, "[ú|ù|ủ|ũ|ụ|ư|ứ|ừ|ử|ữ|ự]", "u", RegexOptions.IgnoreCase);
            Unicode = Regex.Replace(Unicode, "[í|ì|ỉ|ĩ|ị]", "i", RegexOptions.IgnoreCase);
            Unicode = Regex.Replace(Unicode, "[ó|ò|ỏ|õ|ọ|ô|ơ|ố|ồ|ổ|ỗ|ộ|ớ|ờ|ở|ỡ|ợ]", "o", RegexOptions.IgnoreCase);
            Unicode = Regex.Replace(Unicode, "[đ|Đ]", "d", RegexOptions.IgnoreCase);
            Unicode = Regex.Replace(Unicode, "[ý|ỳ|ỷ|ỹ|ỵ|Ý|Ỳ|Ỷ|Ỹ|Ỵ]", "y", RegexOptions.IgnoreCase);


            return Unicode;
        }

        /// <summary>
        /// Hàm chuyển một chuỗi tiếng việt có dấu thành tiếng việt không dấu (không bỏ dấu cách) - chuyển dấu,->cách
        /// </summary>
        /// <param name="Unicode">xâu tiếng việt có dấu</param>
        /// <Modified>        
        ///	Name		Date		    Comment 
        /// TuNT        13/09/2013      Tạo mới
        /// </Modified>
        public static string UnicodeToEngSearch(string Unicode)
        {
            Unicode = Regex.Replace(Unicode, "[á|à|ả|ã|ạ|â|ă|ấ|ầ|ẩ|ẫ|ậ|ắ|ằ|ẳ|ẵ|ặ]", "a", RegexOptions.IgnoreCase);
            Unicode = Regex.Replace(Unicode, "[é|è|ẻ|ẽ|ẹ|ê|ế|ề|ể|ễ|ệ]", "e", RegexOptions.IgnoreCase);
            Unicode = Regex.Replace(Unicode, "[ú|ù|ủ|ũ|ụ|ư|ứ|ừ|ử|ữ|ự]", "u", RegexOptions.IgnoreCase);
            Unicode = Regex.Replace(Unicode, "[í|ì|ỉ|ĩ|ị]", "i", RegexOptions.IgnoreCase);
            Unicode = Regex.Replace(Unicode, "[ó|ò|ỏ|õ|ọ|ô|ơ|ố|ồ|ổ|ỗ|ộ|ớ|ờ|ở|ỡ|ợ]", "o", RegexOptions.IgnoreCase);
            Unicode = Regex.Replace(Unicode, "[đ|Đ]", "d", RegexOptions.IgnoreCase);
            Unicode = Regex.Replace(Unicode, "[ý|ỳ|ỷ|ỹ|ỵ|Ý|Ỳ|Ỷ|Ỹ|Ỵ]", "y", RegexOptions.IgnoreCase);
            Unicode = Regex.Replace(Unicode, "[ ,]", " ", RegexOptions.IgnoreCase);
            Unicode = Regex.Replace(Unicode, "[, ]", " ", RegexOptions.IgnoreCase);
            Unicode = Regex.Replace(Unicode, "[,]", " ", RegexOptions.IgnoreCase);

            return Unicode;
        }
        /// <summary>
        /// hàm Conver rewrite url
        /// </summary>
        /// <param name="Unicode"></param>
        /// <returns></returns>
        public static string ConverRewrite(string Unicode)
        {
            if (Unicode != null)
            {
                Unicode = NewUnicodeToAscii(Unicode);
                Unicode = Unicode.ToLower().Trim();
                Unicode = Regex.Replace(Unicode, @"\s+", " ");
                Unicode = Regex.Replace(Unicode, "[\\s]", "-");
                //Unicode = UnicodeToAscii(Unicode);
                Unicode = Regex.Replace(Unicode, @"-+", "-");
            }
            return Unicode;
        }
        /// <summary>
        /// hàm Conver rewrite url
        /// </summary>
        /// <param name="Unicode"></param>
        /// <returns></returns>
        public static string ConverRewriteAllSpace(string Unicode)
        {
            if (Unicode != null)
            {
                Unicode = Regex.Replace(Unicode, @"\s+", " ");
            }
            return Unicode;
        }
        /// <summary>
        /// Hàm tạo Mã SHA1 lấy từ hệ thống cũ
        /// Name		Date		    Comment        
        /// DongDT      7/1/2014     Thêm string mã hóa: CreateSaltKey và SHA1
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static string CreateSaltKey(int size)
        {
            // Generate a cryptographic random number
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);

            // Return a Base64 string representation of the random number
            return Convert.ToBase64String(buff);
        }

        public static string CreatePasswordHash(string password, string saltkey, string passwordFormat = "SHA1")
        {
            if (String.IsNullOrEmpty(passwordFormat))
                passwordFormat = "SHA1";
            string saltAndPassword = String.Concat(password, saltkey);
            string hashedPassword =
                FormsAuthentication.HashPasswordForStoringInConfigFile(
                    saltAndPassword, passwordFormat);
            return hashedPassword;
        }

        /// <summary>
        /// Hàm tạo mã hóa của hệ thống Service
        /// DongDT
        /// 04/03/2014 
        /// </summary>
        /// <param name="clearData"></param>
        /// <param name="Key"></param>
        /// <param name="IV"></param>
        /// <returns></returns>
        public static byte[] Encrypt(byte[] clearData, byte[] Key, byte[] IV)
        {
            // Create a MemoryStream to accept the encrypted bytes 
            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();
            alg.Key = Key;
            alg.IV = IV;
            CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(clearData, 0, clearData.Length);
            cs.Close();
            byte[] encryptedData = ms.ToArray();

            return encryptedData;
        }

        public static string Encrypt(string UserName, string Password)
        {
            byte[] clearBytes =
              System.Text.Encoding.Unicode.GetBytes(UserName);
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password,
                new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d,
            0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});
            byte[] encryptedData = Encrypt(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16));
            return Convert.ToBase64String(encryptedData);
        }
        /// <summary>
        /// Hàm tạo random 6 ký tự
        /// DongDT 
        /// 04/03/2014
        /// </summary>
        /// <returns></returns>
        public static string CreateRandomKey()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[6];
            var random = new Random();

            for (var i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new String(stringChars);
            var key = finalString;
            return key;
        }

        /// <summary>
        /// Hàm tạo random 6 ký tự
        /// DongDT 
        /// 04/03/2014
        /// </summary>
        /// <returns></returns>
        public static string CreateRandom12Key()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[12];
            var random = new Random();

            for (var i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new String(stringChars);
            var key = finalString;
            return key;
        }

        /// <summary>
        /// Hàm tạo mã md5
        /// </summary>
        /// <param name="str">xâu cần mã hóa</param>
        /// <Modified>        
        ///	Name		Date		    Comment 
        /// TuNT        13/09/2013     Tạo mới
        /// LinhTX      11/12/2013     Thêm string mã hóa: FPTShopver2@2013
        /// </Modified>
        public static string GetMd5Sum(string str)
        {
            str = str + "FPTShopver2@2013";
            var enc = System.Text.Encoding.Unicode.GetEncoder();
            var unicodeText = new byte[str.Length * 2];
            enc.GetBytes(str.ToCharArray(), 0, str.Length, unicodeText, 0, true);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(unicodeText);
            var sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                sb.Append(result[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static string MD5ByPHP(string password)
        {
            byte[] textBytes = System.Text.Encoding.Default.GetBytes(password);
            try
            {
                MD5CryptoServiceProvider cryptHandler;
                cryptHandler = new MD5CryptoServiceProvider();
                byte[] hash = cryptHandler.ComputeHash(textBytes);
                string ret = "";
                foreach (byte a in hash)
                {
                    if (a < 16)
                        ret += "0" + a.ToString("x");
                    else
                        ret += a.ToString("x");
                }
                return ret;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Xóa thẻ HTML
        /// </summary>
        /// <param name="source">xâu có chứa HTML</param>
        /// <Modified>        
        ///	Name		Date		    Comment 
        /// TuNT        13/09/2013    Tạo mới
        /// LinhTX      13/01/2014    Check null
        /// </Modified>
        public static string RemoveHTMLTag(string source)
        {
            if (string.IsNullOrEmpty(source) == false)
            {
                return Regex.Replace(source, "<.*?>", "");
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// create by BienLV 17-01-2014
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string RemoveASCII(string source)
        {
            return Regex.Replace(RemoveHTMLTag(source), @"\t*\n*\r*\s*", "");
        }
        public static string TextAbstract(string text, int length)
        {
            if (text == null)
            {
                return "";
            }
            if (text.Length <= length)
            {
                return text;
            }
            text = text.Substring(0, length);
            var last = text.LastIndexOf(" ");
            text = text.Substring(0, last);
            return text + "...";
        }
        /// <summary>
        /// create by BienLV 11-02-2014
        /// get small hightlightsDes default three line
        /// </summary>
        /// <param name="hightlightsDes"></param>
        /// <returns></returns>
        public static string GetSmallHightlightsShortDes(string hightlightsDes)
        {
            var result = hightlightsDes;
            if (!string.IsNullOrEmpty(hightlightsDes))
            {
                var regex = new Regex(@"<\s*li[^>]*>(.*?)<\s*/li\s*>", RegexOptions.IgnoreCase);
                var collection = regex.Matches(Regex.Replace(hightlightsDes, @"\t*\n*\r*", ""));
                if (collection.Count > 0)
                {
                    result = "<div class='hightlight-des'><ul>";
                    for (var i = 0; i < collection.Count; i++)
                    {
                        if (i < 3)
                        {
                            result += "<li>" + collection[i].Groups[1].Value + "</li>";
                        }
                    }
                    result += "</ul></div>";
                }
            }

            return result;
        }
        /// <summary>
        /// xungvh created 06.08.2015
        /// </summary>
        /// <param name="hightlightsDes"></param>
        /// <returns></returns>
        public static string GetSmallShortDes(string hightlightsDes)
        {
            var result = hightlightsDes;
            if (!string.IsNullOrEmpty(hightlightsDes))
            {
                var regex = new Regex(@"<\s*li[^>]*>(.*?)<\s*/li\s*>", RegexOptions.IgnoreCase);
                var collection = regex.Matches(Regex.Replace(hightlightsDes, @"\t*\n*\r*", ""));
                if (collection.Count > 0)
                {
                    result = "<ul>";
                    for (var i = 0; i < collection.Count; i++)
                    {
                        if (i < 3)
                        {
                            result += "<li>" + collection[i].Groups[1].Value + "</li>";
                        }
                    }
                    result += "</ul>";
                }
            }

            return result;
        }

        public static string AddCssCateLaptopKM(string old)
        {
            var strNew = "";

            if (old.Length > 2)
            {
                if (old.Substring(0, 2) == "<p")
                {
                    strNew = old.Substring(2, old.Length - 2);
                    strNew = strNew.Insert(0, "<p class=\"fshop-lplap-salestitle\"");
                }
                else
                {
                    strNew = old;
                    strNew = strNew.Insert(0, "<p class=\"fshop-lplap-salestitle\">Đặt Online nhận ngay khuyến m&atilde;i:</p>");
                }
            }
            return strNew;
        }
        /// <summary>
        /// create by BienLV 11-02-2014
        /// get small hightlightsDes default three line
        /// </summary>
        /// <param name="hightlightsDes"></param>
        /// <returns></returns>
        public static string GetSmallHightlightsShortDesNew(string hightlightsDes, int rowNumber)
        {
            var result = hightlightsDes;
            if (!string.IsNullOrEmpty(hightlightsDes))
            {
                var regex = new Regex(@"<\s*li[^>]*>(.*?)<\s*/li\s*>", RegexOptions.IgnoreCase);
                var collection = regex.Matches(Regex.Replace(hightlightsDes, @"\t*\n*\r*", ""));
                if (collection.Count > 0)
                {
                    result = "<div class='hightlight-des'><ul>";
                    for (var i = 0; i < collection.Count; i++)
                    {
                        if (i < rowNumber)
                        {
                            result += "<li>" + collection[i].Groups[1].Value + "</li>";
                        }
                    }
                    result += "</ul></div>";
                }
            }

            return result;
        }
        /// <summary> 
        /// boi dam tu khoa trong ket qua tim kiem
        /// </summary>
        /// <author> linhtx </author>
        /// <datemodified> 14-Jan-2014 </datemodified>
        /// <param name="source">result search</param>
        /// <param name="keyword">keyword search</param>
        /// <returns>string</returns>
        public static string ReplaceSuggestKeyword(string source, string keyword)
        {
            if (string.IsNullOrEmpty(source) == false)
            {
                source = source.ToLower();
                keyword = keyword.ToLower();

                return source.Replace(keyword, "<b>" + keyword + "</b>");
            }
            else
            {
                return string.Empty;
            }
        }

        public static string GetFileExtend(string fileName)
        {
            return fileName.Substring(fileName.LastIndexOf("."));
        }

        public static string GetFileNameNoneExtent(string fileName)
        {
            return fileName.Substring(0, fileName.LastIndexOf("."));
        }

        /// <summary>
        /// add by BienLV 18-12-2013
        /// get random string
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static string RandomString(int size)
        {
            var builder = new StringBuilder();
            var random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }
        /// <summary>
        /// Hàm render ra AutoTag
        /// </summary>
        /// <param name="containerName">Tên container cần render</param>
        /// <param name="ValuesSelected">Giá trị đã selected</param>
        /// <returns></returns>
        public static string GetHtmlAuToTag(string containerName, List<FPTShop.Utils.ListItem> ValuesSelected)
        {
            StringBuilder stbBuilder = new StringBuilder();
            stbBuilder.AppendFormat("					<input type=\"hidden\" name=\"{0}\" id=\"{0}\"/>", containerName);
            stbBuilder.AppendFormat("                    <input type=\"text\" name=\"{0}_Input\" id=\"{0}_Input\" value=\"Nhập vào từ khóa để tìm kiếm, nhấn enter để xác nhận !\" onblur=\"if(this.value=='') this.value='Nhập vào từ khóa để tìm kiếm, nhấn enter để xác nhận !';\" onfocus=\"if(this.value=='Nhập vào từ khóa để tìm kiếm, nhấn enter để xác nhận !') this.value='';\" />", containerName);
            stbBuilder.AppendFormat("                    <ul id=\"{0}_Value\" class=\"{0} listValues\">", containerName);

            foreach (ListItem item in ValuesSelected)
            {
                stbBuilder.AppendFormat("                            <li id=\"{0}_Value{1}\" name=\"{1}\" key=\"\">", containerName, item.ID);
                stbBuilder.AppendFormat("                                <span>{0}</span><a href=\"javascript:deletevalues('{1}_Value{2}');\">", item.Title, containerName, item.ID);
                stbBuilder.AppendFormat("                                <img border=\"0\" src=\"/Content/Admin/images/gridview/act_filedelete.png\" /></a>");
                stbBuilder.AppendFormat("                            </li>");
            }
            stbBuilder.AppendFormat("                    </ul>");
            return stbBuilder.ToString();
        }

        public static string Divide(decimal giamoi, decimal giacu)
        {

            string ketqua = "giảm " + Convert.ToString((int)(((giamoi - giacu) / giamoi) * 100)) + "% so với máy mới";


            return ketqua;
        }
        /// <summary>
        /// Hàm gửi SMS
        /// DongDT
        /// 04/03/2014
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="email"></param>
        /// <param name="pass"></param>
        public static bool SendSMSToCustomer(string name, string phoneNumber, string email, string pass)
        {
            string smsTemp = "", sms = "";
            int returncode = 0;
            //var sb = new StringBuilder();
            try
            {
                var client = new smsPortTypeClient();
                string customerPhone = "84" + phoneNumber.Remove(0, 1);
                string customerName = name;
                smsTemp = "Chao {0}. Tai khoan cua Quy Khach tai FPTShop.com.vn: User:{1}. Pass: {2}. Kinh chao Quy khach den voi FPTShop.com.vn";
                sms = string.Format(smsTemp, customerName, email, pass);
                returncode = client.sendSms(SMSParameters.Code, SMSParameters.Account, customerPhone, SMSParameters.BrandName, sms);
                //returncode = 0;      
                return returncode > 0;
            }
            catch (Exception ex)
            {
                return false;
                //UpdateNote(order, sb.ToString());
            }

        }

        /// <summary>
        /// Hàm gửi SMS landing Fstudio Lixi Tet 2015
        /// Author      Date         Action
        /// quannk2     23/01/2015   add
        /// </summary>
        /// <param name="email"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="content"></param>
        public static bool SendSMSToCustomerFStudio(string email, string phoneNumber, string content)
        {
            string smsTemp = "", sms = "";
            int returncode = 0;
            //var sb = new StringBuilder();
            try
            {
                var client = new smsPortTypeClient();
                string customerPhone = "84" + phoneNumber.Remove(0, 1);
                //smsTemp = "Chao {0}. Tai khoan cua Quy Khach tai FPTShop.com.vn: User:{1}. Pass: {2}. Kinh chao Quy khach den voi FPTShop.com.vn";
                sms = string.Format(content, email);
                returncode = client.sendSms(SMSParameters.Code, SMSParameters.Account, customerPhone, SMSParameters.BrandName, sms);
                //returncode = 0;      
                return returncode > 0;
            }
            catch (Exception ex)
            {
                return false;
                //UpdateNote(order, sb.ToString());
            }

        }

        /// <summary>
        /// Hàm gửi SMS game luckydraw
        /// Author      Date         Action
        /// quannk2     19/09/2015   add
        /// </summary>
        /// <param name="email"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="content"></param>
        public static bool SendSMSToCustomerLuckyDraw(string phoneNumber, string content)
        {
            int returncode = 0;
            try
            {
                var client = new smsPortTypeClient();
                string customerPhone = "84" + phoneNumber.Remove(0, 1);
                returncode = client.sendSms(SMSParameters.Code, SMSParameters.Account, customerPhone, SMSParameters.BrandName, content);
                return returncode > 0;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        /// <summary>
        /// Create by NghiaTC
        /// Overload function send mail.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="userName"></param>
        /// <param name="pass"></param>
        public static void SendEmail(string email, string userName, string pass)
        {
            const string emailFromAddress = "frt.contact@fpt.com.vn";
            const string emailSubject = "Tài khoản và mật khẩu từ FptShop";
            var emailBody = "Xin chào bạn " + userName + ".\nEmail của bạn dường như chưa tồn tại trong hệ thống tài khoản của chúng tôi." +
                            "Để thuận lợi cho việc đăng nhập chúng tôi đã tạo cho bạn một tài khoản mặc định với email của bạn.\n" +
                            "Username:" + email + ",Password:" + pass + ".\n" +
                            "Bạn có thể đăng nhập vào tài khoản được cấp để thay đổi thông tin cá nhân.\nXin chân thành cảm ơn.";
            const int portServer = 587;
            const string smtpServer = "mail.fpt.com.vn";

            try
            {
                var mailMessage = new MailMessage();
                var smtpServerClient = new SmtpClient(smtpServer);

                mailMessage.From = new MailAddress(emailFromAddress);
                mailMessage.To.Add(email);
                mailMessage.Subject = emailSubject;
                mailMessage.Body = emailBody;

                smtpServerClient.Port = portServer;
                smtpServerClient.Credentials = new NetworkCredential("frt.contact@fpt.com.vn", "online123");
                smtpServerClient.EnableSsl = true;

                smtpServerClient.Send(mailMessage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        /// <summary>
        /// Overload SendSMSToCustomer.
        /// Send sms confirm for mobile to user.
        /// NghiaTc.
        /// </summary>
        /// <param name="userName"> </param>
        /// <param name="phoneNumber"></param>
        /// <param name="capcha"></param>
        public static bool SendSMSToCustomer(string userName, string phoneNumber, string capcha)
        {
            var sb = new StringBuilder();
            var boolCheckStatus = false;
            try
            {
                var sptClient = new smsPortTypeClient();
                var customerPhone = "84" + phoneNumber.Remove(0, 1);
                var customerName = userName;
                const string smsTemp = "Xin chao {0}.{1} la ma xac thuc so dien thoai cua ban." +
                                       "Ban vui long nhap dung ma so chung toi da gui cho ban de tien hanh thay doi thong tin." +
                                       "Cam on ban da su dung trang web cua chung toi";
                var sms = string.Format(smsTemp, customerName, capcha);
                var returncode = sptClient.sendSms(SMSParameters.Code, SMSParameters.Account, customerPhone, SMSParameters.BrandName, sms);

                if (returncode > 0)
                {
                    boolCheckStatus = true;
                }
            }
            catch (Exception ex)
            {
                boolCheckStatus = false;
            }

            return boolCheckStatus;

        }

        public static void CheckTime(string control, int time)
        {

            FileStream file;
            if (!File.Exists(@"E:\TimeCheck.txt"))
            {
                file = new FileStream(@"E:\TimeCheck.txt", FileMode.CreateNew, FileAccess.Write);
            }
            else file = new FileStream(@"E:\TimeCheck.txt", FileMode.Append, FileAccess.Write);

            // Create a new stream to write to the file
            StreamWriter sw = new StreamWriter(file);

            // Write a string to the file
            sw.WriteLine(control + ":" + time.ToString());
            sw.WriteLine();

            // Close StreamWriter
            sw.Close();

            // Close file
            file.Close();
        }

        /// <summary>
        /// add by BienLV 12-05-2015
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static int GetPercenPriceMarket(decimal priceMarket, decimal price)
        {
            var roundDown = Convert.ToInt32((price - priceMarket) / priceMarket * 100);

            roundDown = roundDown == 0 ? -1 : roundDown;

            return roundDown;
        }

        public static int RandomTotalOrder(int size)
        {
            var ticks = DateTime.UtcNow.Ticks - DateTime.Parse(ConfigCache.DateIndentity).Ticks;
            ticks /= 10000000 * 60;

            var min = (size - 1) * 100;
            var max = size * 100;

            var rn = _r.Next(min, max);

            var ran = ticks + rn;

            return Convert.ToInt32(ran);
        }

        /// <summary>
        /// Nghiatc2-3/7/14.
        /// Remove html tag.
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public static string RemoveHtmlTag(string resource)
        {
            var resourceTemp = resource;

            if (string.IsNullOrEmpty(resourceTemp))
            {
                resourceTemp = HttpUtility.HtmlDecode(resourceTemp);
                var array = new char[resourceTemp.Length];
                var arrayIndex = 0;
                var inside = false;

                foreach (var @let in resourceTemp)
                {
                    if (@let == '<')
                    {
                        inside = true;
                        continue;
                    }

                    if (@let == '>')
                    {
                        inside = false;
                        continue;
                    }

                    if (inside) continue;
                    array[arrayIndex] = @let;
                    arrayIndex++;
                }

                var stringNew = new string(array, 0, arrayIndex);
                return stringNew;
            }
            return resourceTemp;
        }

        public static string GetUserIP()
        {
            var userIp = string.Empty;

            if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                userIp = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            }
            else if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.UserHostAddress))
            {
                userIp = System.Web.HttpContext.Current.Request.UserHostAddress;
            }
            return userIp;
        }

        public static string GetUser()
        {
            try
            {
                if (System.Web.HttpContext.Current.Request.Cookies["customerEmail"] != null)
                {
                    return System.Web.HttpContext.Current.Request.Cookies["customerEmail"].Value;
                }

                return string.Empty;
            }
            catch (Exception)
            {
                return string.Empty;
            }

        }

        public static void WriteFile(string str, string file)
        {
            var directory = Path.GetDirectoryName(file);
            if (directory != null && !Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            if (!File.Exists(file))
            {
                using (StreamWriter sw = File.CreateText(file))
                {
                    sw.WriteLine(str);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(file))
                {
                    sw.WriteLine(str);

                }
            }
        }

        /// <summary>
        /// <para>Hàm có chức năng trả ra ngày đứng trước ngày hiện tại một số ngày nào đó.</para>
        /// <para>Người tạo : Nghiatc2.</para>
        /// <para>Ngày tạo : 12/8/2015.</para>
        /// </summary>
        /// <param name="numberDayBackward">Số ngày cần lùi lại</param>
        /// <returns></returns>
        public static DateTime GetDayBackward(int numberDayBackward)
        {
            DateTime theDayBackward;

            try
            {
                theDayBackward = DateTime.Now.AddDays(-numberDayBackward);
            }
            catch (Exception)
            {
                theDayBackward = DateTime.Now;
            }
            return theDayBackward;
        }
        public static string DecodeFromUtf8(string utf8String)
        {
            // copy the string as UTF-8 bytes.
            byte[] utf8Bytes = new byte[utf8String.Length];
            for (int i = 0; i < utf8String.Length; ++i)
            {

                utf8Bytes[i] = (byte)utf8String[i];
            }

            return Encoding.UTF8.GetString(utf8Bytes, 0, utf8Bytes.Length);


        }
        public static String EncodeUtf8(string Path)
        {
            byte[] bytes = Encoding.Default.GetBytes(Path);
            var utf8_String = Encoding.UTF8.GetString(bytes);
            if (utf8_String.Contains("?") || utf8_String.Contains("�"))
                return Path;
            return utf8_String;
        }
        /// <summary>
        /// Determines a text file's encoding by analyzing its byte order mark (BOM).
        /// Defaults to ASCII when detection of the text file's endianness fails.
        /// </summary>
        /// <param name="filename">The text file to analyze.</param>
        /// <returns>The detected encoding.</returns>
        public static Encoding GetEncoding(string filename)
        {
            // Read the BOM
            var bom = Encoding.Default.GetBytes(filename);
            //using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read))
            //{
            //    file.Read(bom, 0, 4);
            //}

            // Analyze the BOM
            if (bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0x76) return Encoding.UTF7;
            if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf) return Encoding.UTF8;
            if (bom[0] == 0xff && bom[1] == 0xfe) return Encoding.Unicode; //UTF-16LE
            if (bom[0] == 0xfe && bom[1] == 0xff) return Encoding.BigEndianUnicode; //UTF-16BE
            if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff) return Encoding.UTF32;
            return Encoding.ASCII;
        }

        public static string[] FormatPromotionMobile(string promotion, int length, int position)
        {
            var result = new string[length];
            var temp = promotion.Replace("<ul>", "").Replace("</ul>", "").Replace("<li>", "");
            var str = RemoveHTMLTag(temp.Replace("</li>", "#")).Split('#');
            for (int i = 0; i < str.Length && i < length; i++)
            {
                if (str[i].IndexOf(':') >= 0)
                {
                    result[i] = str[i].Split(':')[position - 1].Replace("\r\n", "").Trim().ToString();
                }
            }
            return result;
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

        public static string GetSmallHightlightsShortDesV4(string hightlightsDes)
        {
            var result = hightlightsDes;
            if (!string.IsNullOrEmpty(hightlightsDes))
            {
                var regex = new Regex(@"<\s*li[^>]*>(.*?)<\s*/li\s*>", RegexOptions.IgnoreCase);
                var collection = regex.Matches(Regex.Replace(hightlightsDes, @"\t*\n*\r*", ""));
                if (collection.Count > 0)
                {
                    result = "<ul class='fs-lpil-tskt clearfix'>";
                    for (var i = 0; i < collection.Count; i++)
                    {
                        if (i < 4)
                        {
                            string itemLi = collection[i].Groups[1].Value;
                            string[] itemLiArr = itemLi.Split(':');
                            if (itemLiArr.Count() >= 2)
                                result += "<li><label>" + itemLiArr[0] + ":</label><span>" + itemLi.Substring(itemLi.IndexOf(':') + 1) + "</span></li>";
                            else
                                result += "<li>" + itemLi + "</li>";
                        }
                    }
                    result += "</ul>";
                }
            }

            return result;
        }
    }
}
