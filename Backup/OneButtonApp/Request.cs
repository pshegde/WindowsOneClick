using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CookComputing.XmlRpc;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Security.Cryptography;

namespace OneButtonApp
{
		public struct XMLRPCaddRequestResult
		{
				[XmlRpcMissingMapping(MappingAction.Ignore)]
				public string status;
				[XmlRpcMissingMapping(MappingAction.Ignore)]
				public string requestid;
				[XmlRpcMissingMapping(MappingAction.Ignore)]
				public int errorcode;
				[XmlRpcMissingMapping(MappingAction.Ignore)]
				public string errormsg;
				[XmlRpcMissingMapping(MappingAction.Ignore)]
				public string time;
		}
		public struct XMLRPCRequestStatus
		{
				[XmlRpcMissingMapping(MappingAction.Ignore)]
				public string status;
				[XmlRpcMissingMapping(MappingAction.Ignore)]
				public int errorcode;
				[XmlRpcMissingMapping(MappingAction.Ignore)]
				public string errormsg;
				[XmlRpcMissingMapping(MappingAction.Ignore)]
				public int time;
		}
		public struct XMLRPCconnectData
		{
				[XmlRpcMissingMapping(MappingAction.Ignore)]
				public string status;
				[XmlRpcMissingMapping(MappingAction.Ignore)]
				public string serverIP;
				[XmlRpcMissingMapping(MappingAction.Ignore)]
				public string user;
				[XmlRpcMissingMapping(MappingAction.Ignore)]
				public string password;
				[XmlRpcMissingMapping(MappingAction.Ignore)]
				public int errorcode;
				[XmlRpcMissingMapping(MappingAction.Ignore)]
				public string errormsg;
		}
		public struct XMLRPCgetIP
		{
				[XmlRpcMissingMapping(MappingAction.Ignore)]
				public string status;
				[XmlRpcMissingMapping(MappingAction.Ignore)]
				public string ip;
				[XmlRpcMissingMapping(MappingAction.Ignore)]
				public int errorcode;
				[XmlRpcMissingMapping(MappingAction.Ignore)]
				public string errormsg;
		}
	  public struct XMLRPCOneButtonParams
		{
				[XmlRpcMissingMapping(MappingAction.Ignore)]
				public string status;
				[XmlRpcMissingMapping(MappingAction.Ignore)]
				public string name;
				[XmlRpcMissingMapping(MappingAction.Ignore)]
				public int errorcode;
				[XmlRpcMissingMapping(MappingAction.Ignore)]
				public string errormsg;
				[XmlRpcMissingMapping(MappingAction.Ignore)]
				public int imageid;
				[XmlRpcMissingMapping(MappingAction.Ignore)]
				public int duration;
				[XmlRpcMissingMapping(MappingAction.Ignore)]
				public int notimeout;
				[XmlRpcMissingMapping(MappingAction.Ignore)]
				public int autologin;
				[XmlRpcMissingMapping(MappingAction.Ignore)]
				public string ostype;
		}
	
		public interface IOneButtonXmlRPC : IXmlRpcProxy
		{
				[XmlRpcMethod]
				XMLRPCaddRequestResult XMLRPCaddRequest(int image_id, string time, int duration);
				[XmlRpcMethod]
				XMLRPCRequestStatus XMLRPCgetRequestStatus(Object request_id);
				[XmlRpcMethod]
				XMLRPCconnectData XMLRPCgetRequestConnectData(Object request_id, string remoteIP);
				[XmlRpcMethod]
				XMLRPCOneButtonParams XMLRPCgetOneButtonParams(int onebuttonid);
				[XmlRpcMethod]
				XMLRPCgetIP XMLRPCgetIP();			
		}
	class Request {

		
		private int oneButtonId = 0;
		private int image_id = 0;
		private int duration = 30;
		private string url = null;
		private string credFile = "certs";
		private string parseFile = "config";
		private string puttyInfo = "puttyInfo";
	  
		public string username = null;
		public string password = null;
		public string execPath = null;
		public string puttyExec = "";
		public string gUID = null;

		public static RijndaelManaged myRijndael = null;

		public delegate void reservationStateChanged(String newState, String message);
		public delegate void connectionParametersReceived(String serverIP, String user, String password);
		public delegate void errorReported(String errorCode, String errorMessage);
		public delegate void FormClose();

		public event reservationStateChanged OnReservationStateChanged;
		public event connectionParametersReceived OnConnectionParametersReceived;
		public event errorReported OnErrorReported;
		public event FormClose OnFormClose;
		Control threadControl = new Control();			

		public Request() {
			threadControl.CreateControl();
			execPath = Application.StartupPath;
		}

		public void saveCred()
		{
				Thread credThread = new Thread(saveCredWorker);
				credThread.Start();
		}

		public void savePutty()
		{
				Thread puttyThread = new Thread(savePuttyWorker);
				puttyThread.Start();
		}

		public void makeRequest() {
				Thread workerThread = new Thread(makeResv);
			workerThread.Start();
		}

		private void saveCredWorker()
		{
				try
				{
						byte[] encryData;
						string path = execPath + "\\" + credFile;
						string data = username + ";" + password;
						Request.myRijndael = new RijndaelManaged();
						Request.myRijndael.Key = ASCIIEncoding.ASCII.GetBytes(gUID);
						Request.myRijndael.IV = ASCIIEncoding.ASCII.GetBytes(gUID);

						encryData = encryptCreds(data,myRijndael.Key,myRijndael.IV);
						int length = encryData.Length;
						File.WriteAllBytes(path, encryData);
				}
				catch(Exception ex)
				{
						sendErrorMessage("Error:", ex.Message);
				}
		}

		private void savePuttyWorker()
		{
				try
				{
						string path = execPath + "\\" + puttyInfo;
						string data = puttyExec;
						using (StreamWriter sw = File.CreateText(path))
						{
								sw.WriteLine(data);
						}
				}
				catch (Exception ex)
				{
						sendErrorMessage("Error:", ex.Message);
				}
		}

		private void makeResv() {

				try
				{
						IOneButtonXmlRPC proxy;
						XMLRPCaddRequestResult create_image;
						XMLRPCconnectData connect_data;
						string decryData;
						sendStateChange("Starting:", "Gathering data...");

						string filename = execPath + "\\" + credFile;
						TextReader reader = new StreamReader(filename);						
						byte[] line = File.ReadAllBytes(filename);
						int length = line.Length;
						System.Console.Write(gUID);
						decryData = decryptCreds(line, myRijndael.Key, myRijndael.IV);
						string[] items = decryData.Trim().Split(';');
						username = items[0];
						items = items[1].Split('\0');
						password = items[0];
						/* Parsing file starts */
						parseConfig();
						/* Parsing file ends */
						Thread.Sleep(2000);	
						reader.Close();
						sendStateChange("Authenticating:", "Checking credentials...");

						Thread.Sleep(2000);						
						IOneButtonXmlRPC OneButtonRPC = XmlRpcProxyGen.Create<IOneButtonXmlRPC>();
						XmlRpcStruct[] structure = new XmlRpcStruct[50];
						proxy = (IOneButtonXmlRPC)XmlRpcProxyGen.Create(typeof(IOneButtonXmlRPC));
						proxy.Url = url;
						proxy.Headers.Add("X-APIVERSION", "2");
						proxy.Headers.Add("X-User", username);
						proxy.Headers.Add("X-Pass", password);
						ServicePointManager.ServerCertificateValidationCallback = AcceptCertificateNoMatterWhat;
						XMLRPCOneButtonParams oneButtonParams = proxy.XMLRPCgetOneButtonParams(oneButtonId);
						if (oneButtonParams.status.Equals("success"))
						{
								image_id = oneButtonParams.imageid;
								duration = oneButtonParams.duration;
						}
						else if (oneButtonParams.status.Equals("error"))
						{
								if (oneButtonParams.errorcode == 3)
								{
										sendErrorMessage("Authentication failure:", "User making a call is not a valid VCL user");
										return;
								}
								else if (oneButtonParams.errorcode == 4)
								{
										sendErrorMessage("Invalid Configuration:", "One-Button does not exist. It may have been deleted.");
										return;
								}
								else if (oneButtonParams.errorcode == 5)
								{
										sendErrorMessage("No Privileges:", "User does not have enough privileges.");
										return;
								}
								else if (oneButtonParams.errorcode == 6)
								{
										sendErrorMessage("One-Button missing:", "One-Button is not yet created. Please create one-button and try again.");
										return;
								}
						}

						if( (oneButtonParams.autologin == 1) && (oneButtonParams.ostype.Equals("linux")) )
						{
								string fileName = execPath + "\\" + puttyInfo;
								if (File.Exists(fileName))
								{
										filename = execPath + "\\" + puttyInfo;
										reader = new StreamReader(filename);
										puttyExec = reader.ReadLine();
										if(!File.Exists(puttyExec))
										{
												sendErrorMessage("Putty missing:", "Putty installation is missing. Download putty and try again.");
												return;
										}
								}
								else
								{
										/* Need to open pop up form where user can input putty path */
										PuttyInfo frmputty = new PuttyInfo();
										if (!(File.Exists(puttyExec)))
										{
												if (frmputty.ShowDialog() == DialogResult.OK)
												{
														/* Continue as it is */
												}
												else
												{
														if ((oneButtonParams.autologin == 1) && (puttyExec.Equals("")))
														{
																sendErrorMessage("Putty missing:", "Putty installation is missing. Please download and try again.");
																return;
														}
												}
										}
								}

						}						


						sendStateChange("Add Image:", "Creating reservation...");
						create_image = proxy.XMLRPCaddRequest(image_id, "now", duration);

						if (create_image.status.Equals("success"))
						{
						}
						else if (create_image.status.Equals("notavailable"))
						{
								sendErrorMessage("Not Available:", "Requested Image not available");
								return;
						}
						else
						{
								sendErrorMessage("Error:", create_image.errormsg);
								return;
						}

						Thread.Sleep(2000);

						Object request_id = (Object)create_image.requestid;

						XMLRPCRequestStatus request_status = proxy.XMLRPCgetRequestStatus(request_id);

						while (!(request_status.status.Equals("ready")))
						{
								if (request_status.status.Equals("failed"))
								{
										sendErrorMessage("Failed:", "Image creation failed. Try again.");
										return;
								}
								else if (request_status.status.Equals("timedout"))
								{
										sendErrorMessage("Timeout:", "Image timedout. Try again.");
										return;
								}
								else if (request_status.status.Equals("error"))
								{
										sendErrorMessage("Error:", create_image.errormsg);
										return;
								}
								else if (request_status.status.Equals("loading"))
								{
										string message = "Image will load in " + request_status.time + " minutes";
										sendStateChange("Loading:", message);
										Thread.Sleep(8000);
								}
								request_status = proxy.XMLRPCgetRequestStatus(request_id);
						}

						sendStateChange("Ready:", "Requested image is ready");
						Thread.Sleep(2000);
						string my_ip_addr;
						if(proxy.XMLRPCgetIP().status.Equals("success"))
						{
								my_ip_addr = proxy.XMLRPCgetIP().ip;
						}
						else
						{
								my_ip_addr = getIP();
						}
						connect_data = proxy.XMLRPCgetRequestConnectData(request_id, my_ip_addr);
						while (!(connect_data.status.Equals("ready")))
						{
								if (connect_data.status.Equals("notready"))
								{
										sendStateChange("Waiting:", "Processing image. Please wait...");
										connect_data = proxy.XMLRPCgetRequestConnectData(request_id, my_ip_addr);
										Thread.Sleep(2000);
										continue;
								}
								else
								{
										sendErrorMessage("Error:", create_image.errormsg);
										Thread.Sleep(2000);
										return;
								}
						}

						string server_ip = connect_data.serverIP;
						string username_reservation = connect_data.user;
						string password_reservation = connect_data.password;

						bool success = false;
						if ((oneButtonParams.ostype.Equals("windows")) && (oneButtonParams.autologin == 1))
						{
								sendStateChange("Connection:", "Connecting to machine...");
								Thread.Sleep(5000);
								success = rdpConnect(server_ip, username_reservation, password_reservation);
						}
						else if ((oneButtonParams.ostype.Equals("linux")) && (oneButtonParams.autologin == 1))
						{
								sendStateChange("Connection:", "Connecting to machine...");
								Thread.Sleep(5000);
								success = puttyConnect(server_ip, username_reservation, password_reservation);
						}
						else if (oneButtonParams.autologin == 0)
						{
								success = true;
						}

						if (success)
						{
								sendConnectionParameters(server_ip, username_reservation, password_reservation);
								Thread.Sleep(2000);
						}

				}
				catch (XmlRpcException ex)
				{
						sendErrorMessage("Error:", ex.Message);						
						if(ex.Message.Contains("Access denied"))
						{
								clearCred();
						}
				}
				catch (Exception Ex)
				{
						sendErrorMessage("Error:", Ex.Message);
						if (Ex.Message.Contains("Access denied"))
						{
								CloseForm();
								clearCred();								
						}
				}
			return;
		}

		public void sendErrorMessage(String code, String message) {
				try
				{

						if (threadControl.InvokeRequired)
						{
								object[] pList = { code, message };
								threadControl.BeginInvoke(OnErrorReported, pList);
						}
						else
						{
								OnErrorReported(code, message);
						}
				}
				catch (Exception Ex)
				{
						sendErrorMessage("Error:", Ex.Message);
				}
		}
	
		public void sendStateChange(String newState, String message) {
			try
			{
				if(threadControl.InvokeRequired) {
				object[] pList = { newState, message };
				threadControl.BeginInvoke(OnReservationStateChanged, pList);
            }
            else {
				OnReservationStateChanged(newState, message);
            }
			}
			catch (Exception Ex)
			{
					sendErrorMessage("Error:", Ex.Message);
			}
		}
	
		public void sendConnectionParameters(String serverIP, String user, String password) {

		  try
			{
			if(threadControl.InvokeRequired) {
				object[] pList = { serverIP, user, password };
				threadControl.BeginInvoke(OnConnectionParametersReceived, pList);
            }
            else {
				OnConnectionParametersReceived(serverIP, user, password);
            }
				}
				catch (Exception Ex)
				{
						sendErrorMessage("Error:", Ex.Message);
				}
		}

			private void CloseForm()
			{
					try
					{
							if (threadControl.InvokeRequired)
							{
									threadControl.BeginInvoke(OnFormClose);
							}
							else
							{
									OnFormClose();
							}
					}
					catch (Exception Ex)
					{
							sendErrorMessage("Error:", Ex.Message);
					}
			}

		/* Function used to accept certificate and proceed further */
		private bool AcceptCertificateNoMatterWhat(object sender,
		System.Security.Cryptography.X509Certificates.X509Certificate cert,
		System.Security.Cryptography.X509Certificates.X509Chain chain,
		System.Net.Security.SslPolicyErrors errors)
		{
				return true;
		}

		/* Function to fetch IP address of local machine */
		public string getIP()
		{
				try
				{
						string strHostName = "";
						strHostName = System.Net.Dns.GetHostName();

						IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);

						IPAddress[] addr = ipEntry.AddressList;

						return addr[addr.Length - 1].ToString();
				}
				catch (Exception Ex)
				{
						sendErrorMessage("Error:", Ex.Message);
				}
				return null;
		}

		/* Function which makes used of connection data obtained from fucntion getConnectionData() and will initiate RDC for windows PC */
			public bool rdpConnect(string server, string username, string password)
		{
				try
				{
						Process rdpprocess = new Process();
						string strExE = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\cmdkey.exe");
						string credentials = "/generic:TERMSRV/" + server + " /user:" + username + " /pass:" + password;
						rdpprocess.StartInfo.FileName = strExE;
						rdpprocess.StartInfo.Arguments = credentials;
						rdpprocess.Start();
						strExE = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\mstsc.exe");
						rdpprocess.StartInfo.FileName = strExE;
						rdpprocess.StartInfo.Arguments = "/v:" + server;
						rdpprocess.Start();
						return true;
				}
				catch (Exception Ex)
				{
						sendErrorMessage("Error:", Ex.Message);
				}
				return false;
		}

		/* Function which makes used of connection data obtained from fucntion getConnectionData() and will initiate Putty for Linux */
		/* putty.exe vcldev@152.46.17.149 -pw vcldev */
		public bool puttyConnect(string server, string username, string password)
		{
				try
				{
						string filename = execPath + "\\" + puttyInfo;					
						TextReader reader = new StreamReader(filename);
						puttyExec = reader.ReadLine();
						Process puttyprocess = new Process();
						string strExE = Environment.ExpandEnvironmentVariables(puttyExec);
						string connStr = username + "@" + server + " -pw " + password ;
						puttyprocess.StartInfo.FileName = strExE;
						puttyprocess.StartInfo.Arguments = connStr;
						puttyprocess.Start();
						return true;
				}
				catch (Exception Ex)
				{
						sendErrorMessage("Error:", Ex.Message);
				}
				return false;
		}

		/* Function used to parse text file which will be available from the configurator package */
			void parseConfig()
		{
				try
				{
						string filename = execPath + "\\" + parseFile;
						if (File.Exists(filename))
						{
								TextReader reader = new StreamReader(filename);
								string line;
								while ((line = reader.ReadLine()) != null)
								{
										string[] items = line.Split('=');

										if (items[0].Equals("vclURL"))
										{
												url = items[1].ToString() + "=" + items[2].ToString();
												continue;
										}
										else if (items[0].Equals("oneButtonID"))
										{
												oneButtonId = int.Parse(items[1].ToString());												
										}
								}
								reader.Close();
						}
						else
						{
								MessageBox.Show("Configuration file missing.", "Parameter Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
								Application.Exit();
						}
				}
				catch (Exception Ex)
				{
						sendErrorMessage("Error:", Ex.Message);
				}
		}

		void clearCred()
		{
				try
				{
						string path = execPath + "\\" + credFile;
						if (File.Exists(path))
						{
								File.Delete(path);
								MessageBox.Show("Incorrect Credentials. Please try again.", "Authentication Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
								Application.Restart();
						}
				}
				catch(Exception Ex)
				{
						sendErrorMessage("Error:", Ex.Message);
				}
		}

			static byte[] encryptCreds(string plainText, byte[] Key, byte[] IV)
			{
					// Check arguments.
					if (plainText == null || plainText.Length <= 0)
							throw new ArgumentNullException("plainText");
					if (Key == null || Key.Length <= 0)
							throw new ArgumentNullException("Key");
					if (IV == null || IV.Length <= 0)
							throw new ArgumentNullException("Key");
					byte[] encrypted;
					// Create an RijndaelManaged object
					// with the specified key and IV.
					using (RijndaelManaged rijAlg = new RijndaelManaged())
					{
							rijAlg.Key = Key;
							rijAlg.IV = IV;
							rijAlg.Mode = CipherMode.CBC;
							rijAlg.Padding = PaddingMode.Zeros;

							// Create a decrytor to perform the stream transform.
							ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

							// Create the streams used for encryption.
							using (MemoryStream msEncrypt = new MemoryStream())
							{
									using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
									{
											using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
											{
													//Write all data to the stream.
													swEncrypt.Write(plainText);
											}
											encrypted = msEncrypt.ToArray();
									}
							}
					}
					// Return the encrypted bytes from the memory stream.
					return encrypted;
			}

			static string decryptCreds(byte[] cipherText, byte[] Key, byte[] IV)
			{
					// Check arguments.
					if (cipherText == null || cipherText.Length <= 0)
							throw new ArgumentNullException("cipherText");
					if (Key == null || Key.Length <= 0)
							throw new ArgumentNullException("Key");
					if (IV == null || IV.Length <= 0)
							throw new ArgumentNullException("Key");

					// Declare the string used to hold
					// the decrypted text.
					string plaintext = null;

					// Create an RijndaelManaged object
					// with the specified key and IV.
					using (RijndaelManaged rijAlg = new RijndaelManaged())
					{
							rijAlg.Key = Key;
							rijAlg.IV = IV;
							rijAlg.Mode = CipherMode.CBC;
							rijAlg.Padding = PaddingMode.Zeros;

							// Create a decrytor to perform the stream transform.
							ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

							// Create the streams used for decryption.
							using (MemoryStream msDecrypt = new MemoryStream(cipherText))
							{
									using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
									{
											using (StreamReader srDecrypt = new StreamReader(csDecrypt))
											{
													// Read the decrypted bytes from the decrypting stream
													// and place them in a string.
													plaintext = srDecrypt.ReadToEnd();
											}
									}
							}
					}
					return plaintext;
			}
	}
}
