using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace Crypto_Classes_Library
{
    public static class Crypto_SHA512
    {

        public static byte[] ComputeHashToByte(string text)
        {
            Encoding encoding = Encoding.UTF8;
            try
            {
                string _path_ = $@"{Application.StartupPath}\{new Random().Next()}";
                File.WriteAllText(_path_, text, encoding);
                byte[] answer = new byte[] { };
                using (StreamReader sR = new StreamReader(_path_, encoding)) { answer = new SHA512Managed().ComputeHash(sR.BaseStream); sR.Close(); }
                return answer;
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new byte[] { };
            }
        }

        public static byte[] ComputeHashToByte(string path, bool detectEncodingFromByteOrderMarks = true)
        {

            try
            {
                string _path_ = $@"{Application.StartupPath}\{new Random().Next()}";
                Encoding documentEncoding = null;
                using (StreamReader sR = new StreamReader(path, detectEncodingFromByteOrderMarks)) { documentEncoding = sR.CurrentEncoding; sR.Close(); }
                File.WriteAllLines(_path_, File.ReadAllLines(path, documentEncoding), documentEncoding);
                byte[] answer = new byte[] { };
                using (StreamReader sR = new StreamReader(_path_, documentEncoding)) { answer = new SHA512Managed().ComputeHash(sR.BaseStream); sR.Close(); }
                return answer;
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new byte[] { };
            }
        }

        public static byte[] ComputeHashToByte(string path, Encoding encoding)
        {
            try
            {
                string _path_ = $@"{Application.StartupPath}\{new Random().Next()}";
                File.WriteAllLines(_path_, File.ReadAllLines(path, encoding), encoding);
                byte[] answer = new byte[] { };
                using (StreamReader sR = new StreamReader(_path_, encoding)) { answer = new SHA512Managed().ComputeHash(sR.BaseStream); sR.Close(); }
                return answer;
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new byte[] { };
            }
        }

        public static byte[] ComputeHashToByte(IEnumerable<string> enumerableInformations, Encoding encoding)
        {

            try
            {
                string path = $@"{Application.StartupPath}\{new Random().Next()}";
                byte[] answer = new byte[] { };

                File.WriteAllLines(path, enumerableInformations, encoding);
                using (StreamReader sR = new StreamReader(path, true)) { answer = new SHA512Managed().ComputeHash(sR.BaseStream); sR.Close(); }
                File.Delete(path);
                return answer;
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new byte[] { };
            }
        }

        public static byte[] ComputeHashToByte(Stream streamInformations)
        {
            List<byte[]> cI = new List<byte[]>(); //Computed informations
            try
            {
                return new SHA512Managed().ComputeHash(streamInformations);
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new byte[] { };
            }
        }

        public static List<byte[]> ComputeHashToByte(IEnumerable<Stream> enumerableStreamInformations)
        {
            List<byte[]> cI = new List<byte[]>(); //Computed informations
            try
            {
                foreach (var x in enumerableStreamInformations)
                {
                    cI.Add(new SHA512Managed().ComputeHash(x));
                }

                return cI;
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<byte[]>();
            }
        }



        public static string ComputeHashToString(string text)
        {
            Encoding encoding = Encoding.UTF8;
            try
            {
                string _path_ = $@"{Application.StartupPath}\{new Random().Next()}";
                File.WriteAllText(_path_, text, encoding);
                string answer = string.Empty;
                using (StreamReader sR = new StreamReader(_path_, encoding)) { var hash = new SHA512Managed().ComputeHash(sR.BaseStream); int count = -1, maxCount = hash.Count(); foreach (var x in hash) { count++; answer += x; if (count < maxCount - 1) { answer += "."; } } sR.Close(); }
                return answer;
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        public static string ComputeHashToString(string path, bool detectEncodingFromByteOrderMarks = true)
        {

            try
            {
                string _path_ = $@"{Application.StartupPath}\{new Random().Next()}";
                Encoding documentEncoding = null;
                using (StreamReader sR = new StreamReader(path, detectEncodingFromByteOrderMarks)) { documentEncoding = sR.CurrentEncoding; sR.Close(); }
                File.WriteAllLines(_path_, File.ReadAllLines(path, documentEncoding), documentEncoding);
                string answer = string.Empty;
                using (StreamReader sR = new StreamReader(_path_, documentEncoding)) { foreach (var x in new SHA512Managed().ComputeHash(sR.BaseStream)) { answer += x; } sR.Close(); }
                return answer;
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }

        }

        public static string ComputeHashToString(string path, Encoding encoding)
        {
            try
            {
                string _path_ = $@"{Application.StartupPath}\{new Random().Next()}";
                File.WriteAllLines(_path_, File.ReadAllLines(path, encoding), encoding);
                string answer = string.Empty;
                using (StreamReader sR = new StreamReader(_path_, encoding)) { foreach (var x in new SHA512Managed().ComputeHash(sR.BaseStream)) { answer += x; } sR.Close(); }
                return answer;
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        public static string ComputeHashToString(IEnumerable<string> enumerableInformations, Encoding encoding)
        {

            try
            {
                string path = $@"{Application.StartupPath}\{new Random().Next()}";
                string answer = string.Empty;

                File.WriteAllLines(path, enumerableInformations, encoding);
                using (StreamReader sR = new StreamReader(path, true)) { foreach (var x in new SHA512Managed().ComputeHash(sR.BaseStream)) { answer += x; } sR.Close(); }
                File.Delete(path);
                return answer;
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        public static string ComputeHashToString(Stream streamInformations)
        {
            try
            {
                string answer = string.Empty;
                foreach (var x in new SHA512Managed().ComputeHash(streamInformations)) { answer += x; }
                return answer;

            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        public static List<string> ComputeHashToString(IEnumerable<Stream> enumerableStreamInformations)
        {
            List<string> cI = new List<string>(); //Computed informations
            try
            {
                foreach (var x in enumerableStreamInformations)
                {
                    string answer = string.Empty;
                    foreach (var y in new SHA512Managed().ComputeHash(x)) { answer += y; }
                    cI.Add(answer);
                }

                return cI;
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<string>();
            }
        }
    }

    public static class Crypto_SHA384
    {

        public static byte[] ComputeHashToByte(string text)
        {
            Encoding encoding = Encoding.UTF8;
            try
            {
                string _path_ = $@"{Application.StartupPath}\{new Random().Next()}";
                File.WriteAllText(_path_, text, encoding);
                byte[] answer = new byte[] { };
                using (StreamReader sR = new StreamReader(_path_, encoding)) { answer = new SHA384Managed().ComputeHash(sR.BaseStream); sR.Close(); }
                return answer;
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new byte[] { };
            }
        }

        public static byte[] ComputeHashToByte(string path, bool detectEncodingFromByteOrderMarks = true)
        {

            try
            {
                string _path_ = $@"{Application.StartupPath}\{new Random().Next()}";
                Encoding documentEncoding = null;
                using (StreamReader sR = new StreamReader(path, detectEncodingFromByteOrderMarks)) { documentEncoding = sR.CurrentEncoding; sR.Close(); }
                File.WriteAllLines(_path_, File.ReadAllLines(path, documentEncoding), documentEncoding);
                byte[] answer = new byte[] { };
                using (StreamReader sR = new StreamReader(_path_, documentEncoding)) { answer = new SHA384Managed().ComputeHash(sR.BaseStream); sR.Close(); }
                return answer;
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new byte[] { };
            }
        }

        public static byte[] ComputeHashToByte(string path, Encoding encoding)
        {
            try
            {
                string _path_ = $@"{Application.StartupPath}\{new Random().Next()}";
                File.WriteAllLines(_path_, File.ReadAllLines(path, encoding), encoding);
                byte[] answer = new byte[] { };
                using (StreamReader sR = new StreamReader(_path_, encoding)) { answer = new SHA384Managed().ComputeHash(sR.BaseStream); sR.Close(); }
                return answer;
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new byte[] { };
            }
        }

        public static byte[] ComputeHashToByte(IEnumerable<string> enumerableInformations, Encoding encoding)
        {

            try
            {
                string path = $@"{Application.StartupPath}\{new Random().Next()}";
                byte[] answer = new byte[] { };

                File.WriteAllLines(path, enumerableInformations, encoding);
                using (StreamReader sR = new StreamReader(path, true)) { answer = new SHA384Managed().ComputeHash(sR.BaseStream); sR.Close(); }
                File.Delete(path);
                return answer;
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new byte[] { };
            }
        }

        public static byte[] ComputeHashToByte(Stream streamInformations)
        {
            List<byte[]> cI = new List<byte[]>(); //Computed informations
            try
            {
                return new SHA384Managed().ComputeHash(streamInformations);
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new byte[] { };
            }
        }

        public static List<byte[]> ComputeHashToByte(IEnumerable<Stream> enumerableStreamInformations)
        {
            List<byte[]> cI = new List<byte[]>(); //Computed informations
            try
            {
                foreach (var x in enumerableStreamInformations)
                {
                    cI.Add(new SHA384Managed().ComputeHash(x));
                }

                return cI;
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<byte[]>();
            }
        }



        public static string ComputeHashToString(string text)
        {
            Encoding encoding = Encoding.UTF8;
            try
            {
                string _path_ = $@"{Application.StartupPath}\{new Random().Next()}";
                File.WriteAllText(_path_, text, encoding);
                string answer = string.Empty;
                using (StreamReader sR = new StreamReader(_path_, encoding)) { var hash = new SHA384Managed().ComputeHash(sR.BaseStream); int count = -1, maxCount = hash.Count(); foreach (var x in hash) { count++; answer += x; if (count < maxCount - 1) { answer += "."; } } sR.Close(); }
                return answer;
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        public static string ComputeHashToString(string path, bool detectEncodingFromByteOrderMarks = true)
        {

            try
            {
                string _path_ = $@"{Application.StartupPath}\{new Random().Next()}";
                Encoding documentEncoding = null;
                using (StreamReader sR = new StreamReader(path, detectEncodingFromByteOrderMarks)) { documentEncoding = sR.CurrentEncoding; sR.Close(); }
                File.WriteAllLines(_path_, File.ReadAllLines(path, documentEncoding), documentEncoding);
                string answer = string.Empty;
                using (StreamReader sR = new StreamReader(_path_, documentEncoding)) { foreach (var x in new SHA384Managed().ComputeHash(sR.BaseStream)) { answer += x; } sR.Close(); }
                return answer;
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }

        }

        public static string ComputeHashToString(string path, Encoding encoding)
        {
            try
            {
                string _path_ = $@"{Application.StartupPath}\{new Random().Next()}";
                File.WriteAllLines(_path_, File.ReadAllLines(path, encoding), encoding);
                string answer = string.Empty;
                using (StreamReader sR = new StreamReader(_path_, encoding)) { foreach (var x in new SHA384Managed().ComputeHash(sR.BaseStream)) { answer += x; } sR.Close(); }
                return answer;
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        public static string ComputeHashToString(IEnumerable<string> enumerableInformations, Encoding encoding)
        {

            try
            {
                string path = $@"{Application.StartupPath}\{new Random().Next()}";
                string answer = string.Empty;

                File.WriteAllLines(path, enumerableInformations, encoding);
                using (StreamReader sR = new StreamReader(path, true)) { foreach (var x in new SHA384Managed().ComputeHash(sR.BaseStream)) { answer += x; } sR.Close(); }
                File.Delete(path);
                return answer;
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        public static string ComputeHashToString(Stream streamInformations)
        {
            try
            {
                string answer = string.Empty;
                foreach (var x in new SHA384Managed().ComputeHash(streamInformations)) { answer += x; }
                return answer;

            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        public static List<string> ComputeHashToString(IEnumerable<Stream> enumerableStreamInformations)
        {
            List<string> cI = new List<string>(); //Computed informations
            try
            {
                foreach (var x in enumerableStreamInformations)
                {
                    string answer = string.Empty;
                    foreach (var y in new SHA384Managed().ComputeHash(x)) { answer += y; }
                    cI.Add(answer);
                }

                return cI;
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<string>();
            }
        }
    }

    public static class Crypto_SHA256
    {
        public static byte[] ComputeHashToByte(string text)
        {
            Encoding encoding = Encoding.UTF8;
            try
            {
                string _path_ = $@"{Application.StartupPath}\{new Random().Next()}";
                File.WriteAllText(_path_, text, encoding);
                byte[] answer = new byte[] { };
                using (StreamReader sR = new StreamReader(_path_, encoding)) { answer = new SHA256Managed().ComputeHash(sR.BaseStream); sR.Close(); }
                return answer;
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new byte[] { };
            }
        }

        public static byte[] ComputeHashToByte(string path, bool detectEncodingFromByteOrderMarks = true)
        {

            try
            {
                string _path_ = $@"{Application.StartupPath}\{new Random().Next()}";
                Encoding documentEncoding = null;
                using (StreamReader sR = new StreamReader(path, detectEncodingFromByteOrderMarks)) { documentEncoding = sR.CurrentEncoding; sR.Close(); }
                File.WriteAllLines(_path_, File.ReadAllLines(path, documentEncoding), documentEncoding);
                byte[] answer = new byte[] { };
                using (StreamReader sR = new StreamReader(_path_, documentEncoding)) { answer = new SHA256Managed().ComputeHash(sR.BaseStream); sR.Close(); }
                return answer;
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new byte[] { };
            }
        }

        public static byte[] ComputeHashToByte(string path, Encoding encoding)
        {
            try
            {
                string _path_ = $@"{Application.StartupPath}\{new Random().Next()}";
                File.WriteAllLines(_path_, File.ReadAllLines(path, encoding), encoding);
                byte[] answer = new byte[] { };
                using (StreamReader sR = new StreamReader(_path_, encoding)) { answer = new SHA256Managed().ComputeHash(sR.BaseStream); sR.Close(); }
                return answer;
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new byte[] { };
            }
        }

        public static byte[] ComputeHashToByte(IEnumerable<string> enumerableInformations, Encoding encoding)
        {

            try
            {
                string path = $@"{Application.StartupPath}\{new Random().Next()}";
                byte[] answer = new byte[] { };

                File.WriteAllLines(path, enumerableInformations, encoding);
                using (StreamReader sR = new StreamReader(path, true)) { answer = new SHA256Managed().ComputeHash(sR.BaseStream); sR.Close(); }
                File.Delete(path);
                return answer;
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new byte[] { };
            }
        }

        public static byte[] ComputeHashToByte(Stream streamInformations)
        {
            List<byte[]> cI = new List<byte[]>(); //Computed informations
            try
            {
                return new SHA256Managed().ComputeHash(streamInformations);
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new byte[] { };
            }
        }

        public static List<byte[]> ComputeHashToByte(IEnumerable<Stream> enumerableStreamInformations)
        {
            List<byte[]> cI = new List<byte[]>(); //Computed informations
            try
            {
                foreach (var x in enumerableStreamInformations)
                {
                    cI.Add(new SHA256Managed().ComputeHash(x));
                }

                return cI;
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<byte[]>();
            }
        }



        public static string ComputeHashToString(string text)
        {
            Encoding encoding = Encoding.UTF8;
            try
            {
                string _path_ = $@"{Application.StartupPath}\{new Random().Next()}";
                File.WriteAllText(_path_, text, encoding);
                string answer = string.Empty;
                using (StreamReader sR = new StreamReader(_path_, encoding)) { var hash = new SHA256Managed().ComputeHash(sR.BaseStream); int count = -1, maxCount = hash.Count(); foreach (var x in hash) { count++; answer += x; if (count < maxCount - 1) { answer += "."; } } sR.Close(); }
                return answer;
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        public static string ComputeHashToString(string path, bool detectEncodingFromByteOrderMarks = true)
        {

            try
            {
                string _path_ = $@"{Application.StartupPath}\{new Random().Next()}";
                Encoding documentEncoding = null;
                using (StreamReader sR = new StreamReader(path, detectEncodingFromByteOrderMarks)) { documentEncoding = sR.CurrentEncoding; sR.Close(); }
                File.WriteAllLines(_path_, File.ReadAllLines(path, documentEncoding), documentEncoding);
                string answer = string.Empty;
                using (StreamReader sR = new StreamReader(_path_, documentEncoding)) { foreach (var x in new SHA256Managed().ComputeHash(sR.BaseStream)) { answer += x; } sR.Close(); }
                return answer;
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }

        }

        public static string ComputeHashToString(string path, Encoding encoding)
        {
            try
            {
                string _path_ = $@"{Application.StartupPath}\{new Random().Next()}";
                File.WriteAllLines(_path_, File.ReadAllLines(path, encoding), encoding);
                string answer = string.Empty;
                using (StreamReader sR = new StreamReader(_path_, encoding)) { foreach (var x in new SHA256Managed().ComputeHash(sR.BaseStream)) { answer += x; } sR.Close(); }
                return answer;
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        public static string ComputeHashToString(IEnumerable<string> enumerableInformations, Encoding encoding)
        {

            try
            {
                string path = $@"{Application.StartupPath}\{new Random().Next()}";
                string answer = string.Empty;

                File.WriteAllLines(path, enumerableInformations, encoding);
                using (StreamReader sR = new StreamReader(path, true)) { foreach (var x in new SHA256Managed().ComputeHash(sR.BaseStream)) { answer += x; } sR.Close(); }
                File.Delete(path);
                return answer;
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        public static string ComputeHashToString(Stream streamInformations)
        {
            try
            {
                string answer = string.Empty;
                foreach (var x in new SHA256Managed().ComputeHash(streamInformations)) { answer += x; }
                return answer;

            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        public static List<string> ComputeHashToString(IEnumerable<Stream> enumerableStreamInformations)
        {
            List<string> cI = new List<string>(); //Computed informations
            try
            {
                foreach (var x in enumerableStreamInformations)
                {
                    string answer = string.Empty;
                    foreach (var y in new SHA256Managed().ComputeHash(x)) { answer += y; }
                    cI.Add(answer);
                }

                return cI;
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<string>();
            }
        }

    }

    public static class Crypto_AES
    {
        /// <summary>
        /// Generate a byte array for secret key and initialization vector.
        /// </summary>        
        /// <returns></returns>
        public static Tuple<byte[], byte[]> Generate_Key_IV()
        {
            Aes aes = Aes.Create();
            return new Tuple<byte[], byte[]>(aes.Key, aes.IV);
        }



        public static byte[] EncryptToByte(Stream document, byte[] secretKey, byte[] initializationVector)
        {
            try
            {
                Aes aes = Aes.Create();
                aes.Key = secretKey;
                aes.IV = initializationVector;

                var encrypt = aes.CreateEncryptor(secretKey, initializationVector);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encrypt, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            using (StreamReader sR = new StreamReader(document, true))
                            {
                                swEncrypt.Write(sR.ReadToEnd());
                            }
                        }
                        return msEncrypt.ToArray();
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new byte[] { };
            }
        }

        public static byte[] EncryptToByte(string text, byte[] secretKey, byte[] initializationVector)
        {
            try
            {


                Aes aes = Aes.Create();
                aes.Key = secretKey;
                aes.IV = initializationVector;

                var encrypt = aes.CreateEncryptor(secretKey, initializationVector);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encrypt, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.                        
                            swEncrypt.Write(text);
                        }
                        return msEncrypt.ToArray();
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new byte[] { };
            }
        }

        public static byte[] EncryptToByte(string path, byte[] secretKey, byte[] initializationVector, bool detectEncodingFromByteOrderMarks = true)
        {

            try
            {
                Aes aes = Aes.Create();
                aes.Key = secretKey;
                aes.IV = initializationVector;

                var encrypt = aes.CreateEncryptor(secretKey, initializationVector);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encrypt, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            StreamReader sR = new StreamReader(path, detectEncodingFromByteOrderMarks);
                            string text = sR.ReadToEnd();
                            sR.Close();
                            //Write all data to the stream.                        
                            swEncrypt.Write(text);
                        }
                        return msEncrypt.ToArray();
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new byte[] { };
            }
        }

        public static byte[] EncryptToByte(string path, byte[] secretKey, byte[] initializationVector, Encoding encoding)
        {
            try
            {
                Aes aes = Aes.Create();
                aes.Key = secretKey;
                aes.IV = initializationVector;

                var encrypt = aes.CreateEncryptor(secretKey, initializationVector);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encrypt, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            StreamReader sR = new StreamReader(path, encoding);
                            string text = sR.ReadToEnd();
                            sR.Close();
                            //Write all data to the stream.                        
                            swEncrypt.Write(text);
                        }
                        return msEncrypt.ToArray();
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new byte[] { };
            }
        }

        public static byte[] EncryptToByte(IEnumerable<string> enumerableInformations, byte[] secretKey, byte[] initializationVector, Encoding encoding)
        {

            try
            {

                byte[] answer = new byte[] { };



                Aes aes = Aes.Create();
                aes.Key = secretKey;
                aes.IV = initializationVector;

                var encrypt = aes.CreateEncryptor(secretKey, initializationVector);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encrypt, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            string text = string.Empty;
                            int forCount = -1, iEnumCount = enumerableInformations.Count();
                            foreach (var x in enumerableInformations) { forCount++; text += x; if (forCount < iEnumCount) { text += "\n"; } }
                            //Write all data to the stream.                        
                            swEncrypt.Write(text);
                        }
                        return msEncrypt.ToArray();
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new byte[] { };
            }
        }

        public static List<byte[]> EncryptToByte(IEnumerable<Stream> enumerableStreamInformations, byte[] secretKey, byte[] initializationVector)
        {
            List<byte[]> cI = new List<byte[]>(); //Computed informations
            try
            {
                Aes aes = Aes.Create();
                aes.Key = secretKey;
                aes.IV = initializationVector;

                var encrypt = aes.CreateEncryptor(secretKey, initializationVector);
                foreach (var x in enumerableStreamInformations)
                {

                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encrypt, CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {
                                //Write all data to the stream.
                                using (StreamReader sR = new StreamReader(x, true))
                                {
                                    swEncrypt.Write(sR.ReadToEnd());
                                }
                            }
                            cI.Add(msEncrypt.ToArray());
                        }
                    }
                }

                return cI;
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<byte[]>();
            }
        }




        public static string[] EncryptToStringArrayByte(Stream document, byte[] secretKey, byte[] initializationVector)
        {
            try
            {
                Aes aes = Aes.Create();
                aes.Key = secretKey;
                aes.IV = initializationVector;

                var encrypt = aes.CreateEncryptor(secretKey, initializationVector);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encrypt, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            using (StreamReader sR = new StreamReader(document, true))
                            {
                                swEncrypt.Write(sR.ReadToEnd());
                            }
                        }
                        return ConvertToStringArray(msEncrypt.ToArray());
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new string[] { };
            }
        }

        public static string[] EncryptToStringArrayByte(string text, byte[] secretKey, byte[] initializationVector)
        {
            try
            {


                Aes aes = Aes.Create();
                aes.Key = secretKey;
                aes.IV = initializationVector;

                var encrypt = aes.CreateEncryptor(secretKey, initializationVector);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encrypt, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.                        
                            swEncrypt.Write(text);
                        }
                        return ConvertToStringArray(msEncrypt.ToArray());
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new string[] { };
            }
        }

        public static string[] EncryptToStringArrayByte(string path, byte[] secretKey, byte[] initializationVector, bool detectEncodingFromByteOrderMarks = true)
        {

            try
            {
                Aes aes = Aes.Create();
                aes.Key = secretKey;
                aes.IV = initializationVector;

                var encrypt = aes.CreateEncryptor(secretKey, initializationVector);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encrypt, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            StreamReader sR = new StreamReader(path, detectEncodingFromByteOrderMarks);
                            string text = sR.ReadToEnd();
                            sR.Close();
                            //Write all data to the stream.                        
                            swEncrypt.Write(text);
                        }
                        return ConvertToStringArray(msEncrypt.ToArray());
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new string[] { };
            }
        }

        public static string[] EncryptToStringArrayByte(string path, byte[] secretKey, byte[] initializationVector, Encoding encoding)
        {
            try
            {
                Aes aes = Aes.Create();
                aes.Key = secretKey;
                aes.IV = initializationVector;

                var encrypt = aes.CreateEncryptor(secretKey, initializationVector);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encrypt, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            StreamReader sR = new StreamReader(path, encoding);
                            string text = sR.ReadToEnd();
                            sR.Close();
                            //Write all data to the stream.                        
                            swEncrypt.Write(text);
                        }
                        return ConvertToStringArray(msEncrypt.ToArray());
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new string[] { };
            }
        }

        public static string[] EncryptToStringArrayByte(IEnumerable<string> enumerableInformations, byte[] secretKey, byte[] initializationVector, Encoding encoding)
        {

            try
            {

                byte[] answer = new byte[] { };



                Aes aes = Aes.Create();
                aes.Key = secretKey;
                aes.IV = initializationVector;

                var encrypt = aes.CreateEncryptor(secretKey, initializationVector);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encrypt, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            string text = string.Empty;
                            int forCount = -1, iEnumCount = enumerableInformations.Count();
                            foreach (var x in enumerableInformations) { forCount++; text += x; if (forCount < iEnumCount) { text += "\n"; } }

                            //Write all data to the stream.                        
                            swEncrypt.Write(text);
                        }
                        return ConvertToStringArray(msEncrypt.ToArray());
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new string[] { };
            }
        }

        public static List<string[]> EncryptToStringArrayByte(IEnumerable<Stream> enumerableStreamInformations, byte[] secretKey, byte[] initializationVector)
        {
            List<byte[]> cI = new List<byte[]>(); //Computed informations
            try
            {
                Aes aes = Aes.Create();
                aes.Key = secretKey;
                aes.IV = initializationVector;

                var encrypt = aes.CreateEncryptor(secretKey, initializationVector);
                foreach (var x in enumerableStreamInformations)
                {

                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encrypt, CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {
                                //Write all data to the stream.
                                using (StreamReader sR = new StreamReader(x, true))
                                {
                                    swEncrypt.Write(sR.ReadToEnd());
                                }
                            }
                            cI.Add(msEncrypt.ToArray());
                        }
                    }
                }

                return ConvertToStringArray(cI);
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<string[]>();
            }
        }


        static string[] ConvertToStringArray(byte[] hash)
        {
            string[] stringHash = new string[hash.Length];
            for (int i = 0; i < hash.Length; i++)
            {
                stringHash[i] = $"{hash[i]}";
            }
            return stringHash;
        }

        static List<string[]> ConvertToStringArray(IEnumerable<byte[]> hashCollection)
        {
            List<string[]> listStrignHash = new List<string[]>();

            foreach (var hash in hashCollection)
            {
                string[] stringHash = new string[hash.Length];
                for (int i = 0; i < hash.Length; i++)
                {
                    stringHash[i] = $"{hash[i]}";
                }
                listStrignHash.Add(stringHash);
            }
            return listStrignHash;
        }




        public static string EncryptToString(Stream document, byte[] secretKey, byte[] initializationVector)
        {
            try
            {
                Aes aes = Aes.Create();
                aes.Key = secretKey;
                aes.IV = initializationVector;

                var encrypt = aes.CreateEncryptor(secretKey, initializationVector);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encrypt, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            using (StreamReader sR = new StreamReader(document, true))
                            {
                                swEncrypt.Write(sR.ReadToEnd());
                            }
                        }

                        byte[] hash = msEncrypt.ToArray();
                        string answer = string.Empty;
                        int count = -1, maxCount = hash.Count(); foreach (var x in hash) { count++; answer += x; if (count < maxCount - 1) { answer += "."; } }
                        return answer;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        public static string EncryptToString(string text, byte[] secretKey, byte[] initializationVector)
        {
            try
            {
                Aes aes = Aes.Create();
                aes.Key = secretKey;
                aes.IV = initializationVector;

                var encrypt = aes.CreateEncryptor(secretKey, initializationVector);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encrypt, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.                        
                            swEncrypt.Write(text);
                        }
                        byte[] hash = msEncrypt.ToArray();
                        string answer = string.Empty;
                        int count = -1, maxCount = hash.Count(); foreach (var x in hash) { count++; answer += x; if (count < maxCount - 1) { answer += "."; } }
                        return answer;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        public static string EncryptToString(string path, byte[] secretKey, byte[] initializationVector, bool detectEncodingFromByteOrderMarks = true)
        {

            try
            {
                Aes aes = Aes.Create();
                aes.Key = secretKey;
                aes.IV = initializationVector;

                var encrypt = aes.CreateEncryptor(secretKey, initializationVector);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encrypt, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            StreamReader sR = new StreamReader(path, detectEncodingFromByteOrderMarks);
                            string text = sR.ReadToEnd();
                            sR.Close();
                            //Write all data to the stream.                        
                            swEncrypt.Write(text);
                        }
                        byte[] hash = msEncrypt.ToArray();
                        string answer = string.Empty;
                        int count = -1, maxCount = hash.Count(); foreach (var x in hash) { count++; answer += x; if (count < maxCount - 1) { answer += "."; } }
                        return answer;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        public static string EncryptToString(string path, byte[] secretKey, byte[] initializationVector, Encoding encoding)
        {
            try
            {
                Aes aes = Aes.Create();
                aes.Key = secretKey;
                aes.IV = initializationVector;

                var encrypt = aes.CreateEncryptor(secretKey, initializationVector);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encrypt, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            StreamReader sR = new StreamReader(path, encoding);
                            string text = sR.ReadToEnd();
                            sR.Close();
                            //Write all data to the stream.                        
                            swEncrypt.Write(text);
                        }
                        byte[] hash = msEncrypt.ToArray();
                        string answer = string.Empty;
                        int count = -1, maxCount = hash.Count(); foreach (var x in hash) { count++; answer += x; if (count < maxCount - 1) { answer += "."; } }
                        return answer;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        public static string EncryptToString(IEnumerable<string> enumerableInformations, byte[] secretKey, byte[] initializationVector, Encoding encoding)
        {

            try
            {


                Aes aes = Aes.Create();
                aes.Key = secretKey;
                aes.IV = initializationVector;

                var encrypt = aes.CreateEncryptor(secretKey, initializationVector);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encrypt, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            string text = string.Empty;
                            int forCount = -1, iEnumCount = enumerableInformations.Count();
                            foreach (var x in enumerableInformations) { forCount++; text += x; if (forCount < iEnumCount) { text += "\n"; } }
                            //Write all data to the stream.                        
                            swEncrypt.Write(text);
                        }
                        byte[] hash = msEncrypt.ToArray();
                        string answer = string.Empty;
                        int count = -1, maxCount = hash.Count(); foreach (var x in hash) { count++; answer += x; if (count < maxCount - 1) { answer += "."; } }
                        return answer;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        public static List<string> EncryptToString(IEnumerable<Stream> enumerableStreamInformations, byte[] secretKey, byte[] initializationVector)
        {
            List<string> cI = new List<string>(); //Computed informations
            try
            {
                Aes aes = Aes.Create();
                aes.Key = secretKey;
                aes.IV = initializationVector;

                var encrypt = aes.CreateEncryptor(secretKey, initializationVector);
                foreach (var x in enumerableStreamInformations)
                {

                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encrypt, CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {
                                //Write all data to the stream.
                                using (StreamReader sR = new StreamReader(x, true))
                                {
                                    swEncrypt.Write(sR.ReadToEnd());
                                }
                            }

                            byte[] hash = msEncrypt.ToArray();
                            string answer = string.Empty;
                            int count = -1, maxCount = hash.Count(); foreach (var y in hash) { count++; answer += y; if (count < maxCount - 1) { answer += "."; } }
                            cI.Add(answer);
                        }
                    }
                }

                return cI;
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<string>();
            }
        }



        public static string Decrypt(byte[] hash, byte[] secretKey, byte[] initializationVector)
        {
            try
            {
                Aes aes = Aes.Create();
                aes.Key = secretKey;
                aes.IV = initializationVector;

                var decrypt = aes.CreateDecryptor(secretKey, initializationVector);

                using (MemoryStream msDecrypt = new MemoryStream(hash))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decrypt, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }


            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }

        }

        public static string Decrypt(string[] hash, byte[] secretKey, byte[] initializationVector)
        {
            try
            {
                Aes aes = Aes.Create();
                aes.Key = secretKey;
                aes.IV = initializationVector;

                byte[] _hash_ = new byte[hash.Length];
                for (int i = 0; i < hash.Length; i++)
                {
                    _hash_[i] = Convert.ToByte(hash[i]);
                }

                var decrypt = aes.CreateDecryptor(secretKey, initializationVector);

                using (MemoryStream msDecrypt = new MemoryStream(_hash_))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decrypt, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }


            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }

        }

        public static List<string> Decrypt(IEnumerable<byte[]> hashs, byte[] secretKey, byte[] initializationVector)
        {
            try
            {
                List<string> dI = new List<string>();//decryptographed information

                Aes aes = Aes.Create();
                aes.Key = secretKey;
                aes.IV = initializationVector;

                var decrypt = aes.CreateDecryptor(secretKey, initializationVector);

                foreach (var hash in hashs)
                {
                    using (MemoryStream msDecrypt = new MemoryStream(hash))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decrypt, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {

                                // Read the decrypted bytes from the decrypting stream
                                // and place them in a string.
                                dI.Add(srDecrypt.ReadToEnd());
                            }
                        }
                    }
                }
                return dI;


            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<string>();
            }
        }
    }

    public enum Crypto
    {
        Crypto_SHA512,
        Crypto_SHA384,
        Crypto_SHA256,
        Crypto_Aes
    }

}
