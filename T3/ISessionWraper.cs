using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T3.LectorsSeminarsDataAccessLayerWCFService;

namespace T3
{
    public interface ISessionWraper
    {
        Lector GetLectorById(Int32 Id);

        List<Lector> AllLectors { get; }


        Seminar GetSeminarById(Int32 Id);


        IList<Seminar> AllSeminars { get; }


        object ObjectToSave { set; }


        object ObjectToDelete { set; }


        void CloseSession();


    }
}
