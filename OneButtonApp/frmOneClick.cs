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

namespace OneClickApp
{ 

	public partial class frmOneClick : Form {
		private Request request = null;
        private String request_id = "";
       
		
        public frmOneClick() {
			InitializeComponent();

			request = new Request();
			request.OnReservationStateChanged += new Request.reservationStateChanged(request_OnReservationStateChanged);
			request.OnErrorReported += new Request.errorReported(request_OnErrorReported);
			request.OnConnectionParametersReceived += new Request.connectionParametersReceived(request_OnConnectionParametersReceived);
			request.OnFormClose += new Request.FormClose(request_closeForm);
		}

      
        void request_OnConnectionParametersReceived(string serverIP, string user, string password, Request request)
        {
            progressBar1.Hide();
			lblMessageHeader.ForeColor = Color.Black;
			lblMessageDesc.ForeColor = Color.Black;
			lblMessageHeader.Text = "Connected:";
			lblMessageDesc.Text = "Server IP: " + serverIP;
			lblMessageUn.Text = "User ID: " + user;
			lblMessagePwd.Text = "Password: " + password;
          
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSubmit);
            this.request = request;	
		}

      
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            XMLRPCextendReservationResult result;
            IOneClickXmlRPC proxy;
            IOneClickXmlRPC OneClickRPC = XmlRpcProxyGen.Create<IOneClickXmlRPC>();
            XmlRpcStruct[] structure = new XmlRpcStruct[50];
            proxy = (IOneClickXmlRPC)XmlRpcProxyGen.Create(typeof(IOneClickXmlRPC));
            proxy.Url = request.get_url();
            proxy.Headers.Add("X-APIVERSION", "2");
            proxy.Headers.Add("X-User", request.username);
            proxy.Headers.Add("X-Pass", request.password);
            ServicePointManager.ServerCertificateValidationCallback = request.AcceptCertificateNoMatterWhat;

            int extend_time = 0;
            string extend_by = this.comboBox1.Text.ToString();
            String[] extend_item = extend_by.Split(' ');
            if (extend_item[1].Equals("Hour"))
            {
                extend_time = (Convert.ToInt32(extend_item[0])) * 60;
                if ((extend_item.Length > 2) && (extend_item[3].Equals("Min")))
                    extend_time += Convert.ToInt32(extend_item[2]);
            }
            else if (extend_item[1].Equals("Min"))
                extend_time = Convert.ToInt32(extend_item[0]);

            result = proxy.XMLRPCextendRequest(this.request.get_req_id(), extend_time);
            if (result.status.Equals("error"))
            {
                display_extendreq_error(result.errormsg.ToString());
                return;
            }
            else
            {
                this.label2.ForeColor = Color.Green;
                this.label2.Text = "Reservation extended.";
            }
        }
        

        private void display_extendreq_error(String msg)
        {
            this.label2.ForeColor = Color.Red;
            this.label2.Text = msg;
        }


		void request_OnErrorReported(string errorCode, string errorMessage) {
			lblMessageHeader.ForeColor = Color.Red;
			lblMessageDesc.ForeColor = Color.Red;
			lblMessageHeader.Text = errorCode;
			lblMessageDesc.Text = errorMessage;
			progressBar1.Hide();
		}

		void request_OnReservationStateChanged(string newState, string message) {
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


        private void frmOneClick_Load(object sender, EventArgs e)
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