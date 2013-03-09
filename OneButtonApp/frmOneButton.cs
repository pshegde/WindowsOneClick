using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CookComputing.XmlRpc;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using System.Management;

namespace OneButtonApp
{ 

	public partial class frmOneButton : Form {
		private Request request = null;

		public frmOneButton() {
			InitializeComponent();

			request = new Request();
			request.OnReservationStateChanged += new Request.reservationStateChanged(request_OnReservationStateChanged);
			request.OnErrorReported += new Request.errorReported(request_OnErrorReported);
			request.OnConnectionParametersReceived += new Request.connectionParametersReceived(request_OnConnectionParametersReceived);
			request.OnFormClose += new Request.FormClose(request_closeForm);
		}

		void request_OnConnectionParametersReceived(string serverIP, string user, string password) {
			lblMessageHeader.ForeColor = Color.Black;
			lblMessageDesc.ForeColor = Color.Black;
			lblMessageHeader.Text = "Connected:";
			lblMessageDesc.Text = "Server IP: " + serverIP;
			lblMessageUn.Text = "User ID: " + user;
			lblMessagePwd.Text = "Password: " + password;
			progressBar1.Hide();
		}

		void request_OnErrorReported(string errorCode, string errorMessage) {
			//txtStatus.Text = errorCode + " - " + errorMessage;
			lblMessageHeader.ForeColor = Color.Red;
			lblMessageDesc.ForeColor = Color.Red;
			lblMessageHeader.Text = errorCode;
			lblMessageDesc.Text = errorMessage;
			progressBar1.Hide();
		}

		void request_OnReservationStateChanged(string newState, string message) {
			//txtStatus.Text = newState + " - " + message;
			lblMessageHeader.ForeColor = Color.Black;
			lblMessageDesc.ForeColor = Color.Black;
			lblMessageHeader.Text = newState;
			lblMessageDesc.Text = message;			
		}

		void request_closeForm()
		{
				this.Close();
		}

		private void button1_Click(object sender, EventArgs e) {
			
			progressBar1.Show();
			request.makeRequest();
		}

		//private bool AcceptCertificateNoMatterWhat(object sender,
		//  System.Security.Cryptography.X509Certificates.X509Certificate cert,
		//  System.Security.Cryptography.X509Certificates.X509Chain chain,
		//  System.Net.Security.SslPolicyErrors errors) {
		//  return true;
		//}

			private void frmOneButton_Load(object sender, EventArgs e)
			{

					progressBar1.Show();

					ManagementObjectCollection mbsList = null;
					ManagementObjectSearcher mbs = new ManagementObjectSearcher("Select * From Win32_processor");
					mbsList = mbs.Get();
					string id = "";
					foreach (ManagementObject mo in mbsList)
					{
							id = mo["ProcessorID"].ToString();
					}
					request.gUID = id;

					if (Request.myRijndael == null)
					{
							Request.myRijndael = new RijndaelManaged();
							Request.myRijndael.Key = ASCIIEncoding.ASCII.GetBytes(request.gUID);
							Request.myRijndael.IV = ASCIIEncoding.ASCII.GetBytes(request.gUID);

					}
					request.makeRequest();
					request.execPath = Application.StartupPath;					
			}

			private void btnClose_Click(object sender, EventArgs e)
			{
					Application.Exit();
			}
	}
}
