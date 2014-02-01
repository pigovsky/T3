using LectorsSeminarsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LectorsSeminarsDataAccessLayerWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LectorsSeminarsDataAccessLayerService" in both code and config file together.
    public class LectorsSeminarsDataAccessLayerService : 
        ILectorsSeminarsDataAccessLayerService
    {
        public string DoWork(string name)
        {
            return "Hello, " + name + "!";
        }

        private SessionWraperFactory sessionWraperFactory = 
            new SessionWraperFactory(false);

        volatile private Dictionary<string, ISessionWraper> sessions = 
            new Dictionary<string, ISessionWraper>();
        
        public Lector GetLectorById(string sessionKey, int Id)
        {
            return sessions[sessionKey].GetLectorById(Id);
        }

        public IList<Lector> GetAllLectors(string sessionKey)
        {
            return sessions[sessionKey].AllLectors;
        }

        public Seminar GetSeminarById(string sessionKey, int Id)
        {
            return sessions[sessionKey].GetSeminarById(Id);
        }

        public IList<Seminar> GetAllSeminars(string sessionKey)
        {
            return sessions[sessionKey].AllSeminars;
        }

        public void SaveObject(string sessionKey, object obj)
        {
            sessions[sessionKey].ObjectToSave = obj;
        }

        public void DeleteObject(string sessionKey, object obj)
        {
            sessions[sessionKey].ObjectToDelete = obj;
        }

        

        public string GenerateSession()
        {
            var sessionWraper = sessionWraperFactory.OpenSessionAdapter();
            string sessionKey = sessionWraper.GetHashCode().ToString();
            sessions.Add(sessionKey, sessionWraper);
            return sessionKey;
        }


        public void CloseSession(string sessionKey)
        {
            if (!sessions.ContainsKey(sessionKey))
                return;
            sessions[sessionKey].CloseSession();
            sessions.Remove(sessionKey);
        }
    }
}
