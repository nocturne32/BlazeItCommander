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
        Config config = new Config();
        Config favoritesXml = new Config();

        //deklarace kolekcí
        List<string> favorites = new List<string>();

        public Main()
        {
            InitializeComponent();
            this.Text += " - ver: " + Application.ProductVersion;
            leftSide.CurrentPath = leftTsCboxDrives.Text;
            rightSide.CurrentPath = rightTsCboxDrives.Text;
            Operations.CreateTemp(); //pokud neexistuje
            Xml.CreateXml(config); //pokud neexistuje
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //načtení xml souboru
            //vyhledání jednotek 
            config = Xml.Import(config);
            mainSsLblOpenedLocation.Text = "Opened in: " + Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            leftSide.FindReadyDrives(leftTsCboxDrives, leftListView, config.LeftDefaultDrive); //funkce nastaví defaultní jednotku a rovnou skočí na událost leftTsCboxDrives
            rightSide.FindReadyDrives(rightTsCboxDrives, rightListView, config.RightDefaultDrive); //funkce nastaví defaultní jednotku a rovnou skočí na událost leftTsCboxDrives

        }

        private void menuUpConfiguration_Click(object sender, EventArgs e)
        {
            try
            {
                Configuration configurationForm = new Configuration();
                if (configurationForm.ShowDialog() == DialogResult.OK)
                {
                    //po zavření okna se předají nové hodnoty
                    config = Xml.Import(config);
                    leftSide.CurrentDrive = leftTsCboxDrives.SelectedIndex;
                    leftSide.Show = config.ShowHidden;
                    leftSide.FindAll(leftTsCboxDrives, leftListView, leftHistory, config, imgList);

                    //counter
                    leftSide.GetCounter(leftSsLblFiles, leftSsLblFolders);


                    rightSide.CurrentDrive = rightTsCboxDrives.SelectedIndex;
                    rightSide.Show = config.ShowHidden;
                    rightSide.FindAll(rightTsCboxDrives, rightListView, rightHistory, config, imgList);

                    //counter
                    rightSide.GetCounter(rightSsLblFiles, rightSsLblFolders);
                }
            }
            catch (Exception) { }
        }


        private void menuUpHistory_Click(object sender, EventArgs e)
        {
            try
            {
                //otevře se okno s historií 
                History historyForm = new History(leftHistory, rightHistory);
                historyForm.ShowDialog();
                leftHistory = historyForm.LeftHistory;
                rightHistory = historyForm.RightHistory;
                leftSide.CurrentPath = historyForm.LeftCurrentPath;
                rightSide.CurrentPath = historyForm.RightCurrentPath;
                leftTsBtnRefreshList_Click(sender, e);
                rightTsBtnRefreshList_Click(sender, e);
            }
            catch (Exception) { }
        }



        private void menuUpFavorites_Click(object sender, EventArgs e)
        {
            try
            {
                //okno pro oblíbené 
                //podle toho, jaký listView byl naposledy aktivní, tam se pak případně otevře vybraná složka z oblíbených
                if (leftListView.Focused)
                {
                    Favorites favoritesForm = new Favorites(leftSide.CurrentPath, leftHistory);
                    favoritesForm.ShowDialog();
                    config = Xml.Import(config);
                    leftSide.CurrentPath = favoritesForm.CurrentPath;
                    leftHistory = favoritesForm.History;
                }
                else if (rightListView.Focused)
                {
                    Favorites favoritesForm = new Favorites(rightSide.CurrentPath, rightHistory);
                    favoritesForm.ShowDialog();
                    config = Xml.Import(config);
                    rightSide.CurrentPath = favoritesForm.CurrentPath;
                    rightHistory = favoritesForm.History;
                }
                leftTsBtnRefreshList_Click(sender, e);
                rightTsBtnRefreshList_Click(sender, e);
            }
            catch (Exception) { }
        }


        #region ####OPERACE#####

        private void menuDownMove_Click(object sender, EventArgs e)
        {
            try
            {
                //přesouvání položky
                if (leftListView.Focused && leftListView.FocusedItem.Selected)
                {
                    string selectedFullPath = leftListView.FocusedItem.SubItems[6].Text;
                    Operations.Move(selectedFullPath, rightSide.CurrentPath);
                }
                else if (rightListView.Focused && rightListView.FocusedItem.Selected)
                {
                    string selectedFullPath = rightListView.FocusedItem.SubItems[6].Text;
                    Operations.Move(selectedFullPath, leftSide.CurrentPath);
                }
                leftTsBtnRefreshList_Click(sender, e);
                rightTsBtnRefreshList_Click(sender, e);
            }
            catch (Exception) { }

        }

        private void menuDownCopy_Click(object sender, EventArgs e)
        {
            try
            {
                //kopírování položky
                if (leftListView.Focused && leftListView.FocusedItem.Selected)
                {
                    string selectedFullPath = leftListView.FocusedItem.SubItems[6].Text;
                    Operations.Copy(selectedFullPath, rightSide.CurrentPath);
                }
                else if (rightListView.Focused && rightListView.FocusedItem.Selected)
                {
                    string selectedFullPath = rightListView.FocusedItem.SubItems[6].Text;
                    Operations.Copy(selectedFullPath, leftSide.CurrentPath);
                }
                leftTsBtnRefreshList_Click(sender, e);
                rightTsBtnRefreshList_Click(sender, e);
            }
            catch (Exception) { }
        }
        private void menuDownDuplicate_Click(object sender, EventArgs e)
        {
            try
            {
                //duplikování položky
                if (leftListView.Focused && leftListView.FocusedItem.Selected)
                {
                    string selectedFullPath = leftListView.FocusedItem.SubItems[6].Text;
                    Operations.Duplicate(selectedFullPath);
                }
                else if (rightListView.Focused && rightListView.FocusedItem.Selected)
                {
                    string selectedFullPath = rightListView.FocusedItem.SubItems[6].Text;
                    Operations.Duplicate(selectedFullPath);
                }
                leftTsBtnRefreshList_Click(sender, e);
                rightTsBtnRefreshList_Click(sender, e);
            }
            catch (Exception) { }
        }

        private void menuDownDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //smazání položky
                if (leftListView.Focused && leftListView.FocusedItem.Selected)
                {
                    string selectedFullPath = leftListView.FocusedItem.SubItems[6].Text;
                    Operations.Delete(selectedFullPath);
                }
                else if (rightListView.Focused && rightListView.FocusedItem.Selected)
                {
                    string selectedFullPath = rightListView.FocusedItem.SubItems[6].Text;
                    Operations.Delete(selectedFullPath);
                }
                leftTsBtnRefreshList_Click(sender, e);
                rightTsBtnRefreshList_Click(sender, e);
            }
            catch (Exception) { }
        }
        private void menuUpHelp_Click(object sender, EventArgs e)
        {
            //okno pro historii (zásobník)
            Help helpForm = new Help();
            helpForm.Show();
        }

        private void menuDownRename_Click(object sender, EventArgs e)
        {
            try
            {
                //přejmenování položky
                if (leftListView.Focused && leftListView.FocusedItem.Selected)
                {
                    leftListView.LabelEdit = true;
                    leftListView.FocusedItem.BeginEdit();
                }
                else if (rightListView.Focused && rightListView.FocusedItem.Selected)
                {
                    rightListView.LabelEdit = true;
                    rightListView.FocusedItem.BeginEdit();
                }

            }
            catch (Exception) { }
        }

        private void menuDownNewFolder_Click(object sender, EventArgs e)
        {
            try
            {
                //vytvoření nové složky
                if (leftListView.Focused)
                {
                    Operations.NewFolder(leftSide.CurrentPath);
                }
                else if (rightListView.Focused)
                {
                    Operations.NewFolder(rightSide.CurrentPath);
                }
                leftTsBtnRefreshList_Click(sender, e);
                rightTsBtnRefreshList_Click(sender, e);
            }
            catch (Exception) { }
        }

        private void menuDownProperties_Click(object sender, EventArgs e)
        {
            try
            {
                //zobrazí vlastnosti položky
                if (leftListView.Focused && leftListView.FocusedItem.Selected)
                {
                    ItemProperties info = new ItemProperties(leftListView.FocusedItem.SubItems[6].Text);
                    if (info.ShowDialog() == DialogResult.OK)
                    {
                        leftTsBtnRefreshList_Click(sender, e);
                        rightTsBtnRefreshList_Click(sender, e);
                    }
                }
                else if (rightListView.Focused && rightListView.FocusedItem.Selected)
                {

                    ItemProperties info = new ItemProperties(rightListView.FocusedItem.SubItems[6].Text);
                    if (info.ShowDialog() == DialogResult.OK)
                    {
                        leftTsBtnRefreshList_Click(sender, e);
                        rightTsBtnRefreshList_Click(sender, e);
                    }
                }
            }
            catch (Exception) { }
        }

        private void menuDownOpenRandomFile_Click(object sender, EventArgs e)
        {
            //otevře náhodný soubor (najde jenom soubory - přepíše se listView, aby se nemusely nijak řešit složky....)
            if (leftListView.Focused)
            {
                leftSide.OpenRandomFile(leftTsCboxDrives, leftListView, leftHistory, config, imgList);
            }
            if (rightListView.Focused)
            {
                rightSide.OpenRandomFile(rightTsCboxDrives, rightListView, rightHistory, config, imgList);
            }
        }

        #endregion


        private void menuUpSearch_TextChanged(object sender, EventArgs e)
        {
            //zatím nefunkční 
            //leftTsBtnRefreshList_Click(sender, e);
            //rightTsBtnRefreshList_Click(sender, e);
            //ListViewItem[] found = leftListView.Items.Find(menuUpSearch.Text,false);
            //foreach(ListViewItem item in found)
            //{
            //    item.Focused = true;
            //}
        }

        //OSTATNÍ FUNKCE
        private bool FavExists(Populate side, Config config)
        {
            bool exists = false;
            try
            {
                foreach (string fav in config.Favorites)
                {
                    if (fav == side.CurrentPath) return exists = true;
                }
            }
            catch (Exception) { }
            return exists;
        }

    }
}