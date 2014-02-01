using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LectorsSeminarsDataAccessLayer
{
    [DataContract]
    public class IdNamable
    {
        [DataMember]
        public virtual Int32 Id { get; set; }

        [DataMember]
        public virtual string Name { get; set; }
    }
}
