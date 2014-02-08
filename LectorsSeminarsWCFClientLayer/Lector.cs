using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LectorsSeminarsWCFClientLayer
{
    public class Lector : IdName
    {
        private SessionWraperFromWCF sessionWraperFromWCF;

        public Lector(SessionWraperFromWCF sessionWraperFromWCF)
        {
            // TODO: Complete member initialization
            this.sessionWraperFromWCF = sessionWraperFromWCF;
        }


        public string Birthday
        {
            get
            {
                return sessionWraperFromWCF.GetLectorBirthday(this);
            }
            set
            {
                sessionWraperFromWCF.SetLectorBirthday(this, value);
            }
        }

        public string LectorPhotoName 
        { 
            get
            {
                string photoName = sessionWraperFromWCF.GetLectorPhotoName(this);
                if (photoName == null)
                    return null;
                
                string filename = img + photoName;
                if (!File.Exists(filename))
                {                                        
                    byte[] binData = Convert.FromBase64String(
                        sessionWraperFromWCF.GetLectorPhotoData(this));

                    SaveBinDataToFile(filename, binData);
                }
                return photoName;
            }            
        }

        private static void SaveBinDataToFile(string filename, byte[] binData)
        {
            if (File.Exists(filename))
                return;
            if (!Directory.Exists(img))
                Directory.CreateDirectory(img);
            var fd = File.OpenWrite(filename);
            fd.Write(binData, 0, binData.Length);
            fd.Close();
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
                
                SaveBinDataToFile(img + filename, binData);

                if (filename.Equals(LectorPhotoName))
                    return;
                sessionWraperFromWCF.SetLectorPhotoData(this, value);                
            }
            get
            {                
                string filename = img + LectorPhotoName;                
                                
                var fd = File.OpenRead(filename);
                MemoryStream ms = new MemoryStream();
                fd.CopyTo(ms);
                fd.Close();
                string lectorPhotoData = Convert.ToBase64String(ms.ToArray());                    
                ms.Close();
                                                
                return lectorPhotoData;
            }
        }        
       
        override public void RereadName()
        {
            _Name = sessionWraperFromWCF.GetLectorName(this);
        }

        public override void SaveName()
        {
            sessionWraperFromWCF.SetLectorName(this,_Name);
        }
    }
}
