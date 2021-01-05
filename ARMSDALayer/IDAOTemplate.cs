using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMSDALayer
{
    public interface IDAOTemplate<T>
    {
        T GetRecordByID(string key);
        bool Insert(T objDTO);
        bool Update(T objDTO);
        bool Delete(string key);
        List<T> GetAllRecords();
        List<string> GetAllKeys();

    }
}
