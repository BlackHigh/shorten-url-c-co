namespace shorten_gateway.Service
{
    public class ShortenService
    {
        private string GenerateShortCode()
        {
            // Generate a random short code using a combination of letters and numbers
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars,
            6)
                                     .Select(s => s[random.Next(s.Length)])
                                     .ToArray());
        }
    }
}
