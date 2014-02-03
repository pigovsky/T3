using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3
{
    class Lector : IdName
    {
        private SessionWraperFromWCF sessionWraperFromWCF;

        public Lector(SessionWraperFromWCF sessionWraperFromWCF)
        {
            // TODO: Complete member initialization
            this.sessionWraperFromWCF = sessionWraperFromWCF;
        }
        

        public override string ToString()
        {
            return sessionWraperFromWCF.GetLectorNameById(Id) ;
        }
    }
}
