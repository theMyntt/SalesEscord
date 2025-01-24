namespace SalesEscord.Exceptions
{
    public class UnauthorizedException(string message) : HttpException(message, 401);
}
