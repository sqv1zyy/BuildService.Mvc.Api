namespace BuildService.Mvc.Api
{
    public class AppConfig
    {
        public class TinyMce
        {
            public string? apiKey { get; set; }
        }
        public class Company
        {
            public string? CompanyName { get; set; }
            public string? CompanyPhone { get; set; }
            public string? CompanyPhoneShort { get; set; }
            public string? CompanyEmail { get; set; }
        }
    }
}
