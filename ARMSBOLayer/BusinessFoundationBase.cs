using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ARMSBOLayer
{
    public abstract class BusinessFoundationBase
    {
        //Private instance Data
        private bool m_flagIsDirty = true;
        private bool m_flagIsNew = true;
        private bool m_flagIsDeleted = false;

        //Public Instance Properties 
        public virtual bool IsDirty
        {
           
            get { return m_flagIsDirty; }
        }
        public bool IsNew
        {
            get { return m_flagIsNew; }
        }

        public virtual bool IsDeleted
        {
            get { return m_flagIsDeleted; }
        }

        //is a test
        //abasdsa
        //Protected Instance Method
        protected void MarkDirty()
        {
            m_flagIsDirty = true;
        
        }

        private void MarkClean()
        {
            m_flagIsDirty = false;
        }
        protected void MarkNew()
        {
            m_flagIsDirty = true;
            m_flagIsDeleted = false;
            MarkDirty();
        }
         
        protected void MarkOld()
        {
            m_flagIsNew = false;
            MarkDirty();
        }
        protected void MarkDeleted()
        {
            m_flagIsDeleted = true;
            MarkDirty();
        }

        //Public Instance Method 
        public void DeferredDelete()
        {
            MarkDeleted();
        }


    }
}
