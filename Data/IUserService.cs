namespace WebApplication
{
    public interface IUserService
    {
        User ValidateUser(string userName, string password);
    }
}