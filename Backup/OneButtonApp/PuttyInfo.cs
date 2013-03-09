using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace OneButtonApp
{
		public partial class PuttyInfo : Form
		{
				Request request = new Request();
				bool allowClose = true;
				public PuttyInfo()
				{
						InitializeComponent();
				}

				private void btnSave_Click(object sender, EventArgs e)
				{

				}

				private void PuttyInfo_FormClosing(object sender, FormClosingEventArgs e)
				{
						request.execPath = Application.StartupPath;
						if (txtPuttyPath.Text.Trim().Equals(""))
						{
								lblStatus.Text = "Please enter valid path";
								e.Cancel = allowClose;
						}
						else
						{
								request.puttyExec = txtPuttyPath.Text;
								if (!File.Exists(request.puttyExec))
								{
										lblStatus.Text = "File not Found.";
										request.puttyExec = null;
										e.Cancel = allowClose;
								}
								else
								{
										request.puttyExec = txtPuttyPath.Text;
										if (request.puttyExec.Contains("putty.exe"))
										{
												request.savePutty();
										}
										else
										{
												lblStatus.Text = "Please provide path to 'putty.exe'";
												request.puttyExec = null;
												e.Cancel = allowClose;
										}
										
								}
						}
				}

				private void btnCancel_Click(object sender, EventArgs e)
				{
						allowClose = false;
				}
		}
}