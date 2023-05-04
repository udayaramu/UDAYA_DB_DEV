using System;
using System.Data;
using System.Data.OracleClient;
using System.Collections.Generic;
using System.Text;

namespace OracleGen
{
    public class DBHelper
    {
        public static string connectionString;

        private DBHelper() { }

        public static DataTable GetDT(string sql)
        {
            using (OracleConnection cn = new OracleConnection(connectionString))
            {
                OracleDataAdapter da = new OracleDataAdapter(sql, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }
        public static DataTable GetTableColumns(string tableName)
        {
            string s = string.Format("select user_tab_columns.column_name, user_tab_columns.data_type, user_tab_columns.char_length, user_tab_columns.nullable,(select user_cons_columns.column_name from user_constraints inner join user_cons_columns on user_constraints.constraint_name=user_cons_columns.constraint_name where user_constraints.table_name=user_tab_columns.table_name AND column_name=user_tab_columns.column_name AND constraint_type='P') as PK from user_tab_columns WHERE table_name='{0}'", tableName);
            DataTable dt = DBHelper.GetDT(s);
            dt.Columns.Add("IS_SELECTED", typeof(bool));
            dt.Columns["IS_SELECTED"].DefaultValue = true;

            return dt;
        }

        public static string GetSingularName(string tableName)
        {
            string singularTableName;
            string lowerName = tableName.ToLower();
            if (lowerName.EndsWith("es"))
            {
                singularTableName = tableName.Substring(0, tableName.Length - 2);
            }
            else if (lowerName.EndsWith("s"))
            {
                singularTableName = tableName.Substring(0, tableName.Length - 1);
            }
            else
            {
                singularTableName = tableName;
            }

            return singularTableName;
        }
    }
}
