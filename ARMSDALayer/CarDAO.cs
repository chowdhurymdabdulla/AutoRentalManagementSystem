using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

//this is for test perpouse

namespace ARMSDALayer
{
    public class CarDAO : IDAOTemplate<CarDTO>
    {
        public CarDTO GetRecordByID(string key)
        {
            SqlConnection objConn = new SqlConnection(SQLServerFactory.ConnectionString());

            try
            {
                objConn.Open();
                string strSQL = "SELECT VEHICLE.VINNumber, VEHICLE.Make, VEHICLE.Model, VEHICLE.Year, VEHICLE.Color, VEHICLE.PlateNumber,";
                strSQL = strSQL + "VEHICLE.Milage, VEHICLE.TransmissionType, VEHICLE.SeatCapacity, VEHICLE.DailyRentalRate, VEHICLE.VehicleStatus,";
                strSQL = strSQL + "VEHICLE.VehicleAssignedAgency, VEHICLE.CurrentAgencyLocation, CAR.TrunkCapacity,";
                strSQL = strSQL + "FROM VEHICLE, CAR,";
                strSQL = strSQL + "WHERE VEHICLE.VINNumber = CAR.VINNumber and CAR.VINNumber = @VINNumber;";
                SqlCommand objCmd = new SqlCommand(strSQL, objConn);
                objCmd.CommandType = CommandType.Text;
                objCmd.Parameters.Add("@VINNumber", SqlDbType.VarChar).Value = key;
                SqlDataReader objDR = objCmd.ExecuteReader();
                if (objDR.HasRows)
                {
                    CarDTO objDTO = new CarDTO();
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
                    objDTO.TrunkCapacity = objDR.GetFloat(13);

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
        public bool Insert(CarDTO objDTO)
        {
            SqlConnection objConn = new SqlConnection(SQLServerFactory.ConnectionString());
            try
            {
                objConn.Open();
                string strSQL;
                strSQL = "INSERT INTO Car ( VINNumber,TrunkCapacity); ";
                strSQL = strSQL + "VALUES(@VINNumber, @TrunkCapacity);";
                strSQL = "INSERT INTO Vehicle ( VINNumber, Make, Model, Year,";
                strSQL = strSQL + "Color,PlateNumber,Mileage,TransmissionType,SeatCapacity,";
                strSQL = strSQL + "DailyRentalRate,VehicleStatus, VehicleAssignedAgency, VehicleCurrentAgencyLocation, VehicleType);";
                strSQL = strSQL + "VALUES(@VINNumber, @Make, @Model, @Year,";
                strSQL = strSQL + "@Color,@PlateNumber,@Mileage,@TransmissionType,@SeatCapacity,";
                strSQL = strSQL + "@DailyRentalRate,@VehicleStatus, @VehicleAssignedAgency, @VehicleCurrentAgencyLocation, @VehicleType);";
                string discriminatorAttribute = "CR";



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
                objCmd.Parameters.Add("@TrunkCapacity", SqlDbType.Bit).Value = objDTO.TrunkCapacity;



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
        public bool Update(CarDTO objDTO)
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

                strSQL = "UPDATE Car ";
                strSQL = strSQL + "SET TrunkCapacity=@TrunkCapacity,";
                strSQL = strSQL + " WHERE VINNumber=@VINNumber;";
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
                objCmd.Parameters.Add("@TrunkCapacity", SqlDbType.Bit).Value = objDTO.TrunkCapacity;

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
        public List<CarDTO> GetAllRecords()
        {

            SqlConnection objConn = new SqlConnection(SQLServerFactory.ConnectionString());

            try
            {

                objConn.Open();

                string strSQL = "SELECT * FROM Vehicle INNER JOIN Car on Vehicle.VINNumber = Car.VINNumber WHERE VINNumber = @VINNumber;";


                SqlCommand objCmd = new SqlCommand(strSQL, objConn);

                objCmd.CommandType = CommandType.Text;

                SqlDataReader objDR = objCmd.ExecuteReader();

                if (objDR.HasRows)
                {

                    List<CarDTO> colRecordList = new List<CarDTO>();

                    while (objDR.Read())
                    {
                        CarDTO objDTO = new CarDTO();
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
                        objDTO.TrunkCapacity = objDR.GetFloat(13);

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

                string strSQL = "SELECT VINNumber from Car;";

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


    

