namespace BuildService.Mvc.Api.infrastructure
{
    public class AppConfig
    {
        public TinyMceConfig TinyMce { get; set; } = new();
        public CompanyConfig Company { get; set; } = new();

    }
    public class TinyMceConfig
    {
        public string? apiKey { get; set; }
    }
    public class CompanyConfig
    {
        public string? CompanyName { get; set; }
        public string? CompanyPhone { get; set; }
        public string? CompanyPhoneShort { get; set; }
        public string? CompanyEmail { get; set; }
    }
}
