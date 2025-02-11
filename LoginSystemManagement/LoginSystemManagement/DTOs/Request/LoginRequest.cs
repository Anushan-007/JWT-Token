using System.ComponentModel.DataAnnotations;

namespace LoginSystemManagement.DTOs.Request
{
    public class LoginRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
