using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LectorsSeminarsDataAccessLayer
{
    [DataContract]
    public class Lector : IdNamable
    {       
        [DataMember]
        public virtual string Birthday { get; set; }

        [DataMember]
        public virtual IList<Seminar> Seminars { get; set; }

        public Lector()
        {
            Seminars = new List<Seminar>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
