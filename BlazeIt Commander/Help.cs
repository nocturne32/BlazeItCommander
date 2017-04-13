using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlazeIt_Commander
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
            lblVersion.Text = Application.ProductVersion;
        }

        private void Help_KeyUp(object sender, KeyEventArgs e)
        {
        }

    }
}
