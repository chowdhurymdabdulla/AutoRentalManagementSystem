using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMSBOLayer
{
    public abstract class BusinessFoundationCollectionBase
    {
        public abstract bool IsDirty
        {
            get;
           
        }
        public abstract bool DeferredDelete(string key);
        public abstract void Load();
        public abstract void Save();
        public abstract bool Delete(string key);
        protected abstract void DALayer_Load();
        protected abstract void DALayer_Save();
        protected abstract bool DALayer_Delete(string key);

    }
}
