namespace AdaMedicine.MobileApi.Infrastructure
{
    public class RedisConfig
    {
        public string Host { get; set; }

        public string Port { get; set; }

        public int Database { get; set; }

        public int Timeout { get; set; }
    }
}
