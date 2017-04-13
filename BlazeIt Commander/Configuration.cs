using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BlazeIt_Commander
{
    public partial class Configuration : Form
    {
        //instance třídy Config
        Config config = new Config();

        public Configuration()
        {
            InitializeComponent();
        }

        private void Configuration_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (DriveInfo driveInfo in DriveInfo.GetDrives())
                {
                    if (driveInfo.IsReady)
                    {
                        leftCboxDefaultDrive.Items.Add(driveInfo);
                        rightCboxDefaultDrive.Items.Add(driveInfo);
                    }
                }
                config = Xml.Import(config);
                leftCboxDefaultDrive.SelectedIndex = config.LeftDefaultDrive;
                rightCboxDefaultDrive.SelectedIndex = config.RightDefaultDrive;
                checkBoxShowHidden.Checked = config.ShowHidden;
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message, "ERROR: FindReadyDrives");
                leftCboxDefaultDrive.SelectedIndex = 0;
                rightCboxDefaultDrive.SelectedIndex = 0;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close(); //hehe
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            //uloží do vlastností Config vybrané hodnoty a následně exportuje jako xml 
            config.ShowHidden = checkBoxShowHidden.Checked;
            config.LeftDefaultDrive = leftCboxDefaultDrive.SelectedIndex;
            config.RightDefaultDrive = rightCboxDefaultDrive.SelectedIndex;
            Xml.Export(config);
            Close();
        }

        private void Configuration_KeyDown(object sender, KeyEventArgs e)
        {
        }
    }
}
