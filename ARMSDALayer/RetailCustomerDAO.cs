using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ARMSDALayer
{
  public  class RetailCustomerDAO:IDAOTemplate<RetailCustomerDTO>
    {
        public RetailCustomerDTO GetRecordByID(string key)
        {


            SqlConnection objConn = new SqlConnection(SQLServerFactory.ConnectionString());

            try
            {

                objConn.Open();
                string strSQL;

                strSQL = "SELECT Person.IDNumber, Person.FirstName, Person.LastName, Person.BirthDate,Person.HouseStreetAddress, Person.City, Person.State, Person.ZipCode,";
                strSQL = strSQL + " Person.Country, Person.Phone, Person.Email,Person.DriverLicenseNumber,Person.DriverLicenseExpDate,Person.PersonType,";
                strSQL = strSQL + "Discount.DiscountCode, Discount.DiscountCodeDesc";
                strSQL = strSQL + "EZPlus.EZPlusNumber, EZPlus.EZPlusEarnedPoints";
                strSQL = strSQL + " FROM Person, RetailCustomer, Discount, EZPlus";
                strSQL = strSQL + " WHERE Person.IDNumber = RetailCustomer.IDNumber AND RetailCustomer.DiscountCode = Discount.DiscountCode AND RetailCustomer.EZPlusID =EZPlus.EZPlusID AND RetailCustomer.IDNumber = @IDNumber; ";
                SqlCommand objCmd = new SqlCommand(strSQL, objConn);

                objCmd.CommandType = CommandType.Text;

                objCmd.Parameters.Add("@IDNumber", SqlDbType.VarChar).Value = key;

                SqlDataReader objDR = objCmd.ExecuteReader();

                if (objDR.HasRows)
                {

                    RetailCustomerDTO objDTO = new RetailCustomerDTO();

                    objDR.Read();


                    objDTO.IDNumber = objDR.GetString(0);
                    objDTO.FirstName = objDR.GetString(1);
                    objDTO.LastName = objDR.GetString(2);
                    objDTO.BirthDate = objDR.GetString(3);
                   
                    objDTO.HouseStreetAddress = objDR.GetString(4);
                    objDTO.City = objDR.GetString(5);
                    objDTO.State = objDR.GetString(6);
                    objDTO.ZipCode = objDR.GetString(7);
                    objDTO.Country = objDR.GetString(8);
                    objDTO.Phone = objDR.GetString(9);
                    objDTO.Email = objDR.GetString(10);
                    objDTO.DriverLicenseNumber = objDR.GetString(11);
                    objDTO.DriverLicenseExpDate = objDR.GetString(12);
                    objDTO.PersonType = objDR.GetChar(13);
                    objDTO.DiscountCode = objDR.GetString(14);
                    objDTO.DiscountCodeDesc = objDR.GetString(15);
                    objDTO.EZPlusID = objDR.GetString(16);
                    objDTO.EZPlusEarnedPoints = objDR.GetInt32(17);






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
        public bool Insert(RetailCustomerDTO objDTO)
        {

            SqlConnection objConn = new SqlConnection(SQLServerFactory.ConnectionString());

            try
            {

                objConn.Open();

                string strSQL;
                strSQL = " INSERT INTO EZPlus (EZPlusID,EZPlusEarnedPoints)";
                strSQL = strSQL + " VALUES (@EZPlusID,@EZPlusEarnedPoints);";
                strSQL = "INSERT INTO Person (IDNumber,FirstName,LastName,BirthDate,";
                strSQL = strSQL + "HouseStreetAddress,City,State,ZipCode,Country,Phone,Email,";
                strSQL = strSQL + "DriverLicenseNumber,DriverLicenseExpDate,PersonType)";
                strSQL = strSQL + " VALUES (@IDNumber,@FirstName,@LastName,@BirthDate,@HouseStreetAddress,";
                strSQL = strSQL + "@City,@State,@ZipCode,@Country,@Phone,@Email,";
                strSQL = strSQL + "@DriverLicenseNumber,@DriverLicenseExpDate,@PersonType);";
                strSQL = strSQL + " INSERT INTO RetailCustomer (IDNumber,DiscountCode,EZPlusID)";
                strSQL = strSQL + "VALUES (@IDNumber,@DiscountCode,@EZPlusID);";
                char discriminatorAttribute = 'R';

                SqlCommand objCmd = new SqlCommand(strSQL, objConn);

                objCmd.CommandType = CommandType.Text;

                objCmd.Parameters.Add("@EZPlusID", SqlDbType.VarChar).Value = objDTO.EZPlusID;
                objCmd.Parameters.Add("@EZPlusEarnedPoints", SqlDbType.VarChar).Value = objDTO.EZPlusEarnedPoints;
                objCmd.Parameters.Add("@IDNumber", SqlDbType.VarChar).Value = objDTO.IDNumber;
                objCmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = objDTO.FirstName;
                objCmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = objDTO.LastName;
                objCmd.Parameters.Add("@BirthDate", SqlDbType.VarChar).Value = objDTO.BirthDate;
                objCmd.Parameters.Add("@HouseStreetAddress", SqlDbType.VarChar).Value = objDTO.HouseStreetAddress;
                objCmd.Parameters.Add("@City", SqlDbType.VarChar).Value = objDTO.City;
                objCmd.Parameters.Add("@State", SqlDbType.VarChar).Value = objDTO.State;
                objCmd.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = objDTO.ZipCode;
                objCmd.Parameters.Add("@Country", SqlDbType.VarChar).Value = objDTO.Country;
                objCmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = objDTO.Email;
                objCmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = objDTO.Phone;
                objCmd.Parameters.Add("@DriverLicenseNumber", SqlDbType.VarChar).Value = objDTO.DriverLicenseNumber;
                objCmd.Parameters.Add("@DriverLicenseExpDate", SqlDbType.VarChar).Value = objDTO.DriverLicenseExpDate;
                objCmd.Parameters.Add("@PersonType", SqlDbType.VarChar).Value = discriminatorAttribute;
                objCmd.Parameters.Add("@DiscountCode", SqlDbType.VarChar).Value = objDTO.DiscountCode;



                int intRecordsAffected = objCmd.ExecuteNonQuery();

                if (intRecordsAffected == 3)
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
        public bool Update(RetailCustomerDTO objDTO)
        {
            SqlConnection objConn = new SqlConnection(SQLServerFactory.ConnectionString());
            try
            {
                objConn.Open();
                string strSQL;


                strSQL = "UPDATE Person ";
                strSQL = strSQL + "SET FirstName=@FirstName,";
                strSQL = strSQL + "LastName=@LastName,";
                strSQL = strSQL + "BirthDate=@BirthDate,";
                strSQL = strSQL + "HouseStreetName=@HouseStreetName,";
                strSQL = strSQL + "City=@City,";
                strSQL = strSQL + "State=@State,";
                strSQL = strSQL + "ZipCode=@ZipCode,";
                strSQL = strSQL + "Country=@Country,";
                strSQL = strSQL + "Phone=@Phone,";
                strSQL = strSQL + "Email=@Email";
                strSQL = strSQL + "DriverLicenseNumber=@DriverLicenseNumber";
                strSQL = strSQL + "DriverLicenseExpDate=@DriverLicenseExpDate";
                
                strSQL = strSQL + " WHERE IDNumber=@IDNumber;";

                strSQL = "UPDATE RetailCustomer ";
                strSQL = strSQL + "SET DiscountCode=@DiscountCode,";
                
                strSQL = strSQL + " WHERE IDNumber=@IDNumber;";
                SqlCommand objCmd = new SqlCommand(strSQL, objConn);
                objCmd.CommandType = CommandType.Text;

                objCmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = objDTO.FirstName;
                objCmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = objDTO.LastName;
                objCmd.Parameters.Add("@BirthDate", SqlDbType.VarChar).Value = objDTO.BirthDate;
                objCmd.Parameters.Add("@HouseStreetAddress", SqlDbType.VarChar).Value = objDTO.HouseStreetAddress;
                objCmd.Parameters.Add("@City", SqlDbType.VarChar).Value = objDTO.City;
                objCmd.Parameters.Add("@State", SqlDbType.VarChar).Value = objDTO.State;
                objCmd.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = objDTO.ZipCode;
                objCmd.Parameters.Add("@Country", SqlDbType.VarChar).Value = objDTO.Country;
                objCmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = objDTO.Email;
                objCmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = objDTO.Phone;
                objCmd.Parameters.Add("@DriverLicenseNumber", SqlDbType.VarChar).Value = objDTO.DriverLicenseNumber;
                objCmd.Parameters.Add("@DriverLicenseExpDate", SqlDbType.VarChar).Value = objDTO.DriverLicenseExpDate;
               
                objCmd.Parameters.Add("@DiscountCode", SqlDbType.VarChar).Value = objDTO.DiscountCode;
                objCmd.Parameters.Add("@IDNumber", SqlDbType.VarChar).Value = objDTO.IDNumber;


                int intRecordsAffected = objCmd.ExecuteNonQuery();
                if (intRecordsAffected == 2)
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
                string strSQL = "DELETE FROM Person WHERE IDNumber = @IDNumber;";
                
                SqlCommand objCmd = new SqlCommand(strSQL, objConn);
                
                objCmd.CommandType = CommandType.Text;
                
                objCmd.Parameters.Add("@IDNumber", SqlDbType.VarChar).Value = key;
                
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
        public List<RetailCustomerDTO> GetAllRecords()
        {

            SqlConnection objConn = new SqlConnection(SQLServerFactory.ConnectionString());

            try
            {

                objConn.Open();
                string strSQL;

                strSQL = "SELECT Person.IDNumber, Person.FirstName, Person.LastName, Person.BirthDate,Person.HouseStreetAddress, Person.City, Person.State, Person.ZipCode,";
                strSQL = strSQL + " Person.Country, Person.Phone, Person.Email,Person.DriverLicenseNumber,Person.DriverLicenseExpDate,Person.PersonType,";
                strSQL = strSQL + "Discount.DiscountCode, Discount.DiscountCodeDesc";
                strSQL = strSQL + "EZPlus.EZPlusID, EZPlus.EZPlusEarnedPoints";
                strSQL = strSQL + " FROM Person, RetailCustomer, Discount, EZPlus";
                strSQL = strSQL + " WHERE Person.IDNumber = RetailCustomer.IDNumber AND RetailCustomer.DiscountCode = Discount.DiscountCode AND RetailCustomer.EZPlusID = EZPlus.EZPlusID; ";


                SqlCommand objCmd = new SqlCommand(strSQL, objConn);

                objCmd.CommandType = CommandType.Text;

                SqlDataReader objDR = objCmd.ExecuteReader();

                if (objDR.HasRows)
                {

                    List<RetailCustomerDTO> colRecordList = new List<RetailCustomerDTO>();

                    while (objDR.Read())
                    {
                        RetailCustomerDTO objDTO = new RetailCustomerDTO();
                        objDTO.IDNumber = objDR.GetString(0);
                        objDTO.FirstName = objDR.GetString(1);
                        objDTO.LastName = objDR.GetString(2);
                        objDTO.BirthDate = objDR.GetString(3);
                        objDTO.HouseStreetAddress = objDR.GetString(4);
                        objDTO.City = objDR.GetString(5);
                        objDTO.State = objDR.GetString(6);
                        objDTO.ZipCode = objDR.GetString(7);
                        objDTO.Country = objDR.GetString(8);
                        objDTO.Phone = objDR.GetString(9);
                        objDTO.Email = objDR.GetString(10);
                        objDTO.DriverLicenseNumber = objDR.GetString(11);
                        objDTO.DriverLicenseExpDate = objDR.GetString(12);
                        objDTO.PersonType = objDR.GetChar(13);
                        objDTO.DiscountCode = objDR.GetString(14);
                        objDTO.DiscountCodeDesc = objDR.GetString(15);
                        objDTO.EZPlusID = objDR.GetString(16);
                        objDTO.EZPlusEarnedPoints = objDR.GetInt16(17);

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

                string strSQL = "SELECT IDNumber FROM RetailCustomer;";

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
