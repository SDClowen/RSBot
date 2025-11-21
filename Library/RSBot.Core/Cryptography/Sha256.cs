using System.Security.Cryptography;
using System.Text;

namespace RSBot.Core.Cryptography;

public class Sha256
{
    public static string ComputeHash(string rawData)
    {
        using (var sha256Hash = SHA256.Create())
        {
            var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

            StringBuilder builder = new();
            for (var i = 0; i < bytes.Length; i++)
                builder.Append(bytes[i].ToString("X2"));

            return builder.ToString();
        }
    }
}
