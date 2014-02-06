using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace T3
{
    public class Lector : IdName
    {
        private SessionWraperFromWCF sessionWraperFromWCF;

        public Lector(SessionWraperFromWCF sessionWraperFromWCF)
        {
            // TODO: Complete member initialization
            this.sessionWraperFromWCF = sessionWraperFromWCF;
        }


        

        public string LectorPhotoName 
        { 
            get
            {
                return sessionWraperFromWCF.GetLectorPhotoName(this);
            }            
        }

        public const string img = "img/";

        SHA1 sha1 = SHA1.Create();

        

        public string LectorPhotoData
        {
            set
            {
                if (value == null)
                    return;
                var binData = Convert.FromBase64String(value);
                string filename =
                    new SoapHexBinary(sha1.ComputeHash(binData)) + ".jpg";
                if (filename.Equals(LectorPhotoName))
                    return;
                sessionWraperFromWCF.SetLectorPhotoData(this, value);                
            }
            get
            {                
                string filename = img + LectorPhotoName;
                string lectorPhotoData = null;
                if (!Directory.Exists(img))
                    Directory.CreateDirectory(img);

                if (File.Exists(filename))
                {
                    var fd = File.OpenRead(filename);
                    MemoryStream ms = new MemoryStream();
                    fd.CopyTo(ms);
                    fd.Close();
                    lectorPhotoData = Convert.ToBase64String(ms.ToArray());                    
                    ms.Close();
                }
                else
                {
                    lectorPhotoData = sessionWraperFromWCF.GetLectorPhotoData(this);
                    if (lectorPhotoData == null)
                        return null;
                    byte[] binData = Convert.FromBase64String(lectorPhotoData);
                                                        
                    var fd = File.OpenWrite(filename);
                    fd.Write(binData, 0, binData.Length);
                    fd.Close();
                }
                return lectorPhotoData;
            }
        }        

        public override string ToString()
        {
            return sessionWraperFromWCF.GetLectorNameById(Id) ;
        }
    }
}
