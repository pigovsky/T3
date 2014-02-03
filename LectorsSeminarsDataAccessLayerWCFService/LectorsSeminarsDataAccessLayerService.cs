using LectorsSeminarsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;

namespace LectorsSeminarsDataAccessLayerWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LectorsSeminarsDataAccessLayerService" in both code and config file together.
    public class LectorsSeminarsDataAccessLayerService : 
        ILectorsSeminarsDataAccessLayerService
    {
        static string name;
        public string DoWork(string name)
        {
            LectorsSeminarsDataAccessLayerService.name 
                = name;
            return "Hello, " + name + "!";
        }

        private SessionWraperFactory sessionWraperFactory = 
            new SessionWraperFactory(false);

        static volatile private Dictionary<string, ISessionWraper> sessions = 
            new Dictionary<string, ISessionWraper>();
        
        public string GetLectorNameById(string sessionKey, int Id)
        {
            var lector = sessions[sessionKey].GetLectorById(Id);
            if (lector == null)
                return null;
            return lector.Name;
        }

        public IList<Int32> GetAllLectorIds(string sessionKey)
        {
            List<Int32> res = new List<int>();
            foreach (var lector in sessions[sessionKey].AllLectors)
                res.Add(lector.Id);
            return res;
        }

        public string GetSeminarNameById(string sessionKey, int Id)
        {
            return sessions[sessionKey].GetSeminarById(Id).Name;
        }

        public IList<Int32> GetAllSeminarIds(string sessionKey)
        {
            return GetIds(sessions[sessionKey].AllSeminars);
        }

        private IList<Int32> GetIds(IList<Seminar> idNamables) 
        {
            var res = new List<Int32>();
            foreach (var item in idNamables)
            {
                res.Add(item.Id);
            }
            return res;
        }

        private IList<Int32> GetIds(IList<Lector> idNamables)
        {
            var res = new List<Int32>();
            foreach (var item in idNamables)
            {                
                res.Add(item.Id);                
            }
            
            
            return res;
        }

        public Int32 CreateSeminar(string sessionKey, string name)
        {
            var seminar = new Seminar() { Name = name };
            sessions[sessionKey].ObjectToSave = seminar;
            return seminar.Id;
        }

        public Int32 CreateLector(string sessionKey, string name)
        {
            var lector = new Lector() { Name = name };
            sessions[sessionKey].ObjectToSave = lector;
            return lector.Id;
        }

        public void DeleteSeminar(string sessionKey, Int32 id)
        {
            var session = sessions[sessionKey];
            session.ObjectToDelete = session.GetSeminarById(id);
        }

        public void DeleteLector(string sessionKey, Int32 id)
        {
            var session = sessions[sessionKey];
            session.ObjectToDelete = session.GetLectorById(id);
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
        
        public void AddSeminarToLector(string sessionKey, int lectorId, int seminarId)
        {
            var session = sessions[sessionKey];
            var seminar = session.GetSeminarById(seminarId);
            var lector = session.GetLectorById(lectorId);
            lector.Seminars.Add(seminar);
            session.ObjectToSave = lector;
        }

        public void AddLectorToSeminar(string sessionKey, int lectorId, int seminarId)
        {
            var session = sessions[sessionKey];
            var seminar = session.GetSeminarById(seminarId);
            var lector = session.GetLectorById(lectorId);
            seminar.Lectors.Add(lector);
            session.ObjectToSave = seminar;
        }

        public void RemoveSeminarFromLector(string sessionKey, int lectorId, int seminarId)
        {
            var session = sessions[sessionKey];
            var seminar = session.GetSeminarById(seminarId);
            var lector = session.GetLectorById(lectorId);
            lector.Seminars.Remove(seminar);
            session.ObjectToSave= lector;
        }

        public void RemoveLectorFromSeminar(string sessionKey, int lectorId, int seminarId)
        {
            var session = sessions[sessionKey];
            var seminar = session.GetSeminarById(seminarId);
            var lector = session.GetLectorById(lectorId);
            seminar.Lectors.Remove(lector);
            session.ObjectToSave = seminar;
        }


        public IList<Int32> GetAllLectorIdsFromSeminar(string sessionKey, int seminarId)
        {            
            var session = sessions[sessionKey];
            var seminar = session.GetSeminarById(seminarId);
            try
            {
                return GetIds(seminar.Lectors);
            }
            catch (Exception e)
            {
                MessageBox.Show("No lectors for seminar " + seminar.Name);                
            }
            return new List<Int32>();
        }

        public IList<int> GetAllSeminarIdsFromLector(string sessionKey, int lectorId)
        {
            var session = sessions[sessionKey];
            var lector = session.GetLectorById(lectorId);
            return GetIds(lector.Seminars);
        }
    }
}
