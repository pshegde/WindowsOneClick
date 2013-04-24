namespace OneClickApp
{
		partial class OneClickAppCred
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
                    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OneClickAppCred));
                    this.lblUsername = new System.Windows.Forms.Label();
                    this.txtUsername = new System.Windows.Forms.TextBox();
                    this.lblPassword = new System.Windows.Forms.Label();
                    this.txtPassword = new System.Windows.Forms.TextBox();
                    this.btnSave = new System.Windows.Forms.Button();
                    this.lblStatus = new System.Windows.Forms.Label();
                    this.btnCancel = new System.Windows.Forms.Button();
                    this.pictureBox1 = new System.Windows.Forms.PictureBox();
                    this.pictureBox2 = new System.Windows.Forms.PictureBox();
                    ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
                    ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
                    this.SuspendLayout();
                    // 
                    // lblUsername
                    // 
                    this.lblUsername.AutoSize = true;
                    this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.lblUsername.Location = new System.Drawing.Point(87, 69);
                    this.lblUsername.Name = "lblUsername";
                    this.lblUsername.Size = new System.Drawing.Size(73, 15);
                    this.lblUsername.TabIndex = 0;
                    this.lblUsername.Text = "Username";
                    // 
                    // txtUsername
                    // 
                    this.txtUsername.Location = new System.Drawing.Point(90, 85);
                    this.txtUsername.Name = "txtUsername";
                    this.txtUsername.Size = new System.Drawing.Size(134, 20);
                    this.txtUsername.TabIndex = 1;
                    // 
                    // lblPassword
                    // 
                    this.lblPassword.AutoSize = true;
                    this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.lblPassword.Location = new System.Drawing.Point(89, 119);
                    this.lblPassword.Name = "lblPassword";
                    this.lblPassword.Size = new System.Drawing.Size(69, 15);
                    this.lblPassword.TabIndex = 2;
                    this.lblPassword.Text = "Password";
                    // 
                    // txtPassword
                    // 
                    this.txtPassword.Location = new System.Drawing.Point(90, 135);
                    this.txtPassword.Name = "txtPassword";
                    this.txtPassword.PasswordChar = '*';
                    this.txtPassword.Size = new System.Drawing.Size(134, 20);
                    this.txtPassword.TabIndex = 3;
                    // 
                    // btnSave
                    // 
                    this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.btnSave.Location = new System.Drawing.Point(77, 187);
                    this.btnSave.Name = "btnSave";
                    this.btnSave.Size = new System.Drawing.Size(75, 23);
                    this.btnSave.TabIndex = 4;
                    this.btnSave.Text = "Save";
                    this.btnSave.UseVisualStyleBackColor = true;
                    this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
                    // 
                    // lblStatus
                    // 
                    this.lblStatus.AutoSize = true;
                    this.lblStatus.Location = new System.Drawing.Point(87, 163);
                    this.lblStatus.Name = "lblStatus";
                    this.lblStatus.Size = new System.Drawing.Size(0, 13);
                    this.lblStatus.TabIndex = 5;
                    // 
                    // btnCancel
                    // 
                    this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.btnCancel.Location = new System.Drawing.Point(158, 187);
                    this.btnCancel.Name = "btnCancel";
                    this.btnCancel.Size = new System.Drawing.Size(75, 23);
                    this.btnCancel.TabIndex = 6;
                    this.btnCancel.Text = "Cancel";
                    this.btnCancel.UseVisualStyleBackColor = true;
                    this.btnCancel.Click += new System.EventHandler(this.btnClose_Click);
                    // 
                    // pictureBox1
                    // 
                    this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
                    this.pictureBox1.Location = new System.Drawing.Point(-35, -14);
                    this.pictureBox1.Name = "pictureBox1";
                    this.pictureBox1.Size = new System.Drawing.Size(348, 67);
                    this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                    this.pictureBox1.TabIndex = 7;
                    this.pictureBox1.TabStop = false;
                    // 
                    // pictureBox2
                    // 
                    this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
                    this.pictureBox2.Location = new System.Drawing.Point(-4, 228);
                    this.pictureBox2.Name = "pictureBox2";
                    this.pictureBox2.Size = new System.Drawing.Size(318, 29);
                    this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    this.pictureBox2.TabIndex = 8;
                    this.pictureBox2.TabStop = false;
                    // 
                    // OneClickAppCred
                    // 
                    this.AcceptButton = this.btnSave;
                    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                    this.BackColor = System.Drawing.Color.Silver;
                    this.CancelButton = this.btnCancel;
                    this.ClientSize = new System.Drawing.Size(311, 254);
                    this.Controls.Add(this.pictureBox2);
                    this.Controls.Add(this.pictureBox1);
                    this.Controls.Add(this.btnCancel);
                    this.Controls.Add(this.lblStatus);
                    this.Controls.Add(this.btnSave);
                    this.Controls.Add(this.txtPassword);
                    this.Controls.Add(this.lblPassword);
                    this.Controls.Add(this.txtUsername);
                    this.Controls.Add(this.lblUsername);
                    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                    this.MaximizeBox = false;
                    this.MinimizeBox = false;
                    this.Name = "OneClickAppCred";
                    this.Text = "OneClick Credential";
                    this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OneClickAppCred_FormClosing);
                    this.Load += new System.EventHandler(this.OneClickAppCred_Load);
                    ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
                    ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
                    this.ResumeLayout(false);
                    this.PerformLayout();

				}

				#endregion

				private System.Windows.Forms.Label lblUsername;
				private System.Windows.Forms.TextBox txtUsername;
				private System.Windows.Forms.Label lblPassword;
				private System.Windows.Forms.TextBox txtPassword;
				private System.Windows.Forms.Button btnSave;
				private System.Windows.Forms.Label lblStatus;
				private System.Windows.Forms.Button btnCancel;
				private System.Windows.Forms.PictureBox pictureBox1;
				private System.Windows.Forms.PictureBox pictureBox2;
		}
}