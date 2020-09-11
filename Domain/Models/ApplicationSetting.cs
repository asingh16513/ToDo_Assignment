using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class ApplicationSetting
    { 
        public string AuthenticationTokenSecret { get; set; }

        public LoggingConfiguration LoggingConfiguration { get; set; }
    }

    public class ConnectionSettings
    {
        public string DefaultConnection { get; set; }
    }

    public class LoggingConfiguration
    {
        public bool IsDevelopmentLogsEnabled { get; set; }
        public string LogFileBasePath { get; set; }
    }
}
