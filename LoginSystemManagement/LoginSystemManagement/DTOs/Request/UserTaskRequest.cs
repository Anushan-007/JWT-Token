namespace LoginSystemManagement.DTOs.Request
{
    public class UserTaskRequest
    {
        public string Name { get; set; }
        //public DateTime StartDate { get; set; }
        public Guid UserId { get; set; } // Add this property
    }

}
