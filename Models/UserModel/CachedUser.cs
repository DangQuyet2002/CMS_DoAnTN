namespace Models
{
    public class CachedUser
    {
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public bool isTeacher { get; set; }
        public bool isAdmin { get; set; }
    }
}