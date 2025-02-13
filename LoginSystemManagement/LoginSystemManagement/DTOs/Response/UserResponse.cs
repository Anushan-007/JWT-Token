using LoginSystemManagement.Enum;

namespace LoginSystemManagement.DTOs.Response
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Role UserRole { get; set; }

    }
}
