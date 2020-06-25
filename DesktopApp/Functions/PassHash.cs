using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DesktopApp.Functions
{
    class PassHash
    {
        public string PassHashResult(string passwordData)
        {
            SHA1 encryptor = SHA1.Create();
            byte[] hashdata = encryptor.ComputeHash(Encoding.Default.GetBytes(passwordData));
            StringBuilder stb = new StringBuilder();

            for (int i = 0; i < hashdata.Length; i++)
            {
                stb.Append(hashdata[i].ToString());
            }
            return stb.ToString();
        }
    }
}
