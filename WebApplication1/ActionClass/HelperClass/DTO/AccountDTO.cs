namespace WebApplication1.ActionClass.HelperClass.DTO
{
    public class AccountDTO
    {
        public class UserDTO
        {
            public int UserId { get; set; }

            public string? Name { get; set; }

            public string? Surname { get; set; }

            public string Login { get; set; } = null!;

            public string Password { get; set; } = null!;
        }

    }
}
