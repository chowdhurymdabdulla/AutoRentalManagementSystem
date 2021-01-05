using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ARMSDALayer
{
  public  class MinivanDAO:IDAOTemplate<MinivanDTO>
    {
        public MinivanDTO GetRecordByID(string key)
        {
            SqlConnection objConn = new SqlConnection(SQLServerFactory.ConnectionString());

            try
            {
                objConn.Open();
                string strSQL = "SELECT Vehicle.VINNumber, Vehicle.Make, Vehicle.Model, Vehicle.Year, Vehicle.Color, Vehicle.PlateNumber, Vehicle.Mileage, Vehicle.TransmissionType, Vehicle.SeatCapacity, Vehicle.DailyRentalRate, Vehicle.VehicleStatus, Vehicle.VehicleAssignedAgency, Vehicle.VehicleCurrentAgencyLocation";
                strSQL = strSQL + "Minivan.MVVINNumber, Minivan.DisabilityOption";
                strSQL = strSQL + "FROM Vehicle, Minivan";
                strSQL = strSQL + "WHERE Vehicle.VINNumber = Minivan.MVVINNumber AND Minivan.MVVINNumber = @MVVINNumber;";
               SqlCommand objCmd = new SqlCommand(strSQL, objConn);
                objCmd.CommandType = CommandType.Text;
                objCmd.Parameters.Add("@MVVINNumber", SqlDbType.VarChar).Value = key;
                SqlDataReader objDR = objCmd.ExecuteReader();
                if (objDR.HasRows)
                {
                    MinivanDTO objDTO = new MinivanDTO();
                    objDR.Read();
                    objDTO.VINNumber = objDR.GetString(0);
                    objDTO.Make = objDR.GetString(1);
                    objDTO.Model = objDR.GetString(2);
                    objDTO.Year = objDR.GetInt32(3);
                    objDTO.Color = objDR.GetString(4);
                    objDTO.PlateNumber = objDR.GetString(5);
                    objDTO.Mileage = objDR.GetInt32(6);
                    objDTO.TransmissionType = objDR.GetString(7);
                    objDTO.SeatCapacity = objDR.GetInt32(8);
                    objDTO.DailyRentalRate = objDR.GetDecimal(9);
                    objDTO.VehicleStatus = objDR.GetString(10);
                    objDTO.VehicleAssignedAgency = objDR.GetString(11);
                    objDTO.VehicleCurrentAgencyLocation = objDR.GetString(12);
                    objDTO.DisabilityOption = objDR.GetBoolean(13);

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
        public bool Insert(MinivanDTO objDTO)
        {
            SqlConnection objConn = new SqlConnection(SQLServerFactory.ConnectionString());
            try
            {
                objConn.Open();
                string strSQL;

                strSQL = "INSERT INTO Vehicle ( VINNumber, Make, Model, Year,";
                strSQL = strSQL + "Color,PlateNumber,Mileage,TransmissionType,SeatCapacity,";
                strSQL = strSQL + "DailyRentalRate,VehicleStatus, VehicleAssignedAgency, VehicleCurrentAgencyLocation);";
                strSQL = strSQL + "VALUES(@VINNumber, @Make, @Model, @Year,";
                strSQL = strSQL + "@Color,@PlateNumber,@Mileage,@TransmissionType,@SeatCapacity,";
                strSQL = strSQL + "@DailyRentalRate,@VehicleStatus, @VehicleAssignedAgency, @VehicleCurrentAgencyLocation);";


                strSQL = "INSERT INTO Minivan ( MVVINNumber, DisabilityOption);";
                strSQL = strSQL + "VALUES(@MVVINNumber, @DisabilityOption);";
                string discriminatorAttribute = "MV";
                SqlCommand objCmd = new SqlCommand(strSQL, objConn);
                objCmd.CommandType = CommandType.Text;

                objCmd.Parameters.Add("@VINNumber", SqlDbType.VarChar).Value = objDTO.VINNumber;
                objCmd.Parameters.Add("@Make", SqlDbType.VarChar).Value = objDTO.Make;
                objCmd.Parameters.Add("@Model", SqlDbType.VarChar).Value = objDTO.Model;
                objCmd.Parameters.Add("@Year", SqlDbType.VarChar).Value = objDTO.Year;
                objCmd.Parameters.Add("@Color", SqlDbType.VarChar).Value = objDTO.Color;
                objCmd.Parameters.Add("@PlateNumber", SqlDbType.VarChar).Value = objDTO.PlateNumber;
                objCmd.Parameters.Add("@Mileage", SqlDbType.VarChar).Value = objDTO.Mileage;
                objCmd.Parameters.Add("@TransmissionType", SqlDbType.VarChar).Value = objDTO.TransmissionType;
                objCmd.Parameters.Add("@SeatCapacity", SqlDbType.VarChar).Value = objDTO.SeatCapacity;
                objCmd.Parameters.Add("@DailyRentalRate", SqlDbType.Decimal).Value = objDTO.DailyRentalRate;
                objCmd.Parameters.Add("@VehicleStatus", SqlDbType.Bit).Value = objDTO.VehicleStatus;
                objCmd.Parameters.Add("@VehicleAssignedAgency", SqlDbType.Bit).Value = objDTO.VehicleAssignedAgency;
                objCmd.Parameters.Add("@VehicleCurrentAgencyLocation", SqlDbType.Bit).Value = objDTO.VehicleCurrentAgencyLocation;
                objCmd.Parameters.Add("@VehicleType", SqlDbType.VarChar).Value = discriminatorAttribute;
                objCmd.Parameters.Add("@DisabilityOption", SqlDbType.Bit).Value = objDTO.DisabilityOption;
                



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
        public bool Update(MinivanDTO objDTO)
        {
            SqlConnection objConn = new SqlConnection(SQLServerFactory.ConnectionString());
            try
            {
                objConn.Open();
                string strSQL;


                strSQL = "UPDATE Vehicle ";
                strSQL = strSQL + "SET Make = @Make,";
                strSQL = strSQL + "Model = @Model,";
                strSQL = strSQL + "Year = @Year,";
                strSQL = strSQL + "Color = @Color,";
                strSQL = strSQL + "PlateNumber = @PlateNumber,";
                strSQL = strSQL + "Mileage = @Mileage,";
                strSQL = strSQL + "TransmissionType = @TransmissionType,";
                strSQL = strSQL + "SeatCapacity = @SeatCapacity,";
                strSQL = strSQL + "DailyRentalRate = @DailyRentalRate";
                strSQL = strSQL + "VehicleStatus = @VehicleStatus";
                strSQL = strSQL + "VehicleAssignedAgency = @VehicleAssignedAgency";
                strSQL = strSQL + "VehicleCurrentAgencyLocation = @VehicleCurrentAgencyLocation";
                strSQL = strSQL + " WHERE VINNumber =@VINNumber;";

                strSQL = "UPDATE Minivan ";
                strSQL = strSQL + "SET DisabilityOption=@DisabilityOption,";
                strSQL = strSQL + " WHERE MVVINNumber=@MVVINNumber;";
                SqlCommand objCmd = new SqlCommand(strSQL, objConn);
                objCmd.CommandType = CommandType.Text;

               
                objCmd.Parameters.Add("@Make", SqlDbType.VarChar).Value = objDTO.Make;
                objCmd.Parameters.Add("@Model", SqlDbType.VarChar).Value = objDTO.Model;
                objCmd.Parameters.Add("@Year", SqlDbType.VarChar).Value = objDTO.Year;
                objCmd.Parameters.Add("@Color", SqlDbType.VarChar).Value = objDTO.Color;
                objCmd.Parameters.Add("@PlateNumber", SqlDbType.VarChar).Value = objDTO.PlateNumber;
                objCmd.Parameters.Add("@Mileage", SqlDbType.VarChar).Value = objDTO.Mileage;
                objCmd.Parameters.Add("@TransmissionType", SqlDbType.VarChar).Value = objDTO.TransmissionType;
                objCmd.Parameters.Add("@SeatCapacity", SqlDbType.VarChar).Value = objDTO.SeatCapacity;
                objCmd.Parameters.Add("@DailyRentalRate", SqlDbType.Decimal).Value = objDTO.DailyRentalRate;
                objCmd.Parameters.Add("@VehicleStatus", SqlDbType.Bit).Value = objDTO.VehicleStatus;
                objCmd.Parameters.Add("@VehicleAssignedAgency", SqlDbType.Bit).Value = objDTO.VehicleAssignedAgency;
                objCmd.Parameters.Add("@VehicleCurrentAgencyLocation", SqlDbType.Bit).Value = objDTO.VehicleCurrentAgencyLocation;
                objCmd.Parameters.Add("@DisabilityOption", SqlDbType.Bit).Value = objDTO.DisabilityOption;
                objCmd.Parameters.Add("@VINNumber", SqlDbType.VarChar).Value = objDTO.VINNumber;

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
                string strSQL = "DELETE FROM Vehicle WHERE VINNumber = @VINNumber;";
                
                SqlCommand objCmd = new SqlCommand(strSQL, objConn);                
                objCmd.CommandType = CommandType.Text;               
                objCmd.Parameters.Add("@VINNumber", SqlDbType.VarChar).Value = key;
                
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
        public List<MinivanDTO> GetAllRecords()
        {

            SqlConnection objConn = new SqlConnection(SQLServerFactory.ConnectionString());

            try
            {

                objConn.Open();

                string strSQL = "SELECT Vehicle.VINNumber, Vehicle.Make, Vehicle.Model, Vehicle.Year, Vehicle.Color, Vehicle.PlateNumber, Vehicle.Mileage, Vehicle.TransmissionType, Vehicle.SeatCapacity, Vehicle.DailyRentalRate, Vehicle.VehicleStatus, Vehicle.VehicleAssignedAgency, Vehicle.VehicleCurrentAgencyLocation";
                strSQL = strSQL + "Minivan.MVVINNumber, Minivan.DisabilityOption";
                strSQL = strSQL + "FROM Vehicle, Minivan";
                strSQL = strSQL + "WHERE Vehicle.VINNumber = Minivan.MVVINNumber;";


                SqlCommand objCmd = new SqlCommand(strSQL, objConn);

                objCmd.CommandType = CommandType.Text;

                SqlDataReader objDR = objCmd.ExecuteReader();

                if (objDR.HasRows)
                {

                    List<MinivanDTO> colRecordList = new List<MinivanDTO>();

                    while (objDR.Read())
                    {
                        MinivanDTO objDTO = new MinivanDTO();
                        objDR.Read();
                        objDTO.VINNumber = objDR.GetString(0);
                        objDTO.Make = objDR.GetString(1);
                        objDTO.Model = objDR.GetString(2);
                        objDTO.Year = objDR.GetInt32(3);
                        objDTO.Color = objDR.GetString(4);
                        objDTO.PlateNumber = objDR.GetString(5);
                        objDTO.Mileage = objDR.GetInt32(6);
                        objDTO.TransmissionType = objDR.GetString(7);
                        objDTO.SeatCapacity = objDR.GetInt32(8);
                        objDTO.DailyRentalRate = objDR.GetDecimal(9);
                        objDTO.VehicleStatus = objDR.GetString(10);
                        objDTO.VehicleAssignedAgency = objDR.GetString(11);
                        objDTO.VehicleCurrentAgencyLocation = objDR.GetString(12);
                        objDTO.DisabilityOption = objDR.GetBoolean(13);

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

                string strSQL = "SELECT MVVINNumber FROM Minivan;";

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
