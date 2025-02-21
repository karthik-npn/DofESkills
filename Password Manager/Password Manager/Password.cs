using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Password_Manager
{
    public class Password
    {
        public string Website { get; set; }

        [DisplayName("User")]
        public string Username { get; set; }

        [Browsable(false)]
        public string PwdJN
        {
            get
            {
                return EnCrypt(Pwd);
            }
            set
            {
                Pwd = Decrypt(value);
            }
        }

        [DisplayName("Password")]
        [JsonIgnore]
        public string Pwd { get; set; }
        public string Notes { get; set; }

        private static string EnCrypt(string text)
        {
            return Convert.ToBase64String(
                ProtectedData.Protect(
                    Encoding.Unicode.GetBytes(text), null, DataProtectionScope.LocalMachine));
        }

        private static string Decrypt(string text)
        {
            return Encoding.Unicode.GetString(
                ProtectedData.Unprotect(
                     Convert.FromBase64String(text), null, DataProtectionScope.LocalMachine));
        }
    }
}