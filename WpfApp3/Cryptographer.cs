using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    class Cryptographer
    {

        static public string Encrypt(string str,int key)
        {
            string res = "";

            for (int i = 0; i < str.Length; i++)
            {
                res += (char)(str[i] ^ key);
            }
            return res;
        }
        static public string Decrypt(string str,int key)
        {
            return Encrypt(str, key);
        }
    }
}
