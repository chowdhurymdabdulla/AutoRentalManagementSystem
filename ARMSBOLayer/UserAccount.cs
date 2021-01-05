using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMSBOLayer
{
    public class UserAccount:BusinessFoundationBase
    {
        //Private Data Declaration
        private Guid m_objUserAccountID;
        private string m_Username;
        private string m_Password;
        private string m_Email;


        //Public Properties
        public string UserAccountID
        {
            get
            {
                return m_objUserAccountID.ToString();
            }
        }

        public string UserName
        {
            get { return m_Username; }
            set { m_Username = value;
                base.MarkDirty();
            }
        }
        public string Password
        {
            get { return m_Password; }
            set { m_Password = value;
                base.MarkDirty();
            }
        }
        public string Email
        {
            get { return m_Email; }
            set { m_Email = value;
                base.MarkDirty();
            }
        }

        private UserAccount()
        {
            m_objUserAccountID = Guid.NewGuid();
            m_Username = "";
            m_Password = "";
            m_Email = "";

        }

        private UserAccount(string strUserName, string strPassword, string strEmail)
        {
            m_objUserAccountID = Guid.NewGuid();
            this.UserName = strUserName;
            this.Password = strPassword;
            this.Email = strEmail;
        }

        //Public STATIC Properties Declarations
        ~UserAccount()
        {

            Console.WriteLine("Destructure Created");
        }

        public static UserAccount GetInstance()
        {
            UserAccount objUserAccount1 = new UserAccount();

            return objUserAccount1;
        }

        public static UserAccount GetInstance(string strUserName, string strPassword, string strEmail)
        {
            UserAccount objUserAccount2 = new UserAccount(strUserName, strPassword, strEmail);

            return objUserAccount2;
        }

        public bool Authenticate(string strUserName, string strPassword)
        {
            if (m_Username == strUserName && m_Password == strPassword)
                return true;
            else
                return false;
        }//note: page number 86 compleated 
    }
}
