using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ActionClass.Account
{
    public class UserCreate
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
