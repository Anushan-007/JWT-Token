namespace LoginSystemManagement.Entity
{
    public class UserTask
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
       // public DateTime StartDate { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; } // Add this property
      
    }
}
