using LoginSystemManagement.Enum;

namespace LoginSystemManagement.Entity
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Role UserRole { get; set; }

        public List<UserTask> UserTasks { get; set; }
        //public Guid UserTaskId { get; set; } // Add this property

    }
}
