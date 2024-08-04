using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Comman
{
    public static class General
    {
        #region DataTable to List Conversation
        public static List<T> ToList<T>(this DataTable table) where T : new()
        {
            List<T> list = new List<T>();

            foreach (DataRow row in table.Rows)
            {
                T obj = new T();

                foreach (var prop in typeof(T).GetProperties())
                {
                    if (table.Columns.Contains(prop.Name) && !DBNull.Value.Equals(row[prop.Name]))
                    {
                        prop.SetValue(obj, Convert.ChangeType(row[prop.Name], prop.PropertyType), null);
                    }
                }

                list.Add(obj);
            }

            return list;
        }
        #endregion

        #region HelthStatus Enum
        public enum HealthStatus
        {
            Normal = 1,
            High = 2,
            Low = 3
        }
        #endregion

        #region EncryptString 

        public static string EncryptString(string plainText, string Key, string IV)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(Key);
                aesAlg.IV = Encoding.UTF8.GetBytes(IV);

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        return Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }
            }
        }
        #endregion

        #region DecryptString
        public static string DecryptString(string cipherText, string Key,string IV )
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(Key);
                aesAlg.IV = Encoding.UTF8.GetBytes(IV);

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }


        #endregion

    }
}
