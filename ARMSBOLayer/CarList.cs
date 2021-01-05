using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ARMSBOLayer
{
    public class CarList : BusinessFoundationCollectionBase
    {
        private Dictionary<string, Car> m_colCarList;

        public CarList()
        {
            m_colCarList = new Dictionary<string, Car>();
        }

        ~CarList()
        {
            m_colCarList = null;
        }


        public override bool IsDirty
        {

            get
            {

                try
                {

                    foreach (KeyValuePair<string, Car> objKeyValuePointer in m_colCarList)
                    {
                        //STEP 2- SEARCH for the first or any
                        //Dirty Object in the collection
                        if (objKeyValuePointer.Value.IsDirty)
                        {
                            //found, thus return and exit
                            return true;
                        }
                    }//End of foreach

                    return false;
                }//End of try

                catch (Exception objE)
                {
                    //Step C-Re-Throw an general exceptions
                    throw new Exception("Unexpected Error in IsDirty Property: { 0 } " + objE.Message);
                }

            }

        }

        public int Count
        {

            get
            {
                return m_colCarList.Count();
            }

        }

        public Dictionary<string, Car>.KeyCollection Keys
        {
            get { return m_colCarList.Keys; }

        }
        public Dictionary<string, Car>.ValueCollection Values
        {
            get { return m_colCarList.Values; }
        }
        public Car Search(string key)
        {
            try
            {
                if (m_colCarList.ContainsKey(key))
                {
                    return m_colCarList[key];
                }
                else
                {
                    return null;
                }
            }

            catch (Exception objE)
            {
                //Step C-Re-Throw an general exceptions
                throw new Exception("Unexpected Error in IsDirty Property: { 0 } " + objE.Message);
            }
        }
        public bool Add(string key, Car objCar)
        {
            try
            {
                if (!m_colCarList.ContainsKey(key))
                {
                    m_colCarList.Add(key, objCar);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception objE)
            {
                //Step C-Re-Throw an general exceptions
                throw new Exception("Unexpected Error in IsDirty Property: { 0 } " + objE.Message);
            }
        }
        public bool Edit(string key, Car objUpdatedCar)
        {
            try
            {
                Car objExistingCar = m_colCarList[key];

                if (objExistingCar != null)
                {
                    objExistingCar.Make = objUpdatedCar.Make;
                    objExistingCar.Model = objUpdatedCar.Model;
                    objExistingCar.Year = objUpdatedCar.Year;
                    objExistingCar.Color = objUpdatedCar.Color;
                    objExistingCar.PlateNumber = objUpdatedCar.PlateNumber;
                    objExistingCar.Mileage = objUpdatedCar.Mileage;
                    objExistingCar.TransmissionType = objUpdatedCar.TransmissionType;
                    objExistingCar.SeatCapacity = objUpdatedCar.SeatCapacity;
                    objExistingCar.DailyRentalRate = objUpdatedCar.DailyRentalRate;
                    objExistingCar.VehicleStatus = objUpdatedCar.VehicleStatus;
                    objExistingCar.VehicleAssignedAgency = objUpdatedCar.VehicleAssignedAgency;
                    objExistingCar.VehicleCurrentAgencyLocation = objUpdatedCar.VehicleCurrentAgencyLocation;
                    objExistingCar.TrunkCapacity = objUpdatedCar.TrunkCapacity;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception objE)
            {
                //Step C-Re-Throw an general exceptions
                throw new Exception("Unexpected Error in IsDirty Property: { 0 } " + objE.Message);
            }
        }
        public bool Remove(string key)
        {

            try
            {

                if (m_colCarList.ContainsKey(key))
                {
                   return m_colCarList.Remove(key);
                   
                }
                else
                {
                    return false;
                }

            }
            catch (Exception objE)
            {
                //Step C-Re-Throw an general exceptions
                throw new Exception("Unexpected Error in IsDirty Property: { 0 } " + objE.Message);
            }
        }
        public bool ContainsKey (string key)
        {
            try
            {

                if (m_colCarList.ContainsKey(key))
                {
                    return m_colCarList.ContainsKey(key);

                }
                else
                {
                    return false;
                }

            }
            catch (Exception objE)
            {
                //Step C-Re-Throw an general exceptions
                throw new Exception("Unexpected Error in IsDirty Property: { 0 } " + objE.Message);
            }

        }
        public bool Print(string key)
        {

            try
            {

                if (m_colCarList.ContainsKey(key))
                {
                     m_colCarList[key].Print();
                    return true;

                }
                else
                {
                    return false;
                }

            }
            catch (Exception objE)
            {
                //Step C-Re-Throw an general exceptions
                throw new Exception("Unexpected Error in IsDirty Property: { 0 } " + objE.Message);
            }
        }
        public void PrintAll()
        {
            try
            {

                foreach (KeyValuePair<string, Car> objKeyValuePointer in m_colCarList)
                {

                    objKeyValuePointer.Value.Print();

                }
                

            }
            catch (Exception objE)
            {
                //Step C-Re-Throw an general exceptions
                throw new Exception("Unexpected Error in IsDirty Property: { 0 } " + objE.Message);
            }
        }
        public void Clear()
        {
            m_colCarList.Clear();
        }
        public override bool DeferredDelete(string key)
        {
            try
            {

                if (m_colCarList.ContainsKey(key))
                {
                    m_colCarList[key].DeferredDelete();
                    return true;

                }
                else
                {
                    return false;
                }

            }
            catch (Exception objE)
            {
                //Step C-Re-Throw an general exceptions
                throw new Exception("Unexpected Error in IsDirty Property: { 0 } " + objE.Message);
            }
        }
        public override void Load()
        {
            DALayer_Load();
        }

        public override void Save()
        {
            DALayer_Save();
        }
        public override bool Delete(string key)
        {
            if(m_colCarList.ContainsKey(key))
            {
                DALayer_Delete(key);
                return true;
            }
            else
            {
                return false;
            }
        }
        protected override void DALayer_Load()
        {
            Console.WriteLine("DALayer_Load has been called");
        }

        protected override void DALayer_Save()
        {
            Console.WriteLine("DALayer_Save has been called");
        }

        protected override bool DALayer_Delete(string key)
        {
            Console.WriteLine("DALayer_Save has been called");
            return true;
        }
    }
}





    

    

