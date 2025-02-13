using LoginSystemManagement.Enum;

namespace LoginSystemManagement.DTOs.Request
{
    public class UserRequest
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public Role UserRole { get; set; }

    }
}
