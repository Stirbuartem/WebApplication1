using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ActionClass.Account
{
    public class AccountCreate
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastrtName { get; set; }
        [Required]
        public string Patronomic { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
