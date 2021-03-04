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
            discordAppIdTextBox.Text = _configService.Get(c => c.DiscordAppId);

            showFrequencyCheckBox.Enabled = isEnabledCheckBox.Checked;
            showRdsCheckBox.Enabled = isEnabledCheckBox.Checked;
            discordAppIdTextBox.Enabled = isEnabledCheckBox.Checked;
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

        private void DiscordAppIdTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;

            if (((TextBox) sender).Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private static bool IsCheckboxEnabled(object checkboxObj)
        {
            if (checkboxObj is not CheckBox checkbox)
                throw new ArgumentException(null, nameof(checkboxObj));

            return checkbox.Checked;
        }

        private void DiscordAppIdTextBox_TextChanged(object sender, EventArgs e)
        {
            if (sender is not TextBox textBox)
                throw new ArgumentException(null, nameof(sender));

            _configService.Set(c => c.DiscordAppId = textBox.Text);
        }
    }
}