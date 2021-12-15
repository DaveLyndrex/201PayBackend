using BackEnd.Models;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace BackEnd.Services
{
    public class Encryptor : TypeConverter
    {
        private static byte[] keybytes = Encoding.UTF8.GetBytes("cninja1234567890");
        private static byte[] iv = Encoding.UTF8.GetBytes("cninja1234567890");

        private static string DecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv)
        {
            // Check arguments.  
            if (cipherText == null || cipherText.Length <= 0)
            {
                throw new ArgumentNullException("cipherText");
            }
            if (key == null || key.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }
            if (iv == null || iv.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }

            // Declare the string used to hold  
            // the decrypted text.  
            string plaintext = null;

            // Create an RijndaelManaged object  
            // with the specified key and IV.  
            using (var rijAlg = new RijndaelManaged())
            {
                //Settings  
                //rijAlg.Mode = CipherMode.CBC;
                //rijAlg.Padding = PaddingMode.PKCS7;
                rijAlg.FeedbackSize = 128;
                rijAlg.Key = key;
                rijAlg.IV = iv;

                // Create a decrytor to perform the stream transform.  
                var decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                try
                {
                    // Create the streams used for decryption.  
                    using (var msDecrypt = new MemoryStream(cipherText))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {

                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                // Read the decrypted bytes from the decrypting stream  
                                // and place them in a string.  
                                plaintext = srDecrypt.ReadToEnd();

                            }

                        }
                    }
                }
                catch
                {
                    plaintext = "keyError";
                }
            }

            return plaintext;
        }

        public static string EncryptStringToBytes(string plainText)
        {
            // Check arguments.  
            if (plainText == null || plainText.Length <= 0)
            {
                throw new ArgumentNullException("plainText");
            }
            if (keybytes == null || keybytes.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }
            if (iv == null || iv.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }
            byte[] encrypted;
            // Create a RijndaelManaged object  
            // with the specified key and IV.  
            using (var rijAlg = new RijndaelManaged())
            {
                //rijAlg.Mode = CipherMode.CBC;
                //rijAlg.Padding = PaddingMode.PKCS7;
                rijAlg.FeedbackSize = 128;

                rijAlg.Key = keybytes;
                rijAlg.IV = iv;

                // Create a decrytor to perform the stream transform.  
                var encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for encryption.  
                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.  
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(encrypted);
        }
        public static string DecryptStringAES(EncryptedDataModel data)
        {   
            if (data != null)
            {
                var encrypted = Convert.FromBase64String(data.ciphertext);
                var decriptedFromJavascript = DecryptStringFromBytes(encrypted, keybytes, iv);
                return decriptedFromJavascript.ToString();
            }
            else
            {
                return null;
            }
        }

        public static string ObjectToJsonString(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static Object StringToObject(string jsonString, object modelType)
        {
            return JsonConvert.DeserializeObject<object>(jsonString);
        }

        public static string getByParams(HttpRequestMessage request)
        {
            string[] c = new string[] { "ciphertext=" };
            string[] uri = request.RequestUri.AbsoluteUri.Split(c, StringSplitOptions.None);
            return DecryptStringAES(new EncryptedDataModel { ciphertext = uri[1] });

        }
        public static Object getByModel(Type modeltype, EncryptedDataModel text)
        {
            var decrypted = Encryptor.DecryptStringAES(text);
            var ser = new DataContractJsonSerializer(modeltype);
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(decrypted));
            var response = ser.ReadObject(stream);

            return response;
        }

        public static string DecryptGetParams(HttpRequestMessage request)
        {
            string[] c = new string[] { "ciphertext=" };
            string[] uri = request.RequestUri.AbsoluteUri.Split(c, StringSplitOptions.None);
            Uri newUri = new Uri(uri[0] + DecryptStringAES(new EncryptedDataModel { ciphertext = uri[1] }));
            var query = HttpUtility.ParseQueryString(newUri.Query);
            var jsonString = new JavaScriptSerializer().Serialize(query.AllKeys.ToDictionary(k => k, k => query[k]));
            return jsonString;
        }
    }
}