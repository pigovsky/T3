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
        private Lector lector;

        public EditLectorDialog()
        {
            InitializeComponent();
        }

        public EditLectorDialog(Lector lector) : this()
        {
            // TODO: Complete member initialization
            this.lector = lector;
            PhotoData = lector.LectorPhotoData;
            if (lector.LectorPhotoName!=null)
                pictureBoxPhoto.Image = Image.FromFile(Lector.img+ lector.LectorPhotoName);
            LectorName = lector.Name;
        }

        private string _LectorName;

        public string LectorName 
        {
            get
            {
                return _LectorName;
            }
            set
            {
                _LectorName = value;
                textBoxName.Text = value;
            }
        }

        public string PhotoData { get; set; }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            LectorName = textBoxName.Text;
            Hide();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            LectorName = null;
            Hide();
        }

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
            PhotoData = Convert.ToBase64String(ms.ToArray());
            ms.Close();
        }
    }
}
