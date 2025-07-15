using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TheGuiXeCho.Web.Data;
using TheGuiXeCho.Web.Entity;
using TheGuiXeCho.Web.Interface;

namespace TheGuiXeCho.Web.Services
{
    public class UserService : IUserService
    {
        private readonly TheGuiXeChoDbContext dbContext;
        public UserService(TheGuiXeChoDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }
        public async Task<bool> Login(string userName, string password)
        {
            User? user = await dbContext.Users.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password);
            if (user == null)
            {
                return false; 
            }
            return true;
        }
        public async Task<bool> Register(string userName, string password, string fullName, CancellationToken cancellationToken = default)
        {
            User user = new User
            {
                UserName = userName,
                Password = password,
                FullName = fullName
            };
            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
