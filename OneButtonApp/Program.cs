using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace OneClickApp
{
		static class Program
		{
				/// <summary>
				/// The main entry point for the application.
				/// </summary>
				[STAThread]
				static void Main(String[] args)
				{
						string credFile = "certs";
						string path = Application.StartupPath + "\\" + credFile;
						if (args.Length > 0)
						{
								if (args[0].ToString().Equals("-clear"))
								{
										if (File.Exists(path))
										{
												File.Delete(path);
												return;
										}
								}
						}
						Application.EnableVisualStyles();						
						Application.SetCompatibleTextRenderingDefault(false);												
						if (!(File.Exists(path)))
						{
								OneClickAppCred frmLogin = new OneClickAppCred();
								if (frmLogin.ShowDialog() == DialogResult.OK)
								{
										Application.Run(new frmOneClick());
								}
						}
						else
						{
								Application.Run(new frmOneClick());
						}
				}
		}
}