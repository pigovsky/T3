using LectorsSeminarsWCFClientLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T3
{
    public partial class EditLectorDialog : Form
    {
        
        public Lector lector { get; set; }

        public EditLectorDialog(SessionWraperFromWCF client)
            : this(client, null)
        {            
        }

        public EditLectorDialog(SessionWraperFromWCF client, Lector lector) 
        {
            InitializeComponent();
            this.client = client;            
            this.lector = lector;
 
            if (lector!=null)
            {                               
                if (lector.Name!=null)
                    textBoxName.Text = lector.Name;
                if (lector.Birthday != null)
                    try
                    {
                        dateTimePickerBirthday.Value = DateTime.Parse(lector.Birthday);
                    }
                    catch (Exception e) { }
                if (lector.LectorPhotoName != null)
                    pictureBoxPhoto.Image = Image.FromFile(Lector.img + lector.LectorPhotoName);
            }                                    
        }
        
        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (lector == null)
                lector = client.CreateLector(textBoxName.Text);
            else
                lector.Name = textBoxName.Text;
            lector.Birthday = dateTimePickerBirthday.Value.ToString("yyyy-MM-dd");
            if (photoData !=null)
                lector.LectorPhotoData = photoData;
            Hide();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {            
            Hide();
        }

        private string photoData = null;

        private void buttonBrowseForPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "*.jpg;*.png;*.bmp";
            var res = ofd.ShowDialog();

            if (res != System.Windows.Forms.DialogResult.OK)
                return;

            var original = Image.FromFile(ofd.FileName);
            float resizeRatio = 1f;
            if (original.Height > original.Width)
                resizeRatio = (float)pictureBoxPhoto.Height / original.Height;
            else
                resizeRatio = (float)pictureBoxPhoto.Width / original.Width;

            pictureBoxPhoto.Image = new Bitmap(original, 
                (int)(original.Width*resizeRatio), 
                (int)(original.Height*resizeRatio));

            MemoryStream ms = new MemoryStream();
            pictureBoxPhoto.Image.Save(ms, ImageFormat.Jpeg);
            ms.Position = 0;
            photoData = Convert.ToBase64String(ms.ToArray());
            ms.Close();
        }

        public SessionWraperFromWCF client { get; set; }
    }
}
