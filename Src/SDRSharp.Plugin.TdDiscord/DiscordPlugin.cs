using System;
using System.ComponentModel;
using System.Windows.Forms;
using DiscordRPC;
using SDRSharp.Common;

namespace SDRSharp.Plugin.TdDiscord
{
    public class DiscordPlugin : ISharpPlugin, ICanLazyLoadGui, ISupportStatus
    {
        private static DiscordRpcClient _client;

        private readonly RichPresence _richPresence = new()
        {
            Details = "Loading...",
            State = "Loading...",
        };

        private bool _closed;

        private IConfigService _configService;
        private ISharpControl _control;

        public void LoadGui()
        {
            Gui ??= new PluginPanel(_configService);
        }

        public string DisplayName => "Td Discord RPC";
        public UserControl Gui { get; private set; }

        public void Initialize(ISharpControl control)
        {
            _control = control;
            _configService = new ConfigService();

            control.PropertyChanged += Control_PropertyChanged;

            _client = new DiscordRpcClient(_configService.Get(c => c.DiscordAppId), -1);
            _client.Initialize();

            _configService.ConfigurationChanged += ConfigService_ConfigurationChanged;
        }

        public void Close()
        {
            _configService.ApplyChanges();

            _closed = true;

            _client.Dispose();
            Gui.Dispose();
        }

        public bool IsActive => _configService.Get(c => c.Enabled);

        public void ConfigService_ConfigurationChanged(object sender, EventArgs e)
        {
            var settingsModel = new RpcSettingsModel
            {
                Frequency = _control.Frequency,
                IsPlaying = _control.IsPlaying,
                Modulation = _control.DetectorType.ToString(),
                Rds = _control.RdsRadioText,
            };

            ApplyRpc(settingsModel);
        }

        private void Control_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var settingsModel = new RpcSettingsModel
            {
                Frequency = _control.Frequency,
                IsPlaying = _control.IsPlaying,
                Modulation = _control.DetectorType.ToString(),
                Rds = _control.RdsRadioText,
            };

            ApplyRpc(settingsModel);
        }

        private void ApplyRpc(RpcSettingsModel settingsModel)
        {
            if (_closed)
                return;

            if (!_configService.Get(c => c.Enabled))
            {
                _client.ClearPresence();
                return;
            }

            if (!settingsModel.IsPlaying)
            {
                _richPresence.Details = _configService.Get(c => c.ShowFrequency) ? "Frequency: Not playing" : string.Empty;
                _richPresence.State = _configService.Get(c => c.ShowRds) ? "RDS: Not playing" : string.Empty;

                return;
            }

            _richPresence.Details = _configService.Get(c => c.ShowFrequency)
                ? $"Frequency: {settingsModel.Frequency:#,0,,0} Hz {settingsModel.Modulation}"
                : string.Empty;

            _richPresence.State = _configService.Get(c => c.ShowRds) ? $"RDS: {settingsModel.Rds}" : string.Empty;

            _client.SetPresence(_richPresence);
        }
    }
}