using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;

namespace Password_Manager
{
    public class Password // creates a class called password that can be used throughout the program because it is public
    {
        public string Website { get; set; } // creates a property called Website that can be used to store the website

        [DisplayName("User")] // attribute is used to change the name of the column in the datagrid
        public string Username { get; set; } // creates a property called Username that can be used to store the username

        [Browsable(false)]
        public string PwdJN // used to store the password in the json file securely
        {
            get
            {
                return EnCrypt(Pwd); // makes its value equal to the encrypted password
            }
            set
            {
                Pwd = Decrypt(value); // makes the password equal to the decrypted value
            }
        }

        [DisplayName("Password")] // attribute is used to change the name of the column in the datagrid
        [JsonIgnore]
        public string Pwd { get; set; } // creates a property called Pwd that can be used to store the password
        public string Notes { get; set; } // creates a property called Notes that can be used to store the notes

        private static string EnCrypt(string text) //encrytpts the test by using a byte array
        {
            return Convert.ToBase64String(
                ProtectedData.Protect(
                    Encoding.Unicode.GetBytes(text), null, DataProtectionScope.LocalMachine));
        }

        private static string Decrypt(string text) //decrypts the text by using a byte array
        {
            return Encoding.Unicode.GetString(
                ProtectedData.Unprotect(
                     Convert.FromBase64String(text), null, DataProtectionScope.LocalMachine));
        }
    }
}