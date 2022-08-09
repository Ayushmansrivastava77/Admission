﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace AdmissionManagement
{
    public class clsDbConnector
    {
        private SqlConnection dbConnection;
        private SqlDataAdapter dbAdapter;
        private SqlCommand cmd;


        public clsDbConnector()
        {
            this.dbConnection = new SqlConnection(ConfigurationManager.AppSettings["connstr"]);
            //Or
            //this.dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"]);
            if (dbConnection.State == ConnectionState.Closed)
            {
                try
                {
                    if (dbConnection.State == ConnectionState.Broken)
                    {
                        dbConnection.Close();
                        dbConnection.Open();
                    }
                }
                catch (Exception err)
                {
                    throw err;
                }
            }
            if (dbConnection.State == ConnectionState.Broken)
            {
                dbConnection.Close();
                dbConnection.Open();
            }
            cmd = new SqlCommand();
        }


        public DataSet GetDataSet(string strSQL)
        {
            if (dbConnection.State == ConnectionState.Closed)
            {
                dbConnection.Open();
            }
            if (dbConnection.State == ConnectionState.Broken)
            {
                dbConnection.Close();
                dbConnection.Open();
            }
            dbAdapter = new SqlDataAdapter(strSQL, dbConnection);
            DataSet dsTemp;
            dsTemp = new DataSet();
            dbAdapter.Fill(dsTemp);
            dbConnection.Close();
            return dsTemp;
        }

        public SqlDataReader getSqlDataReader(string strSQL)
        {
            if (dbConnection.State == ConnectionState.Closed)
            {
                dbConnection.Open();
            }
            if (dbConnection.State == ConnectionState.Broken)
            {
                dbConnection.Close();
                dbConnection.Open();
            }
            cmd.Connection = dbConnection;
            cmd.CommandText = strSQL;
            return cmd.ExecuteReader();
        }

        public bool runSQL(string strSQL)
        {
            try
            {
                if (dbConnection.State == ConnectionState.Closed)
                {
                    dbConnection.Open();
                }
                else if (dbConnection.State == ConnectionState.Broken)
                {
                    dbConnection.Close();
                    dbConnection.Open();
                }
                cmd = new SqlCommand(strSQL, dbConnection);
                cmd.ExecuteNonQuery();
                dbConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Find_Automatic_no(string Columnname, string Tablename)
        {


            string strQry = "SELECT MAX(" + Columnname + ") FROM  " + Tablename;
            DataSet ds = GetDataSet(strQry);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0].ToString() == "")
                {
                    return (1);
                }
                else
                {
                    return (Convert.ToInt64(ds.Tables[0].Rows[0][0].ToString()) + 1);
                }
            }

            else
            {
                return (-1);
            }
        }
    }
}
