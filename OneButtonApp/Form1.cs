using System;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using CookComputing.XmlRpc;
using System.Net;
using System.IO;
using System.Threading;

namespace OneClickApp
{
		public delegate void getConnectionDataDelegate(Object request_id);
		//public struct XMLRPCaddRequestResult
		//{
		//    [XmlRpcMissingMapping(MappingAction.Ignore)]
		//    public string status;
		//    [XmlRpcMissingMapping(MappingAction.Ignore)]
		//    public string requestid;
		//    [XmlRpcMissingMapping(MappingAction.Ignore)]
		//    public int errorcode;
		//    [XmlRpcMissingMapping(MappingAction.Ignore)]
		//    public string errormsg;
		//    [XmlRpcMissingMapping(MappingAction.Ignore)]
		//    public string time;
		//}
		//public struct XMLRPCRequestStatus
		//{
		//    [XmlRpcMissingMapping(MappingAction.Ignore)]
		//    public string status;
		//    [XmlRpcMissingMapping(MappingAction.Ignore)]
		//    public int errorcode;
		//    [XmlRpcMissingMapping(MappingAction.Ignore)]
		//    public string errormsg;
		//    [XmlRpcMissingMapping(MappingAction.Ignore)]
		//    public int time;
		//}
		//public struct XMLRPCconnectData
		//{
		//    [XmlRpcMissingMapping(MappingAction.Ignore)]
		//    public string status;
		//    [XmlRpcMissingMapping(MappingAction.Ignore)]
		//    public string serverIP;
		//    [XmlRpcMissingMapping(MappingAction.Ignore)]
		//    public string user;
		//    [XmlRpcMissingMapping(MappingAction.Ignore)]
		//    public string password;
		//    [XmlRpcMissingMapping(MappingAction.Ignore)]
		//    public int errorcode;
		//    [XmlRpcMissingMapping(MappingAction.Ignore)]
		//    public string errormsg;
		//}

		//[XmlRpcUrl("https://152.46.20.165/index.php?mode=xmlrpccall")]
		////[XmlRpcUrl("https://152.46.19.199/index.php?mode=xmlrpccall")]
		////[XmlRpcUrl(url)]
		//public interface IOneButtonXmlRPC : IXmlRpcProxy
		//{
		//    [XmlRpcMethod]
		//    XMLRPCaddRequestResult XMLRPCaddRequest(int image_id, string time, int duration);
		//    [XmlRpcMethod]
		//    XMLRPCRequestStatus XMLRPCgetRequestStatus(Object request_id);
		//    [XmlRpcMethod]
		//    XMLRPCconnectData XMLRPCgetRequestConnectData(Object request_id, string remoteIP);
		//}
		public partial class Form1 : Form
		{
				//XMLRPCconnectData connect_data;
				//IOneButtonXmlRPC proxy;
				//string url = null;
				//int image_id = 0;
				//int duration = 0;
				//string when = null;
				public Form1()
				{
						InitializeComponent();
				}

				private void Form1_Load(object sender, EventArgs e)
				{
						lblUserMessage.Text = "";
						lblUserMessage.ForeColor = Color.Black;
				}

				private void btnLogin_Click(object sender, EventArgs e)
				{
						////parse_file();
						//lblUserMessage.Text = "";
						//lblUserMessage.ForeColor = Color.Black;
						////Thread run_th = new Thread(getConnectionData);					

						//IOneButtonXmlRPC OneButtonRPC = XmlRpcProxyGen.Create<IOneButtonXmlRPC>();
						//XmlRpcStruct[] structure = new XmlRpcStruct[50];
						//XMLRPCaddRequestResult create_image;

						//try
						//{
						//    proxy = (IOneButtonXmlRPC)XmlRpcProxyGen.Create(typeof(IOneButtonXmlRPC));
						//    proxy.Url = url;
						//    proxy.Headers.Add("X-APIVERSION", "2");
						//    proxy.Headers.Add("X-User", txtUserName.Text);
						//    proxy.Headers.Add("X-Pass", txtPassword.Text);

						//    //Accept server's invalid certificate
						//    ServicePointManager.ServerCertificateValidationCallback = AcceptCertificateNoMatterWhat;

						//    create_image = proxy.XMLRPCaddRequest(image_id, when, duration);

						//    if (create_image.status.Equals("success"))
						//    {
						//        lblUserMessage.Text = "Image created successfully and image id is " + create_image.requestid;
						//    }
						//    else if (create_image.status.Equals("notavailable"))
						//    {
						//        lblUserMessage.Text = "No computers are available for this request";
						//        lblUserMessage.ForeColor = Color.Red;
						//        return;
						//    }
						//    else
						//    {
						//        lblUserMessage.Text = "Image creation failed";
						//        lblUserMessage.ForeColor = Color.Red;
						//        return;
						//    }

						//    Object request_id = (Object)create_image.requestid;

						//    XMLRPCRequestStatus request_status = proxy.XMLRPCgetRequestStatus(request_id);


						//    if (request_status.status.Equals("ready"))
						//    {
						//        lblUserMessage.Text = "Request is ready, Please wait...";
						//    }
						//    else if (request_status.status.Equals("failed"))
						//    {
						//        lblUserMessage.Text = "Request failed to load properly";
						//        lblUserMessage.ForeColor = Color.Red;
						//        return;
						//    }
						//    else if (request_status.status.Equals("timedout"))
						//    {
						//        lblUserMessage.Text = "Request timedout";
						//        lblUserMessage.ForeColor = Color.Red;
						//        return;
						//    }
						//    else if (request_status.status.Equals("error"))
						//    {
						//        lblUserMessage.Text = "Request failed to load properly";
						//        lblUserMessage.ForeColor = Color.Red;
						//        return;
						//    }
						//    else if (request_status.status.Equals("loading"))
						//    {
						//        lblUserMessage.Text = "Image loading time approx. 1 minute";
						//        lblUserMessage.ForeColor = Color.Black;
						//    }
						//    /* TODO - Need to take care of "future" return state */								
						//    //string my_ip_addr = GetIP();								
						//    run_th.Start(request_id);

						//    lblUserMessage.Text = "Loading Image, Please wait...";
								
						//    run_th.Join();
						//    getConnectionDataDelegate conn_data = getConnectionData;
						//    //conn_data.BeginInvoke(request_id, null, null);
						//    //do
						//    //{
						//    //    connect_data = proxy.XMLRPCgetRequestConnectData(request_id, my_ip_addr);
						//    //    if (connect_data.status.Equals("ready"))
						//    //    {
						//    //        break;
						//    //    }
						//    //} while (loop_continue); /* Continue looping while image is ready */

						//    string server_ip = connect_data.serverIP;
						//    string username = connect_data.user;
						//    string password = connect_data.password;
						//    bool success = RdcTest(server_ip, username, password);

						//    if (success)
						//    {
						//        lblUserMessage.Text = "Connect to: ServerIP: " + server_ip + ", Username: " + username + ", Password: " + password;
						//        lblUserMessage.ForeColor = Color.Black;
										
						//    }
						//    else
						//    {
						//        lblUserMessage.Text = "RDCtest is a failure";
						//        lblUserMessage.ForeColor = Color.Red;
						//    }
						//    Thread.Sleep(5000);
						//    //Application.Exit();
						//}
						//catch (XmlRpcFaultException fex)
						//{
						//    lblUserMessage.Text = "Fault Response: " + fex.FaultCode + " " + fex.FaultString;
						//    lblUserMessage.ForeColor = Color.Red;
						//}

						//catch (Exception Ex)
						//{
						//    lblUserMessage.Text = Ex.Message;
						//    lblUserMessage.ForeColor = Color.Red;
						//}
				}

				///* Function used to accept certificate and proceed further */
				//private bool AcceptCertificateNoMatterWhat(object sender,
				//System.Security.Cryptography.X509Certificates.X509Certificate cert,
				//System.Security.Cryptography.X509Certificates.X509Chain chain,
				//System.Net.Security.SslPolicyErrors errors)
				//{
				//    return true;
				//}

				///* Function to fetch IP address of local machine */
				//public string GetIP()
				//{
				//    try
				//    {
				//        string strHostName = "";
				//        strHostName = System.Net.Dns.GetHostName();

				//        IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);

				//        IPAddress[] addr = ipEntry.AddressList;

				//        return addr[addr.Length - 1].ToString();
				//    }
				//    catch (Exception Ex)
				//    {
				//        lblUserMessage.Text = Ex.Message;
				//        lblUserMessage.ForeColor = Color.Red;
				//    }
				//    return null;
				//}

				///* Function which makes used of connection data obtained from fucntion getConnectionData() and will initiate RDC for windows PC */
				//public bool RdcTest(string server, string username, string password)
				//{
				//    try
				//    {
				//        Process rdpprocess = new Process();
				//        string strExE = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\cmdkey.exe");
				//        string credentials = "/generic:TERMSRV/" + server + " /user:" + username + " /pass:" + password;
				//        rdpprocess.StartInfo.FileName = strExE;
				//        rdpprocess.StartInfo.Arguments = credentials;
				//        rdpprocess.Start();
				//        strExE = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\mstsc.exe");
				//        rdpprocess.StartInfo.FileName = strExE;
				//        rdpprocess.StartInfo.Arguments = "/v:" + server;
				//        rdpprocess.Start();
				//        return true;
				//    }
				//    catch (Exception Ex)
				//    {
				//        lblUserMessage.Text = Ex.Message;
				//        lblUserMessage.ForeColor = Color.Red;
				//    }
				//    return false;
				//}

				///* Function used to get connection infromation to the available user requested image */
				//public void getConnectionData(Object request_id)
				//{
				//    try
				//    {
				//        bool loop_continue = true;
				//        string my_ip_addr = GetIP();
				//        do
				//        {
				//            /* TODO */
				//            /* We may face issue on connection due to XMLRPCgetRequestConnectData as it tries to bind image with IP address of the requester */
				//            /* Cases when user is hidden behind NAT may cause issues where user will not be able to connect to remote desktop */
				//            connect_data = proxy.XMLRPCgetRequestConnectData(request_id, my_ip_addr);
				//            if (connect_data.status.Equals("ready"))
				//            {
				//                return;
				//            }
				//        } while (loop_continue); /* Continue looping while image is ready */
				//    }
				//    catch (Exception Ex)
				//    {
				//        lblUserMessage.Text = Ex.Message;
				//        lblUserMessage.ForeColor = Color.Red;
				//    }
				//}

				///* Function used to parse text file which will be available from the configurator package */
				//void parse_file()
				//{
				//    try
				//    {
				//        string filename = @"c:\parse.txt";	
				//        TextReader reader = new StreamReader(filename);
				//        string line;
				//        while ((line = reader.ReadLine()) != null) {
				//            string[] items = line.Split('=');

				//            if (items[0].Equals("vclURL"))
				//            {
				//                url = items[1].ToString() + "=" + items[2].ToString();
				//                continue;
				//            }
				//            else if (items[0].Equals("oneButtonID"))
				//            {
				//                /* TODO : use oneButtonId to get recored from VCL using our custom made XMLRPCgetOneButtonParams() call */
				//            }
				//            else if (items[0].Equals("IMAGEID"))
				//            {
				//                image_id = int.Parse(items[1].ToString());
				//                continue;
				//            }
				//            else if (items[0].Equals("DURATION"))
				//            {
				//                duration = int.Parse(items[1].ToString());
				//                continue;
				//            }
				//            else if (items[0].Equals("WHEN"))
				//            {
				//                when = items[1].ToString();
				//                continue;
				//            }
				//        }
				//    }
				//    catch (Exception Ex)
				//    {
				//        lblUserMessage.Text = Ex.Message;
				//        lblUserMessage.ForeColor = Color.Red;
				//    }
				//}
		}
}