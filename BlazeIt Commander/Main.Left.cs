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
        //hlavní
        //vytvoření instancí
        Populate leftSide = new Populate();

        //deklarace kolekcí;
        Stack<string> leftHistory = new Stack<string>();

        private void leftTsCboxDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            leftTsBtnHome_Click(sender, e);
        }


        private void leftListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string selectedName = leftListView.FocusedItem.SubItems[0].Text;
            string selectedFullPath = leftListView.FocusedItem.SubItems[6].Text;

            //autonavigate slouží k tomu, aby určil, zda byla kliknuto zpět, nebo na položku, to pak udělá danou akci (otevře...)
            Navigate.AutoNavigate(leftSide, leftHistory, leftTsCboxDrives, leftListView, imgList, config,
                leftSsLblFiles, leftSsLblFolders, leftTsLblCurrentPath, selectedFullPath);

        }

        private void leftTsBtnHome_Click(object sender, EventArgs e)
        {
            //smaže historii a následně přidá do historie jednotku (v zásobníku bude jeden string)
            leftSide.ReturnHome(leftHistory, leftTsCboxDrives, leftListView, imgList, config, leftTsLblDriveInfo, leftTsLblDriveSize,
                leftSsLblFiles, leftSsLblFolders, leftTsLblCurrentPath);
        }

        private void leftTsBtnFindDrives_Click(object sender, EventArgs e)
        {
            //najde jednotky
            leftTsCboxDrives.Items.Clear();
            leftSide.FindReadyDrives(leftTsCboxDrives, leftListView, config.LeftDefaultDrive);
            //counter
            leftSide.GetCounter(leftSsLblFiles, leftSsLblFolders);
        }

        private void leftTsBtnRefreshList_Click(object sender, EventArgs e)
        {
            //načtou se znovu všechny položky pro aktuální složku 
            leftSide.RefreshAll(leftHistory, leftTsCboxDrives, leftListView, imgList, config, leftTsLblDriveInfo, leftTsLblDriveSize,
                leftSsLblFiles, leftSsLblFolders, leftTsLblCurrentPath);
        }

        private void leftListView_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {  
            //pro přepsání položky rovnou v listview ...
            //NEFUNGUJE DELETE BĚHEM ZMĚNY NÁZVU, JELIKOŽ JE DELETE ZKRATKOU PRO ODSTRANĚNÍ POLOŽKY
            try
            {
                if (e.Label != null)
                {
                    string leftSelectedFullPath = leftListView.FocusedItem.SubItems[6].Text;
                    string newName = e.Label;
                    Operations.Rename(leftSelectedFullPath, Path.Combine(Path.GetDirectoryName(leftSelectedFullPath), newName));

                }
                leftListView.LabelEdit = false;
                leftTsBtnRefreshList_Click(sender, e);
            }
            catch (Exception) { }
        }

        private void leftListView_KeyUp(object sender, KeyEventArgs e)
        {

            try
            {
                //použití kláves... v nápovědě (help) je popsáno, co k čemu je...
                if (leftListView.Focused)
                {
                    switch (e.KeyData)
                    {
                        case Keys.Enter:
                            string selectedFullPath = leftListView.FocusedItem.SubItems[6].Text;

                            Navigate.AutoNavigate(leftSide, leftHistory, leftTsCboxDrives, leftListView, imgList, config,
                                leftSsLblFiles, leftSsLblFolders, leftTsLblCurrentPath, selectedFullPath);
                            break;
                        case Keys.Back:
                            Navigate.Back(leftSide, leftHistory, leftTsCboxDrives, leftListView, imgList, config);
                            leftTsLblCurrentPath.Text = leftSide.CurrentPath;
                            //counter
                            leftSide.GetCounter(leftSsLblFiles, leftSsLblFolders);
                            break;
                        case (Keys.Control | Keys.R):
                            leftTsBtnRefreshList_Click(sender, e);
                            break;
                        case (Keys.Control | Keys.H):
                            leftTsBtnHome_Click(sender, e);
                            break;
                        case (Keys.Control | Keys.S):
                            leftTsBtnFindDrives_Click(sender, e);
                            break;
                        case (Keys.Control | Keys.F):
                            leftTsBtnAddFavorite_Click(sender, e);
                            break;
                        case (Keys.Control | Keys.A):
                            rightTsBtnFindDrives_Click(sender, e);
                            leftTsBtnFindDrives_Click(sender, e);
                            break;
                        case (Keys.Control | Keys.E):
                            leftTsCboxDrives.Text = rightTsCboxDrives.Text;
                            leftSide.CurrentPath = rightSide.CurrentPath;
                            
                            leftHistory.Push(leftSide.CurrentPath);

                            leftTsBtnRefreshList_Click(sender, e);
                            rightTsBtnRefreshList_Click(sender, e);
                            break;
                    }
                    
                }
            }
            catch (Exception) { }
        }

        private void leftTsBtnAddFavorite_Click(object sender, EventArgs e)
        {
            try
            {
                //přidání do oblíbench
                //pokud existuje, zeptá se uživatele, zdali chce položku ze seznamu (oblíbené) smazat
                //tímpádem stačí jenom jedno tlačítko na přidání/odstranění
                if (!FavExists(leftSide, config))
                {
                    MessageBox.Show(leftSide.CurrentPath + "\nadded to favorites.", "Notification");
                    config.Favorites.Add(leftSide.CurrentPath);
                    Xml.Export(config);
                }
                else
                {
                    if (MessageBox.Show(leftSide.CurrentPath + "\nis already in favorites.\nDo you want to delete it from the list?",
                        "Notification", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        config.Favorites.Remove(leftSide.CurrentPath);
                        Xml.Export(config);
                    }
                }
                config = Xml.Import(config);
            }
            catch (Exception) { }
        }
    }
}