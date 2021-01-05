using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ARMSDALayer
{
    public class SQLServerFactory : DALObjectFactoryBase
    {
        public static string ConnectionString()
        {
            return "Data Source =.\\SQLExpress;Initial Catalog =DatabaseName; Integrated Security = True";
        }

        public override CreditCardDAO GetCreditCardDAO()
        {
            CreditCardDAO objCreditCardDAO = new CreditCardDAO();
            return objCreditCardDAO;
        }
        public override UserAccountDAO GetUserAccountDAO()
        {
            UserAccountDAO objUserAccountDAO = new UserAccountDAO();
             return objUserAccountDAO;
        }

        public override RetailCustomerDAO GetRetailCustomerDAO()
        {
            RetailCustomerDAO objRetailCustomerDAO = new RetailCustomerDAO();
            return objRetailCustomerDAO;
        }

        public override CorporateCustomerDAO GetCorporateCustomerDAO()
        {
            CorporateCustomerDAO objCorporateCustomerDAO = new CorporateCustomerDAO();
            return objCorporateCustomerDAO;
        }

        public override CarDAO GetCarDAO()
        {
            CarDAO objCarDAO = new CarDAO();
            return objCarDAO;
        }

        public override SUVDAO GetSUVDAO()
        {
            SUVDAO objSUVDAO = new SUVDAO();
            return objSUVDAO;
        }

        public override MinivanDAO GetMinivanDAO()
        {
            MinivanDAO objMinivanDAO = new MinivanDAO();
            return objMinivanDAO;
        }

        public override CargoVanDAO GetCargoVanDAO()
        {
            CargoVanDAO objCargoVanDAO = new CargoVanDAO();
            return objCargoVanDAO;
        }


    }
}
