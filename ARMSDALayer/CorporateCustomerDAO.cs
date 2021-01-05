using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ARMSDALayer
{
    public class CorporateCustomerDAO:IDAOTemplate<CorporateCustomerDTO>
    {
        public CorporateCustomerDTO GetRecordByID(string key)
        {
            SqlConnection objConn = new SqlConnection(SQLServerFactory.ConnectionString());

            try
            {
                objConn.Open();
                string strSQL;
                strSQL = "SELECT Person.IDNumber, Person.FirstName, Person.LastName, Person.BirthDate,Person.HouseStreetAddress, Person.City, Person.State, Person.ZipCode,";
                strSQL = strSQL + " Person.Country, Person.Phone, Person.Email,Person.DriverLicenseNumber,Person.DriverLicenseExpDate,Person.PersonType";
                strSQL = strSQL + "Company.CompanyID, Company.CompanyName, Company.ContactName, Company.ContactPhone, Company.ContactEmail,";
                strSQL = strSQL + "CorporateCustomer.CompanyDailyRate,";
                strSQL = strSQL + " FROM Person, CorporateCustomer, Company";
                strSQL = strSQL + " WHERE Person.IDNumber = CorporateCustomer.IDNumber AND CorporateCustomer.CompanyID = Company.CompanyID  AND CorporateCustomer.IDNumber = @IDNumber; ";
                SqlCommand objCmd = new SqlCommand(strSQL, objConn);
                objCmd.CommandType = CommandType.Text;
                objCmd.Parameters.Add("@IDNumber", SqlDbType.VarChar).Value = key;
                SqlDataReader objDR = objCmd.ExecuteReader();
                if (objDR.HasRows)
                {
                    CorporateCustomerDTO objDTO = new CorporateCustomerDTO();
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
                    objDTO.CompanyID = objDR.GetString(14);
                    objDTO.CompanyName = objDR.GetString(15);
                    objDTO.ContactName = objDR.GetString(16);
                    objDTO.ContactPhone = objDR.GetString(17);
                    objDTO.ContactEmail = objDR.GetString(18);
                    objDTO.CompanyDailyRate = objDR.GetDecimal(19);
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
        public bool Insert(CorporateCustomerDTO objDTO)
        {
            SqlConnection objConn = new SqlConnection(SQLServerFactory.ConnectionString());
            try
            {
                objConn.Open();
                string strSQL;

                strSQL = "INSERT INTO Person ( IDNumber, FirstName, LastName, BirthDate,";
                strSQL = strSQL + "HouseStreetName,City,State,ZipCode,Country,";
                strSQL = strSQL + "Phone,Email, DriverLicenseNumber, DriverLicenseExpDate, PersonType);";
                strSQL = strSQL + "VALUES(@IDNumber, @FirstName, @LastName, @BirthDate,";
                strSQL = strSQL + "@HouseStreetName,@City,@State,@ZipCode,@Country,";
                strSQL = strSQL + "@Phone,@Email,@DriverLicenseNumber,@DriverLicenseExpDate, @PersonType);";


                strSQL = "INSERT INTO Company ( CompanyID, CompanyName, ContactName, ContactPhone, ContactEmail);";
                strSQL = strSQL + "VALUES(@CompanyID, @CompanyName, @ContactName, @ContactPhone, @ContactEmail);";

                strSQL = "INSERT INTO CorporateCustomer (IDNumber, CompanyID, CompanyDailyRate);";
                strSQL = strSQL + "VALUES(@IDNumber, @CompanyID, @CompanyDailyRate);";
                char discriminatorAttribute = 'C';

                SqlCommand objCmd = new SqlCommand(strSQL, objConn);
                objCmd.CommandType = CommandType.Text;

                objCmd.Parameters.Add("@IDNumber", SqlDbType.VarChar).Value = objDTO.IDNumber;
                objCmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = objDTO.FirstName;
                objCmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = objDTO.LastName;
                objCmd.Parameters.Add("@BirthDate", SqlDbType.VarChar).Value = objDTO.BirthDate;
                objCmd.Parameters.Add("@HouseStreetName", SqlDbType.VarChar).Value = objDTO.HouseStreetAddress;
                objCmd.Parameters.Add("@City", SqlDbType.VarChar).Value = objDTO.City;
                objCmd.Parameters.Add("@State", SqlDbType.VarChar).Value = objDTO.State;
                objCmd.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = objDTO.ZipCode;
                objCmd.Parameters.Add("@Country", SqlDbType.VarChar).Value = objDTO.Country;
                objCmd.Parameters.Add("@Phone", SqlDbType.Decimal).Value = objDTO.Phone;
                objCmd.Parameters.Add("@Email", SqlDbType.Bit).Value = objDTO.Email;
                objCmd.Parameters.Add("@DriverLicenseNumber", SqlDbType.Bit).Value = objDTO.DriverLicenseNumber;
                objCmd.Parameters.Add("@DriverLicenseExpDate", SqlDbType.Bit).Value = objDTO.DriverLicenseExpDate;
                objCmd.Parameters.Add("@PersonType", SqlDbType.VarChar).Value = discriminatorAttribute;
                objCmd.Parameters.Add("@CompanyID", SqlDbType.Bit).Value = objDTO.CompanyID;
                objCmd.Parameters.Add("@CompanyName", SqlDbType.Bit).Value = objDTO.CompanyName;
                objCmd.Parameters.Add("@ContactName", SqlDbType.Bit).Value = objDTO.ContactName;
                objCmd.Parameters.Add("@ContactPhone", SqlDbType.Bit).Value = objDTO.ContactPhone;
                objCmd.Parameters.Add("@ContactEmail", SqlDbType.Bit).Value = objDTO.ContactEmail;
                objCmd.Parameters.Add("@CompanyDailyRate", SqlDbType.Bit).Value = objDTO.CompanyDailyRate;
                


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
        public bool Update(CorporateCustomerDTO objDTO)
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

                strSQL = "UPDATE Company ";
                //strSQL = strSQL + "SET CompanyID=@CompanyID,";
                strSQL = strSQL + "CompanyName=@CompanyName,";
                strSQL = strSQL + "ContactName=@ContactName,";
                strSQL = strSQL + "ContactPhone=@ContactPhone,";
                strSQL = strSQL + "ContactEmail=@ContactEmail,";
                strSQL = strSQL + "CompanyDailyRate=@CompanyDailyRate,";
                strSQL = strSQL + " WHERE IDNumber=@IDNumber;";

                strSQL = "UPDATE CorporateCustomer ";
                strSQL = strSQL + "CompanyDailyRate=@CompanyDailyRate,";
                strSQL = strSQL + " WHERE IDNumber=@IDNumber and CompanyID=@CompanyID;";
                SqlCommand objCmd = new SqlCommand(strSQL, objConn);
                objCmd.CommandType = CommandType.Text;

                objCmd.Parameters.Add("@IDNumber", SqlDbType.VarChar).Value = objDTO.IDNumber;
                objCmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = objDTO.FirstName;
                objCmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = objDTO.LastName;
                objCmd.Parameters.Add("@BirthDate", SqlDbType.VarChar).Value = objDTO.BirthDate;
                objCmd.Parameters.Add("@HouseStreetName", SqlDbType.VarChar).Value = objDTO.HouseStreetAddress;
                objCmd.Parameters.Add("@City", SqlDbType.VarChar).Value = objDTO.City;
                objCmd.Parameters.Add("@State", SqlDbType.VarChar).Value = objDTO.State;
                objCmd.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = objDTO.ZipCode;
                objCmd.Parameters.Add("@Country", SqlDbType.VarChar).Value = objDTO.Country;
                objCmd.Parameters.Add("@Phone", SqlDbType.Decimal).Value = objDTO.Phone;
                objCmd.Parameters.Add("@Email", SqlDbType.Bit).Value = objDTO.Email;
                objCmd.Parameters.Add("@DriverLicenseNumber", SqlDbType.Bit).Value = objDTO.DriverLicenseNumber;
                objCmd.Parameters.Add("@DriverLicenseExpDate", SqlDbType.Bit).Value = objDTO.DriverLicenseExpDate;
                objCmd.Parameters.Add("@CompanyID", SqlDbType.Bit).Value = objDTO.CompanyID;
                objCmd.Parameters.Add("@CompanyName", SqlDbType.Bit).Value = objDTO.CompanyName;
                objCmd.Parameters.Add("@ContactName", SqlDbType.Bit).Value = objDTO.ContactName;
                objCmd.Parameters.Add("@ContactPhone", SqlDbType.Bit).Value = objDTO.ContactPhone;
                objCmd.Parameters.Add("@ContactEmail", SqlDbType.Bit).Value = objDTO.ContactEmail;
                objCmd.Parameters.Add("@CompanyDailyRate", SqlDbType.Bit).Value = objDTO.CompanyDailyRate;

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
        public List<CorporateCustomerDTO> GetAllRecords()
        {

            SqlConnection objConn = new SqlConnection(SQLServerFactory.ConnectionString());

            try
            {

                objConn.Open();

                string strSQL;

                strSQL = "SELECT Person.IDNumber, Person.FirstName, Person.LastName, Person.BirthDate,Person.HouseStreetAddress, Person.City, Person.State, Person.ZipCode,";
                strSQL = strSQL + " Person.Country, Person.Phone, Person.Email,Person.DriverLicenseNumber,Person.DriverLicenseExpDate,Person.PersonType,";
                strSQL = strSQL + "Company.CompanyID, Company.CompanyName, Company.ContactName, Company.ContactPhone, Company.ContactEmail, CorporateCustomer.CompanyDailyRate";
              
                strSQL = strSQL + " FROM Person, CorporateCustomer, Company";
                strSQL = strSQL + " WHERE Person.IDNumber = CorporateCustomer.IDNumber AND CorporateCustomer.IDNumber = Company.CompanyID ; ";


                SqlCommand objCmd = new SqlCommand(strSQL, objConn);

                objCmd.CommandType = CommandType.Text;

                SqlDataReader objDR = objCmd.ExecuteReader();

                if (objDR.HasRows)
                {

                    List<CorporateCustomerDTO> colRecordList = new List<CorporateCustomerDTO>();

                    while (objDR.Read())
                    {
                        CorporateCustomerDTO objDTO = new CorporateCustomerDTO();
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
                        objDTO.CompanyID = objDR.GetString(14);
                        objDTO.CompanyName = objDR.GetString(15);
                        objDTO.ContactName = objDR.GetString(16);
                        objDTO.ContactPhone = objDR.GetString(17);
                        objDTO.ContactEmail = objDR.GetString(18);
                        objDTO.CompanyDailyRate = objDR.GetDecimal(19);

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

                string strSQL = "SELECT IDNumber FROM CorporateCustomer;";

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
