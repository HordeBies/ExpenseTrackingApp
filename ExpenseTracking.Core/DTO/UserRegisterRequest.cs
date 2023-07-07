using System.ComponentModel.DataAnnotations;

namespace ExpenseTracking.Core.DTO
{
    public class UserRegisterRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
