using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;

namespace BlazeIt_Commander
{
    public class Populate
    {
        //PROMĚNNÉ//
        private string[] _fileInfo = new string[10];
        private string[] _dirInfo = new string[10];
        private string[] _backInfo = new string[10];
        private string[] _driveInfo = new string[6];


        //FUNKCE//
        //vyhledávání 
        public void FindAll(ToolStripComboBox comboBox, ListView listView,
            Stack<string> history, Config config, ImageList imgList, int dirImg = 0)
        {
            try
            {
                listView.Items.Clear();
                _backInfo[0] = "[...]";
                ListViewItem back = new ListViewItem(_backInfo, 1);
                listView.Items.Add(back);

                //zavolání funkcí pro vyhledání složek a souborů
                FindAllFolders(comboBox, listView, dirImg);
                FindAllFiles(comboBox, listView, imgList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR: FindAll");
                Navigate.Back(this, history, comboBox, listView, imgList, config);
            }
        }

        //vyhledávání
        public void FindReadyDrives(ToolStripComboBox comboBox, ListView listView, int defaultDrive = 1)
        {
            try
            {
                foreach (DriveInfo driveInfo in DriveInfo.GetDrives())
                {
                    if (driveInfo.IsReady) //pouze použitelné jednotky
                        comboBox.Items.Add(driveInfo);
                }
                comboBox.SelectedIndex = defaultDrive;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR: FindReadyDrives");
                comboBox.SelectedIndex = 0;
            }
            listView.Refresh();
        }

        public void FindAllFiles(ToolStripComboBox comboBox, ListView listView, ImageList imgList)
        {
            try
            {
                DriveInfo drive = (DriveInfo)comboBox.SelectedItem;
                DirectoryInfo rootDir = new DirectoryInfo(CurrentPath);
                FileInfo[] files = rootDir.GetFiles();
                //FilesCount = files.Count();
                FilesCount = 0;
                foreach (FileInfo file in files)
                {
                    if (Show == true)
                    {
                        FileInfo(file, listView, imgList);
                        FilesCount++;
                    }
                    else if (Show == false && ((file.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden))
                    {
                        FileInfo(file, listView, imgList);
                        FilesCount++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR: FindAllFiles");
            }
        }

        public void FindAllFolders(ToolStripComboBox comboBox, ListView listView, int imgList = 0)
        {
            try
            {
                DriveInfo drive = (DriveInfo)comboBox.SelectedItem;
                DirectoryInfo rootDir = new DirectoryInfo(CurrentPath);
                DirectoryInfo[] dirs = rootDir.GetDirectories();
                //FoldersCount = dirs.Count();
                FoldersCount = 0;
                foreach (DirectoryInfo dir in dirs)
                {
                    if (Show == true)
                    {
                        DirInfo(dir, listView, imgList);
                        FoldersCount++;
                    }
                    else if (Show == false && ((dir.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden))
                    {
                        DirInfo(dir, listView, imgList);
                        FoldersCount++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR: FindAllFolders");
            }
        }



        public void ReturnHome(Stack<string> history, ToolStripComboBox comboBox,
            ListView listView, ImageList imgList, Config config, ToolStripLabel driveInfo,
            ToolStripLabel driveSize, ToolStripStatusLabel files, ToolStripStatusLabel folders,
            ToolStripLabel currentPath)
        {
            try
            {
                Show = config.ShowHidden;
                CurrentPath = comboBox.Text;

                //drive info
                GetDriveInfo(comboBox, driveInfo, driveSize);

                FindAll(comboBox, listView, history, config, imgList);
                currentPath.Text = comboBox.Text;
                ClearHistory(history);
                history.Push(comboBox.Text);

                //counter
                GetCounter(files, folders);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR: ReturnHome");
            }

        }

        public void RefreshAll(Stack<string> history, ToolStripComboBox comboBox,
            ListView listView, ImageList imgList, Config config, ToolStripLabel driveInfo,
            ToolStripLabel driveSize, ToolStripStatusLabel files, ToolStripStatusLabel folders,
            ToolStripLabel currentPath)
        {
            try
            {
                Show = config.ShowHidden;
                GetDriveInfo(comboBox, driveInfo, driveSize);

                FindAll(comboBox, listView, history, config, imgList);
                currentPath.Text = CurrentPath;

                //counter
                GetCounter(files, folders);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR: RefreshAll");
            }
        }

        public void GetDriveInfo(ToolStripComboBox comboBox, ToolStripLabel labelInfo, ToolStripLabel labelSize)
        {
            try
            {
                DriveInfo driveInfo = new DriveInfo(comboBox.SelectedItem.ToString());
                _driveInfo[0] = driveInfo.Name;
                _driveInfo[1] = driveInfo.VolumeLabel;
                _driveInfo[2] = driveInfo.DriveType.ToString();
                _driveInfo[3] = driveInfo.DriveFormat;
                _driveInfo[4] = Conversions.BytesConversion(driveInfo.TotalSize); //vrací defaultně string
                _driveInfo[5] = Conversions.BytesConversion(driveInfo.TotalFreeSpace);  //vrací string

                labelInfo.Text = _driveInfo[1] + " (" + _driveInfo[3] + ") - " + _driveInfo[2];
                labelSize.Text = "Free space: " + _driveInfo[5] + " out of " + _driveInfo[4];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR: FindDriveInfo");
            }
        }

        private void DirInfo(DirectoryInfo dir, ListView listView, int imgList = 0)
        {
            try
            {
                _dirInfo[0] = dir.Name;
                _dirInfo[2] = "<DIR>";
                _dirInfo[3] = dir.CreationTimeUtc.ToString();
                _dirInfo[4] = dir.FullName;
                _dirInfo[5] = dir.Attributes.ToString(); ;
                _dirInfo[6] = dir.FullName;
                //_dirInfo[7] = dir.Name;

                ListViewItem item = new ListViewItem(_dirInfo, imgList);
                item.ToolTipText = _dirInfo[6];
                listView.Items.Add(item);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR: DirInfo");
            }
        }


        private void FileInfo(FileInfo file, ListView listView, ImageList imgList)
        {
            try
            {
                _fileInfo[0] = file.Name;
                _fileInfo[1] = file.Extension;
                double fileSize = file.Length;
                _fileInfo[2] = Conversions.BytesConversion(fileSize);
                _fileInfo[3] = file.CreationTimeUtc.ToString();
                _fileInfo[4] = file.DirectoryName;
                _fileInfo[5] = file.Attributes.ToString();
                _fileInfo[6] = file.FullName;
                //_fileInfo[7] = file.Name;
                int index = imgList.Images.Count - 1; //pro případ
                if (!imgList.Images.Keys.Contains(_fileInfo[1]) && _fileInfo[1] != ".lnk" && _fileInfo[1] != ".url")
                {
                    imgList.Images.Add(_fileInfo[1], Icon.ExtractAssociatedIcon(_fileInfo[6]).ToBitmap());
                    index = imgList.Images.IndexOfKey(_fileInfo[1]);
                }
                else if (imgList.Images.Keys.Contains(_fileInfo[1]) && _fileInfo[1] != ".lnk" && _fileInfo[1] != ".url")
                {
                    index = imgList.Images.IndexOfKey(_fileInfo[1]);
                }
                else if (_fileInfo[1] == ".lnk" || _fileInfo[1] == ".url")
                {
                    imgList.Images.Add(_fileInfo[1], Icon.ExtractAssociatedIcon(_fileInfo[6]).ToBitmap());
                    index = imgList.Images.Count - 1;
                }
                ListViewItem item = new ListViewItem(_fileInfo);
                item.ImageIndex = index;
                item.ToolTipText = _fileInfo[6];
                listView.Items.Add(item);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR: FileInfo");
            }
        }


        public void GetCounter(ToolStripStatusLabel labelFiles, ToolStripStatusLabel labelFolders)
        {
            try
            {
                labelFiles.Text = "Files: " + FilesCount.ToString();
                labelFolders.Text = "Folders: " + FoldersCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR: GetCounter");
            }
        }

        public void ShowHistory(Stack<string> history, ListView listView)
        {
            try
            {
                listView.Items.Clear();
                foreach (string path in history)
                    listView.Items.Add(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR: ShowHistory");
            }
        }

        public void ClearHistory(Stack<string> history)
        {
            try
            {
                history.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR: ClearHistory");
            }
        }

        public void ShowOnlyFiles(ToolStripComboBox comboBox, ListView listView,
            Stack<string> history, Config config, ImageList imgList)
        {
            try
            {
                listView.Items.Clear();
                _backInfo[0] = "[...]";
                ListViewItem back = new ListViewItem(_backInfo, 1);
                listView.Items.Add(back);

                FindAllFiles(comboBox, listView, imgList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR: ShowOnlyFiles");
            }
        }

        public void OpenRandomFile(ToolStripComboBox comboBox, ListView listView,
            Stack<string> history, Config config, ImageList imgList)
        {
            try
            {
                if (FilesCount > 0)
                {
                    ShowOnlyFiles(comboBox, listView, history, config, imgList);
                    Random random = new Random();
                    int rand = random.Next(1, FilesCount);
                    listView.Items[rand].Selected = true;
                    listView.Select();

                    System.Diagnostics.Process.Start(listView.Items[rand].SubItems[6].Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR: OpenRandomFile");
            }
        }

        //VLASTNOSTI//
        public int CurrentDrive { get; set; }
        public string CurrentPath { get; set; }
        //vlastnost skrytí (výchozí je false => složky jsou skryty)
        public bool Show { get; set; }
        //ostatní
        public int FilesCount { get; private set; } = 0;
        public int FoldersCount { get; private set; } = 0;
    }

}
