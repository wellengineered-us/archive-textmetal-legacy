// ****************************************************************
// Copyright 2008, Charlie Poole
// This is free software licensed under the NUnit license. You may
// obtain a copy of the license at http://nunit.org
// ****************************************************************

using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace NUnit.UiKit
{
	/// <summary>
	/// 	Summary description for NewTabPageDialog.
	/// </summary>
	public class AddTabPageDialog : NUnitFormBase
	{
		#region Constructors/Destructors

		public AddTabPageDialog(TextDisplayTabSettings tabSettings)
		{
			//
			// Required for Windows Form Designer support
			//
			this.InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.tabSettings = tabSettings;
		}

		#endregion

		#region Fields/Constants

		private Button cancelButton;

		/// <summary>
		/// 	Required designer variable.
		/// </summary>
		private Container components = null;

		private Label label1;
		private Button okButton;
		private TextDisplayTabSettings tabSettings;

		private TextBox titleTextBox;

		#endregion

		#region Properties/Indexers/Events

		public string Title
		{
			get
			{
				return this.titleTextBox.Text;
			}
		}

		#endregion

		#region Methods/Operators

		/// <summary>
		/// 	Clean up any resources being used.
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

		/// <summary>
		/// 	Required method for Designer support - do not modify
		/// 	the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.titleTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// titleTextBox
			// 
			this.titleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			                                                                 | System.Windows.Forms.AnchorStyles.Right)));
			this.titleTextBox.Location = new System.Drawing.Point(16, 32);
			this.titleTextBox.Name = "titleTextBox";
			this.titleTextBox.Size = new System.Drawing.Size(312, 22);
			this.titleTextBox.TabIndex = 0;
			this.titleTextBox.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 8);
			this.label1.Name = "label1";
			this.label1.TabIndex = 1;
			this.label1.Text = "Tab Page Title:";
			// 
			// okButton
			// 
			this.okButton.Location = new System.Drawing.Point(88, 72);
			this.okButton.Name = "okButton";
			this.okButton.TabIndex = 2;
			this.okButton.Text = "OK";
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(184, 72);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.TabIndex = 3;
			this.cancelButton.Text = "Cancel";
			// 
			// AddTabPageDialog
			// 
			this.AcceptButton = this.okButton;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(344, 104);
			this.ControlBox = false;
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.titleTextBox);
			this.Name = "AddTabPageDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "New Tab Page";
			this.ResumeLayout(false);
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			if (this.Title == string.Empty)
			{
				this.MessageDisplay.Error("No title entered");
				return;
			}

			this.tabSettings.Tabs.AddNewTab(this.Title);

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		#endregion
	}
}