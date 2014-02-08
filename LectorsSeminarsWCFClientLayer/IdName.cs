using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectorsSeminarsWCFClientLayer
{
    public abstract class IdName
    {
        protected string _Name = null;

        public abstract void RereadName();

        public abstract void SaveName();

        public override string ToString()
        {
            return Name;
        }

        public Int32 Id { get; set; }

        public string Name
        {
            get
            {
                if (_Name == null)
                    RereadName();
                return _Name;
            }
            set
            {
                _Name = value;
                SaveName();
            }
        }
    }
}
