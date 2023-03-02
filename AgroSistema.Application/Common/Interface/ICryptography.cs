using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Common.Interface
{
    public interface ICryptography
    {
        string Encrypt(string plainText, string key, string iv);
        string Encrypt(string plainText);
        string Decrypt(string cipherText, string key, string iv);
        string Decrypt(string cipherText);
        bool TryDecrypt(string cipherText, out string result);
    }
}
