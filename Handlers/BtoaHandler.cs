using SalesEscord.Interfaces;

namespace SalesEscord.Handlers
{
    public class BtoaHandler : IBtoaHandler
    {
        public string Decrypt(string input)
        {
            var bytes = Convert.FromBase64String(input);

            return System.Text.Encoding.UTF8.GetString(bytes);
        }

        public string Encrypt(string input)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);

            return Convert.ToBase64String(bytes);
        }
    }
}
