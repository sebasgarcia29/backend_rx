using Microsoft.VisualBasic;
using Rxlightning.Configuration;

namespace Rxlightning.Extensions
{
    public static class EncodingExtensions
    {

        public static string EncodeId(this string txtString)
        {

            if (string.IsNullOrWhiteSpace(txtString)) return string.Empty;
            var data = $"{Config.secretKeyByEncode}{txtString}";
            var plainText = System.Text.Encoding.UTF8.GetBytes(data);
            return Convert.ToBase64String(plainText);
        }

        public static string DecodeId(this string encodedData)
        {
            string plainText = string.Empty;
            if (!string.IsNullOrWhiteSpace(encodedData))
            {
                try
                {
                    var base64EncodedBytes = Convert.FromBase64String(encodedData);
                    var data = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);

                    if (data.StartsWith(Config.secretKeyByEncode))
                    {
                        plainText = data.Replace(Config.secretKeyByEncode, string.Empty);
                    }
                }
                catch { }
            }
            return plainText;
        }
    }
}