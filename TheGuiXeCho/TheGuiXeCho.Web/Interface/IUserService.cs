namespace TheGuiXeCho.Web.Interface
{
    public interface IUserService
    {
        Task<bool> Login(string userName, string password);
        Task<bool> Register(string userName, string password, string fullName, CancellationToken cancellationToken = default);
    }
}
