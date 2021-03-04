namespace SDRSharp.Plugin.TdDiscord
{
    public sealed class RpcSettingsModel
    {
        public bool IsPlaying { get; set; }
        public string SdrUrl { get; set; }
        public string Rds { get; set; }
        public string Modulation { get; set; }
        public long Frequency { get; set; }
    }
}