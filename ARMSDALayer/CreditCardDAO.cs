using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace ARMSDALayer
{
   public class CreditCardDAO:IDAOTemplate<CreditCardDTO>
    {
        public CreditCardDTO GetRecordByID(string key)
        {
           
               
                SqlConnection objConn = new SqlConnection(SQLServerFactory.ConnectionString());
               
                try
                {
                   
                    objConn.Open();
                    
                    string strSQL = "SELECT * FROM CreditCard WHERE CardNumber = @CardNumber;";

                   
                    SqlCommand objCmd = new SqlCommand(strSQL, objConn);
                   
                    objCmd.CommandType = CommandType.Text;
                   
                    objCmd.Parameters.Add("@CardNumber", SqlDbType.VarChar).Value = key;
                   
                    SqlDataReader objDR = objCmd.ExecuteReader();
                   
                    if (objDR.HasRows)
                    {
                       
                        CreditCardDTO objDTO = new CreditCardDTO();
                        
                        objDR.Read();
                        
                        objDTO.CardNumber = objDR.GetString(0);
                        objDTO.CustomerName = objDR.GetString(1);
                        objDTO.MerchantName = objDR.GetString(2);
                        objDTO.ExpDate = objDR.GetString(3);
                        objDTO.HouseStreetAddress = objDR.GetString(4);
                        objDTO.City = objDR.GetString(5);
                        objDTO.State = objDR.GetString(6);
                        objDTO.ZipCode = objDR.GetString(7);
                        objDTO.Country = objDR.GetString(8);
                        objDTO.CreditLimit = objDR.GetDecimal(9);
                        objDTO.ActivationStatus = objDR.GetBoolean(10);
                       
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

        public bool Insert(CreditCardDTO objDTO)
        {
           
            SqlConnection objConn = new SqlConnection(SQLServerFactory.ConnectionString());
           
            try
            {
                
                objConn.Open();
                
                string strSQL;
                strSQL = "INSERT INTO CreditCard (CardNumber,CustomerName,MerchantName,ExpDate,";
                strSQL = strSQL + "HouseStreetName,City,State,ZipCode,Country,";
                strSQL = strSQL + "CreditLimit,ActivationStatus)";
                strSQL = strSQL + "VALUES(@CardNumber,@CustomerName,@MerchantName,@CardNumber,@ExpDate,";
                strSQL = strSQL + "@HouseStreetName,@City,@State,@ZipCode,@Country,";
                strSQL = strSQL + "@CreditLimit,@ActivationStatus);";

                
                SqlCommand objCmd = new SqlCommand(strSQL, objConn);
               
                objCmd.CommandType = CommandType.Text;
               
                objCmd.Parameters.Add("@CardNumber", SqlDbType.VarChar).Value = objDTO.CardNumber;
                objCmd.Parameters.Add("@CustomerName", SqlDbType.VarChar).Value = objDTO.CustomerName;
                objCmd.Parameters.Add("@MerchantName", SqlDbType.VarChar).Value = objDTO.MerchantName;
                objCmd.Parameters.Add("@ExpDate", SqlDbType.VarChar).Value = objDTO.ExpDate;
                objCmd.Parameters.Add("@HouseStreetName", SqlDbType.VarChar).Value = objDTO.HouseStreetAddress;
                objCmd.Parameters.Add("@City", SqlDbType.VarChar).Value = objDTO.City;
                objCmd.Parameters.Add("@State", SqlDbType.VarChar).Value = objDTO.State;
                objCmd.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = objDTO.ZipCode;
                objCmd.Parameters.Add("@Country", SqlDbType.VarChar).Value = objDTO.Country;
                objCmd.Parameters.Add("@CreditLimit", SqlDbType.Decimal).Value = objDTO.CreditLimit;
                objCmd.Parameters.Add("@ActivationStatus", SqlDbType.Bit).Value = objDTO.ActivationStatus;
               
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
        public bool InsertChildObjectOfAParent(string parentKey, CreditCardDTO objDTO)
        {
            
            SqlConnection objConn = new SqlConnection(SQLServerFactory.ConnectionString());
            
            try
            {
                
                objConn.Open();
                
                string strSQL;
                
                strSQL = "INSERT INTO CreditCard (CardNumber,CustomerName,MerchantName,ExpDate,";
                strSQL = strSQL + "HouseStreetAddress,CreditLimit,ActivationStatus)";
                strSQL = strSQL + "VALUES (@CardNumber,@CustomerName,@MerchantName,@ExpDate,";
                strSQL = strSQL + "@HouseStreetAddress,@CreditLimit,@ActivationStatus);";
                strSQL = strSQL + " INSERT INTO Person_CreditCard (IDNumber,CardNumber)";
                strSQL = strSQL + "VALUES (@IDNumber,@CardNumber);";

                
                SqlCommand objCmd = new SqlCommand(strSQL, objConn);
                
                objCmd.CommandType = CommandType.Text;
               
                objCmd.Parameters.Add("@CardNumber", SqlDbType.VarChar).Value = objDTO.CardNumber;
                objCmd.Parameters.Add("@CustomerName", SqlDbType.VarChar).Value = objDTO.CustomerName;
                objCmd.Parameters.Add("@MerchantName", SqlDbType.VarChar).Value = objDTO.MerchantName;
                objCmd.Parameters.Add("@ExpDate", SqlDbType.VarChar).Value = objDTO.ExpDate;
                objCmd.Parameters.Add("@HouseStreetName", SqlDbType.VarChar).Value = objDTO.HouseStreetAddress;
                objCmd.Parameters.Add("@City", SqlDbType.VarChar).Value = objDTO.City;
                objCmd.Parameters.Add("@State", SqlDbType.VarChar).Value = objDTO.State;
                objCmd.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = objDTO.ZipCode;
                objCmd.Parameters.Add("@Country", SqlDbType.VarChar).Value = objDTO.Country;
                objCmd.Parameters.Add("@CreditLimit", SqlDbType.Decimal).Value = objDTO.CreditLimit;
                objCmd.Parameters.Add("@ActivationStatus", SqlDbType.Bit).Value = objDTO.ActivationStatus;
                objCmd.Parameters.Add("@IDNumber", SqlDbType.VarChar).Value = parentKey;
                
                int intRecordsAffected = objCmd.ExecuteNonQuery();
                
                if (intRecordsAffected == 2)
                {
                    
                    return true;
                }
               
                objCmd.Dispose();
                objCmd = null;
                
                return false;
            }
             
            catch (Exception objE)
            {
                
                throw new Exception("Unexpected Error in CreditCardADO InsertChildObjectOfAParent (Key,CreditCardDTO objDTO) Method: { 0}" + objE.Message);
            }
            finally
            {
               
                objConn.Close();
                objConn.Dispose();
                objConn = null;
            }
        }


        public bool Update(CreditCardDTO objDTO)
        {
           
            SqlConnection objConn = new SqlConnection(SQLServerFactory.ConnectionString());
           
            try
            {
               
                objConn.Open();
               
                string strSQL;
                strSQL = "UPDATE CreditCard ";
                strSQL = strSQL + "SET CustomerName=@CustomerName,";
                strSQL = strSQL + "MerchantName=@MerchantName,";
                strSQL = strSQL + "ExpDate=@ExpDate,";
                strSQL = strSQL + "HouseStreetName=@HouseStreetName,";
                strSQL = strSQL + "City=@City,";
                strSQL = strSQL + "State=@State,";
                strSQL = strSQL + "ZipCode=@ZipCode,";
                strSQL = strSQL + "Country=@Country,";
                strSQL = strSQL + "CreditLimit=@CreditLimit,";
                strSQL = strSQL + "ActivationStatus=@ActivationStatus";
                strSQL = strSQL + " WHERE CardNumber=@CardNumber;";

               
                SqlCommand objCmd = new SqlCommand(strSQL, objConn);
               
                objCmd.CommandType = CommandType.Text;
                
                objCmd.Parameters.Add("@CustomerName", SqlDbType.VarChar).Value = objDTO.CustomerName;
                objCmd.Parameters.Add("@MerchantName", SqlDbType.VarChar).Value = objDTO.MerchantName;
                objCmd.Parameters.Add("@ExpDate", SqlDbType.VarChar).Value = objDTO.ExpDate;
                objCmd.Parameters.Add("@HouseStreetName", SqlDbType.VarChar).Value = objDTO.HouseStreetAddress;
                objCmd.Parameters.Add("@City", SqlDbType.VarChar).Value = objDTO.City;
                objCmd.Parameters.Add("@State", SqlDbType.VarChar).Value = objDTO.State;
                objCmd.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = objDTO.ZipCode;
                objCmd.Parameters.Add("@Country", SqlDbType.VarChar).Value = objDTO.Country;
                objCmd.Parameters.Add("@CreditLimit", SqlDbType.Decimal).Value = objDTO.CreditLimit;
                objCmd.Parameters.Add("@ActivationStatus", SqlDbType.Bit).Value = objDTO.ActivationStatus;
                objCmd.Parameters.Add("@CardNumber", SqlDbType.VarChar).Value = objDTO.CardNumber;
               
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
                
                string strSQL = "DELETE FROM CreditCard WHERE CardNumber = @CardNumber;";

               
                SqlCommand objCmd = new SqlCommand(strSQL, objConn);
                
                objCmd.CommandType = CommandType.Text;
                
                objCmd.Parameters.Add("@CardNumber", SqlDbType.VarChar).Value = key;
               
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

        public List<CreditCardDTO> GetAllRecords()
        {
            
            SqlConnection objConn = new SqlConnection(SQLServerFactory.ConnectionString());
            
            try
            {
               
                objConn.Open();
                
                string strSQL = "SELECT * FROM CreditCard;";

               
                SqlCommand objCmd = new SqlCommand(strSQL, objConn);
                
                objCmd.CommandType = CommandType.Text;
               
                SqlDataReader objDR = objCmd.ExecuteReader();
                
                if (objDR.HasRows)
                {
                    
                    List<CreditCardDTO > colRecordList = new List<CreditCardDTO>();
                   
                    while (objDR.Read())
                    {
                        
                        CreditCardDTO objDTO = new CreditCardDTO();
                       
                        objDTO.CardNumber = objDR.GetString(0);
                        objDTO.CustomerName = objDR.GetString(1);
                        objDTO.MerchantName = objDR.GetString(2);
                        objDTO.ExpDate = objDR.GetString(3);
                        objDTO.HouseStreetAddress = objDR.GetString(4);
                        objDTO.City = objDR.GetString(5);
                        objDTO.State = objDR.GetString(6);
                        objDTO.ZipCode = objDR.GetString(7);
                        objDTO.Country = objDR.GetString(8);
                        objDTO.CreditLimit = objDR.GetDecimal(9);
                        objDTO.ActivationStatus = objDR.GetBoolean(10);
                        
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
               
                string strSQL = "SELECT CardNumber FROM CreditCard;";

               
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
        public List<string> GetAllChildKeysOwnedByParent(string ParentKey)
        {
            
            SqlConnection objConn = new SqlConnection(SQLServerFactory.ConnectionString());
            
            try
            {
                
                objConn.Open();
               
                string strSQL;
                strSQL = "SELECT CreditCard.CardNumber";
                strSQL = strSQL + " FROM CreditCard, Person_CreditCard";
                strSQL = strSQL + " WHERE CreditCard.CardNumber = Person_CreditCard.CardNumber";
                strSQL = strSQL + " AND Person_CreditCard.CustomerID = @IDNumber;";

                
                SqlCommand objCmd = new SqlCommand(strSQL, objConn);
                
                objCmd.CommandType = CommandType.Text;
                
                objCmd.Parameters.Add("@IDNumber", SqlDbType.VarChar).Value = ParentKey;
                
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
             
            catch (Exception objE)
            {
               
                throw new Exception("Unexpected Error in CreditCardADO GetAllChildKeysOwnedByParent() Method:{0} " + objE.Message);
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

