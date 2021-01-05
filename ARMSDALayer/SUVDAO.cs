using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ARMSDALayer
{
  public  class SUVDAO:IDAOTemplate<SUVDTO>
    {
        public SUVDTO GetRecordByID(string key)
        {
            SqlConnection objConn = new SqlConnection(SQLServerFactory.ConnectionString());

            try
            {
                objConn.Open();
                string strSQL;

                strSQL = "Select Vehicle.VINNumber, Vehicle.Make, Vehicle.Model, Vehicle.Year,";
                strSQL = strSQL + "Vehicle.Color, Vehicle.PlateNumber, Vehicle.Mileage, Vehicle.TransmissionType, Vehicle.SeatCapacity,";
                strSQL = strSQL + "Vehicle.DailyRentalRate, Vehicle.VehicleStatus, Vehicle.VehicleAssignedAgency, Vehicle.VehicleCurrentAgencyLocation";
                strSQL = strSQL + "SUV.TowingCapacity, SUV.IsAWD,";
                strSQL = strSQL + "FROM Vehicle, SUV";
                strSQL = strSQL + "where Vehicle.VINNumber = SUV.SUVINNumber and SUV.SUVINNumber = @SUVINNumber;";

                SqlCommand objCmd = new SqlCommand(strSQL, objConn);
                objCmd.CommandType = CommandType.Text;
                objCmd.Parameters.Add("@SUVINNumber", SqlDbType.VarChar).Value = key;
                SqlDataReader objDR = objCmd.ExecuteReader();
                if (objDR.HasRows)
                {
                    SUVDTO objDTO = new SUVDTO();
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
                    objDTO.TowingCapacity = objDR.GetFloat(13);
                    objDTO.IsAWD = objDR.GetBoolean(14);

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
        public bool Insert(SUVDTO objDTO)
        {
            SqlConnection objConn = new SqlConnection(SQLServerFactory.ConnectionString());
            try
            {
                objConn.Open();
                string strSQL;
                strSQL = "INSERT INTO SUV (VINNumber, TowingCapacity, IsAWD);";
                strSQL = strSQL + "VALUES(@VINNumber, @TowingCapacity, @IsAWD);";

                strSQL = "INSERT INTO Vehicle ( VINNumber, Make, Model, Year,";
                strSQL = strSQL + "Color,PlateNumber,Mileage,TransmissionType,SeatCapacity,";
                strSQL = strSQL + "DailyRentalRate,VehicleStatus, VehicleAssignedAgency, VehicleCurrentAgencyLocation, TowingCapacity, IsAWD);";
                strSQL = strSQL + "VALUES(@VINNumber, @Make, @Model, @Year,";
                strSQL = strSQL + "@Color,@PlateNumber,@Mileage,@TransmissionType,@SeatCapacity,";
                strSQL = strSQL + "@DailyRentalRate,@VehicleStatus, @VehicleAssignedAgency, @VehicleCurrentAgencyLocation);";
                string discriminatorAttribute = "SV";



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
                objCmd.Parameters.Add("@TowingCapacity", SqlDbType.Bit).Value = objDTO.TowingCapacity;
                objCmd.Parameters.Add("@IsAWD", SqlDbType.Bit).Value = objDTO.IsAWD;

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
        public bool Update(SUVDTO objDTO)
        {
            SqlConnection objConn = new SqlConnection(SQLServerFactory.ConnectionString());
            try
            {
                objConn.Open();
                string strSQL;


                strSQL = "UPDATE Vehicle ";
                strSQL = strSQL + "SET VINNumber = @VINNumber,";
                strSQL = strSQL + "Make = @Make,";
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

                strSQL = "UPDATE SUV ";
                strSQL = strSQL + "SET TowingCapacity=@TowingCapacity,";
                strSQL = strSQL + " IsAWD=@IsAWD;";
                strSQL = strSQL + " WHERE SUVINNumber=@SUVINNumber;";


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
                objCmd.Parameters.Add("@TowingCapacity", SqlDbType.Bit).Value = objDTO.TowingCapacity;
                objCmd.Parameters.Add("@IsAWD", SqlDbType.Bit).Value = objDTO.IsAWD;
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
        public List<SUVDTO> GetAllRecords()
        {

            SqlConnection objConn = new SqlConnection(SQLServerFactory.ConnectionString());

            try
            {

                objConn.Open();

                string strSQL;
                strSQL = "Select Vehicle.VINNumber, Vehicle.Make, Vehicle.Model, Vehicle.Year,";
                strSQL = strSQL + "Vehicle.Color, Vehicle.PlateNumber, Vehicle.Mileage, Vehicle.TransmissionType, Vehicle.SeatCapacity,";
                strSQL = strSQL + "Vehicle.DailyRentalRate, Vehicle.VehicleStatus, Vehicle.VehicleAssignedAgency, Vehicle.VehicleCurrentAgencyLocation";
                strSQL = strSQL + "SUV.TowingCapacity, SUV.IsAWD,";
                strSQL = strSQL + "FROM Vehicle, SUV";
                strSQL = strSQL + "where Vehicle.VINNumber = SUV.SUVINNumber";

                SqlCommand objCmd = new SqlCommand(strSQL, objConn);
                objCmd.CommandType = CommandType.Text;
                SqlDataReader objDR = objCmd.ExecuteReader();

                if (objDR.HasRows)
                {

                    List<SUVDTO> colRecordList = new List<SUVDTO>();

                    while (objDR.Read())
                    {
                        SUVDTO objDTO = new SUVDTO();
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
                        objDTO.TowingCapacity = objDR.GetFloat(13);
                        objDTO.IsAWD = objDR.GetBoolean(14);

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

                string strSQL = "Select SUVINNumber from SUV;";
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
