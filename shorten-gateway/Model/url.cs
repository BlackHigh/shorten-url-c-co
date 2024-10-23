namespace shorten_gateway.Model
{
    public class URL
    {
        public int Id { get; set; }
        public string? OriginalUrl { get; set; } //missing NotNull define
        public string? ShortCode { get; set; } //missing NotNull define
    }
}
