using System;
using System.Net;
using System.Text;
using Microsoft.AspNet.Mvc;
using SwissPouchCore.Attributes;
using SwissPouchCore.Extensions;

namespace SwissPouchCore.Controllers
{
    [Route("api/[controller]/[action]/")]
    public class UtilitiesController:Controller
    {
        [HttpPost]
        [Owsv("Convert To Upper Case", "Convert")]
        public string ToUpper(string data)
        {
            return data.ToUpper();
        }

        [HttpPost]
        [Owsv("Convert To Lower Case", "Convert")]
        public string ToLower(string data)
        {
            return data.ToLower();
        }

        [HttpPost]
        [Owsv("To Hex String", "Convert")]
        public string ToHexString(string data)
        {
            return data.ToBytes().ToHex();
        }

        [HttpPost]
        [Twsv("Base64 Encode/Decode", "Encode", "Decode")]
        public string Base64(int id, string data)
        {
            try
            {
                if (id == 1) return Convert.ToBase64String(data.ToBytes());
                if (id == 2) return Encoding.UTF8.GetString(Convert.FromBase64String(data));
            }
            catch
            {
                // ignored
            }
            return string.Empty;
        }

        [HttpPost]
        [Twsv("Html Encode/Decode", "Encode", "Decode")]
        public string Html(int id, string data)
        {
            try
            {
                if (id == 1) return WebUtility.HtmlEncode(data);
                if (id == 2) return WebUtility.HtmlDecode(data);
            }
            catch
            {
                //ignore
            }
            return string.Empty;
        }

        [HttpPost]
        [Twsv("URL Encode/Decode", "Encode", "Decode")]
        public string Uri(int id, string data)
        {
            try
            {
                if (id == 1) return WebUtility.UrlEncode(data);
                if (id == 2) return WebUtility.UrlDecode(data);
            }
            catch
            {
                //ignore
            }
            return string.Empty;
        }
    }
}
