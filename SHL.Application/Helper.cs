using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace SHL.Application
{


    public static class StringExtensions
    {
        private const string _passPhrase = "siswiusj34938322*";
        private static readonly byte[] initVectorBytes = Encoding.ASCII.GetBytes("tu89geji340t89u2");
        private const int keysize = 256;

        public static byte[] GenerateKey(string passphrase, int keySize = 256, int iterations = 10000)
        {
            using (var deriveBytes = new Rfc2898DeriveBytes(passphrase, saltSize: 16, iterations))
            {
                return deriveBytes.GetBytes(keySize / 8);
            }
        }
        public static string Encrypt(this string plainText, string passPhrase = "")
        {
            
            passPhrase = string.IsNullOrWhiteSpace(passPhrase) ? _passPhrase : passPhrase;
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null))
            {
                byte[] keyBytes = password.GetBytes(keysize / 8);
                using (RijndaelManaged symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.Mode = CipherMode.CBC;
                    using (ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes))
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                byte[] cipherTextBytes = memoryStream.ToArray();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }

        }

        public static string Decrypt(this string cipherText, string passPhrase = "")
        {
            
            passPhrase = string.IsNullOrWhiteSpace(passPhrase) ? _passPhrase : passPhrase;
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            using (PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null))
            {
                byte[] keyBytes = password.GetBytes(keysize / 8);
                using (RijndaelManaged symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.Mode = CipherMode.CBC;
                    //symmetricKey.Padding = PaddingMode.None;
                    using (ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes))
                    {
                        using (MemoryStream memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                                int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                            }
                        }
                    }
                }
            }
        }

    }
    public static class StringHelperExtension
    {
        public static string StripeHtml(this string input)
        {
            // Will this simple expression replace all tags???
            var tagsExpression = new Regex(@"</?.+?>");
            return tagsExpression.Replace(input, " ");
        }
    }




    public class Helper
    {
        public static string GenerateRandomOTP(int iOtpLength)
        {
            var sOtp = string.Empty;
            var rand = new Random();

            for (var i = 0; i < iOtpLength; i++)
            {
                var p = rand.Next(0, _otpAllowedChars.Length);
                var sTempChars = _otpAllowedChars[rand.Next(0, _otpAllowedChars.Length)];
                sOtp += sTempChars;
            }
            return sOtp;
        }

        public static int? GetCount(object @object)
        {
            var collection = @object as ICollection;
            return collection?.Count;
        }

    }

}
