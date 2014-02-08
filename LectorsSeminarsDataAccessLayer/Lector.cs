using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LectorsSeminarsDataAccessLayer
{
    [DataContract]
    public class Lector : IdNamable
    {       
        [DataMember]
        public virtual DateTime Birthday { get; set; }

        [DataMember]
        public virtual IList<Seminar> Seminars { get; set; }

        public virtual string Photo { get; set; }

        const string img = "img/";

        SHA1 sha1 = SHA1.Create();

        public virtual void SetPhotoData(string data)
        {
            if (!Directory.Exists(img))
                Directory.CreateDirectory(img);
            var binData = Convert.FromBase64String(data);
            string filename = 
                new SoapHexBinary(sha1.ComputeHash(binData)) + ".jpg";
            var fd = File.OpenWrite(img  + filename);
            fd.Write(binData, 0, binData.Length);
            fd.Close();
            Photo = filename;
        }

        public virtual string GetPhotoData()
        {
            if (Photo == null)
                return null;
            var ms = new MemoryStream();
            var fd = File.OpenRead(img+Photo);
            fd.CopyTo(ms);
            fd.Close();
            var data = Convert.ToBase64String(ms.ToArray());
            ms.Close();
            return data;
        }

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
