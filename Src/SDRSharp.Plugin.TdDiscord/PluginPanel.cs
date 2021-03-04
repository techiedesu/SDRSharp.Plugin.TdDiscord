using System;
using System.Windows.Forms;

namespace SDRSharp.Plugin.TdDiscord
{
    public partial class PluginPanel : UserControl
    {
        private readonly IConfigService _configService;

        public PluginPanel(IConfigService configService)
        {
            _configService = configService;
            InitializeComponent();

            isEnabledCheckBox.Checked = _configService.Get(c => c.Enabled);
            showFrequencyCheckBox.Checked = _configService.Get(c => c.ShowFrequency);
            showRdsCheckBox.Checked = _configService.Get(c => c.ShowRds);

            showFrequencyCheckBox.Enabled = isEnabledCheckBox.Checked;
            showRdsCheckBox.Enabled = isEnabledCheckBox.Checked;

            backgroundWorker.RunWorkerAsync();
        }

        private void IsEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var enabled = IsCheckboxEnabled(sender);
            _configService.Set(c => c.Enabled = enabled);

            showFrequencyCheckBox.Enabled = enabled;
            showRdsCheckBox.Enabled = enabled;
        }

        public void ShowFrequencyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _configService.Set(c => c.ShowFrequency = IsCheckboxEnabled(sender));
        }

        private void ShowRdsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _configService.Set(c => c.ShowRds = IsCheckboxEnabled(sender));
        }

        private static bool IsCheckboxEnabled(object checkboxObj)
        {
            if (checkboxObj is not CheckBox checkbox)
                throw new ArgumentException(nameof(checkbox));

            return checkbox.Checked;
        }
    }
}