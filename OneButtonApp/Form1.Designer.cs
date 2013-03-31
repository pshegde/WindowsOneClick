namespace OneClickApp
{
		partial class Form1
		{
				/// <summary>
				/// Required designer variable.
				/// </summary>
				private System.ComponentModel.IContainer components = null;

				/// <summary>
				/// Clean up any resources being used.
				/// </summary>
				/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
				protected override void Dispose(bool disposing)
				{
						if (disposing && (components != null))
						{
								components.Dispose();
						}
						base.Dispose(disposing);
				}

				#region Windows Form Designer generated code

				/// <summary>
				/// Required method for Designer support - do not modify
				/// the contents of this method with the code editor.
				/// </summary>
				private void InitializeComponent()
				{
						this.lblUserName = new System.Windows.Forms.Label();
						this.lblPassword = new System.Windows.Forms.Label();
						this.txtUserName = new System.Windows.Forms.TextBox();
						this.txtPassword = new System.Windows.Forms.TextBox();
						this.btnLogin = new System.Windows.Forms.Button();
						this.lblUserMessage = new System.Windows.Forms.Label();
						this.lblHeader = new System.Windows.Forms.Label();
						this.SuspendLayout();
						// 
						// lblUserName
						// 
						this.lblUserName.AutoSize = true;
						this.lblUserName.Location = new System.Drawing.Point(57, 112);
						this.lblUserName.Name = "lblUserName";
						this.lblUserName.Size = new System.Drawing.Size(66, 13);
						this.lblUserName.TabIndex = 0;
						this.lblUserName.Text = "User Name: ";
						// 
						// lblPassword
						// 
						this.lblPassword.AutoSize = true;
						this.lblPassword.Location = new System.Drawing.Point(60, 173);
						this.lblPassword.Name = "lblPassword";
						this.lblPassword.Size = new System.Drawing.Size(59, 13);
						this.lblPassword.TabIndex = 1;
						this.lblPassword.Text = "Password: ";
						// 
						// txtUserName
						// 
						this.txtUserName.Location = new System.Drawing.Point(207, 112);
						this.txtUserName.Name = "txtUserName";
						this.txtUserName.Size = new System.Drawing.Size(100, 20);
						this.txtUserName.TabIndex = 2;
						// 
						// txtPassword
						// 
						this.txtPassword.Location = new System.Drawing.Point(207, 165);
						this.txtPassword.Name = "txtPassword";
						this.txtPassword.PasswordChar = '*';
						this.txtPassword.Size = new System.Drawing.Size(100, 20);
						this.txtPassword.TabIndex = 3;
						// 
						// btnLogin
						// 
						this.btnLogin.Location = new System.Drawing.Point(63, 211);
						this.btnLogin.Name = "btnLogin";
						this.btnLogin.Size = new System.Drawing.Size(75, 23);
						this.btnLogin.TabIndex = 4;
						this.btnLogin.Text = "Login";
						this.btnLogin.UseVisualStyleBackColor = true;
						this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
						// 
						// lblUserMessage
						// 
						this.lblUserMessage.AutoSize = true;
						this.lblUserMessage.Location = new System.Drawing.Point(60, 265);
						this.lblUserMessage.Name = "lblUserMessage";
						this.lblUserMessage.Size = new System.Drawing.Size(0, 13);
						this.lblUserMessage.TabIndex = 5;
						// 
						// lblHeader
						// 
						this.lblHeader.AutoSize = true;
						this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
						this.lblHeader.Location = new System.Drawing.Point(12, 9);
						this.lblHeader.Name = "lblHeader";
						this.lblHeader.Size = new System.Drawing.Size(260, 29);
						this.lblHeader.TabIndex = 6;
						this.lblHeader.Text = "One-Button Application";
						// 
						// Form1
						// 
						this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
						this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
						this.ClientSize = new System.Drawing.Size(478, 427);
						this.Controls.Add(this.lblHeader);
						this.Controls.Add(this.lblUserMessage);
						this.Controls.Add(this.btnLogin);
						this.Controls.Add(this.txtPassword);
						this.Controls.Add(this.txtUserName);
						this.Controls.Add(this.lblPassword);
						this.Controls.Add(this.lblUserName);
						this.Name = "Form1";
						this.Text = "Form1";
						this.Load += new System.EventHandler(this.Form1_Load);
						this.ResumeLayout(false);
						this.PerformLayout();

				}

				#endregion

				private System.Windows.Forms.Label lblUserName;
				private System.Windows.Forms.Label lblPassword;
				private System.Windows.Forms.TextBox txtUserName;
				private System.Windows.Forms.TextBox txtPassword;
				private System.Windows.Forms.Button btnLogin;
				private System.Windows.Forms.Label lblUserMessage;
				private System.Windows.Forms.Label lblHeader;
		}
}

