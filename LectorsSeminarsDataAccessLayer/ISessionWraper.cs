using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace LectorsSeminarsDataAccessLayer
{
    
    public interface ISessionWraper
    {
        Lector GetLectorById(Int32 Id);
        
        IList<Lector> AllLectors { get; }


        Seminar GetSeminarById(Int32 Id);

        
        IList<Seminar> AllSeminars { get; }

        
        object ObjectToSave { set; }

        
        object ObjectToDelete { set; }


        void CloseSession();


    }
}
