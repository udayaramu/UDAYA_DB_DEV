using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OracleGen
{
    public partial class CodeOptionsDialog : Form
    {
        public string _tableName;
        public DataTable _dtCols;

        public CodeOptionsDialog()
        {
            InitializeComponent();
        }

        private void CodeOptionsDialog_Load(object sender, EventArgs e)
        {
            this.Text = "Options - "+_tableName;

            ShowColumns();
        }

        private void ShowColumns()
        {
            txtSeq.Text = _tableName + "_SEQ";

            DataTable dt = DBHelper.GetTableColumns(_tableName);
            _dtCols = dt;
            foreach (DataRow row in dt.Rows)
            {
                string isPk = (row["PK"].ToString().Length > 0).ToString();
                ListViewItem lvi = new ListViewItem(
                    new string[]{
                        row["COLUMN_NAME"].ToString(),
                        row["DATA_TYPE"].ToString(),
                        row["CHAR_LENGTH"].ToString(),
                        isPk,
                        row["NULLABLE"].ToString()});
                lvi.Checked = true;

                lvColumns.Items.Add(lvi);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lvColumns.Items.Count; i++)
            {
                _dtCols.Rows[i]["IS_SELECTED"] = lvColumns.Items[i].Checked;
            }
            _dtCols.AcceptChanges();

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}