using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectorsSeminarsDataAccessLayer
{
    public class SessionWraper : ISessionWraper
    {
        private ISession session;

        public SessionWraper(ISession session)
        {
            this.session = session;
        }        

        public Lector GetLectorById(Int32 id)
        {            
            return session.Get<Lector>(id);
        }

        public Seminar GetSeminarById(Int32 id)
        {
            return session.Get<Seminar>(id);
        }

        public IList<Lector> AllLectors
        {
            get
            {
                return session.QueryOver<Lector>().List();
            }
        }

        public IList<Seminar> AllSeminars
        {
            get
            {
                return session.QueryOver<Seminar>().List();
            }
        }

        public object ObjectToSave
        {            
            set 
            {
                session.Save(value);
                session.Flush();
            }
        }
        
        public object ObjectToDelete
        {            
            set 
            {
                session.Delete(value);
                session.Flush();
            }
        }


        public void CloseSession()
        {
            session.Close();
        }
    }
}
