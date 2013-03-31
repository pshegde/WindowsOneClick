namespace OneClickApp
{
		partial class PuttyInfo
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
						System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PuttyInfo));
						this.lblHdr = new System.Windows.Forms.Label();
						this.txtPuttyPath = new System.Windows.Forms.TextBox();
						this.btnSave = new System.Windows.Forms.Button();
						this.btnCancel = new System.Windows.Forms.Button();
						this.lblStatus = new System.Windows.Forms.Label();
						this.pictureBox1 = new System.Windows.Forms.PictureBox();
						this.pictureBox2 = new System.Windows.Forms.PictureBox();
						((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
						((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
						this.SuspendLayout();
						// 
						// lblHdr
						// 
						this.lblHdr.AutoSize = true;
						this.lblHdr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
						this.lblHdr.Location = new System.Drawing.Point(14, 70);
						this.lblHdr.Name = "lblHdr";
						this.lblHdr.Size = new System.Drawing.Size(81, 16);
						this.lblHdr.TabIndex = 0;
						this.lblHdr.Text = "Putty Path:";
						// 
						// txtPuttyPath
						// 
						this.txtPuttyPath.Location = new System.Drawing.Point(17, 96);
						this.txtPuttyPath.Name = "txtPuttyPath";
						this.txtPuttyPath.Size = new System.Drawing.Size(250, 20);
						this.txtPuttyPath.TabIndex = 1;
						// 
						// btnSave
						// 
						this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
						this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
						this.btnSave.Location = new System.Drawing.Point(76, 160);
						this.btnSave.Name = "btnSave";
						this.btnSave.Size = new System.Drawing.Size(75, 23);
						this.btnSave.TabIndex = 2;
						this.btnSave.Text = "Save";
						this.btnSave.UseVisualStyleBackColor = true;
						this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
						// 
						// btnCancel
						// 
						this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
						this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
						this.btnCancel.Location = new System.Drawing.Point(156, 160);
						this.btnCancel.Name = "btnCancel";
						this.btnCancel.Size = new System.Drawing.Size(75, 23);
						this.btnCancel.TabIndex = 3;
						this.btnCancel.Text = "Cancel";
						this.btnCancel.UseVisualStyleBackColor = true;
						this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
						// 
						// lblStatus
						// 
						this.lblStatus.AutoSize = true;
						this.lblStatus.Location = new System.Drawing.Point(14, 133);
						this.lblStatus.Name = "lblStatus";
						this.lblStatus.Size = new System.Drawing.Size(0, 13);
						this.lblStatus.TabIndex = 4;
						// 
						// pictureBox1
						// 
						this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
						this.pictureBox1.Location = new System.Drawing.Point(-113, -26);
						this.pictureBox1.Name = "pictureBox1";
						this.pictureBox1.Size = new System.Drawing.Size(423, 83);
						this.pictureBox1.TabIndex = 5;
						this.pictureBox1.TabStop = false;
						// 
						// pictureBox2
						// 
						this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
						this.pictureBox2.Location = new System.Drawing.Point(-1, 212);
						this.pictureBox2.Name = "pictureBox2";
						this.pictureBox2.Size = new System.Drawing.Size(311, 31);
						this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
						this.pictureBox2.TabIndex = 6;
						this.pictureBox2.TabStop = false;
						// 
						// PuttyInfo
						// 
						this.AcceptButton = this.btnSave;
						this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
						this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
						this.BackColor = System.Drawing.Color.Silver;
						this.CancelButton = this.btnCancel;
						this.ClientSize = new System.Drawing.Size(307, 242);
						this.Controls.Add(this.pictureBox2);
						this.Controls.Add(this.pictureBox1);
						this.Controls.Add(this.lblStatus);
						this.Controls.Add(this.btnCancel);
						this.Controls.Add(this.btnSave);
						this.Controls.Add(this.txtPuttyPath);
						this.Controls.Add(this.lblHdr);
						this.Name = "PuttyInfo";
						this.Text = "PuttyInfo";
						this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PuttyInfo_FormClosing);
						((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
						((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
						this.ResumeLayout(false);
						this.PerformLayout();

				}

				#endregion

				private System.Windows.Forms.Label lblHdr;
				private System.Windows.Forms.TextBox txtPuttyPath;
				private System.Windows.Forms.Button btnSave;
				private System.Windows.Forms.Button btnCancel;
				private System.Windows.Forms.Label lblStatus;
				private System.Windows.Forms.PictureBox pictureBox1;
				private System.Windows.Forms.PictureBox pictureBox2;
		}
}