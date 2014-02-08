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
        string GetLectorNameById(string sessionKey, Int32 Id);

        [OperationContract]
        void SetLectorNameById(string sessionKey, Int32 Id, string Name);

        [OperationContract]
        string GetLectorBirthdayById(string sessionKey, Int32 Id);

        [OperationContract]
        void SetLectorBirthdayById(string sessionKey, Int32 Id, string Birthday);

        [OperationContract]
        IList<Int32> GetAllLectorIds(string sessionKey);

        [OperationContract]
        IList<Int32> GetAllLectorIdsFromSeminar(string sessionKey, Int32 seminarId);

        [OperationContract]
        IList<Int32> GetAllSeminarIdsFromLector(string sessionKey, Int32 lectorId);

        [OperationContract]
        string GetSeminarNameById(string sessionKey, Int32 Id);

        [OperationContract]
        void SetSeminarNameById(string sessionKey, Int32 Id, string Name);

        [OperationContract]
        IList<Int32> GetAllSeminarIds(string sessionKey);

        [OperationContract]
        Int32 CreateSeminar(string sessionKey, string name);

        [OperationContract]
        Int32 CreateLector(string sessionKey, string name);

        [OperationContract]
        void SetLectorPhotoData(string sessionKey, Int32 id, string data);

        [OperationContract]
        string GetLectorPhotoData(string sessionKey, Int32 id);

        [OperationContract]
        string GetLectorPhotoName(string sessionKey, Int32 id);

        [OperationContract]
        void AddSeminarToLector(string sessionKey, Int32 lectorId, Int32 seminarId);

        [OperationContract]
        void AddLectorToSeminar(string sessionKey, Int32 lectorId, Int32 seminarId);

        [OperationContract]
        void RemoveSeminarFromLector(string sessionKey, Int32 lectorId, Int32 seminarId);

        [OperationContract]
        void RemoveLectorFromSeminar(string sessionKey, Int32 lectorId, Int32 seminarId);

        [OperationContract]
        void DeleteSeminar(string sessionKey, Int32 Id);

        [OperationContract]
        void DeleteLector(string sessionKey, Int32 Id);

        [OperationContract]
        void CloseSession(string sessionKey);

        [OperationContract]
        string DoWork(string name);

        [OperationContract]
        string GenerateSession();        
    }
}
