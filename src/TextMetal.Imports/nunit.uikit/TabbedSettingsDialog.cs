// ****************************************************************
// Copyright 2008, Charlie Poole
// This is free software licensed under the NUnit license. You may
// obtain a copy of the license at http://nunit.org
// ****************************************************************

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace NUnit.UiKit
{
	public class TabbedSettingsDialog : SettingsDialogBase
	{
		#region Constructors/Destructors

		public TabbedSettingsDialog()
		{
			// This call is required by the Windows Form Designer.
			this.InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
		}

		#endregion

		#region Fields/Constants

		private IContainer components = null;
		protected TabControl tabControl1;

		#endregion

		#region Methods/Operators

		public static void Display(Form owner, params SettingsPage[] pages)
		{
			using (TabbedSettingsDialog dialog = new TabbedSettingsDialog())
			{
				owner.Site.Container.Add(dialog);
				dialog.Font = owner.Font;
				dialog.SettingsPages.AddRange(pages);
				dialog.ShowDialog();
			}
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

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tabControl1 = new TabControl();
			this.SuspendLayout();
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new Point(394, 392);
			this.cancelButton.Name = "cancelButton";
			// 
			// okButton
			// 
			this.okButton.Location = new Point(306, 392);
			this.okButton.Name = "okButton";
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom)
														| AnchorStyles.Left)
														| AnchorStyles.Right)));
			this.tabControl1.ItemSize = new Size(46, 18);
			this.tabControl1.Location = new Point(10, 8);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new Size(456, 376);
			this.tabControl1.TabIndex = 2;
			// 
			// TabbedSettingsDialog
			// 
			this.ClientSize = new Size(474, 426);
			this.Controls.Add(this.tabControl1);
			this.Name = "TabbedSettingsDialog";
			this.Load += new EventHandler(this.TabbedSettingsDialog_Load);
			this.Controls.SetChildIndex(this.okButton, 0);
			this.Controls.SetChildIndex(this.cancelButton, 0);
			this.Controls.SetChildIndex(this.tabControl1, 0);
			this.ResumeLayout(false);
		}

		private void TabbedSettingsDialog_Load(object sender, EventArgs e)
		{
			foreach (SettingsPage page in this.SettingsPages)
			{
				TabPage tabPage = new TabPage(page.Title);
				tabPage.Controls.Add(page);
				page.Location = new Point(0, 16);
				this.tabControl1.TabPages.Add(tabPage);
			}
		}

		#endregion
	}
}