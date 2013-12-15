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
	/// <summary>
	/// LongRunningOperationDisplay shows an overlay message block
	/// that describes the operation in progress.
	/// </summary>
	public class LongRunningOperationDisplay : Form
	{
		#region Constructors/Destructors

		public LongRunningOperationDisplay(Form owner, string text)
		{
			//
			// Required for Windows Form Designer support
			//
			this.InitializeComponent();

			// Save the arguments
			this.Owner = owner;
			this.operation.Text = text;

			// Save owner's current cursor and set it to the WaitCursor
			this.ownerCursor = owner.Cursor;
			owner.Cursor = Cursors.WaitCursor;

			// Force immediate display upon construction
			this.Show();
			this.Invalidate();
			this.Update();
		}

		#endregion

		#region Fields/Constants

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		private Label operation;
		private Cursor ownerCursor;

		#endregion

		#region Methods/Operators

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.components != null)
					this.components.Dispose();

				this.Owner.Cursor = this.ownerCursor;
			}
			base.Dispose(disposing);
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.operation = new Label();
			this.SuspendLayout();
			// 
			// operation
			// 
			this.operation.BorderStyle = BorderStyle.FixedSingle;
			this.operation.Dock = DockStyle.Fill;
			this.operation.Font = new Font(FontFamily.GenericSansSerif, 10.2F, FontStyle.Italic, GraphicsUnit.Point, ((Byte)(0)));
			this.operation.Location = new Point(0, 0);
			this.operation.Name = "operation";
			this.operation.Size = new Size(320, 40);
			this.operation.TabIndex = 0;
			this.operation.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// LongRunningOperationDisplay
			// 
			this.BackColor = Color.LightYellow;
			this.ClientSize = new Size(320, 40);
			this.ControlBox = false;
			this.Controls.Add(this.operation);
			this.Cursor = Cursors.WaitCursor;
			this.FormBorderStyle = FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "LongRunningOperationDisplay";
			this.ShowInTaskbar = false;
			this.StartPosition = FormStartPosition.Manual;
			this.ResumeLayout(false);
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			// Set this again, see Mono Bug #82769
			this.ClientSize = new Size(320, 40);
			Point origin = this.Owner.Location;
			origin.Offset(
				(this.Owner.Size.Width - this.Size.Width) / 2,
				(this.Owner.Size.Height - this.Size.Height) / 2);
			this.Location = origin;
		}

		#endregion
	}
}