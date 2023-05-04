using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace DBExplorer
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmlogin : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtusername;
		private System.Windows.Forms.TextBox txtpasswd;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnlogin;
		private System.Windows.Forms.Button btnclear;
		private System.Windows.Forms.TextBox txtdatasrc;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmlogin()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
		#region user-defined variables...
		public static OleDbConnection   con;
		public static frmdbexplorer objexplorer;
		public static frmlogin objlogin;
		public static string username,passwd,datasrc,dbname;
		#endregion

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.txtusername = new System.Windows.Forms.TextBox();
			this.txtpasswd = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtdatasrc = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnlogin = new System.Windows.Forms.Button();
			this.btnclear = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Enter User-Name: ";
			// 
			// txtusername
			// 
			this.txtusername.Location = new System.Drawing.Point(128, 16);
			this.txtusername.Name = "txtusername";
			this.txtusername.Size = new System.Drawing.Size(168, 20);
			this.txtusername.TabIndex = 1;
			this.txtusername.Text = "";
			// 
			// txtpasswd
			// 
			this.txtpasswd.Location = new System.Drawing.Point(128, 48);
			this.txtpasswd.Name = "txtpasswd";
			this.txtpasswd.PasswordChar = '*';
			this.txtpasswd.Size = new System.Drawing.Size(168, 20);
			this.txtpasswd.TabIndex = 3;
			this.txtpasswd.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Enter Password:";
			// 
			// txtdatasrc
			// 
			this.txtdatasrc.Location = new System.Drawing.Point(128, 80);
			this.txtdatasrc.Name = "txtdatasrc";
			this.txtdatasrc.Size = new System.Drawing.Size(168, 20);
			this.txtdatasrc.TabIndex = 5;
			this.txtdatasrc.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(24, 80);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Data Source";
			// 
			// btnlogin
			// 
			this.btnlogin.Location = new System.Drawing.Point(72, 120);
			this.btnlogin.Name = "btnlogin";
			this.btnlogin.TabIndex = 6;
			this.btnlogin.Text = "Login";
			this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
			// 
			// btnclear
			// 
			this.btnclear.Location = new System.Drawing.Point(160, 120);
			this.btnclear.Name = "btnclear";
			this.btnclear.TabIndex = 7;
			this.btnclear.Text = "Clear";
			this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
			// 
			// frmlogin
			// 
			this.AcceptButton = this.btnlogin;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.ClientSize = new System.Drawing.Size(312, 158);
			this.Controls.Add(this.txtdatasrc);
			this.Controls.Add(this.txtpasswd);
			this.Controls.Add(this.txtusername);
			this.Controls.Add(this.btnclear);
			this.Controls.Add(this.btnlogin);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.MaximizeBox = false;
			this.Name = "frmlogin";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Login...";
			this.Closed += new System.EventHandler(this.frmlogin_Closed);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			objlogin = new frmlogin();
			objlogin.Show();
			Application.Run();
		}
       private void btnlogin_Click(object sender, System.EventArgs e)
		{
			try
			{
				username = txtusername.Text.Trim();
				passwd   = txtpasswd.Text.Trim();
				datasrc  = txtdatasrc.Text.Trim();
				if(txtdatasrc.Text.ToUpper().IndexOf("SID") == -1 && txtdatasrc.Text.Trim() != "")
				{
					con = new  OleDbConnection("provider=msdaora;data source="+txtdatasrc.Text.ToString().Trim()+";user id="+username+";password="+passwd+";");
					dbname = datasrc;
				}
				if(txtdatasrc.Text.Trim() == "")
				{
					con = new  OleDbConnection("provider=msdaora;data source="+System.Configuration.ConfigurationSettings.AppSettings[0].ToString()+";user id="+username+";password="+passwd+";");
					dbname = System.Configuration.ConfigurationSettings.AppSettings[0].ToString().Trim().ToUpper().Substring(System.Configuration.ConfigurationSettings.AppSettings[0].ToString().Trim().ToUpper().IndexOf("SID")).Replace("SID","").Replace("=","").Replace(")","").Replace(";","").Trim();
				}
					
				else if(txtdatasrc.Text.ToUpper().IndexOf("SID") != -1)
				{
	                con = new  OleDbConnection("provider=msdaora;data source="+txtdatasrc.Text.ToString()+";user id="+username+";password="+passwd+";");
					dbname = txtdatasrc.Text.Trim().ToUpper().Substring(txtdatasrc.Text.Trim().ToUpper().IndexOf("SID")).Replace("SID","").Replace("=","").Replace(")","").Replace(";","").Trim();
				}
				con.Open();
				if(con.State.ToString().ToUpper() == "OPEN")
				{
                  objlogin.Hide();
				  objexplorer = new frmdbexplorer();
				  objexplorer.Text = "Database Name : "+dbname;
				  objexplorer.Show();
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				txtpasswd.Text = "";
				txtusername.Text = "";
				txtdatasrc.Text = "";
				txtusername.Focus();
			}

		}

		private void btnclear_Click(object sender, System.EventArgs e)
		{
			txtpasswd.Text = "";
			txtusername.Text = "";
			txtdatasrc.Text = "";
			txtusername.Focus();
		}
		private void frmlogin_Closed(object sender, System.EventArgs e)
		{
			Application.Exit();
		}
	}
}
