using WebApplication1.ActionClass.Account;
using WebApplication1.ActionClass.HelperClass.DTO;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace WebApplication1.Interface
{
    public interface IUser
    {
        public List<AccountDTO> GetUsers();

        public List<AccountDTO> GetUser(string phone);

        public List<string> AddAcount(AccountCreate account);

        public List<string> UpdateUser(string phone, AccountUpdateDTO user);

        public List<string> DeleteUser(long id);
        List<string> UpdateUser(int userId, UserUpdate user);
        object AddUser(UserCreate user);
        object GetUser(int userId);
        List<string> UserUpdate(int userId, UserUpdate user);
    }
}
