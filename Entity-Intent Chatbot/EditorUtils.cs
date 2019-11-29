using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace aytimothy.EIChatbot.Editor
{
    public class EditorUtils {
        /// <summary>
        /// Converts a byte array into a hexdecimal string.
        /// </summary>
        /// <remarks>
        /// https://stackoverflow.com/a/311179/3505377
        /// </remarks>
        /// <param name="bytes">The byte array to convert into string.</param>
        /// <returns>The resulting hexdecimal string.</returns>
        public string ByteArrayToHexString(byte[] bytes) {
            StringBuilder hex = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        /// <summary>
        /// Converts a hexdecimal string into a byte array.
        /// </summary>
        /// <remarks>
        /// https://stackoverflow.com/a/311179/3505377
        /// </remarks>
        /// <param name="hex">The string to convert into a byte array.</param>
        /// <returns>The resulting byte array.</returns>
        public byte[] HexStringToByteArray(string hex) {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        /// <summary>
        /// Generates the next unique GUID (or UUID) based on the current time.
        /// </summary>
        /// <remarks>
        /// Should always be unique, at least 99.999999999999999999999999% of the time.
        /// </remarks>
        /// <returns>A byte array representing the current GUID.</returns>
        public byte[] GenerateNextUUID() {
            SHA256 sha256 = SHA256.Create();

            DateTime timestamp = DateTime.Now;
            string guidGeneratorPayload = timestamp.ToString("dd-MM-yyyy%THHmmss%.FFFFFFK");
            byte[] rawPayload = Encoding.ASCII.GetBytes(guidGeneratorPayload);
            byte[] result = sha256.ComputeHash(rawPayload);
            sha256.Dispose();
            return result;
        }

        public byte[] GenerateNextUUID(string salt) {
            SHA256 sha256 = SHA256.Create();

            DateTime timestamp = DateTime.Now;
            string guidGeneratorPayload = timestamp.ToString("dd-MM-yyyy%THHmmss%.FFFFFFK") + salt;
            byte[] rawPayload = Encoding.ASCII.GetBytes(guidGeneratorPayload);
            byte[] result = sha256.ComputeHash(rawPayload);
            sha256.Dispose();
            return result;

        }

        public byte[] GenerateNextUUID(byte[] salt) {
            SHA256 sha256 = SHA256.Create();

            DateTime timestamp = DateTime.Now;
            string guidGeneratorPayload = timestamp.ToString("dd-MM-yyyy%THHmmss%.FFFFFFK");
            byte[] rawPayload = Encoding.ASCII.GetBytes(guidGeneratorPayload);
            List<byte> actualRawPayload = new List<byte>();
            actualRawPayload.AddRange(rawPayload);
            actualRawPayload.AddRange(salt);
            byte[] actualRawPayloadInArrayForm = actualRawPayload.ToArray();
            byte[] result = sha256.ComputeHash(actualRawPayloadInArrayForm);
            sha256.Dispose();
            return result;
        }

        // Aliases of GenerateNextUUID for naming conventions.
        public byte[] GenerateNextGUID() => GenerateNextUUID();
        public byte[] GenerateNextGUID(string salt) => GenerateNextUUID(salt);
        public byte[] GenerateNextGUID(byte[] salt) => GenerateNextUUID(salt);
    }
}
