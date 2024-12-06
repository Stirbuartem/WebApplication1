namespace WebApplication1.Interface
{
    public interface IUser
    {
        public List<AccountDTO> GetUsers();

        public List<AccountDTO> GetUser(string phone);

        public List<string> AddAcount(AccountCreate account);

        public List<string> UpdateUser(string phone, AccountUpdateDTO user);

        public List<string> DeleteUser(long id);
    }
}
