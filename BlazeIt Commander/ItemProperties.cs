        using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlazeIt_Commander
{
    public partial class ItemProperties : Form
    {
        //informace o daném souboru/složce (nové okno)  
        string targetPath;
        public ItemProperties(string path)
        {
            InitializeComponent();
            targetPath = path;
            Info item = new Info(targetPath);
            Text = item.Name + " - Properties";
        }

        private void ItemProperties_Load(object sender, EventArgs e)
        {
            Info item = new Info(targetPath);
            txtName.Text = item.Name;
            lblPath.Text = item.Path;
            lblType.Text = item.Type;
            lblSize.Text = item.Size;
            lblCreatedAt.Text = item.CreatedAt;
            lblCounter.Text = item.ContentsCount;
            lblAttributes.Text = item.Attributes;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            Info item = new Info(targetPath);
            if (item.Name != txtName.Text)
            {
                Operations.Rename(targetPath, Path.Combine(Path.GetDirectoryName(targetPath), txtName.Text));
            }
            Close();
        }

        private void ItemProperties_KeyDown(object sender, KeyEventArgs e)
        {
        }
    }
}
