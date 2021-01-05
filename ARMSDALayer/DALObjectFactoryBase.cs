using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMSDALayer
{
   public abstract class DALObjectFactoryBase
    {
        public const int SQLSERVER = 1;
        public const int ORACLE = 2;
        public const int MYSQL = 3;

        public static DALObjectFactoryBase GetDataSourceDAOFactory(int
                                                     targetDatasource)
        {
            switch (targetDatasource)
            {
                case 1: 

                   
                    return new SQLServerFactory();
                case 2: 

                    
                    throw new NotImplementedException();
                case 3: 
                    throw new NotImplementedException();
                
                default: 
                    return null;
            }

        }
        public abstract CreditCardDAO GetCreditCardDAO();
        public abstract UserAccountDAO GetUserAccountDAO();
        public abstract RetailCustomerDAO GetRetailCustomerDAO();
        public abstract CorporateCustomerDAO GetCorporateCustomerDAO();
        public abstract CarDAO GetCarDAO();
        public abstract SUVDAO GetSUVDAO();
        public abstract MinivanDAO GetMinivanDAO();
        public abstract CargoVanDAO GetCargoVanDAO();


    }
}
