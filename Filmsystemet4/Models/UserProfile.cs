public class UserProfile
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public List<string> MovieLinks { get; set; }
    public Dictionary<int, int> MovieRatings { get; set; }
    // Add other properties as needed
}
