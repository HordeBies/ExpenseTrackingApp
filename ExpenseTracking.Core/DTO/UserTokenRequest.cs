using System.ComponentModel.DataAnnotations;

namespace ExpenseTracking.Core.DTO
{
    public class UserTokenRequest
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
