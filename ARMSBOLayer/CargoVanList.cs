using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMSBOLayer
{
   public class CargoVanList:BusinessFoundationCollectionBase
    {
        private Dictionary<string, CargoVan> m_colCargoVanList;

        public CargoVanList()
        {
            m_colCargoVanList = new Dictionary<string, CargoVan>();
        }

        ~CargoVanList()
        {
            m_colCargoVanList = null;
        }

        public override bool IsDirty
        {

            get
            {

                try
                {

                    foreach (KeyValuePair<string, CargoVan> objKeyValuePointer in m_colCargoVanList)
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
                return m_colCargoVanList.Count();
            }
        }

        public Dictionary<string, CargoVan>.KeyCollection Keys
        {

            get
            {
                return m_colCargoVanList.Keys;
            }
        }

        public Dictionary<string, CargoVan>.ValueCollection Values
        {
            get
            {
                return m_colCargoVanList.Values;
            }

        }

        public CargoVan Search(string key)
        {
            try
            {

                if (m_colCargoVanList.ContainsKey(key))
                {
                    return m_colCargoVanList[key];
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

        public bool Add(string key, CargoVan objCargoVan)
        {

            try
            {

                if (!m_colCargoVanList.ContainsKey(key))
                {
                    m_colCargoVanList.Add(key, objCargoVan);
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

        public bool Edit(string key, CargoVan objUpdatedCargoVan)
        {

            try
            {
                CargoVan objExistingCargoVan = m_colCargoVanList[key];

                if (m_colCargoVanList != null)
                {
                    objExistingCargoVan.Make = objUpdatedCargoVan.Make;
                    objExistingCargoVan.Model = objUpdatedCargoVan.Model;
                    objExistingCargoVan.Year = objUpdatedCargoVan.Year;
                    objExistingCargoVan.Color = objUpdatedCargoVan.Color;
                    objExistingCargoVan.PlateNumber = objUpdatedCargoVan.PlateNumber;
                    objExistingCargoVan.Mileage = objUpdatedCargoVan.Mileage;
                    objExistingCargoVan.TransmissionType = objUpdatedCargoVan.TransmissionType;
                    objExistingCargoVan.SeatCapacity = objUpdatedCargoVan.SeatCapacity;
                    objExistingCargoVan.DailyRentalRate = objUpdatedCargoVan.DailyRentalRate;
                    objExistingCargoVan.VehicleAssignedAgency = objUpdatedCargoVan.VehicleAssignedAgency;
                    objExistingCargoVan.VehicleCurrentAgencyLocation = objUpdatedCargoVan.VehicleCurrentAgencyLocation;
                    objExistingCargoVan.CargoCapacity = objUpdatedCargoVan.CargoCapacity;
                    objExistingCargoVan.MaximumPayload = objUpdatedCargoVan.MaximumPayload;
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

                if (m_colCargoVanList.ContainsKey(key))
                {
                    return m_colCargoVanList.Remove(key);
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

        public bool ContainsKey(string key)
        {

            try
            {

                if (m_colCargoVanList.ContainsKey(key))
                {
                    return m_colCargoVanList.ContainsKey(key);

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

                if (m_colCargoVanList.ContainsKey(key))
                {
                    m_colCargoVanList[key].Print();
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

                foreach (KeyValuePair<string, CargoVan> objKeyValuePointer in m_colCargoVanList)
                {

                    objKeyValuePointer.Value.Print();

                }
            }//End of try

            catch (Exception objE)
            {
                //Step C-Re-Throw an general exceptions
                throw new Exception("Unexpected Error in IsDirty Property: { 0 } " + objE.Message);
            }
        }

        public void Clear()
        {
            m_colCargoVanList.Clear();
        }

        public override bool DeferredDelete(string key)
        {
            try
            {

                if (m_colCargoVanList.ContainsKey(key))
                {
                    m_colCargoVanList[key].DeferredDelete();
                    return true;

                }
                else
                {
                    return false;
                }

            }//End of try

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
            if (m_colCargoVanList.ContainsKey(key))
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
            Console.WriteLine("Delet method has been called");
            return true;
        }
    }
}
