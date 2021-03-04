using System;
using System.Linq.Expressions;
using Newtonsoft.Json;
using SDRSharp.Radio;

namespace SDRSharp.Plugin.TdDiscord
{
    public interface IConfigService
    {
        event EventHandler ConfigurationChanged;
        TResult Get<TResult>(Expression<Func<ConfigurationModel, TResult>> selector);
        void Set(Action<ConfigurationModel> selector);
        void ApplyChanges();
    }

    public sealed class ConfigService : IConfigService
    {
        private readonly string _configurationKey;
        private readonly ConfigurationModel _configurationModel;

        public ConfigService()
        {
            _configurationKey = GetType().Namespace;

            try
            {
                _configurationModel = JsonConvert.DeserializeObject<ConfigurationModel>(Utils.GetStringSetting(_configurationKey));
            }
            catch
            {
                // ignored
            }

            _configurationModel ??= new ConfigurationModel();
        }

        public event EventHandler ConfigurationChanged;

        public TResult Get<TResult>(Expression<Func<ConfigurationModel, TResult>> selector)
        {
            return selector.Compile().Invoke(_configurationModel);
        }

        public void Set(Action<ConfigurationModel> selector)
        {
            selector.Invoke(_configurationModel);
            ConfigurationChanged?.Invoke(_configurationModel, EventArgs.Empty);
        }

        public void ApplyChanges()
        {
            Utils.SaveSetting(_configurationKey, JsonConvert.SerializeObject(_configurationModel));
        }
    }
}