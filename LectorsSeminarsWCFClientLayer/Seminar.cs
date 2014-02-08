using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectorsSeminarsWCFClientLayer
{
    public class Seminar : IdName
    {
        private SessionWraperFromWCF sessionWraperFromWCF;

        private IList<Lector> _Lectors;

        public IList<Lector> Lectors 
        {

            get
            {
                if (_Lectors == null)
                {
                    _Lectors = sessionWraperFromWCF.
                        GetLectorsFromSeminar(this);
                }
                return _Lectors;
            }

            set
            {
                _Lectors = value;
            }
        
        }

        public void RemoveLector(Lector lector)
        {
            sessionWraperFromWCF.RemoveLectorFromSeminar(lector, this);
            Lectors.Remove(lector);
        }

        public void AddLector(Lector lector)
        {
            sessionWraperFromWCF.AddLectorToSeminar(lector, this);
            Lectors.Add(lector);
        }

        public Seminar(SessionWraperFromWCF sessionWraperFromWCF)
        {
            // TODO: Complete member initialization
            this.sessionWraperFromWCF = sessionWraperFromWCF;
        }

        override public void RereadName()
        {
            if (sessionWraperFromWCF != null)                
                _Name = sessionWraperFromWCF.GetSeminarName(this);
        }

        public override void SaveName()
        {
            sessionWraperFromWCF.SetSeminarName(this,_Name);
        }
    }
}
