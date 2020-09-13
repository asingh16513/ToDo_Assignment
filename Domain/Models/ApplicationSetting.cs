namespace Domain.Models
{
    public class ApplicationSetting
    {
        public string AuthenticationTokenSecret { get; set; }
    }

    public class ConnectionSettings
    {
        public string DefaultConnection { get; set; }
    }

    public class Logging
    {
        public LogLevel LogLevel { get; set; }
    }

    public class LogLevel
    {
        public string Default { get; set; }
    }
}
