using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T3
{
    public partial class EditSeminarDialog : Form
    {
        private string _SeminarName;
        public string SeminarName { 
            get { return _SeminarName; } 
        }

        public EditSeminarDialog()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            _SeminarName = textBoxSeminarName.Text;
            Hide();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            _SeminarName = null;
            Hide();
        }
    }
}
