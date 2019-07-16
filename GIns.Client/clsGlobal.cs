using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using System.IO;

namespace GIns.Client
{
    public class clsGlobal
    {
        //--------------------------------------------------------------------
        //Convert C# object to json string object for web api transfer
        //--------------------------------------------------------------------
        public static StringContent GetStringContent(object obj)
            => new StringContent(JsonConvert.SerializeObject(obj), Encoding.Default, "application/json");


        public static StringContent GetStringContent_UTF8(object obj)
                => new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");


        public static StringContent GetStringContent_UTF32(object obj)
                => new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF32, "application/json");


        public static StringContent GetStringContent_ASCII(object obj)
                => new StringContent(JsonConvert.SerializeObject(obj), Encoding.ASCII, "application/json");


        public static StringContent GetStringContent_Uni(object obj)
                => new StringContent(JsonConvert.SerializeObject(obj), Encoding.Unicode, "application/json");


        // Encrypt a file.
        public static void AddEncryption(string FileName)
        {

            File.Encrypt(FileName);

        }

        // Decrypt a file.
        public static void RemoveEncryption(string FileName)
        {
            File.Decrypt(FileName);
        }
    }
}
