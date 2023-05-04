using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OracleGen.Properties;
using System.IO;

namespace OracleGen
{
    public partial class Form1 : Form
    {
        private StringFormat _stringFormat = new StringFormat(StringFormatFlags.NoWrap);
        private DataTable _dtTypeMappings;

        public Form1()
        {
            InitializeComponent();


            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            _stringFormat.LineAlignment = StringAlignment.Center;
            _stringFormat.Trimming = StringTrimming.EllipsisCharacter;

        }

        void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void setConnectionStringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectDialog dlg = new ConnectDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                ShowTables();
            }
            dlg.Dispose();
        }

        private void ShowTables()
        {
            DataTable dt = DBHelper.GetDT("select table_name from user_tables order by table_name");
            lsTables.BeginUpdate();
            lsTables.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                lsTables.Items.Add(new MyListItem(row["TABLE_NAME"].ToString()));
            }
            lsTables.EndUpdate();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save();    
        }

        private void lsTables_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (lsTables.Items.Count == 0 || e.Index<0)
            {
                return;
            }
            Brush fontBrush = Brushes.Black; ;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(Brushes.Green, e.Bounds);
                fontBrush = Brushes.White;
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);
            }
            
            e.Graphics.DrawString(lsTables.Items[e.Index].ToString(), e.Font, fontBrush, e.Bounds, _stringFormat);

            if ((e.State & DrawItemState.Focus) == DrawItemState.Focus)
            {
                e.DrawFocusRectangle();
            }
        }

        private void lsTables_SizeChanged(object sender, EventArgs e)
        {
            //lsTables.BeginUpdate();
            //lsTables.Refresh();
            //lsTables.EndUpdate();
        }

        private void lsTables_DoubleClick(object sender, EventArgs e)
        {
            if (lsTables.SelectedItem == null)
            {
                return;
            }
            GenerateCode(lsTables.SelectedItem.ToString());
        }

        private void GenerateCode(string tableName)
        {
            CodeOptionsDialog dlg = new CodeOptionsDialog();
            dlg._tableName = tableName;
            dlg.txtPackageName.Text = "PKG_"+DBHelper.GetSingularName(tableName);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                MyListItem item = (MyListItem)lsTables.SelectedItem;
                item.DtCols = dlg._dtCols;
                item.ProcHeaders.Clear();
                WriteCode(item, dlg);
            }
            dlg.Dispose();
        }

        private void WriteCode(MyListItem item, CodeOptionsDialog dlg)
        {
            WriteSQLCode(item, dlg);
        }

        private void WriteSQLCode(MyListItem item, CodeOptionsDialog dlg)
        {
            rtbSQL.Text = "";
            rtbCode.Text = "";
            SQLGenerator gen = new SQLGenerator(item.ItemText, item.DtCols);
            CodeGenerator codeGen;
            string packageName = dlg.txtPackageName.Text.Trim();
            if (dlg.chkSelect.Checked)
            {
                string sql = gen.GenerateSELECT();
                rtbSQL.AppendText(sql);
                rtbSQL.AppendText(Environment.NewLine);

                codeGen = new CodeGenerator(_dtTypeMappings, packageName, item.DtCols);
                string code = codeGen.GenerateDataTableMethod(sql);
                rtbCode.AppendText(code);
                rtbCode.AppendText(Environment.NewLine);

                AddProcHeader(item, sql, SPReturnType.DataTable, code);
            }
            if (dlg.chkSelectByPK.Checked)
            {
                string sql = gen.GenerateSELECTByPK();
                rtbSQL.AppendText(sql);
                rtbSQL.AppendText(Environment.NewLine);

                codeGen = new CodeGenerator(_dtTypeMappings, packageName, item.DtCols);
                string code = codeGen.GenerateDataTableMethod(sql);
                rtbCode.AppendText(code);
                rtbCode.AppendText(Environment.NewLine);

                AddProcHeader(item, sql, SPReturnType.DataTable, code);
            }
            if (dlg.chkInsert.Checked)
            {
                string sql = gen.GenerateINSERT();
                rtbSQL.AppendText(sql);
                rtbSQL.AppendText(Environment.NewLine);

                codeGen = new CodeGenerator(_dtTypeMappings, packageName, item.DtCols);
                string code = codeGen.GenerateIntMethod(sql);
                rtbCode.AppendText(code);
                rtbCode.AppendText(Environment.NewLine);

                AddProcHeader(item, sql, SPReturnType.Int, code);
            }
            if (dlg.chkUpdate.Checked)
            {
                string sql = gen.GenerateUPDATE();
                rtbSQL.AppendText(sql);
                rtbSQL.AppendText(Environment.NewLine);

                codeGen = new CodeGenerator(_dtTypeMappings, packageName, item.DtCols);
                string code = codeGen.GenerateVoidMethod(sql);
                rtbCode.AppendText(code);
                rtbCode.AppendText(Environment.NewLine);

                AddProcHeader(item, sql, SPReturnType.Void, code);
            }
            if (dlg.chkDelete.Checked)
            {
                string sql = gen.GenerateDELETE();
                rtbSQL.AppendText(sql);
                rtbSQL.AppendText(Environment.NewLine);

                codeGen = new CodeGenerator(_dtTypeMappings, packageName, item.DtCols);
                string code = codeGen.GenerateVoidMethod(sql);
                rtbCode.AppendText(code);
                rtbCode.AppendText(Environment.NewLine);

                AddProcHeader(item, sql, SPReturnType.Void, code);
            }
        }
        private void AddProcHeader(MyListItem item, string sql, SPReturnType retType, string code)
        {
            ProcHeader header = new ProcHeader();
            header.procHeaderText = sql;
            header.returnType = retType;
            header.codeText = code;
            item.ProcHeaders.Add(header);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ReadDataTypeMappings();

            cmbReturnType.DataSource = Enum.GetNames(typeof(SPReturnType));
            cmbReturnType.SelectedIndex = 0;
        }

        private void ReadDataTypeMappings()
        {
            _dtTypeMappings = new DataTable("TypeMapping");
            _dtTypeMappings.Columns.Add("SourceType");
            _dtTypeMappings.Columns.Add("TargetType");
            _dtTypeMappings.Columns.Add("TargetMethodType");
            _dtTypeMappings.Columns.Add("IncludeLength", typeof(bool));

            _dtTypeMappings.ReadXml(Path.Combine(Application.StartupPath, "DataTypes.xml"));
        }

        private void lsTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtbSQL.Clear();
            rtbCode.Clear();

            if (lsTables.SelectedItem == null)
            {
                return;
            }
            MyListItem item = lsTables.SelectedItem as MyListItem;
            if (item == null)
            {
                return;
            }

            txtTable.Text = lsTables.SelectedItem.ToString();
            //txtPackage.Text = "PKG_" + DBHelper.GetSingularName(lsTables.SelectedItem.ToString());

            if (item.ProcHeaders == null)
            {
                return;
            }
            foreach (ProcHeader header in item.ProcHeaders)
            {
                rtbSQL.AppendText(header.procHeaderText);
                rtbSQL.AppendText(Environment.NewLine);

                rtbCode.AppendText(header.codeText);
                rtbCode.AppendText(Environment.NewLine);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FillProcedures();
        }

        private void FillProcedures()
        {
            cmbProcedures.Sorted = false;
            cmbProcedures.Items.Clear();

            DataTable dt = DBHelper.GetDT("select * from user_source where upper(text) like '%PROCEDURE%;%'");
            foreach (DataRow row in dt.Rows)
            {
                string packageName = "";
                string itemType = row["TYPE"].ToString();
                if (itemType.Equals("PACKAGE"))
                {
                    packageName = row["NAME"].ToString();
                }
                MyProcComboBoxItem item = new MyProcComboBoxItem(row["TEXT"].ToString(), packageName);
                if (item.IsProc)
                {
                    cmbProcedures.Items.Add(item);
                }
            }

            cmbProcedures.Sorted = true;

            if (cmbProcedures.Items.Count > 0)
            {
                cmbProcedures.SelectedIndex = 0;
            }
        }

        private void cmbProcedures_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProcedures.SelectedItem == null)
            {
                return;
            }

            MyProcComboBoxItem item=(MyProcComboBoxItem)cmbProcedures.SelectedItem;
            txtProc.Text = item.Declaration;

            if (item.Name.StartsWith("GET_"))
            {
                cmbReturnType.SelectedIndex = 0;
            }
            else if (item.Name.StartsWith("ADD_"))
            {
                cmbReturnType.SelectedIndex = 2;
            }
            else
            {
                cmbReturnType.SelectedIndex = 1;
            }

            txtPackage.Text = item.Package;
        }

        private void btnShowCode_Click(object sender, EventArgs e)
        {
            if (txtTable.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please, select a table", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            CodeGenerator gen = new CodeGenerator(_dtTypeMappings, txtPackage.Text.Trim(), DBHelper.GetTableColumns(txtTable.Text));
            SPReturnType retType = (SPReturnType)Enum.Parse(typeof(SPReturnType), cmbReturnType.SelectedIndex.ToString());
            string ret;
            switch (retType)
            {
                case SPReturnType.DataTable:
                    ret = gen.GenerateDataTableMethod(txtProc.Text);
                    break;
                case SPReturnType.Int:
                    ret = gen.GenerateIntMethod(txtProc.Text);
                    break;
                default:
                    ret = gen.GenerateVoidMethod(txtProc.Text);
                    break;
            }

            txtCode.Text = ret;

        }

      
    }
}