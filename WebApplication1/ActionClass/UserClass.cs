using WebApplication1.Interface;
using WebApplication1.Models;

namespace WebApplication1.AcshanClass
{
    public class UserClass : IUser
    {
        private readonly Shtirbu223ToysShopDbContext _context;
        public UserClass(Shtirbu223ToysShopDbContext context);
        {
        _context = context; 
        }

        public List<string> AddAccount(AccountCreate account)
        {
            throw new NotImplementedException();
        }

        public List<string> DeleteUser(long id)
        {
            throw new NotImplementedException();
        }

        public List<AccountDTO> GetUser(string phone)
        {
            throw new NotImplementedException();
        }

        public List<AccountDTO> GetUsers()
        {
            throw new NotImplementedException();
        }

        public List<string> UpdateUser(string phone, AccountUpdateDTO user)
        {
            throw new NotImplementedException();
        }  

    }
}
