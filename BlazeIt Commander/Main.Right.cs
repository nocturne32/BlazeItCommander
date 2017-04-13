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
using System.Threading;

namespace BlazeIt_Commander
{
    public partial class Main : Form
    {
        //Poznámky jsou úplně stejné jako u MAIN.LEFT.CS

        //hlavní
        //vytvoření instancí
        Populate rightSide = new Populate();

        //deklarace kolekcí
        Stack<string> rightHistory = new Stack<string>();

        private void rightTsCboxDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            rightTsBtnHome_Click(sender, e);
        }


        private void rightListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string selectedName = rightListView.FocusedItem.SubItems[0].Text;
            string selectedFullPath = rightListView.FocusedItem.SubItems[6].Text;

            Navigate.AutoNavigate(rightSide, rightHistory, rightTsCboxDrives, rightListView, imgList, config,
                rightSsLblFiles, rightSsLblFolders, rightTsLblCurrentPath, selectedFullPath);

            //counter
            //rightSide.GetCounter(rightSsLblFiles, rightSsLblFolders);
        }

        private void rightTsBtnHome_Click(object sender, EventArgs e)
        {
            rightSide.ReturnHome(rightHistory, rightTsCboxDrives, rightListView, imgList, config, rightTsLblDriveInfo, rightTsLblDriveSize,
                rightSsLblFiles, rightSsLblFolders, rightTsLblCurrentPath);
        }

        private void rightTsBtnFindDrives_Click(object sender, EventArgs e)
        {
            rightTsCboxDrives.Items.Clear();
            rightSide.FindReadyDrives(rightTsCboxDrives, rightListView, config.RightDefaultDrive);
            //counter
            rightSide.GetCounter(rightSsLblFiles, rightSsLblFolders);
        }

        private void rightTsBtnRefreshList_Click(object sender, EventArgs e)
        {
            rightSide.RefreshAll(rightHistory, rightTsCboxDrives, rightListView, imgList, config, rightTsLblDriveInfo, rightTsLblDriveSize,
                rightSsLblFiles, rightSsLblFolders, rightTsLblCurrentPath);
        }

        private void rightListView_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            try
            {
                if (e.Label != null)
                {
                    string rightSelectedFullPath = rightListView.FocusedItem.SubItems[6].Text;
                    string newName = e.Label;
                    Operations.Rename(rightSelectedFullPath, Path.Combine(Path.GetDirectoryName(rightSelectedFullPath), newName));

                }
                rightListView.LabelEdit = false;
                rightTsBtnRefreshList_Click(sender, e);
            }
            catch (Exception) { }
        }

        private void rightListView_KeyUp(object sender, KeyEventArgs e)
        {

            try
            {
                if (rightListView.Focused)
                {
                    switch (e.KeyData)
                    {
                        case Keys.Enter:
                            string selectedFullPath = rightListView.FocusedItem.SubItems[6].Text;

                            Navigate.AutoNavigate(rightSide, rightHistory, rightTsCboxDrives, rightListView, imgList, config,
                                rightSsLblFiles, rightSsLblFolders, rightTsLblCurrentPath, selectedFullPath);
                            break;
                        case Keys.Back:
                            Navigate.Back(rightSide, rightHistory, rightTsCboxDrives, rightListView, imgList, config);
                            rightTsLblCurrentPath.Text = rightSide.CurrentPath;
                            //counter
                            rightSide.GetCounter(rightSsLblFiles, rightSsLblFolders);
                            break;
                        case (Keys.Control | Keys.R):
                            rightTsBtnRefreshList_Click(sender, e);
                            break;
                        case (Keys.Control | Keys.H):
                            rightTsBtnHome_Click(sender, e);
                            break;
                        case (Keys.Control | Keys.S):
                            rightTsBtnFindDrives_Click(sender, e);
                            break;
                        case (Keys.Control | Keys.F):
                            rightTsBtnAddFavorite_Click(sender, e);
                            break;
                        case (Keys.Control | Keys.A):
                            rightTsBtnFindDrives_Click(sender, e);
                            leftTsBtnFindDrives_Click(sender, e);
                            break;
                        case (Keys.Control | Keys.E):
                            rightTsCboxDrives.Text = leftTsCboxDrives.Text;
                            rightSide.CurrentPath = leftSide.CurrentPath;

                            rightHistory.Push(rightSide.CurrentPath);

                            leftTsBtnRefreshList_Click(sender, e);
                            rightTsBtnRefreshList_Click(sender, e);
                            break;
                    }

                }
            }
            catch (Exception) { }
        }

        private void rightTsBtnAddFavorite_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FavExists(rightSide, config))
                {
                    MessageBox.Show(rightSide.CurrentPath + "\nadded to favorites.", "Notification");
                    config.Favorites.Add(rightSide.CurrentPath);
                    Xml.Export(config);
                }
                else
                {
                    if (MessageBox.Show(rightSide.CurrentPath + "\nis already in favorites.\nDo you want to delete it from the list?",
                        "Notification", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        config.Favorites.Remove(rightSide.CurrentPath);
                        Xml.Export(config);
                    }
                }
                config = Xml.Import(config);
            }
            catch (Exception) { }
        }
    }
}