using LectorsSeminarsWCFClientLayer.LectorsSeminarsDataAccessLayerWCFService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace LectorsSeminarsWCFClientLayer
{
    public class SessionWraperFromWCF
    {
        private string key;
        LectorsSeminarsDataAccessLayerServiceClient client;

        public SessionWraperFromWCF(LectorsSeminarsDataAccessLayerServiceClient client)
        {
            this.client = client;
            this.key = client.GenerateSession();
        }

        public string GetLectorName(Lector lector)
        {
            return client.GetLectorNameById(key, lector.Id);
        }

        public void SetLectorName(Lector lector, string Name)
        {
            client.SetLectorNameById(key, lector.Id, Name);
        }

        public string GetLectorBirthday(Lector lector)
        {
            return client.GetLectorBirthdayById(key, lector.Id);
        }

        public void SetLectorBirthday(Lector lector, string Birthday)
        {
            client.SetLectorBirthdayById(key, lector.Id, Birthday);
        }

        public string GetSeminarName(Seminar seminar)
        {
            return client.GetSeminarNameById(key, seminar.Id);
        }

        public void SetSeminarName(Seminar seminar, string Name)
        {
            client.SetSeminarNameById(key, seminar.Id, Name);
        }

        public Lector GetLectorById(int Id)
        {
            return new Lector(this) { Id = Id };
        }

        public Int32[] AllLectorIds
        {
            get { return client.GetAllLectorIds(key); }
        }

        public IList<Lector> AllLectors
        {
            get 
            {
                return GetLectorListFromIds(client.GetAllLectorIds(key));                    
            }
        }

        public IList<Seminar> AllSeminars
        {
            get
            {
                return GetSeminarListFromIds(client.GetAllSeminarIds(key));
            }
        }

        public IList<Lector> GetLectorsFromSeminar(Seminar seminar)
        {
            return GetLectorListFromIds(client.GetAllLectorIdsFromSeminar(key, seminar.Id));
        }

        private IList<Lector> GetLectorListFromIds(Int32[] Ids)
        {
            List<Lector> lectors = new List<Lector>();
            foreach (var id in Ids)
            {
                lectors.Add(new Lector(this) { Id = id });                
            }
            return lectors; 
        }

        private IList<Seminar> GetSeminarListFromIds(Int32[] Ids)
        {
            List<Seminar> seminars = new List<Seminar>();
            foreach (var id in Ids)
            {
                seminars.Add(new Seminar(this) { Id = id });
            }
            return seminars;
        }

        public Seminar GetSeminarById(int Id)
        {
            return new Seminar(this) { Id = Id };
        }

        public Int32[] AllSeminarIds
        {
            get { return client.GetAllSeminarIds(key); }
        }

        public void AddLectorToSeminar(Lector lector, Seminar seminar)
        {
            client.AddLectorToSeminar(key, lector.Id, seminar.Id);
        }

        public Seminar CreateSeminar(string name)
        {
            var id = client.CreateSeminar(key, name);
            return new Seminar(this) { Id = id };
        }

        public string GetLectorPhotoName(Lector lector)
        {
            return client.GetLectorPhotoName(key, lector.Id);
        }


        public void SetLectorPhotoData(Lector lector, string data)
        {
            client.SetLectorPhotoData(key, lector.Id, data);
        }

        public string GetLectorPhotoData(Lector lector)
        {
            return client.GetLectorPhotoData(key, lector.Id);
        }

        public void DeleteSeminar(Seminar seminar)
        {
            client.DeleteSeminar(key, seminar.Id) ;
        }

        public void DeleteLector(Lector lector)
        {
            client.DeleteLector(key, lector.Id);
        }

        public void RemoveLectorFromSeminar(Lector lector, Seminar seminar)
        {
            client.RemoveLectorFromSeminar(key, lector.Id, seminar.Id);
        }

        public Lector CreateLector(string name)
        {
            var id = client.CreateLector(key, name);
            return new Lector(this) { Id = id };
        }

        public void CloseSession()
        {
            client.CloseSession(key);
        }
    }
}
