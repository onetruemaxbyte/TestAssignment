namespace Core.Enitity;

public class Candidate
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime? PreferredCallTimeInterval { get; set; }
    public string? Phone { get; set; }
    public string? LinkedInProfile { get; set; }
    public string? GithubProfile { get; set; }
    public string? Comment { get; set; }
}