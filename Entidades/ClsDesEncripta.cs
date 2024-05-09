using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Entidades
{
    public class ClsDesEncripta
    {
        #region Variables Privadas

        private TripleDESCryptoServiceProvider TripleDes = new TripleDESCryptoServiceProvider();
        private const string miKey = "MILLENIUM2010";

        #endregion

        #region Constructor

        public ClsDesEncripta()
        {
            // Inicializamos nuestra clase nuestro.
            string key = System.Convert.ToString("MILLENIUM2010");
            TripleDes.Key = TruncateHash(key, TripleDes.KeySize / 8);
            TripleDes.IV = TruncateHash("", TripleDes.BlockSize / 8);
        }

        #endregion

        #region Funciones

        private byte[] TruncateHash(string key, int length)
        {

            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();

            byte[] keyBytes = System.Text.Encoding.Unicode.GetBytes(key);
            byte[] hash = sha1.ComputeHash(keyBytes);

            Array.Resize(ref hash, length - 1 + 1);
            return hash;

        }

        public string Encripta(string sEncripta)
        {

            // convertimos la cadena a un arregl ode bytes
            byte[] aEncripta = System.Text.Encoding.Unicode.GetBytes(sEncripta);

            //Creamos el stream
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            //creamos el codificados para escribirlo en el stream
            CryptoStream encStream = new CryptoStream(ms, TripleDes.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write);

            // Usamos el crypto stream para escribir el arreglo de bytes en el stream
            encStream.Write(aEncripta, 0, aEncripta.Length);
            encStream.FlushFinalBlock();

            // lo convertimos a cadena
            return Convert.ToBase64String(ms.ToArray());

        }

        public string Desencripta(string sEncriptado)
        {

            // Convierte el texto encriptado en un arreglo de bytes
            byte[] encryptedBytes = Convert.FromBase64String(sEncriptado);

            // Creamos el Stream
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            // Creamos el decodificador para escribir en el stream
            CryptoStream decStream = new CryptoStream(ms, TripleDes.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write);

            //Uso el crypto stream para escribir el arreglo de bytes al stream
            decStream.Write(encryptedBytes, 0, encryptedBytes.Length);
            decStream.FlushFinalBlock();

            //convertimos el strea, a cadena
            return System.Text.Encoding.Unicode.GetString(ms.ToArray());
        }

        #endregion

    }
}