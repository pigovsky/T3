using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LectorsSeminarsDataAccessLayer
{
    [DataContract]
    public class Seminar : IdNamable
    {       
        [DataMember]
        public virtual IList<Lector> Lectors { get; set; }

        public Seminar()
        {
            Lectors = new List<Lector>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
