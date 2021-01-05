using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMSBOLayer
{
    public class SUVList:BusinessFoundationCollectionBase
    {
        private Dictionary<string, SUV> m_colSUVList;

    public SUVList()
    {
        m_colSUVList = new Dictionary<string, SUV>();
    }
    ~SUVList()
        {
            m_colSUVList = null;
        }
    public override bool IsDirty
    {
        get
        {
            //Step A- Begin Error trapping
            try
            {

                foreach (KeyValuePair<string, SUV>
                        objKeyValuePointer in m_colSUVList)
                {
                    //STEP 2- SEARCH for the first or any
                    //Dirty Object in the collection
                    if (objKeyValuePointer.Value.IsDirty)
                    {
                        //found, thus return and exit
                        return true;
                    }
                }//End of foreach
                 //STEP 3- SEARCH completed. If you made it to
                 //this point, no Dirty objects found
                return false;
            }//End of try
             //Step B-Traps for general exception.
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
                return m_colSUVList.Count();
            }

        }
        public Dictionary<string, SUV>.KeyCollection Keys
        {
            get { return m_colSUVList.Keys; }

        }
        public Dictionary<string, SUV>.ValueCollection Values
        {
            get { return m_colSUVList.Values; }
        }
        public SUV Search(string key)
        {
            try
            {
                if (m_colSUVList.ContainsKey(key))
                {
                    return m_colSUVList[key];
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
        public bool Add(string key, SUV objCar)
        {
            try
            {
                if (!m_colSUVList.ContainsKey(key))
                {
                    m_colSUVList.Add(key, objCar);
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

        public bool Edit(string key, SUV objUpdatedSUV)
        {
            try
            {
                SUV objExistingSUV = m_colSUVList[key];

                if (objExistingSUV != null)
                {
                    objExistingSUV.Make = objUpdatedSUV.Make;
                    objExistingSUV.Model = objUpdatedSUV.Model;
                    objExistingSUV.Year = objUpdatedSUV.Year;
                    objExistingSUV.Color = objUpdatedSUV.Color;
                    objExistingSUV.PlateNumber = objUpdatedSUV.PlateNumber;
                    objExistingSUV.Mileage = objUpdatedSUV.Mileage;
                    objExistingSUV.TransmissionType = objUpdatedSUV.TransmissionType;
                    objExistingSUV.SeatCapacity = objUpdatedSUV.SeatCapacity;
                    objExistingSUV.DailyRentalRate = objUpdatedSUV.DailyRentalRate;
                    objExistingSUV.VehicleStatus = objUpdatedSUV.VehicleStatus;
                    objExistingSUV.VehicleAssignedAgency = objUpdatedSUV.VehicleAssignedAgency;
                    objExistingSUV.VehicleCurrentAgencyLocation = objUpdatedSUV.VehicleCurrentAgencyLocation;
                    objExistingSUV.TowingCapacity = objUpdatedSUV.TowingCapacity;
                    objExistingSUV.IsAWD = objUpdatedSUV.IsAWD;
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

                if (m_colSUVList.ContainsKey(key))
                {
                    return m_colSUVList.Remove(key);

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

                if (m_colSUVList.ContainsKey(key))
                {
                    return m_colSUVList.ContainsKey(key);

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

                if (m_colSUVList.ContainsKey(key))
                {
                    m_colSUVList[key].Print();
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

                foreach (KeyValuePair<string, SUV> objKeyValuePointer in m_colSUVList)
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
            m_colSUVList.Clear();
        }
        public override bool DeferredDelete(string key)
        {
            try
            {

                if (m_colSUVList.ContainsKey(key))
                {
                    m_colSUVList[key].DeferredDelete();
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
            if (m_colSUVList.ContainsKey(key))
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
