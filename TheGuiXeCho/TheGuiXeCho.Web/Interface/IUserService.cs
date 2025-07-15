namespace TheGuiXeCho.Web.Interface
{
    public interface IUserService
    {
        Task<bool> Login(string userName, string password);
    }
}
