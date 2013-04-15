namespace OneClickApp {
	partial class frmOneClick {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOneClick));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblMessageHeader = new System.Windows.Forms.Label();
            this.lblMessageDesc = new System.Windows.Forms.Label();
            this.lblMessageUn = new System.Windows.Forms.Label();
            this.lblMessagePwd = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(41, 68);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(234, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 6;
            this.progressBar1.Visible = false;
            // 
            // lblMessageHeader
            // 
            this.lblMessageHeader.AutoSize = true;
            this.lblMessageHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessageHeader.Location = new System.Drawing.Point(30, 101);
            this.lblMessageHeader.Name = "lblMessageHeader";
            this.lblMessageHeader.Size = new System.Drawing.Size(0, 16);
            this.lblMessageHeader.TabIndex = 7;
            // 
            // lblMessageDesc
            // 
            this.lblMessageDesc.AutoSize = true;
            this.lblMessageDesc.Location = new System.Drawing.Point(20, 117);
            this.lblMessageDesc.Name = "lblMessageDesc";
            this.lblMessageDesc.Size = new System.Drawing.Size(0, 13);
            this.lblMessageDesc.TabIndex = 8;
            // 
            // lblMessageUn
            // 
            this.lblMessageUn.AutoSize = true;
            this.lblMessageUn.Location = new System.Drawing.Point(20, 131);
            this.lblMessageUn.Name = "lblMessageUn";
            this.lblMessageUn.Size = new System.Drawing.Size(0, 13);
            this.lblMessageUn.TabIndex = 9;
            // 
            // lblMessagePwd
            // 
            this.lblMessagePwd.AutoSize = true;
            this.lblMessagePwd.Location = new System.Drawing.Point(20, 145);
            this.lblMessagePwd.Name = "lblMessagePwd";
            this.lblMessagePwd.Size = new System.Drawing.Size(0, 13);
            this.lblMessagePwd.TabIndex = 10;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(20, 163);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-2, 194);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(321, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(-43, -1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(362, 58);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(160, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Extend Reservation By";
            // 
            // comboBox1 : Durations for extend reservation request.
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "15 Min",
            "30 Min ",
            "1 Hour",
            "1 Hour 30 Min",
            "2 Hour",
            "2 Hour 30 Min",
            "3 Hour"});
            this.comboBox1.Location = new System.Drawing.Point(160, 136);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.Text = "Select Dration";
            // 
            // btnSubmit : To submit extend reservation request.
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(160, 163);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 11;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label2 : For status of extend reservation request
            // 
            this.label2.Location = new System.Drawing.Point(160, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(300, 15);
            this.label2.TabIndex = 9;
            //this.label2.Text = "ldjflishfdljkdshjsfdghkfdjsghdjfslkghkdshgljsadhfkjsdahfjsadhfjsdahfsdjkfhdlsjk";
            // 
            // frmOneClick
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(317, 225);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblMessagePwd);
            this.Controls.Add(this.lblMessageUn);
            this.Controls.Add(this.lblMessageDesc);
            this.Controls.Add(this.lblMessageHeader);
            this.Controls.Add(this.progressBar1);
            this.Name = "frmOneClick";
            this.Text = "One-Button Application";
            this.Load += new System.EventHandler(this.frmOneClick_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ProgressBar progressBar1;
			private System.Windows.Forms.Label lblMessageHeader;
			private System.Windows.Forms.Label lblMessageDesc;
			private System.Windows.Forms.Label lblMessageUn;
			private System.Windows.Forms.Label lblMessagePwd;
			private System.Windows.Forms.Button btnClose;
			private System.Windows.Forms.PictureBox pictureBox1;
			private System.Windows.Forms.PictureBox pictureBox2;
            private System.Windows.Forms.Label label2;
            private System.Windows.Forms.Label label1;
            private System.Windows.Forms.ComboBox comboBox1;
            private System.Windows.Forms.Button btnSubmit;
	}
}

