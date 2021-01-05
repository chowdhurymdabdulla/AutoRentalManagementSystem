using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMSBOLayer
{
    public class MinivanList:BusinessFoundationCollectionBase
    {
        private Dictionary<string, Minivan> m_colMinivanList;

        public MinivanList()
        {
            m_colMinivanList = new Dictionary<string, Minivan>();
        }

        ~MinivanList()
        {
            m_colMinivanList = null;
        }

        public override bool IsDirty
        {

            get
            {

                try
                {

                    foreach (KeyValuePair<string, Minivan> objKeyValuePointer in m_colMinivanList)
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
                return m_colMinivanList.Count();
            }

        }

        public Dictionary<string, Minivan>.KeyCollection Keys
        {

            get
            {
                return m_colMinivanList.Keys;
            }
        }

        public Dictionary<string, Minivan>.ValueCollection Values
        {
            get
            {
                return m_colMinivanList.Values;
            }

        }
        public Minivan Search(string key)
        {
            try
            {

                if (m_colMinivanList.ContainsKey(key))
                {
                    return m_colMinivanList[key];
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
        public bool Add(string key, Minivan objMinivan)
        {

            try
            {

                if (!m_colMinivanList.ContainsKey(key))
                {
                    m_colMinivanList.Add(key, objMinivan);
                   
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

        public bool Edit(string key, Minivan objUpdatedMinivan)
        {

            try
            {
                Minivan objExistingMinivan = m_colMinivanList[key];

                if (m_colMinivanList != null)
                {
                    objExistingMinivan.Make = objUpdatedMinivan.Make;
                    objExistingMinivan.Model = objUpdatedMinivan.Model;
                    objExistingMinivan.Year = objUpdatedMinivan.Year;
                    objExistingMinivan.Color = objUpdatedMinivan.Color;
                    objExistingMinivan.PlateNumber = objUpdatedMinivan.PlateNumber;
                    objExistingMinivan.Mileage = objUpdatedMinivan.Mileage;
                    objExistingMinivan.TransmissionType = objUpdatedMinivan.TransmissionType;
                    objExistingMinivan.SeatCapacity = objUpdatedMinivan.SeatCapacity;
                    objExistingMinivan.DailyRentalRate = objUpdatedMinivan.DailyRentalRate;
                    objExistingMinivan.VehicleAssignedAgency = objUpdatedMinivan.VehicleAssignedAgency;
                    objExistingMinivan.VehicleCurrentAgencyLocation = objUpdatedMinivan.VehicleCurrentAgencyLocation;
                    objExistingMinivan.DisabilityOption = objUpdatedMinivan.DisabilityOption;
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

                if (m_colMinivanList.ContainsKey(key))
                {
                    return m_colMinivanList.Remove(key);
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

                if (m_colMinivanList.ContainsKey(key))
                {
                    return m_colMinivanList.ContainsKey(key);

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

                if (m_colMinivanList.ContainsKey(key))
                {
                    m_colMinivanList[key].Print();
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

                foreach (KeyValuePair<string, Minivan> objKeyValuePointer in m_colMinivanList)
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
            m_colMinivanList.Clear();
        }

        public override bool DeferredDelete(string key)
        {
            try
            {

                if (m_colMinivanList.ContainsKey(key))
                {
                    m_colMinivanList[key].DeferredDelete();
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
            if (m_colMinivanList.ContainsKey(key))
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

