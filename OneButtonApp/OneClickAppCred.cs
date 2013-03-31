using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Management;

namespace OneClickApp
{
		public partial class OneClickAppCred : Form
		{
				private Request request = null;
				private bool allowClose = true;
				public OneClickAppCred()
				{
						InitializeComponent();
						request = new Request();
						request.OnReservationStateChanged += new Request.reservationStateChanged(request_OnReservationStateChanged);
				}

				void request_OnReservationStateChanged(string newState, string message)
				{
						lblStatus.Text = message;
				}

				private void btnSave_Click(object sender, EventArgs e)
				{

				}

				private void btnClose_Click(object sender, EventArgs e)
				{
						txtUsername.Text = "";
						txtPassword.Text = "";
						allowClose = false;
				}

				private void OneClickAppCred_Load(object sender, EventArgs e)
				{
						ManagementObjectCollection mbsList = null;
						ManagementObjectSearcher mbs = new ManagementObjectSearcher("Select * From Win32_processor");
						mbsList = mbs.Get();
						string id = "";
						foreach (ManagementObject mo in mbsList)
						{
								id = mo["ProcessorID"].ToString();
						}
						request.gUID = id;
						txtUsername.Focus();
				}

				private void OneClickAppCred_FormClosing(object sender, FormClosingEventArgs e)
				{
						try
						{
								if ( ((txtUsername.Text.Trim().Equals("")) || (txtPassword.Text.Trim().Equals(""))) )
								{
										if (allowClose)
										{
												MessageBox.Show("Credential must not be null. Please try again.", "Authentication Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
										}
										e.Cancel = allowClose;
								}
								else
								{
										request.username = txtUsername.Text;
										request.password = txtPassword.Text;
										request.execPath = Application.StartupPath;
										request.saveCred();
								}					
						}
						catch (Exception ex)
						{
								MessageBox.Show(ex.Message);
								DialogResult = DialogResult.Cancel;
						}
				}
		}
}