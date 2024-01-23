namespace ApplicationLayer.Extensions;

using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

public static class DeterministicHashExtension
{
    public static string ToDeterministicHash(this object myObject) //TODO change this object to the return type of the GetApplicationStatusAsync
    {
        string json = JsonConvert.SerializeObject(myObject);
        return json.GetDeterministicHashCode();
    }

    private static string GetDeterministicHashCode(this string json)
    {
        StringBuilder sb = new StringBuilder();

        // Initialize a MD5 hash object
        using (MD5 md5 = MD5.Create())
        {
            // Compute the hash of the given string
            byte[] hashValue = md5.ComputeHash(Encoding.UTF8.GetBytes(json));

            // Convert the byte array to string format
            foreach (byte b in hashValue)
            {
                sb.Append($"{b:X2}");
            }
        }

        return sb.ToString();
    }
}