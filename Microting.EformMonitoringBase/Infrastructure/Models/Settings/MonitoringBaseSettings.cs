namespace Microting.EformMonitoringBase.Infrastructure.Models.Settings
{
    public class MonitoringBaseSettings
    {
        public string LogLevel { get; set; }
        public string LogLimit { get; set; }
        public string SdkConnectionString { get; set; }
        public string SendGridApiKey { get; set; }
        public string FromEmailAddress { get; set; }
        public string FromEmailName { get; set; }
    }
}
