using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Login_Wpf
{
    public static class GeneralMethods
    {
        public static bool EmailControl(string srEmail)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(srEmail);
        }

        public static string ComputeSha256Hash(this string rawData)
        {
            //I am creating sha256 
            using (SHA256 sha256Hash = SHA256.Create())
            {
                //I am converting the incoming string data to Byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                //I am converting the converted data to string array
                StringBuilder builder = new StringBuilder();

                //With the for loop, I process and assign as much data as the character length of the data.
                for (int i = 0; i < bytes.Length; i++)
                {
                    //We format the string as two uppercase hexadecimal characters with ToString(x2)
                    builder.Append(bytes[i].ToString("x2"));
                }
                //I'm sending back the resulting encrypted value
                return builder.ToString();
            }
        }
    }
}
