using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Xml;
using System.Xml.Schema;

namespace FN
{
    public class FN
    {
        public static string GetCRC(ref byte[] file)
        {
            byte[] hash = null;

            if (file == null) return string.Empty;

            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();

            sha1.ComputeHash(file);
            hash = sha1.Hash;

            return ByteArrayToString(ref hash);
        }

        public static string ByteArrayToString(ref byte[] arr)
        {
            StringBuilder sb = new StringBuilder(arr.Length);

            for (int i = 0; i < arr.Length; i++)
            {
                sb.Append(arr[i].ToString("X2"));
            }

            return sb.ToString();
        }

        public static string XmlRead(string path, Encoding encoding)
        {
            string result;
            using (StreamReader streamReader = new StreamReader(path, encoding))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }

        public static int XmlValidate(ref MemoryStream xml, ref XmlReader xsd)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(null, xsd);
            settings.ValidationType = ValidationType.Schema;
            XmlDocument document = new XmlDocument();

            try
            {
                document.Load(xml);
            }
            catch
            {
                return 1;
            }

            try
            {
                XmlReader reader = XmlReader.Create(new StringReader(document.InnerXml), settings);
                while (reader.Read()) ;
            }
            catch
            {
                return 2;
            }

            return 0;
        }
    }
}
