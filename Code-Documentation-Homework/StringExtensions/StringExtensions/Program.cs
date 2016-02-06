using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace StringExtension
{
    public static class StringExtensions
    {
        /// <summary>
        /// Converts an input string to md5 hash
        ///  and returns it's hexadecimal representation.
        /// </summary>
        /// <param name="input">The string that will be converted</param>
        /// <returns>The converted MD5 hex string</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            var builder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                //Appends encrypted bytes in (two symbol)hexadecimal format
                builder.Append(data[i].ToString("x2"));
            }

            return builder.ToString();
        }

        /// <summary>
        /// Checks if the input argument is a True Value.
        /// </summary>
        /// <param name="input"></param>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] {"true", "ok", "yes", "1", "да"};
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Converts input string to short type value.
        /// </summary>
        /// <param name="input">The string to be converted</param>
        /// <returns>returns 0 if the operation failed or the converted number if succeeded</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Converts input string to int type value.
        /// </summary>
        /// <param name="input">The string to be converted</param>
        /// <returns>returns 0 if the operation failed or the converted number if succeeded</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Converts input string to long type value.
        /// </summary>
        /// <param name="input">The string to be converted</param>
        /// <returns>returns 0 if the operation failed or the converted number if succeeded</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Converts input string to DateTime type value.
        /// </summary>
        /// <param name="input">The string to be converted</param>
        /// <returns>returns MinValue if the operation failed or the converted DateTime if succeeded</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Capitalizes a string.
        /// </summary>
        /// <param name="input">The string which will be capitalized</param>
        /// <returns>If the input string is null or empty returns the input string,
        /// else it returns the input string with first letter in Uppercase</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return
                input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) +
                input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Returns the elements between start and end string.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="startString">Start string</param>
        /// <param name="endString">End string</param>
        /// <param name="startFrom">The position to start the search of start string.</param>
        /// <returns>returns string.Empty if start or end string 
        /// is not contained in the input string starting from startFrom agrument.
        /// Otherwise it returns the elements between start and end string.</returns>
        public static string GetStringBetween(
            this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition =
                input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Converts from cyrillic to latin string.
        /// </summary>
        /// <param name="input">The cyrillic string to be converted</param>
        /// <returns>The converted string</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
            {
                "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о",
                "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
            };
            var latinRepresentationsOfBulgarianLetters = new[]
            {
                "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
            };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(),
                    latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Converts from latin to cyrillic string.
        /// </summary>
        /// <param name="input">The latin string to be converted</param>
        /// <returns>The converted string</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
            {
                "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
            };

            var bulgarianRepresentationOfLatinKeyboard = new[]
            {
                "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                "в", "ь", "ъ", "з"
            };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(),
                    bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Validates Username .
        /// </summary>
        /// <param name="input">The username to be validated</param>
        /// <returns>Returns the valid latin username without any non-latin(cyrillic) letters</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Validates FileName.
        /// </summary>
        /// <param name="input">The filename to be validated</param>
        /// <returns>Returns the valid latin filename without any non-latin(cyrillic) letters.
        /// And converts every empty space to dash for clarity.</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Returns the (charsCount(argument) or the minimum) characters of the input string.
        /// </summary>
        /// <param name="input">The string to get the characters from.</param>
        /// <param name="charsCount">The characters count.</param>
        /// <returns>The first charsCount characters of the input string or
        /// if the input string's length is less than charsCount
        ///  it returns the input string.</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Returns the file extension.
        /// </summary>
        /// <param name="fileName">The filename which extension will be extracted</param>
        /// <returns>The file's extension</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] {"."}, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Returns the content type of the specified file extension.
        /// </summary>
        /// <param name="fileExtension">The file extension</param>
        /// <returns>returns the file extension.
        /// if none of the listed file extensions is matched,
        ///  it returnes application/octet-stream content type.</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
            {
                {"jpg", "image/jpeg"},
                {"jpeg", "image/jpeg"},
                {"png", "image/x-png"},
                {"docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document"},
                {"doc", "application/msword"},
                {"pdf", "application/pdf"},
                {"txt", "text/plain"},
                {"rtf", "application/rtf"}
            };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Converts a string to a byte array.
        /// </summary>
        /// <param name="input">The string to be converted</param>
        /// <returns>The converted byte array.</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length*sizeof (char)];
            //Copies the input as charArray to our new byteArray array.
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}