namespace SDRSharp.Plugin.TdDiscord
{
    public sealed class ConfigurationModel
    {
        public bool Enabled { get; set; }
        public bool ShowFrequency { get; set; }
        public bool ShowRds { get; set; }
        public string DiscordAppId { get; set; } = "765213507321856078";
    }
}