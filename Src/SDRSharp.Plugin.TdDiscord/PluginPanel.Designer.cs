
namespace SDRSharp.Plugin.TdDiscord
{
    partial class PluginPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.isEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.showFrequencyCheckBox = new System.Windows.Forms.CheckBox();
            this.showRdsCheckBox = new System.Windows.Forms.CheckBox();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // isEnabledCheckBox
            // 
            this.isEnabledCheckBox.AutoSize = true;
            this.isEnabledCheckBox.Location = new System.Drawing.Point(24, 21);
            this.isEnabledCheckBox.Name = "isEnabledCheckBox";
            this.isEnabledCheckBox.Size = new System.Drawing.Size(101, 29);
            this.isEnabledCheckBox.TabIndex = 0;
            this.isEnabledCheckBox.Text = "Enabled";
            this.isEnabledCheckBox.UseVisualStyleBackColor = true;
            this.isEnabledCheckBox.CheckedChanged += new System.EventHandler(this.IsEnabledCheckBox_CheckedChanged);
            // 
            // showFrequencyCheckBox
            // 
            this.showFrequencyCheckBox.AutoSize = true;
            this.showFrequencyCheckBox.Location = new System.Drawing.Point(24, 56);
            this.showFrequencyCheckBox.Name = "showFrequencyCheckBox";
            this.showFrequencyCheckBox.Size = new System.Drawing.Size(168, 29);
            this.showFrequencyCheckBox.TabIndex = 1;
            this.showFrequencyCheckBox.Text = "Show Frequency";
            this.showFrequencyCheckBox.UseVisualStyleBackColor = true;
            this.showFrequencyCheckBox.CheckedChanged += new System.EventHandler(this.ShowFrequencyCheckBox_CheckedChanged);
            // 
            // showRdsCheckBox
            // 
            this.showRdsCheckBox.AutoSize = true;
            this.showRdsCheckBox.Location = new System.Drawing.Point(24, 91);
            this.showRdsCheckBox.Name = "showRdsCheckBox";
            this.showRdsCheckBox.Size = new System.Drawing.Size(121, 29);
            this.showRdsCheckBox.TabIndex = 2;
            this.showRdsCheckBox.Text = "Show RDS";
            this.showRdsCheckBox.UseVisualStyleBackColor = true;
            this.showRdsCheckBox.CheckedChanged += new System.EventHandler(this.ShowRdsCheckBox_CheckedChanged);
            // 
            // PluginPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.showRdsCheckBox);
            this.Controls.Add(this.showFrequencyCheckBox);
            this.Controls.Add(this.isEnabledCheckBox);
            this.Name = "PluginPanel";
            this.Size = new System.Drawing.Size(413, 626);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox isEnabledCheckBox;
        private System.Windows.Forms.CheckBox showFrequencyCheckBox;
        private System.Windows.Forms.CheckBox showRdsCheckBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
    }
}