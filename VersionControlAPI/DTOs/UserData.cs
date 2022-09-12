namespace VersionControlAPI.DTOs
{
    public class User
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Picture { get; set; }
    }

    public class UserResponseData
    {
        public List<User>? Data { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
    }
}
