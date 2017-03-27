using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using repository.Repositories;
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
                if(dar != null)
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
            catch(Exception aObj)
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
            int affectedRows = 0;
            bool logInResponse = false;
            string _connectionString = DataSource.getConnectionString("swagbaseCoolString");
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM ACCOUNT WHERE Username = '" + accObj.Username + "' AND Password = '" + accObj.Password + "';", con);
            try
            {
              con.Open();
              affectedRows = cmd.ExecuteNonQuery();
            }catch(Exception aObj)
            {
                throw aObj;
            }
            finally
            {
                if(affectedRows == 1)
                {
                    logInResponse = true;
                }
                if (con != null)
                    con.Close();
            }
            return logInResponse;
        }



    }
}
