using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace OracleGen
{
    public class SQLGenerator
    {
        private string tableName;
        private DataTable dtColumns;
        private string singularTableName;
        private readonly string varPrefix="V_";

        public SQLGenerator(string tableName, DataTable dtColumns)
        {
            this.tableName = tableName;
            this.dtColumns = dtColumns;

            singularTableName = DBHelper.GetSingularName(tableName);
        }
        public string GenerateINSERT()
        {
            StringBuilder bld = new StringBuilder();
            bld.AppendFormat("PROCEDURE ADD_{0}", singularTableName);
            bld.Append("(").Append(GetParamDeclarations(true));
            bld.Append(",V_NEW_ROW_ID OUT NUMBER");
            bld.Append(") IS\r\n");
            bld.Append("BEGIN\r\n");

            bld.AppendFormat("INSERT INTO {0} ({1}) VALUES ({2});\r\n",
                tableName, GetParamNamesAsLine(false, true),
                GetParamNamesAsLine(true, true));
            bld.AppendFormat("SELECT {0}_SEQ.CURRVAL INTO V_NEW_ROW_ID  FROM DUAL;\r\n", tableName);
            

            bld.Append("END;\r\n");
            return bld.ToString();

        }
        public string GenerateSELECT()
        {
            StringBuilder bld = new StringBuilder();
            bld.AppendFormat("PROCEDURE GET_ALL_{0}", tableName);
            bld.Append("(ITEMS_CURSOR OUT T_CURSOR) IS\r\n");
            bld.Append("BEGIN\r\n");

            bld.AppendFormat("OPEN ITEMS_CURSOR FOR SELECT {0} FROM {1};\r\n",
                GetParamNamesAsLine(false, false), tableName);

            bld.Append("END;\r\n");
            return bld.ToString();
        }
        public string GenerateSELECTByPK()
        {
            StringBuilder bld = new StringBuilder();
            DataRow row=GetPKColumn();
            bld.AppendFormat("PROCEDURE GET_{0}_BY_ID", singularTableName);
            bld.AppendFormat("({0}{1} {2}", varPrefix, row["COLUMN_NAME"], row["DATA_TYPE"]);
            bld.Append(",ITEMS_CURSOR OUT T_CURSOR) IS\r\n");
            bld.Append("BEGIN\r\n");

            bld.AppendFormat("OPEN ITEMS_CURSOR FOR SELECT {0} FROM {1} WHERE {2};\r\n",
                GetParamNamesAsLine(false, false), tableName, GetPKWhereClause());

            bld.Append("END;\r\n");
            return bld.ToString();
        }
        public string GenerateUPDATE()
        {
            StringBuilder bld = new StringBuilder();
            bld.AppendFormat("PROCEDURE UPDATE_{0}", singularTableName);
            bld.Append("(").Append(GetParamDeclarations(false));
            bld.Append(") IS\r\n");
            bld.Append("BEGIN\r\n");

            bld.AppendFormat("UPDATE {0} SET {1} WHERE {2};\r\n",
                tableName, GetUpdateParamNames(), GetPKWhereClause());
            
            bld.Append("END;\r\n");
            return bld.ToString();
        }
        public string GenerateDELETE()
        {
            StringBuilder bld = new StringBuilder();
            bld.AppendFormat("PROCEDURE DELETE_{0}", singularTableName);
            DataRow row = GetPKColumn();
            bld.Append("(").AppendFormat("{0}{1} {2}", varPrefix, row["COLUMN_NAME"], row["DATA_TYPE"]);
            bld.Append(") IS\r\n");
            bld.Append("BEGIN\r\n");

            bld.AppendFormat("DELETE FROM {0} WHERE {1};\r\n",
                tableName, GetPKWhereClause());

            bld.Append("END;\r\n");
            return bld.ToString();
        }
        private DataRow GetPKColumn()
        {
            DataRow[] rows = dtColumns.Select("LEN(PK)>0");
            if (rows.Length > 0)
            {
                return rows[0];
            }
            return dtColumns.NewRow() ;
        }
        private string GetPKWhereClause()
        {
            StringBuilder bld = new StringBuilder();

            DataRow[] rows = dtColumns.Select("LEN(PK)>0");
            if (rows.Length > 0)
            {
                bld.AppendFormat("{0}={1}{0}", rows[0]["COLUMN_NAME"], varPrefix);
            }
            return bld.ToString();
        }
        private string GetUpdateParamNames()
        {
            StringBuilder bld = new StringBuilder();
            for (int i = 0; i < dtColumns.Rows.Count; i++)
            {
                DataRow row = dtColumns.Rows[i];
                bool isSelected = (bool)row["IS_SELECTED"];
                if (isSelected)
                {
                    bld.AppendFormat("{0}={1}{0},", row["COLUMN_NAME"], varPrefix);
                }
            }
            if (bld.Length > 0)
            {
                return bld.ToString().Substring(0, bld.Length - 1);
            }
            else
            {
                return "";
            }
        }
        private string GetParamNamesAsLine(bool appendVarPrefix, bool forInsert)
        {
            StringBuilder bld = new StringBuilder();
            for (int i = 0; i < dtColumns.Rows.Count; i++)
            {
                DataRow row = dtColumns.Rows[i];
                bool isSelected = (bool)row["IS_SELECTED"];
                if (isSelected)
                {
                    if (forInsert && row["PK"].ToString().Length > 0)
                    {
                        if (appendVarPrefix)
                        {
                            bld.AppendFormat("{0}_SEQ.NEXTVAL,", tableName);
                        }
                        else
                        {
                            bld.AppendFormat("{0},", row["COLUMN_NAME"]);
                        }
                    }
                    else
                    {
                        bld.AppendFormat("{0},", (appendVarPrefix ? varPrefix : "") + row["COLUMN_NAME"]);
                    }
                }
            }
            if (bld.Length > 0)
            {
                return bld.ToString().Substring(0, bld.Length-1);
            }
            else
            {
                return "";
            }
        }
        private string GetParamDeclarations(bool forInsert)
        {
            StringBuilder bld = new StringBuilder();
            for (int i = 0; i < dtColumns.Rows.Count; i++)
            {
                DataRow row=dtColumns.Rows[i];
                bool isSelected = (bool)row["IS_SELECTED"];
                if (isSelected)
                {
                    if (forInsert && row["PK"].ToString().Length > 0)
                    {
                        continue;
                    }
                    bld.AppendFormat("{0}{1} {2},",  varPrefix,row["COLUMN_NAME"], row["DATA_TYPE"]);
                }
            }
            if (bld.Length > 0)
            {
                return bld.ToString().Substring(0, bld.Length-1);
            }
            else
            {
                return "";
            }

        }
    }
}
