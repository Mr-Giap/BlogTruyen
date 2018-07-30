using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using FPTShop.Base;

namespace FPTShop.Utils
{
    public class ConvertUtil
    {
        public static int ToInt32(object obj)
        {
            var retVal = 0;
            try
            {
                retVal = Convert.ToInt32(obj);
            }
            catch
            {
                retVal = 0;
            }
            return retVal;
        }

        public static string StringToBoolString(string obj)
        {
            var retVal = "0";
            if (obj.ToLower() == "true")
                retVal = "1";
            return retVal;
        }

        public static int ToInt32(object obj, int defaultValue)
        {
            int retVal = defaultValue;

            if (obj == null || obj == DBNull.Value)
                return retVal;

            try
            {
                retVal = Convert.ToInt32(obj);
            }
            catch
            {
                retVal = defaultValue;
            }

            return retVal;
        }

        public static double ToDouble(object obj)
        {
            double retVal = 0;

            try
            {
                retVal = Convert.ToDouble(obj);
            }
            catch
            {
                retVal = 0;
            }

            return retVal;
        }

        public static long ToLong(object obj)
        {
            long retVal = 0;

            try
            {
                retVal = Convert.ToInt64(obj);
            }
            catch
            {
                retVal = 0;
            }

            return retVal;
        }

        public static decimal ToDecimal(object obj)
        {
            decimal retVal = 0;

            try
            {
                retVal = Convert.ToDecimal(obj);
            }
            catch
            {
                retVal = 0;
            }

            return retVal;
        }

        public static double ToDouble(object obj, double defaultValue)
        {
            double retVal = 0;

            if (obj == null || obj == DBNull.Value)
                return retVal;

            try
            {
                retVal = Convert.ToDouble(obj);
            }
            catch
            {
                retVal = defaultValue;
            }

            return retVal;
        }

        public static string ToString(object obj)
        {
            string retVal = String.Empty;

            try
            {
                retVal = Convert.ToString(obj);
            }
            catch
            {
                retVal = String.Empty;
            }

            return retVal;
        }

        public static string ToString(object obj, string defaultValue)
        {
            string retVal = String.Empty;

            if (obj == null || obj == DBNull.Value)
                return retVal;

            try
            {
                retVal = Convert.ToString(obj);
            }
            catch
            {
                retVal = defaultValue;
            }

            return retVal;
        }

        public static DateTime ToDate(object obj)
        {
            DateTime retVal = DateTime.Now;
            string[] strArr = obj.ToString().Split(' ');
            int lenStrArr = strArr.Length;
            try
            {
                if (lenStrArr >= 1)
                {
                    string str = strArr[0].ToString();
                    string[] strTemp = str.ToString().Split('/');
                    if (strTemp.Length == 3)
                    {
                        string t = string.Empty;
                        if (lenStrArr == 2)
                        {
                            t = strArr[1].ToString();
                        }
                        string input = string.Format("{0}-{1}-{2} {3}", strTemp[2].ToString(), strTemp[1].ToString(), strTemp[0].ToString(), t);

                        retVal = Convert.ToDateTime(input);
                    }
                }
            }
            catch
            {
                retVal = DateTime.Now;
            }

            return retVal;
        }

        public static DateTime ToDateTime(string obj)
        {
            if (!string.IsNullOrEmpty(obj))
            {
                DateTime retVal = DateTime.Now;
                string[] strArr = obj.Split(' ');
                int lenStrArr = strArr.Length;
                try
                {
                    if (lenStrArr >= 1)
                    {
                        string str = strArr[0].ToString();
                        string[] strTemp = str.ToString().Split('/');
                        if (strTemp.Length == 3)
                        {
                            string t = string.Empty;
                            if (lenStrArr == 2)
                            {
                                t = strArr[1].ToString();
                            }
                            string input = string.Format("{0}-{2}-{1} {3}", strTemp[2].ToString(), strTemp[1].ToString(), strTemp[0].ToString(), t);

                            retVal = Convert.ToDateTime(input);
                        }
                    }
                }
                catch
                {
                    retVal = DateTime.Now;
                }

                return retVal;

            }
            else return DateTime.Now;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="template"></param>
        /// <param name="tokens"></param>
        /// <param name="htmlEncode"></param>
        /// <returns></returns>
        public static string Replace(string template, IEnumerable<TokenEmailItem> tokens, bool htmlEncode, bool encode = false)
        {
            if (string.IsNullOrWhiteSpace(template))
                throw new ArgumentNullException("template");

            if (tokens == null)
                throw new ArgumentNullException("tokens");

            foreach (var token in tokens)
            {
                var tokenValue = token.Value;
                //do not encode URLs
                if (htmlEncode && !token.NeverHtmlEncoded && !encode)
                    tokenValue = HttpUtility.HtmlEncode(tokenValue);
                template = Replace(template, String.Format(@"%{0}%", token.Key), tokenValue);
            }
            return template;

        }

        public static string ReplaceSmsTemplate(string template, Dictionary<string, string> listReplace)
        {
            foreach (var item in listReplace)
            {
                template = template.Replace("[" + item.Key + "]", item.Value);
            }
            return template;
        }

        private static readonly StringComparison _stringComparison;
        private static string Replace(string original, string pattern, string replacement)
        {
            if (_stringComparison == StringComparison.Ordinal)
            {
                return original.Replace(pattern, replacement);
            }
            else
            {
                int count, position0, position1;
                count = position0 = position1 = 0;
                var inc = (original.Length / pattern.Length) * (replacement.Length - pattern.Length);
                var chars = new char[original.Length + Math.Max(0, inc)];
                while ((position1 = original.IndexOf(pattern, position0, _stringComparison)) != -1)
                {
                    for (int i = position0; i < position1; ++i)
                        chars[count++] = original[i];
                    for (int i = 0; i < replacement.Length; ++i)
                        chars[count++] = replacement[i];
                    position0 = position1 + pattern.Length;
                }
                if (position0 == 0) return original;
                for (var i = position0; i < original.Length; ++i)
                    chars[count++] = original[i];
                return new string(chars, 0, count);
            }
        }

        private IList<TokenEmailItem> GenerateTokens(Shop_Order order)
        {
            var tokens = new List<TokenEmailItem>();
            AddTokens(tokens, order);
            return tokens;
        }

        public virtual void AddTokens(IList<TokenEmailItem> tokens, Shop_Order order)
        {
            tokens.Add(new TokenEmailItem("Order.OrderNumber", order.ID.ToString(CultureInfo.InvariantCulture)));
            //tokens.Add(new TokenEmailItem("Store.Name", store.Name));
            //tokens.Add(new TokenEmailItem("Store.URL", store.Address, true));

            tokens.Add(new TokenEmailItem("Order.CustomerFullName", string.Format("{0} {1}", order.Address.FirstName, order.Address.LastName)));
            tokens.Add(new TokenEmailItem("Order.CustomerEmail", order.Address.Email));

            tokens.Add(new TokenEmailItem("Order.BillingFirstName", order.Address.FirstName));
            tokens.Add(new TokenEmailItem("Order.BillingLastName", order.Address.LastName));
            tokens.Add(new TokenEmailItem("Order.BillingPhoneNumber", order.Address.Phone));
            tokens.Add(new TokenEmailItem("Order.BillingEmail", order.Address.Email));
            tokens.Add(new TokenEmailItem("Order.BillingFaxNumber", order.Address.Fax));
            tokens.Add(new TokenEmailItem("Order.BillingCompany", order.Address.Company));
            tokens.Add(new TokenEmailItem("Order.BillingAddress1", order.Address.Address1));
            tokens.Add(new TokenEmailItem("Order.BillingAddress2", order.Address.Address2));
            // Thieu city, district 
            tokens.Add(new TokenEmailItem("Order.ShippingMethod", order.ShippingMethodID.ToString()));
            tokens.Add(new TokenEmailItem("Order.ShippingFirstName", order.Address1.FirstName ?? ""));
            tokens.Add(new TokenEmailItem("Order.ShippingLastName", order.Address1.LastName ?? ""));
            tokens.Add(new TokenEmailItem("Order.ShippingPhoneNumber", order.Address1.Phone ?? ""));
            tokens.Add(new TokenEmailItem("Order.ShippingEmail", order.Address1.Email ?? ""));
            tokens.Add(new TokenEmailItem("Order.ShippingFaxNumber", order.Address1.Fax ?? ""));
            tokens.Add(new TokenEmailItem("Order.ShippingCompany", order.Address1.Company ?? ""));
            tokens.Add(new TokenEmailItem("Order.ShippingAddress1", order.Address1.Address1 ?? ""));
            tokens.Add(new TokenEmailItem("Order.ShippingAddress2", order.Address1.Address2 ?? ""));
            tokens.Add(new TokenEmailItem("Order.PaymentMethod", order.Payment_Method.Name));
            tokens.Add(new TokenEmailItem("Order.VatNumber", order.VAT.ToString()));

            if (order.DateCreated.HasValue)
                tokens.Add(new TokenEmailItem("Order.CreatedOn", order.DateCreated.Value.ToString("dd-MM-yyyy")));

        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public class TokenEmailItem
        {
            private readonly string _key;
            private readonly string _value;
            private readonly bool _neverHtmlEncoded;

            public TokenEmailItem(string key, string value) :
                this(key, value, false)
            {

            }
            public TokenEmailItem(string key, string value, bool neverHtmlEncoded)
            {
                this._key = key;
                this._value = value;
                this._neverHtmlEncoded = neverHtmlEncoded;
            }

            /// <summary>
            /// Token key
            /// </summary>
            public string Key { get { return _key; } }
            /// <summary>
            /// Token value
            /// </summary>
            public string Value { get { return _value; } }
            /// <summary>
            /// Indicates whether this token should not be HTML encoded
            /// </summary>
            public bool NeverHtmlEncoded { get { return _neverHtmlEncoded; } }

            public override string ToString()
            {
                return string.Format("{0}: {1}", Key, Value);
            }
        }
    }
}
