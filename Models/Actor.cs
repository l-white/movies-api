namespace movies_api.Models
{
    public class Actor
    {
        public int id { get; set; }
        public string? title { get; set; }
        public string? poster { get; set; }
        public DateOnly release_date { get; set; }
    }
}
