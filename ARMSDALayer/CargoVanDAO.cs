using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ARMSDALayer
{
   public class CargoVanDAO:IDAOTemplate<CargoVanDTO>
    {
        public CargoVanDTO GetRecordByID(string key)
        {
            SqlConnection objConn = new SqlConnection(SQLServerFactory.ConnectionString());

            try
            {
                objConn.Open();
                string strSQL;

                strSQL = "Select Vehicle.VINNumber, Vehicle.Make, Vehicle.Model, Vehicle.Year,";
                strSQL = strSQL + "Vehicle.Color, Vehicle.PlateNumber, Vehicle.Mileage, Vehicle.TransmissionType, Vehicle.SeatCapacity,";
                strSQL = strSQL + "Vehicle.DailyRentalRate, Vehicle.VehicleStatus, Vehicle.VehicleAssignedAgency, Vehicle.VehicleCurrentAgencyLocation";
                strSQL = strSQL + "CargoVan.CargoCapacity, CargoVan.MaximumPayload,";
                strSQL = strSQL + "FROM Vehicle, CargoVan";
                strSQL = strSQL + "where Vehicle.VINNumber = CargoVan.CVVINNumber and CargoVan.CVVINNumber = @CVVINNumber;";

                SqlCommand objCmd = new SqlCommand(strSQL, objConn);
                objCmd.CommandType = CommandType.Text;
                objCmd.Parameters.Add("@CVVINNumber", SqlDbType.VarChar).Value = key;
                SqlDataReader objDR = objCmd.ExecuteReader();
                if (objDR.HasRows)
                {
                    CargoVanDTO objDTO = new CargoVanDTO();
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
                    objDTO.CargoCapacity = objDR.GetInt32(13);
                    objDTO.MaximumPayload = objDR.GetInt32(14);

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

        public bool Insert(CargoVanDTO objDTO)
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


                strSQL = "INSERT INTO CargoVan (CargoCapacity, MaximumPayload);";
                strSQL = strSQL + "VALUES(@CargoCapacity, @MaximumPayload);";

                string discrimanatorAttribute = "CV";

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
                objCmd.Parameters.Add("@VehicleType", SqlDbType.VarChar).Value = discrimanatorAttribute;
                objCmd.Parameters.Add("@CargoCapacity", SqlDbType.Bit).Value = objDTO.CargoCapacity;
                objCmd.Parameters.Add("@MaximumPayload", SqlDbType.Bit).Value = objDTO.MaximumPayload;



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

        public bool Update(CargoVanDTO objDTO)
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

                strSQL = "UPDATE CargoVan ";
                strSQL = strSQL + "SET CargoCapacity=@CargoCapacity,";
                strSQL = strSQL + " MaximumPayload=@MaximumPayload,";
                strSQL = strSQL + " WHERE CVVINNumber=@CVVINNumber;";
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
                objCmd.Parameters.Add("@CargoCapacity", SqlDbType.Bit).Value = objDTO.CargoCapacity;
                objCmd.Parameters.Add("@MaximumPayload", SqlDbType.Bit).Value = objDTO.MaximumPayload;
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

        public List<CargoVanDTO> GetAllRecords()
        {

            SqlConnection objConn = new SqlConnection(SQLServerFactory.ConnectionString());

            try
            {

                objConn.Open();

                string strSQL;
                strSQL = "Select Vehicle.VINNumber, Vehicle.Make, Vehicle.Model, Vehicle.Year,";
                strSQL = strSQL + "Vehicle.Color, Vehicle.PlateNumber, Vehicle.Mileage, Vehicle.TransmissionType, Vehicle.SeatCapacity,";
                strSQL = strSQL + "Vehicle.DailyRentalRate, Vehicle.VehicleStatus, Vehicle.VehicleAssignedAgency, Vehicle.VehicleCurrentAgencyLocation";
                strSQL = strSQL + "CargoVan.CargoCapacity, CargoVan.MaximumPayload,";
                strSQL = strSQL + "FROM Vehicle, CargoVan";
                strSQL = strSQL + "where Vehicle.VINNumber = CargoVan.CVVINNumber and CargoVan.CVVINNumber = @CVVINNumber;";

                SqlCommand objCmd = new SqlCommand(strSQL, objConn);
                objCmd.CommandType = CommandType.Text;
                SqlDataReader objDR = objCmd.ExecuteReader();

                if (objDR.HasRows)
                {

                    List<CargoVanDTO> colRecordList = new List<CargoVanDTO>();

                    while (objDR.Read())
                    {
                        CargoVanDTO objDTO = new CargoVanDTO();
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
                        objDTO.CargoCapacity = objDR.GetInt32(13);
                        objDTO.MaximumPayload = objDR.GetInt32(14);
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

                string strSQL;
                strSQL = "Select CVVINNumber FROM CargoVan";
                

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
