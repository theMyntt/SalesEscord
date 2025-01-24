namespace SalesEscord.Interfaces
{
    public interface IBtoaHandler
    {
        string Encrypt(string input);
        string Decrypt(string input);
    }
}
