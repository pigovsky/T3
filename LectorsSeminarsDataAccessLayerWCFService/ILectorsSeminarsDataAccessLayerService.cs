using LectorsSeminarsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LectorsSeminarsDataAccessLayerWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILectorsSeminarsDataAccessLayerService" in both code and config file together.
    [ServiceContract]
    public interface ILectorsSeminarsDataAccessLayerService
    {
        [OperationContract]
        Lector GetLectorById(string sessionKey, Int32 Id);

        [OperationContract]
        IList<Lector> GetAllLectors(string sessionKey);

        [OperationContract]
        Seminar GetSeminarById(string sessionKey, Int32 Id);

        [OperationContract]
        IList<Seminar> GetAllSeminars(string sessionKey);

        [OperationContract]
        void SaveObject(string sessionKey, object obj);

        [OperationContract]
        void DeleteObject(string sessionKey, object obj);

        [OperationContract]
        void CloseSession(string sessionKey);

        [OperationContract]
        string DoWork(string name);

        [OperationContract]
        string GenerateSession();        
    }
}
