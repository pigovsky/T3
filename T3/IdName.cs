using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3
{
    public class IdName
    {
        public Int32 Id { get; set; }
        public string Name
        {
            get
            {
                return ToString();
            }
        }
    }
}
