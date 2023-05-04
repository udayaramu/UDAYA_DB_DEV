using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Xml;
using System.IO;
using System.Data;
using System.Threading;
using System.Diagnostics;

namespace DBExplorer
{
	/// <summary>
	/// Summary description for frmdbexplorer.
	/// </summary>
	/// 
	 
	public class frmdbexplorer : System.Windows.Forms.Form
	{
    	private System.Windows.Forms.TreeView tvdbexplorer;
		private System.Windows.Forms.TabControl tbctrl;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TextBox txtdefn;
		private System.Windows.Forms.TextBox txtselectquery;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.ContextMenu cxtmnutreeview;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.ImageList tvimglist;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem14;
		private System.Windows.Forms.MenuItem menuItem17;
		private System.Windows.Forms.MenuItem menuItem18;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbDBItems;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.MenuItem menuItem16;
		private System.Windows.Forms.MenuItem menuItem19;
		private System.Windows.Forms.MenuItem menuItem20;
		private System.Windows.Forms.MenuItem menuItem21;
		private System.Windows.Forms.MenuItem menuItem22;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.MenuItem mnurecentqueries;
        public bool fulldetailsrequired = false;
		private System.Windows.Forms.MenuItem menuItem10;
		public ArrayList recentqueries;
		public frmdbexplorer()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmdbexplorer));
			this.tvdbexplorer = new System.Windows.Forms.TreeView();
			this.cxtmnutreeview = new System.Windows.Forms.ContextMenu();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.tvimglist = new System.Windows.Forms.ImageList(this.components);
			this.tbctrl = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.txtdefn = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.txtselectquery = new System.Windows.Forms.TextBox();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuItem17 = new System.Windows.Forms.MenuItem();
			this.menuItem18 = new System.Windows.Forms.MenuItem();
			this.menuItem14 = new System.Windows.Forms.MenuItem();
			this.menuItem15 = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem16 = new System.Windows.Forms.MenuItem();
			this.menuItem21 = new System.Windows.Forms.MenuItem();
			this.menuItem22 = new System.Windows.Forms.MenuItem();
			this.menuItem19 = new System.Windows.Forms.MenuItem();
			this.menuItem20 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.mnurecentqueries = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.menuItem12 = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbDBItems = new System.Windows.Forms.ComboBox();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.tbctrl.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// tvdbexplorer
			// 
			this.tvdbexplorer.ContextMenu = this.cxtmnutreeview;
			this.tvdbexplorer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tvdbexplorer.ImageIndex = 3;
			this.tvdbexplorer.ImageList = this.tvimglist;
			this.tvdbexplorer.ItemHeight = 16;
			this.tvdbexplorer.Location = new System.Drawing.Point(8, 32);
			this.tvdbexplorer.Name = "tvdbexplorer";
			this.tvdbexplorer.Size = new System.Drawing.Size(296, 624);
			this.tvdbexplorer.TabIndex = 0;
			this.tvdbexplorer.Click += new System.EventHandler(this.tvdbexplorer_Click);
			// 
			// cxtmnutreeview
			// 
			this.cxtmnutreeview.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						   this.menuItem11});
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 0;
			this.menuItem11.Text = "Load Data";
			this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
			// 
			// tvimglist
			// 
			this.tvimglist.ImageSize = new System.Drawing.Size(20, 20);
			this.tvimglist.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("tvimglist.ImageStream")));
			this.tvimglist.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// tbctrl
			// 
			this.tbctrl.Controls.Add(this.tabPage1);
			this.tbctrl.Controls.Add(this.tabPage2);
			this.tbctrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbctrl.Location = new System.Drawing.Point(320, 32);
			this.tbctrl.Name = "tbctrl";
			this.tbctrl.SelectedIndex = 0;
			this.tbctrl.Size = new System.Drawing.Size(704, 632);
			this.tbctrl.TabIndex = 1;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.txtdefn);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(696, 606);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Selected Item Defn";
			// 
			// txtdefn
			// 
			this.txtdefn.BackColor = System.Drawing.SystemColors.HighlightText;
			this.txtdefn.Location = new System.Drawing.Point(8, 8);
			this.txtdefn.Multiline = true;
			this.txtdefn.Name = "txtdefn";
			this.txtdefn.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtdefn.Size = new System.Drawing.Size(672, 592);
			this.txtdefn.TabIndex = 0;
			this.txtdefn.Text = "";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.dataGrid1);
			this.tabPage2.Controls.Add(this.txtselectquery);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(696, 606);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Execute Query";
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(8, 256);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(672, 336);
			this.dataGrid1.TabIndex = 1;
			// 
			// txtselectquery
			// 
			this.txtselectquery.Location = new System.Drawing.Point(8, 8);
			this.txtselectquery.Multiline = true;
			this.txtselectquery.Name = "txtselectquery";
			this.txtselectquery.Size = new System.Drawing.Size(672, 232);
			this.txtselectquery.TabIndex = 0;
			this.txtselectquery.Text = "";
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem5,
																					  this.menuItem2,
																					  this.menuItem3,
																					  this.mnurecentqueries,
																					  this.menuItem9,
																					  this.menuItem4});
			this.menuItem1.Text = "Main";
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 0;
			this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem6,
																					  this.menuItem7});
			this.menuItem5.Text = "View objects of";
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 0;
			this.menuItem6.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem8,
																					  this.menuItem14,
																					  this.menuItem15});
			this.menuItem6.Text = "ALL";
			this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 0;
			this.menuItem8.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem17,
																					  this.menuItem18});
			this.menuItem8.Text = "Tables";
			// 
			// menuItem17
			// 
			this.menuItem17.Index = 0;
			this.menuItem17.Text = "Full Details";
			this.menuItem17.Click += new System.EventHandler(this.menuItem17_Click);
			// 
			// menuItem18
			// 
			this.menuItem18.Index = 1;
			this.menuItem18.Text = "Partial Details";
			this.menuItem18.Click += new System.EventHandler(this.menuItem18_Click);
			// 
			// menuItem14
			// 
			this.menuItem14.Index = 1;
			this.menuItem14.Text = "Procedures";
			this.menuItem14.Click += new System.EventHandler(this.menuItem14_Click);
			// 
			// menuItem15
			// 
			this.menuItem15.Index = 2;
			this.menuItem15.Text = "Functions";
			this.menuItem15.Click += new System.EventHandler(this.menuItem15_Click_1);
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 1;
			this.menuItem7.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem16,
																					  this.menuItem19,
																					  this.menuItem20});
			this.menuItem7.Text = "MINE";
			this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
			// 
			// menuItem16
			// 
			this.menuItem16.Index = 0;
			this.menuItem16.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem21,
																					   this.menuItem22});
			this.menuItem16.Text = "Tables";
			// 
			// menuItem21
			// 
			this.menuItem21.Index = 0;
			this.menuItem21.Text = "Full Details";
			this.menuItem21.Click += new System.EventHandler(this.menuItem21_Click);
			// 
			// menuItem22
			// 
			this.menuItem22.Index = 1;
			this.menuItem22.Text = "Partial Details";
			this.menuItem22.Click += new System.EventHandler(this.menuItem22_Click);
			// 
			// menuItem19
			// 
			this.menuItem19.Index = 1;
			this.menuItem19.Text = "Procedures";
			this.menuItem19.Click += new System.EventHandler(this.menuItem19_Click);
			// 
			// menuItem20
			// 
			this.menuItem20.Index = 2;
			this.menuItem20.Text = "Functions";
			this.menuItem20.Click += new System.EventHandler(this.menuItem20_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Shortcut = System.Windows.Forms.Shortcut.F5;
			this.menuItem2.Text = "Execute Query";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 2;
			this.menuItem3.Text = "Export to XML";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// mnurecentqueries
			// 
			this.mnurecentqueries.Index = 3;
			this.mnurecentqueries.Text = "Recent Queries";
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 4;
			this.menuItem9.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem12,
																					  this.menuItem10});
			this.menuItem9.Text = "Cancel Current";
			// 
			// menuItem12
			// 
			this.menuItem12.Index = 0;
			this.menuItem12.Text = " Loading Tables";
			this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click);
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 1;
			this.menuItem10.Text = "Loading Objects";
			this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 5;
			this.menuItem4.Text = "E&xit";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(368, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "Available Procedures: ";
			// 
			// cmbDBItems
			// 
			this.cmbDBItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cmbDBItems.Location = new System.Drawing.Point(512, 0);
			this.cmbDBItems.Name = "cmbDBItems";
			this.cmbDBItems.Size = new System.Drawing.Size(360, 21);
			this.cmbDBItems.TabIndex = 4;
			this.cmbDBItems.SelectedIndexChanged += new System.EventHandler(this.cmbDBItems_SelectedIndexChanged);
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "DB Explorer is in Visible Mode";
			this.notifyIcon1.Visible = true;
			this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
			// 
			// frmdbexplorer
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1028, 673);
			this.Controls.Add(this.cmbDBItems);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbctrl);
			this.Controls.Add(this.tvdbexplorer);
			this.MaximizeBox = false;
			this.Menu = this.mainMenu1;
			this.Name = "frmdbexplorer";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Oracle Explorer";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmdbexplorer_Closing);
			this.Load += new System.EventHandler(this.frmdbexplorer_Load);
			this.tbctrl.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
		#region Delegates,Threads Declaration...
		public DelegateLoadObjects m_Delegateloadobj;
		public delegate void DelegateLoadObjects();
		public delegate void addobj(TreeNode node,TreeNode childnode);
		public addobj m_addobj;
		public TreeNode rootnode,tablesnode,procnode;
		public string type,objecttype;
		public Thread tloadtables,t;
		public delegate void DelegateLoadProcedures();
		public DelegateLoadProcedures m_Delegateloadproc;
		public delegate void addproctocombo(string name);
		public addproctocombo m_addproc;
		public string dbobjaccesstype;

		//Thread to execute any query entered...
		public DelegateExecuteQuery m_executequery;
		public delegate void DelegateExecuteQuery();
		public Thread execquerythread;
		public delegate void adddatatogrid(DataSet ds);
		public adddatatogrid m_updategrid;

		//To show Definition of Selected Object in Textbox...
		public DelegateShowDEFN m_showdefn;
		public delegate void DelegateShowDEFN();
		public Thread defnthread;
		public delegate void showdefn(string defn);
		public showdefn m_updateobjdefn;
		
		public DataSet ds;
		public OleDbDataAdapter da;
		#endregion
		#region All User-Defined Methods...
		private void adddefntotxtbox(string text)
		{
			txtdefn.Text += text;
		}
		private void LoadObjDefn()
		{
			m_updateobjdefn  = new  showdefn(this.adddefntotxtbox);
			string username = frmlogin.username.Trim();
			string passwd   = frmlogin.passwd.Trim();
			OleDbConnection proccon;
			if(frmlogin.datasrc.Trim() == "")
			{
				proccon = new  OleDbConnection("provider=msdaora;data source="+System.Configuration.ConfigurationSettings.AppSettings[0].ToString()+";user id="+username+";password="+passwd+";");
				frmlogin.objexplorer.Text  = System.Configuration.ConfigurationSettings.AppSettings[0].ToString().Trim().ToUpper().Substring(System.Configuration.ConfigurationSettings.AppSettings[0].ToString().Trim().ToUpper().IndexOf("SID")).Replace("SID","").Replace("=","").Replace(")","").Replace(";","").Trim();
			}
			else
			{
				proccon = new  OleDbConnection("provider=msdaora;data source="+frmlogin.datasrc.Trim()+";user id="+username+";password="+passwd+";");
				frmlogin.objexplorer.Text = frmlogin.datasrc.Trim().ToUpper().Substring(frmlogin.datasrc.Trim().ToUpper().IndexOf("SID")).Replace("SID","").Replace("=","").Replace(")","").Replace(";","").Trim();
			}
			proccon.Open();
			OleDbCommand cmd = new OleDbCommand("select text from "+type.ToUpper()+"_source where type like '"+objecttype.ToUpper()+"' and name like '"+cmbDBItems.SelectedItem.ToString()+"' order by line",proccon);
			OleDbDataReader dr = cmd.ExecuteReader();
			while(dr.Read())
			{
				frmlogin.objexplorer.Invoke(m_updateobjdefn,new object[]{dr.GetString(0).ToString().Replace("\n","\r\n").Replace("\t"," ")});
			}
			dr.Close();
			proccon.Close();
		}
		private void LoadQueryData()
		{
			try
			{
				if(txtselectquery.Text != "")
				{
					string username = frmlogin.username.Trim();
					string passwd   = frmlogin.passwd.Trim();
					OleDbConnection conselquery;
					if(frmlogin.datasrc.Trim() == "")
					{
						conselquery = new  OleDbConnection("provider=msdaora;data source="+System.Configuration.ConfigurationSettings.AppSettings[0].ToString()+";user id="+username+";password="+passwd+";");
						frmlogin.objexplorer.Text  = System.Configuration.ConfigurationSettings.AppSettings[0].ToString().Trim().ToUpper().Substring(System.Configuration.ConfigurationSettings.AppSettings[0].ToString().Trim().ToUpper().IndexOf("SID")).Replace("SID","").Replace("=","").Replace(")","").Replace(";","").Trim();
					}
					else
					{
						conselquery = new  OleDbConnection("provider=msdaora;data source="+frmlogin.datasrc.Trim()+";user id="+username+";password="+passwd+";");
						frmlogin.objexplorer.Text = frmlogin.datasrc.Trim().ToUpper().Substring(frmlogin.datasrc.Trim().ToUpper().IndexOf("SID")).Replace("SID","").Replace("=","").Replace(")","").Replace(";","").Trim();
					}
					conselquery.Open();
					string strsqlselect = txtselectquery.Text;
					da = new OleDbDataAdapter(strsqlselect,conselquery);
					ds = new DataSet();
					da.Fill(ds);
					m_updategrid = new adddatatogrid(this.UpdateGridAndRecentQueryList);
					frmlogin.objexplorer.Invoke(m_updategrid,new object[]{ds});
					conselquery.Close();
				}
			}
			catch(Exception ex)
			{
				//txtselectquery.Enabled = true;
				MessageBox.Show(ex.Message);
			}
		}
		private void UpdateGridAndRecentQueryList(DataSet ds)
		{
			if(!recentqueries.Contains(txtselectquery.Text.Trim()))
			{
				recentqueries.Add(txtselectquery.Text.Trim());
				MenuItem testitem = new MenuItem(txtselectquery.Text.Trim());
				testitem.Click += new EventHandler(testitem_Click);
				mnurecentqueries.MenuItems.Add(testitem); 
			}
			dataGrid1.DataSource = ds;
			txtselectquery.Enabled = true;
		}
		private void AddNodes(TreeNode parentnode,TreeNode childnode)
		{
			try
			{
				if(!(parentnode.Text.ToUpper() == "ORACLE") && (parentnode.Text.ToUpper() == "TABLES" || parentnode.Parent.Text.ToUpper() == "TABLES"))
				{
					childnode.ImageIndex = 0;
				}
				else if(parentnode.Text.ToUpper() == "ORACLE")
				{
					childnode.ImageIndex = 1;
				}
				else 
				{
					childnode.ImageIndex = 2;
				}
				parentnode.Nodes.Add(childnode);
			}
			catch{}
		}
		private void LoadObjects()
		{
			m_addobj = new addobj(this.AddNodes);
			OleDbCommand cmd = null;
			OleDbDataReader reader = null;
			OleDbCommand colcmd = null;
			OleDbDataReader colreader= null;
			TreeNode tablesnode;
			TreeNode tablenode;
			try
			{
				tablesnode = new TreeNode("Tables");
				frmlogin.objexplorer.Invoke(m_addobj,new object[]{rootnode,tablesnode});
				string tableslist = "select table_name from "+type+"_tables";
				cmd = new OleDbCommand(tableslist,frmlogin.con);
				reader = cmd.ExecuteReader();
				string tablename = "";
				Stack stktables = new Stack();
				while(reader.Read())
				{
					stktables.Push(reader.GetString(0));
				}
				reader.Close();
				while(stktables.Count != 0)
				{
					tablename = stktables.Pop().ToString();
					colcmd = new OleDbCommand("select count(*) from "+tablename,frmlogin.con);
					string rowscount = "";
					try
					{
						rowscount = colcmd.ExecuteScalar().ToString();
					}
					catch{}
					tablenode = new TreeNode(tablename+"("+rowscount+" rows)");
					frmlogin.objexplorer.Invoke(m_addobj,new object[]{tablesnode,tablenode});
					if(fulldetailsrequired)
					{
						colcmd = null;
						colcmd = new OleDbCommand("select COLUMN_NAME, DATA_TYPE, DATA_LENGTH, NULLABLE, DATA_DEFAULT from "+type+"_TAB_COLUMNS where TABLE_NAME = \'"+tablename+"\'",frmlogin.con);
						colreader = colcmd.ExecuteReader();
						while(colreader.Read())
						{
							TreeNode colnode = new TreeNode(colreader.GetString(0));
							TreeNode coldatatype = new TreeNode("Data Type : "+colreader.GetString(1));
							frmlogin.objexplorer.Invoke(m_addobj,new object[]{tablenode,colnode});
							frmlogin.objexplorer.Invoke(m_addobj,new object[]{colnode,coldatatype});
						
							TreeNode collength = new TreeNode("Length : "+colreader.GetValue(2).ToString());
							frmlogin.objexplorer.Invoke(m_addobj,new object[]{colnode,collength});
						
							TreeNode colnullable = new TreeNode("Nullable : "+colreader.GetString(3));
							frmlogin.objexplorer.Invoke(m_addobj,new object[]{colnode,colnullable});
						
							TreeNode coldefaultval = new TreeNode("Default  : "+colreader.GetValue(4).ToString());
							frmlogin.objexplorer.Invoke(m_addobj,new object[]{colnode,coldefaultval});
						}
						colreader.Close();
					}
				}
			}
			
			catch
			{
				
			}
			finally
			{
				if(colreader != null)
				{
					colreader.Close();
				}
				if(reader != null)
				{
					reader.Close();
				}
			}
		}
		private void LoadProcedures()
		{
			try
			{
				cmbDBItems.Items.Clear();
				string username = frmlogin.username.Trim();
				string passwd   = frmlogin.passwd.Trim();
				OleDbConnection proccon;
				if(frmlogin.datasrc.Trim() == "")
				{
					proccon = new  OleDbConnection("provider=msdaora;data source="+System.Configuration.ConfigurationSettings.AppSettings[0].ToString()+";user id="+username+";password="+passwd+";");
					frmlogin.objexplorer.Text  = System.Configuration.ConfigurationSettings.AppSettings[0].ToString().Trim().ToUpper().Substring(System.Configuration.ConfigurationSettings.AppSettings[0].ToString().Trim().ToUpper().IndexOf("SID")).Replace("SID","").Replace("=","").Replace(")","").Replace(";","").Trim();
				}
				else
				{
					proccon = new  OleDbConnection("provider=msdaora;data source="+frmlogin.datasrc.Trim()+";user id="+username+";password="+passwd+";");
					frmlogin.objexplorer.Text = frmlogin.datasrc.Trim().ToUpper().Substring(frmlogin.datasrc.Trim().ToUpper().IndexOf("SID")).Replace("SID","").Replace("=","").Replace(")","").Replace(";","").Trim();
				}
				proccon.Open();
				OleDbCommand cmd;
				if(objecttype.ToUpper() == "PROCEDURE")
				{
					cmd = new OleDbCommand("select distinct name from "+type+"_source where type like 'PROCEDURE'",proccon);
				}
				else
				{
					cmd = new OleDbCommand("select distinct name from "+type+"_source where type like 'FUNCTION'",proccon);
				}
				OleDbDataReader dr = cmd.ExecuteReader();
				m_addproc  = new addproctocombo(this.AddProcedurestocombo);
				while(dr.Read())
				{
					frmlogin.objexplorer.Invoke(m_addproc ,new object[]{dr.GetString(0)});
				}
				dr.Close();
				proccon.Close();
			}
			catch{}

		}
		private void AddProcedurestocombo(string procname)
		{
			cmbDBItems.Items.Add(procname);
		}
		private void tvdbexplorer_Click(object sender, System.EventArgs e)
		{
			tvdbexplorer.SelectedNode = tvdbexplorer.GetNodeAt(tvdbexplorer.PointToClient(Cursor.Position)); 
		}
		#endregion
		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			frmlogin.con.Dispose();
			Application.Exit();
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			if(txtselectquery.Text.Trim() != "")
			{
				try
				{
					txtselectquery.Enabled = false;
					m_executequery = new DelegateExecuteQuery(this.LoadQueryData);
					ThreadStart ts = new ThreadStart(this.m_executequery);
					execquerythread = new Thread(ts);
					execquerythread.Start();
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message);
					txtselectquery.Enabled = true;
				}
			}

		}
		private void testitem_Click(object sender,EventArgs e)
		{
			txtselectquery.Text = sender.ToString().Substring(sender.ToString().IndexOf("Text")+6);
			menuItem2_Click(sender,e);
		}
		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			tvdbexplorer.Nodes.Clear();
			type = "all";
			rootnode = new TreeNode("Oracle");
			rootnode.ImageIndex = 1;
			tvdbexplorer.Nodes.Add(rootnode);
			ThreadStart ts = new ThreadStart(this.m_Delegateloadobj);
			t = new Thread(ts);
			t.Start();
		}
		private void frmdbexplorer_Load(object sender, System.EventArgs e)
		{
			m_Delegateloadobj = new DelegateLoadObjects(this.LoadObjects);
			recentqueries = new ArrayList();
		}

		private void menuItem7_Click(object sender, System.EventArgs e)
		{
			tvdbexplorer.Nodes.Clear();
			type = "user";
			rootnode = new TreeNode("Oracle");
			rootnode.ImageIndex = 1;
			tvdbexplorer.Nodes.Add(rootnode);
			ThreadStart ts = new ThreadStart(this.m_Delegateloadobj);
			t = new Thread(ts);
			t.Start();
		}

		private void menuItem12_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(tloadtables.IsAlive)
				{
					tloadtables.Abort();
				}
			}
			catch{}
		}

		private void menuItem11_Click(object sender, System.EventArgs e)
		{
			
			try
			{
				string nodepath = tvdbexplorer.SelectedNode.FullPath;
				string tablename = nodepath.Substring(nodepath.IndexOf("Oracle\\Tables")+14);
				tablename = tablename.Split('(').GetValue(0).ToString();
				if(tablename.IndexOf("\\")== -1)
				{
					txtselectquery.Text = "";
					txtselectquery.Text = "select * from "+ tablename;
					menuItem2_Click(sender,e);
					tbctrl.SelectedIndex  = 1;
				}

			}
			catch{}

		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			try
			{
				string nodepath = tvdbexplorer.SelectedNode.FullPath;
				string tablename = nodepath.Substring(nodepath.IndexOf("Oracle\\Tables")+14);
				tablename = tablename.Split('(').GetValue(0).ToString();
				if(tablename.IndexOf("\\")== -1)
				{
					string username = frmlogin.username.Trim();
					string passwd   = frmlogin.passwd.Trim();
					OleDbConnection conselquery;
					if(frmlogin.datasrc.Trim() == "")
					{
						conselquery = new  OleDbConnection("provider=msdaora;data source="+System.Configuration.ConfigurationSettings.AppSettings[0].ToString()+";user id="+username+";password="+passwd+";");
						frmlogin.objexplorer.Text  = System.Configuration.ConfigurationSettings.AppSettings[0].ToString().Trim().ToUpper().Substring(System.Configuration.ConfigurationSettings.AppSettings[0].ToString().Trim().ToUpper().IndexOf("SID")).Replace("SID","").Replace("=","").Replace(")","").Replace(";","").Trim();
					}
					else
					{
						conselquery = new  OleDbConnection("provider=msdaora;data source="+frmlogin.datasrc.Trim()+";user id="+username+";password="+passwd+";");
						frmlogin.objexplorer.Text = frmlogin.datasrc.Trim().ToUpper().Substring(frmlogin.datasrc.Trim().ToUpper().IndexOf("SID")).Replace("SID","").Replace("=","").Replace(")","").Replace(";","").Trim();
					}
					conselquery.Open();
					OleDbDataAdapter da = new OleDbDataAdapter("select * from "+ tablename,conselquery);
					DataSet ds =  new DataSet(); 
					da.Fill(ds);
					conselquery.Close();
					string tmpfile = @"c:\querydata.xml";
					if(File.Exists(tmpfile))
					{
						File.Delete(tmpfile);
					}
					File.Create(tmpfile).Close();
					ds.WriteXml(tmpfile);
					//TO show the contents of xml file in IE...
					System.Diagnostics.Process ie = new Process();
					System.Diagnostics.ProcessStartInfo ieinfo = new ProcessStartInfo(@"C:\Program Files\Internet Explorer\iexplore.exe",tmpfile);
					ie.StartInfo = ieinfo;
					bool started =	ie.Start();
										
				}

			}
			catch{}
		}
		private void menuItem14_Click(object sender, System.EventArgs e)
		{
			t = null;
			type = "ALL";
			label1.Text = "Available Procedures: ";
			objecttype = "PROCEDURE";
			m_Delegateloadproc = new DelegateLoadProcedures(this.LoadProcedures);
			ThreadStart ts = new ThreadStart(this.m_Delegateloadproc);
			t = new Thread(ts);
			t.Start();
		}
		
		private void menuItem17_Click(object sender, System.EventArgs e)
		{
			tvdbexplorer.Nodes.Clear();
			type = "ALL";
			rootnode = new TreeNode("Oracle");
			rootnode.ImageIndex = 1;
			tvdbexplorer.Nodes.Add(rootnode);
			m_Delegateloadobj = null;
			t = null;
			fulldetailsrequired = true;
			m_Delegateloadobj = new DelegateLoadObjects(this.LoadObjects);
			ThreadStart ts = new ThreadStart(this.m_Delegateloadobj);
			tloadtables = new Thread(ts);
			tloadtables.Start();
			
		}
		private void menuItem18_Click(object sender, System.EventArgs e)
		{
			tvdbexplorer.Nodes.Clear();
			type = "ALL";
			rootnode = new TreeNode("Oracle");
			rootnode.ImageIndex = 1;
			tvdbexplorer.Nodes.Add(rootnode);
			m_Delegateloadobj = null;
			t = null;
			fulldetailsrequired = false;
			m_Delegateloadobj = new DelegateLoadObjects(this.LoadObjects);
			ThreadStart ts = new ThreadStart(this.m_Delegateloadobj);
			tloadtables = new Thread(ts);
			tloadtables.Start();
		}

		private void frmdbexplorer_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				t = null;
				defnthread=null;
				execquerythread=null;
				frmlogin.con.Close();
				Application.Exit();
			}
			catch{}
		}

		private void cmbDBItems_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtdefn.Text = "";
			m_showdefn  = new DelegateShowDEFN(this.LoadObjDefn);
			ThreadStart ts = new ThreadStart(this.m_showdefn);
			t = new Thread(ts);
			t.Start();
		}
    	private void menuItem15_Click_1(object sender, System.EventArgs e)
		{
			t = null;
			type= "ALL";
			objecttype = "FUNCTION";
			label1.Text = "Available Functions: ";
			m_Delegateloadproc = new DelegateLoadProcedures(this.LoadProcedures);
			ThreadStart ts = new ThreadStart(this.m_Delegateloadproc);
			t = new Thread(ts);
			t.Start();
		}

		private void menuItem21_Click(object sender, System.EventArgs e)
		{
			tvdbexplorer.Nodes.Clear();
			type = "USER";
			rootnode = new TreeNode("Oracle");
			rootnode.ImageIndex = 1;
			tvdbexplorer.Nodes.Add(rootnode);
			m_Delegateloadobj = null;
			t = null;
			fulldetailsrequired = true;
			m_Delegateloadobj = new DelegateLoadObjects(this.LoadObjects);
			ThreadStart ts = new ThreadStart(this.m_Delegateloadobj);
			tloadtables = new Thread(ts);
			tloadtables.Start();
		}

		private void menuItem19_Click(object sender, System.EventArgs e)
		{
			t = null;
			type = "USER";
			label1.Text = "Available Procedures: ";
			objecttype = "PROCEDURE";
			m_Delegateloadproc = new DelegateLoadProcedures(this.LoadProcedures);
			ThreadStart ts = new ThreadStart(this.m_Delegateloadproc);
			t = new Thread(ts);
			t.Start();
		}

		private void menuItem20_Click(object sender, System.EventArgs e)
		{
			t = null;
			type= "USER";
			objecttype = "FUNCTION";
			label1.Text = "Available Functions: ";
			m_Delegateloadproc = new DelegateLoadProcedures(this.LoadProcedures);
			ThreadStart ts = new ThreadStart(this.m_Delegateloadproc);
			t = new Thread(ts);
			t.Start();
		}

		private void menuItem22_Click(object sender, System.EventArgs e)
		{
			tvdbexplorer.Nodes.Clear();
			type = "USER";
			rootnode = new TreeNode("Oracle");
			rootnode.ImageIndex = 1;
			tvdbexplorer.Nodes.Add(rootnode);
			m_Delegateloadobj = null;
			t = null;
			fulldetailsrequired = false;
			m_Delegateloadobj = new DelegateLoadObjects(this.LoadObjects);
			ThreadStart ts = new ThreadStart(this.m_Delegateloadobj);
			tloadtables = new Thread(ts);
			tloadtables.Start();
		}

		private void notifyIcon1_Click(object sender, System.EventArgs e)
		{
			if(frmlogin.objexplorer.Visible)
			{
				frmlogin.objexplorer.Visible = false;
				notifyIcon1.Text = "DB Explorer is in Invisible Mode";
			}
			else
			{
				frmlogin.objexplorer.Visible = true;
				notifyIcon1.Text = "DB Explorer is in Visible Mode";
			}
		}

		private void menuItem10_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(t.IsAlive)
				{
					t.Abort();
				}
			}
			catch{}
		}

	}
}

