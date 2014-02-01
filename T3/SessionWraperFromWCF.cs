using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T3.LectorsSeminarsDataAccessLayerWCFService;

namespace T3
{
    class SessionWraperFromWCF : ISessionWraper
    {
        private string key;
        LectorsSeminarsDataAccessLayerServiceClient client;

        public SessionWraperFromWCF(LectorsSeminarsDataAccessLayerServiceClient client)
        {
            this.client = client;
            this.key = client.GenerateSession();
        }

        public Lector GetLectorById(int Id)
        {
            return client.GetLectorById(key,Id);
        }

        public List<Lector> AllLectors
        {
            get { return client.GetAllLectors(key); }
        }

        public Seminar GetSeminarById(int Id)
        {
            return client.GetSeminarById(key,Id);
        }

        public IList<Seminar> AllSeminars
        {
            get { return client.GetAllSeminars(key); }
        }

        public object ObjectToSave
        {
            set { client.SaveObject(key,value); }
        }

        public object ObjectToDelete
        {
            set { client.DeleteObject(key,value); }
        }

        public void CloseSession()
        {
            client.CloseSession(key);
        }
    }
}
