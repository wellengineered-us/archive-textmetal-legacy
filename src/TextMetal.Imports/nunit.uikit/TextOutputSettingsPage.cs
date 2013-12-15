// ****************************************************************
// Copyright 2008, Charlie Poole
// This is free software licensed under the NUnit license. You may
// obtain a copy of the license at http://nunit.org
// ****************************************************************

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using NUnit.Core;
using NUnit.Util;

namespace NUnit.UiKit
{
	public class TextOutputSettingsPage : SettingsPage
	{
		#region Constructors/Destructors

		public TextOutputSettingsPage(string key)
			: base(key)
		{
			// This call is required by the Windows Form Designer.
			this.InitializeComponent();

			this.logLevelComboBox.Items.Clear();
			foreach (string name in Enum.GetNames(typeof(LoggingThreshold)))
				this.logLevelComboBox.Items.Add(name);

			this.labelsComboBox.Items.Clear();
			foreach (string name in Enum.GetNames(typeof(TestLabelLevel)))
				this.labelsComboBox.Items.Add(name);
		}

		#endregion

		#region Fields/Constants

		private IContainer components = null;
		private CheckBox enabledCheckBox;
		private GroupBox groupBox2;
		private HelpProvider helpProvider1;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label5;
		private Label label6;
		private ComboBox labelsComboBox;
		private ComboBox logLevelComboBox;
		private int selectedTabIndex = -1;
		private CheckBox showErrorOutput;
		private CheckBox showStandardOutput;
		private CheckBox showTraceOutput;
		private ComboBox tabSelectComboBox;
		private TextDisplayTabSettings tabSettings = new TextDisplayTabSettings();
		private TextBox textBox1;
		private Button useDefaultsButton;

		#endregion

		#region Methods/Operators

		public override void ApplySettings()
		{
			this.tabSettings.ApplySettings();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.components != null)
					this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void FillTabSelectComboBox()
		{
			this.tabSelectComboBox.Items.Clear();

			foreach (TextDisplayTabSettings.TabInfo tabInfo in this.tabSettings.Tabs)
				this.tabSelectComboBox.Items.Add(tabInfo.Title);

			this.tabSelectComboBox.Items.Add("<New...>");
			this.tabSelectComboBox.Items.Add("<Edit...>");
		}

		private void InitDisplay(TextDisplayTabSettings.TabInfo tabInfo)
		{
			this.textBox1.Text = tabInfo.Title;

			TextDisplayContent content = tabInfo.Content;
			this.showStandardOutput.Checked = content.Out;
			this.showErrorOutput.Checked = content.Error;
			this.showTraceOutput.Checked = content.Trace;
			this.logLevelComboBox.SelectedIndex = (int)content.LogLevel;
			this.labelsComboBox.SelectedIndex = (int)content.Labels;

			this.enabledCheckBox.Checked = tabInfo.Enabled;
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new Label();
			this.label2 = new Label();
			this.showStandardOutput = new CheckBox();
			this.showErrorOutput = new CheckBox();
			this.tabSelectComboBox = new ComboBox();
			this.groupBox2 = new GroupBox();
			this.useDefaultsButton = new Button();
			this.textBox1 = new TextBox();
			this.enabledCheckBox = new CheckBox();
			this.label5 = new Label();
			this.helpProvider1 = new HelpProvider();
			this.label6 = new Label();
			this.logLevelComboBox = new ComboBox();
			this.label3 = new Label();
			this.labelsComboBox = new ComboBox();
			this.showTraceOutput = new CheckBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new Size(62, 13);
			this.label1.TabIndex = 11;
			this.label1.Text = "Select Tab:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new Point(8, 104);
			this.label2.Name = "label2";
			this.label2.Size = new Size(44, 13);
			this.label2.TabIndex = 16;
			this.label2.Text = "Content";
			// 
			// showStandardOutput
			// 
			this.showStandardOutput.AutoSize = true;
			this.helpProvider1.SetHelpString(this.showStandardOutput, "If checked, standard Console output is displayed on this Tab.");
			this.showStandardOutput.Location = new Point(40, 128);
			this.showStandardOutput.Name = "showStandardOutput";
			this.helpProvider1.SetShowHelp(this.showStandardOutput, true);
			this.showStandardOutput.Size = new Size(104, 17);
			this.showStandardOutput.TabIndex = 17;
			this.showStandardOutput.Text = "Standard Output";
			this.showStandardOutput.CheckedChanged += new EventHandler(this.showStandardOutput_CheckedChanged);
			// 
			// showErrorOutput
			// 
			this.showErrorOutput.AutoSize = true;
			this.helpProvider1.SetHelpString(this.showErrorOutput, "If checked, error output is displayed on this Tab.");
			this.showErrorOutput.Location = new Point(242, 128);
			this.showErrorOutput.Name = "showErrorOutput";
			this.helpProvider1.SetShowHelp(this.showErrorOutput, true);
			this.showErrorOutput.Size = new Size(83, 17);
			this.showErrorOutput.TabIndex = 18;
			this.showErrorOutput.Text = "Error Output";
			this.showErrorOutput.CheckedChanged += new EventHandler(this.showErrorOutput_CheckedChanged);
			// 
			// tabSelectComboBox
			// 
			this.tabSelectComboBox.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
															| AnchorStyles.Right)));
			this.tabSelectComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.helpProvider1.SetHelpString(this.tabSelectComboBox, "Allows the user to select an existing Tab, create a new Tab or edit the list of T" +
																	"abs.");
			this.tabSelectComboBox.Location = new Point(105, 14);
			this.tabSelectComboBox.Name = "tabSelectComboBox";
			this.helpProvider1.SetShowHelp(this.tabSelectComboBox, true);
			this.tabSelectComboBox.Size = new Size(195, 21);
			this.tabSelectComboBox.TabIndex = 22;
			this.tabSelectComboBox.SelectedIndexChanged += new EventHandler(this.tabSelectComboBox_SelectedIndexChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
													| AnchorStyles.Right)));
			this.groupBox2.Location = new Point(131, 104);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(325, 8);
			this.groupBox2.TabIndex = 24;
			this.groupBox2.TabStop = false;
			// 
			// useDefaultsButton
			// 
			this.useDefaultsButton.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
			this.useDefaultsButton.AutoSize = true;
			this.helpProvider1.SetHelpString(this.useDefaultsButton, "Restores the list of Tabs and their content to the default values.");
			this.useDefaultsButton.Location = new Point(329, 12);
			this.useDefaultsButton.Name = "useDefaultsButton";
			this.helpProvider1.SetShowHelp(this.useDefaultsButton, true);
			this.useDefaultsButton.Size = new Size(112, 23);
			this.useDefaultsButton.TabIndex = 25;
			this.useDefaultsButton.Text = "Restore Defaults";
			this.useDefaultsButton.Click += new EventHandler(this.button1_Click);
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
													| AnchorStyles.Right)));
			this.helpProvider1.SetHelpString(this.textBox1, "The title to be displayed on the selected Tab.");
			this.textBox1.Location = new Point(105, 64);
			this.textBox1.Name = "textBox1";
			this.helpProvider1.SetShowHelp(this.textBox1, true);
			this.textBox1.Size = new Size(215, 20);
			this.textBox1.TabIndex = 30;
			this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
			// 
			// enabledCheckBox
			// 
			this.enabledCheckBox.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
			this.enabledCheckBox.AutoSize = true;
			this.helpProvider1.SetHelpString(this.enabledCheckBox, "If checked, the Tab is enabled. If not, it is hidden.");
			this.enabledCheckBox.Location = new Point(350, 64);
			this.enabledCheckBox.Name = "enabledCheckBox";
			this.helpProvider1.SetShowHelp(this.enabledCheckBox, true);
			this.enabledCheckBox.Size = new Size(65, 17);
			this.enabledCheckBox.TabIndex = 31;
			this.enabledCheckBox.Text = "Enabled";
			this.enabledCheckBox.CheckedChanged += new EventHandler(this.displayTab_CheckedChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new Point(8, 64);
			this.label5.Name = "label5";
			this.label5.Size = new Size(30, 13);
			this.label5.TabIndex = 32;
			this.label5.Text = "Title:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new Point(239, 161);
			this.label6.Name = "label6";
			this.label6.Size = new Size(63, 13);
			this.label6.TabIndex = 35;
			this.label6.Text = "Log Output:";
			// 
			// logLevelComboBox
			// 
			this.logLevelComboBox.FormattingEnabled = true;
			this.helpProvider1.SetHelpString(this.logLevelComboBox, "Selects the logging threshold for display on this Tab.");
			this.logLevelComboBox.Location = new Point(329, 161);
			this.logLevelComboBox.Name = "logLevelComboBox";
			this.helpProvider1.SetShowHelp(this.logLevelComboBox, true);
			this.logLevelComboBox.Size = new Size(77, 21);
			this.logLevelComboBox.TabIndex = 36;
			this.logLevelComboBox.SelectedIndexChanged += new EventHandler(this.logLevel_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new Point(37, 200);
			this.label3.Name = "label3";
			this.label3.Size = new Size(92, 13);
			this.label3.TabIndex = 37;
			this.label3.Text = "Test Case Labels:";
			// 
			// labelsComboBox
			// 
			this.labelsComboBox.FormattingEnabled = true;
			this.helpProvider1.SetHelpString(this.labelsComboBox, "Selects whether test case labels are displayed. Option \'On\' displays labels only " +
																"when there is other output from the test.");
			this.labelsComboBox.Items.AddRange(new object[]
												{
													"Off",
													"On",
													"All"
												});
			this.labelsComboBox.Location = new Point(176, 200);
			this.labelsComboBox.Name = "labelsComboBox";
			this.helpProvider1.SetShowHelp(this.labelsComboBox, true);
			this.labelsComboBox.Size = new Size(77, 21);
			this.labelsComboBox.TabIndex = 38;
			this.labelsComboBox.SelectedIndexChanged += new EventHandler(this.labelsComboBox_SelectedIndexChanged);
			// 
			// showTraceOutput
			// 
			this.showTraceOutput.AutoSize = true;
			this.helpProvider1.SetHelpString(this.showTraceOutput, "If checked, trace output is displayed on this Tab.");
			this.showTraceOutput.Location = new Point(40, 161);
			this.showTraceOutput.Name = "showTraceOutput";
			this.helpProvider1.SetShowHelp(this.showTraceOutput, true);
			this.showTraceOutput.Size = new Size(89, 17);
			this.showTraceOutput.TabIndex = 39;
			this.showTraceOutput.Text = "Trace Output";
			this.showTraceOutput.UseVisualStyleBackColor = true;
			this.showTraceOutput.CheckedChanged += new EventHandler(this.showTraceOutput_CheckedChanged);
			// 
			// TextOutputSettingsPage
			// 
			this.Controls.Add(this.showTraceOutput);
			this.Controls.Add(this.labelsComboBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.logLevelComboBox);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.enabledCheckBox);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.useDefaultsButton);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.tabSelectComboBox);
			this.Controls.Add(this.showErrorOutput);
			this.Controls.Add(this.showStandardOutput);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "TextOutputSettingsPage";
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private void InitializeTabSelectComboBox()
		{
			this.FillTabSelectComboBox();

			if (this.tabSelectComboBox.Items.Count > 0)
			{
				this.tabSelectComboBox.SelectedIndex = this.selectedTabIndex = 0;
				this.InitDisplay(this.tabSettings.Tabs[0]);
			}
		}

		public override void LoadSettings()
		{
			this.tabSettings.LoadSettings(this.settings);
			this.InitializeTabSelectComboBox();
		}

		private void addNewTabPage()
		{
			using (AddTabPageDialog dlg = new AddTabPageDialog(this.tabSettings))
			{
				this.ParentForm.Site.Container.Add(dlg);
				if (dlg.ShowDialog(this) == DialogResult.OK)
				{
					this.FillTabSelectComboBox();
					this.tabSelectComboBox.SelectedIndex = this.tabSettings.Tabs.Count - 1;
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.tabSettings.LoadDefaults();
			this.InitializeTabSelectComboBox();
		}

		private void displayTab_CheckedChanged(object sender, EventArgs e)
		{
			this.tabSettings.Tabs[this.tabSelectComboBox.SelectedIndex].Enabled = this.enabledCheckBox.Checked;
		}

		private void editTabPages()
		{
			using (EditTabPagesDialog dlg = new EditTabPagesDialog(this.tabSettings))
			{
				this.ParentForm.Site.Container.Add(dlg);
				dlg.ShowDialog(this);

				this.FillTabSelectComboBox();

				if (this.tabSelectComboBox.Items.Count > 0)
					this.tabSelectComboBox.SelectedIndex = this.selectedTabIndex = 0;
			}
		}

		private void labelsComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.tabSettings.Tabs[this.tabSelectComboBox.SelectedIndex].Content.Labels = (TestLabelLevel)this.labelsComboBox.SelectedIndex;
		}

		private void logLevel_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.tabSettings.Tabs[this.tabSelectComboBox.SelectedIndex].Content.LogLevel = (LoggingThreshold)this.logLevelComboBox.SelectedIndex;
		}

		private void showErrorOutput_CheckedChanged(object sender, EventArgs e)
		{
			this.tabSettings.Tabs[this.tabSelectComboBox.SelectedIndex].Content.Error = this.showErrorOutput.Checked;
		}

		private void showStandardOutput_CheckedChanged(object sender, EventArgs e)
		{
			this.tabSettings.Tabs[this.tabSelectComboBox.SelectedIndex].Content.Out = this.showStandardOutput.Checked;
		}

		private void showTraceOutput_CheckedChanged(object sender, EventArgs e)
		{
			this.tabSettings.Tabs[this.tabSelectComboBox.SelectedIndex].Content.Trace = this.showTraceOutput.Checked;
		}

		private void tabSelectComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			int index = this.tabSelectComboBox.SelectedIndex;
			if (index < this.tabSettings.Tabs.Count)
			{
				this.selectedTabIndex = index;
				this.InitDisplay(this.tabSettings.Tabs[index]);
			}
			else // Not a tab, but a "menu" item
			{
				this.tabSelectComboBox.SelectedIndex = this.selectedTabIndex;

				if (index == this.tabSettings.Tabs.Count)
					this.addNewTabPage();
				else
					this.editTabPages();
			}
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			this.tabSettings.Tabs[this.tabSelectComboBox.SelectedIndex].Title = this.textBox1.Text;
		}

		#endregion
	}
}