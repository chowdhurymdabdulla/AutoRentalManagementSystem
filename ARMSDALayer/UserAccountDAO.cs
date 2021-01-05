using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace ARMSDALayer
{
   public class UserAccountDAO:IDAOTemplate<UserAccountDTO>
    {
        public UserAccountDTO GetRecordByID(string key)
        {


            SqlConnection objConn = new SqlConnection(SQLServerFactory.ConnectionString());

            try
            {

                objConn.Open();

                string strSQL = "SELECT * FROM UserAccount WHERE UserAccountID = @UserAccountID;";


                SqlCommand objCmd = new SqlCommand(strSQL, objConn);

                objCmd.CommandType = CommandType.Text;

                objCmd.Parameters.Add("@UserAccountID", SqlDbType.VarChar).Value = key;

                SqlDataReader objDR = objCmd.ExecuteReader();

                if (objDR.HasRows)
                {

                    UserAccountDTO objDTO = new UserAccountDTO();

                    objDR.Read();

                    
                    objDTO.Username = objDR.GetString(0);
                    objDTO.Password = objDR.GetString(1);
                    objDTO.Email = objDR.GetString(2);
                    

                    return objDTO;
                }

                objDR.Close();
                objDR = null;
                objCmd.Dispose();
                objCmd = null;

                return null;
            }

            catch (System.Exception)
            {

                throw new System.Exception();
            }
            finally
            {

                objConn.Close();
                objConn.Dispose();
                objConn = null;
            }
        }
        public bool Insert(UserAccountDTO objDTO)
        {

            SqlConnection objConn = new SqlConnection(SQLServerFactory.ConnectionString());

            try
            {

                objConn.Open();

                string strSQL;
                strSQL = "INSERT INTO UserAccount (Username,Password,Email)";
                strSQL = strSQL + "VALUES(@Username,@Password,@Email)";


                SqlCommand objCmd = new SqlCommand(strSQL, objConn);

                objCmd.CommandType = CommandType.Text;

                objCmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = objDTO.Username;
                objCmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = objDTO.Password;
                objCmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = objDTO.Email;
                

                int intRecordsAffected = objCmd.ExecuteNonQuery();

                if (intRecordsAffected == 1)
                {

                    return true;
                }

                objCmd.Dispose();
                objCmd = null;

                return false;
            }

            catch (System.Exception)
            {

                throw new System.Exception();
            }
            finally
            {

                objConn.Close();
                objConn.Dispose();
                objConn = null;
            }

        }
        public bool Update(UserAccountDTO objDTO)
        {

            SqlConnection objConn = new SqlConnection(SQLServerFactory.ConnectionString());

            try
            {

                objConn.Open();

                string strSQL;
                strSQL = "UPDATE UserAccount ";
                strSQL = strSQL + "SET Username=@Username,";
                strSQL = strSQL + "Password=@Password,";
                strSQL = strSQL + "Email=@Email,";



                SqlCommand objCmd = new SqlCommand(strSQL, objConn);

                objCmd.CommandType = CommandType.Text;

                objCmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = objDTO.Username;
                objCmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = objDTO.Password;
                objCmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = objDTO.Email;
                

                int intRecordsAffected = objCmd.ExecuteNonQuery();

                if (intRecordsAffected == 1)
                {

                    return true;
                }

                objCmd.Dispose();
                objCmd = null;

                return false;
            }

            catch (System.Exception)
            {

                throw new System.Exception();
            }
            finally
            {

                objConn.Close();
                objConn.Dispose();
                objConn = null;
            }
        }
        public bool Delete(string key)
        {

            SqlConnection objConn = new SqlConnection(SQLServerFactory.ConnectionString());

            try
            {

                objConn.Open();

                string strSQL = "DELETE FROM UserAccount WHERE UserAccountID = @UserAccountID;";


                SqlCommand objCmd = new SqlCommand(strSQL, objConn);

                objCmd.CommandType = CommandType.Text;

                objCmd.Parameters.Add("@UserAccountID", SqlDbType.VarChar).Value = key;

                int intRecordsAffected = objCmd.ExecuteNonQuery();

                if (intRecordsAffected == 1)
                {

                    return true;
                }

                objCmd.Dispose();
                objCmd = null;

                return false;
            }

            catch (System.Exception)
            {

                throw new System.Exception();
            }
            finally
            {

                objConn.Close();
                objConn.Dispose();
                objConn = null;
            }
        }
        public List<UserAccountDTO> GetAllRecords()
        {

            SqlConnection objConn = new SqlConnection(SQLServerFactory.ConnectionString());

            try
            {

                objConn.Open();

                string strSQL = "SELECT * FROM UserAccount;";


                SqlCommand objCmd = new SqlCommand(strSQL, objConn);

                objCmd.CommandType = CommandType.Text;

                SqlDataReader objDR = objCmd.ExecuteReader();

                if (objDR.HasRows)
                {

                    List<UserAccountDTO> colRecordList = new List<UserAccountDTO>();

                    while (objDR.Read())
                    {

                        UserAccountDTO objDTO = new UserAccountDTO();
                        
                        objDTO.Username = objDR.GetString(0);
                        objDTO.Password = objDR.GetString(1);
                        objDTO.Email = objDR.GetString(2);
                        

                        colRecordList.Add(objDTO);
                    }
                    return colRecordList;
                }
                else
                {

                    objDR.Close();
                    objDR = null;
                    objCmd.Dispose();
                    objCmd = null;

                    return null;

                }
            }
            catch (System.Exception)
            {

                throw new System.Exception();
            }
            finally
            {

                objConn.Close();
                objConn.Dispose();
                objConn = null;
            }
        }
        public List<string> GetAllKeys()
        {

            SqlConnection objConn = new SqlConnection(SQLServerFactory.ConnectionString());

            try
            {

                objConn.Open();

                string strSQL = "SELECT UserAccountID FROM UserAccount;";


                SqlCommand objCmd = new SqlCommand(strSQL, objConn);

                objCmd.CommandType = CommandType.Text;

                SqlDataReader objDR = objCmd.ExecuteReader();

                if (objDR.HasRows)
                {

                    List<string> colKeyList = new List<string>();

                    while (objDR.Read())
                    {

                        colKeyList.Add(objDR.GetString(0));
                    }
                    return colKeyList;
                }
                else
                {

                    objDR.Close();
                    objDR = null;
                    objCmd.Dispose();
                    objCmd = null;

                    return null;

                }
            }
            catch (System.Exception)
            {

                throw new System.Exception();
            }
            finally
            {

                objConn.Close();
                objConn.Dispose();
                objConn = null;
            }
        }
    }
}
