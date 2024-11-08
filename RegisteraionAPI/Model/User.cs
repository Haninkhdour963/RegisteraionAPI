namespace RegisteraionAPI.Model
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }  // For demonstration; normally would handle this securely
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
