﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using repository.Repositories;
using System.Data.Common;
namespace repository.EntityModel
{
    public class EAccount
    {
        public List<ACCOUNT> getAccountList()
        {

            List<ACCOUNT> _accountList = new List<ACCOUNT>();
            string _connectionString = DataSource.getConnectionString("swagbaseCoolString");
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM ACCOUNT;", con);
            try
            {
                con.Open();
                SqlDataReader dar = cmd.ExecuteReader();
                if (dar != null)
                {
                    while (dar.Read())
                    {
                        ACCOUNT _accObj = new ACCOUNT();
                        _accObj.Username = dar["Username"] as string;
                        _accObj.Password = dar["Password"] as string;
                        _accObj.Rank = Convert.ToInt32(dar["Rank"]);
                        _accountList.Add(_accObj);

                    }
                }

            }

            catch (Exception aObj)
            {
                throw aObj;
            }
            finally
            {
                if (con != null)
                    con.Close();
            }
            return _accountList;
        }
        public ACCOUNT getAccountByUserName(string userName)
        {
            ACCOUNT _accObj = new ACCOUNT();
            string _connectionString = DataSource.getConnectionString("swagbaseCoolString");
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM ACCOUNT WHERE Username = '" + userName + "';", con);
            try
            {
                con.Open();
                SqlDataReader dar = cmd.ExecuteReader();
                if (dar.Read())
                {
                    _accObj.Username = dar["Username"] as string;
                    _accObj.Password = dar["Password"] as string;
                    _accObj.Rank = Convert.ToInt32(dar["Rank"]);
                }
            }
            catch (Exception aObj)
            {
                throw aObj;
            }
            finally
            {
                if (con != null)
                    con.Close();
            }
            return _accObj;
        }
        public void editAccount(ACCOUNT accObj)
        {

            string _connectionString = DataSource.getConnectionString("swagbaseCoolString");
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("UPDATE ACCOUNT SET Password = '" + accObj.Password + "' WHERE Username = '" + accObj.Username + "';", con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception aObj)
            {
                throw aObj;
            }
            finally
            {
                if (con != null)
                    con.Close();
            }
        }
        public bool logInAccount(ACCOUNT accObj)
        {


            ACCOUNT _accObj = new ACCOUNT();
            string _connectionString = DataSource.getConnectionString("swagbaseCoolString");
            SqlConnection con = new SqlConnection(_connectionString);
            //SqlCommand cmd = new SqlCommand("SELECT * FROM ACCOUNT WHERE Username = '" + accObj.Username.ToString() + "';", con);
            SqlCommand cmd = new SqlCommand("SELECT * FROM ACCOUNT WHERE Username = '" + accObj.Username + "' AND Password = '" + accObj.Password + "';", con);
            try
            {
                con.Open();
                SqlDataReader dar = cmd.ExecuteReader();
                if (dar.Read())
                {
                    _accObj.Username = dar["Username"] as string;
                    _accObj.Password = dar["Password"] as string;
                    _accObj.Rank = Convert.ToInt32(dar["Rank"]);
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {

                if (con != null)
                {
                    con.Close();
                }

            }
            if (_accObj.Username != null && _accObj.Password != null)
            {
                return true;

            }
            else return false;
        }

        public bool checkDbCOnn()
        {
            
            using (var db = new swagbaseEntities())
            {
                try
                {
                   DbConnection conn = db.Database.Connection;
                   conn.Open();
                   return true;
                }
                catch
                {
                    return false;
                }
            }

        }
        public void deleteAccount(string Username)
        {
            string _connectionString = DataSource.getConnectionString("swagbaseCoolString");
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("DELETE FROM ACCOUNT WHERE Username = '" + Username + "';", con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch(Exception aObj)
            {
                throw aObj;

            }
            finally
            {
                if(con != null)
                {
                    con.Close();
                }
            }
        }


    }
}
