using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LectorsSeminarsDataAccessLayerWCFService
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        ServiceHost host;

        private void buttonRun_Click(object sender, EventArgs e)
        {
            host = new 
                ServiceHost(
                typeof(LectorsSeminarsDataAccessLayerService));
            host.Open();
            
            WriteLog(host.State);
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            host.Close();
            WriteLog(host.State);
        }

        private void WriteLog(object msg)
        {
            listBoxLog.Items.Add(DateTime.Now + "\t" + msg);
        }
    }
}
