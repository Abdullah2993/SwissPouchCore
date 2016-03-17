using System.Security.Cryptography;
using Microsoft.AspNet.Mvc;
using SwissPouchCore.Attributes;
using SwissPouchCore.Extensions;

namespace SwissPouchCore.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CryptoController:Controller
    {
        [HttpPost]
        [Owsv("Compute MD5 Hash", "Compute")]
        public string Md5( string data)
        {
            using (var hasher = MD5.Create())
            {
                return hasher.ComputeHash(data.ToBytes()).ToHex().Replace("-", "");
            }
        }

        [HttpPost]
        [Owsv("Compute Sha1 Hash", "Compute")]
        public string Sha1( string data)
        {
            using (var hasher = SHA1.Create())
            {
                return hasher.ComputeHash(data.ToBytes()).ToHex().Replace("-", "");
            }
        }

        [HttpPost]
        [Owsv("Compute Sha256 Hash", "Compute")]
        public string Sha256( string data)
        {
            using (var hasher = SHA256.Create())
            {
                return hasher.ComputeHash(data.ToBytes()).ToHex().Replace("-", "");
            }
        }

        [HttpPost]
        [Owsv("Compute Sha384 Hash", "Compute")]
        public string Sha384( string data)
        {
            using (var hasher = SHA384.Create())
            {
                return hasher.ComputeHash(data.ToBytes()).ToHex().Replace("-", "");
            }
        }
    }
}
