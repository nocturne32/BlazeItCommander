using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace BlazeIt_Commander
{
    static class Operations
    {
        static string temp = @"temp";

        static public void CreateTemp()
        {
            if (!Directory.Exists(temp))
                Directory.CreateDirectory(temp);
        }

        static public void Duplicate(string sourcePath = @"D:\testSource")
        {
            if (Directory.Exists(sourcePath)) //true pokud se jedná o složku (musí existovat)
            {
                string newPath = sourcePath;
                newPath = Path.Combine(Path.GetDirectoryName(sourcePath), NewNameCopy(newPath));
                CopyFolder(sourcePath, newPath);
                MessageBox.Show("Duplicated successfully\n" + newPath, "Notification");
            }
            else if (File.Exists(sourcePath))
            {
                string newPath = sourcePath;
                newPath = Path.Combine(Path.GetDirectoryName(sourcePath), NewNameCopy(newPath));
                File.Copy(sourcePath, newPath);
                MessageBox.Show("Duplicated successfully\n" + newPath, "Notification");
            }
        }

        static public void Copy(string sourcePath = @"D:\testSource", string targetPath = @"D:\testTarget")
        {
            if (!string.Equals(targetPath, sourcePath)) //false pokud cesty nejsou stejné; pokud by byly stejné, nemá cenu přesouvat
            {
                if (Directory.Exists(sourcePath) && (MessageBox.Show("Do you really want to copy this folder?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes))
                {
                    MessageBox.Show("Copying directory " + sourcePath + "\n to directory " + targetPath, "Notification");
                    string newTargetPath = Path.Combine(targetPath, Path.GetFileName(sourcePath));

                    //new name 
                    newTargetPath = Path.Combine(targetPath, NewNameCopy(newTargetPath));
                    CopyFolder(sourcePath, newTargetPath);
                }


                else if (File.Exists(sourcePath))
                {
                    MessageBox.Show("Copying file " + sourcePath + "\n to directory " + targetPath, "Notification");

                    if (Directory.Exists(targetPath))
                    {
                        string newTargetPath = Path.Combine(targetPath, Path.GetFileName(sourcePath));
                        if ((MessageBox.Show("Do you really want to copy this file?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes))
                        {
                            if (File.Exists(newTargetPath))
                            {
                                if ((MessageBox.Show("File already exists. Do you want to overwrite it?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes))
                                {
                                    File.Copy(sourcePath, newTargetPath, true);
                                    MessageBox.Show("File copied successfully.", "Notification");
                                }
                                else
                                {
                                    newTargetPath = Path.Combine(targetPath, NewNameCopy(newTargetPath));
                                    File.Copy(sourcePath, newTargetPath);
                                }
                            }
                            else
                            {
                                newTargetPath = Path.Combine(targetPath, NewNameCopy(newTargetPath));
                                File.Copy(sourcePath, newTargetPath);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(targetPath + "\nwas not found.\nCreating new folder", "Notification");
                        Directory.CreateDirectory(targetPath);
                        targetPath = Path.Combine(targetPath, Path.GetFileName(sourcePath));
                        if ((MessageBox.Show("Do you really want to copy this file?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes))
                        {
                            File.Move(sourcePath, targetPath);
                            MessageBox.Show("File copied successfully.", "Notification");
                        }
                    }
                }
            }
            else MessageBox.Show("Paths are .", "Notification");
        }


        static public void Move(string sourcePath = @"D:\testSource", string targetPath = @"D:\testTarget")
        {
            try
            {
                if (!string.Equals(targetPath, sourcePath)) //false pokud cesty nejsou stejné; pokud by byly stejné, nemá cenu přesouvat
                {
                    if (Directory.Exists(sourcePath)) //true pokud se jedná o složku (musí existovat)
                    {
                        MessageBox.Show("Moving directory " + sourcePath + "\n to directory " + targetPath, "Notification");
                        targetPath = Path.Combine(targetPath, Path.GetFileName(sourcePath));
                        if (!string.Equals(targetPath, sourcePath)) //false pokud cesty nejsou stejné; pokud by byly stejné, nemá cenu přesouvat
                        {
                            if ((MessageBox.Show("Do you really want to move this folder?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes))
                            {
                                if (Directory.Exists(targetPath)) //pokud existuje složka v cíli
                                {
                                    if ((MessageBox.Show("Folder already exists. Do you want to delete it first?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes))
                                    {
                                        string tempNew = Path.Combine(temp, Path.GetFileName(targetPath));
                                        //CopyFolder(sourcePath, tempNew);
                                        Directory.Delete(targetPath, true);
                                        MessageBox.Show("Folder deleted successfully. Now moving.", "Notification");
                                        Directory.Move(sourcePath, targetPath);
                                        MessageBox.Show("Folder moved successfully.", "Notification");
                                    }
                                }
                                else
                                {
                                    Directory.Move(sourcePath, targetPath);
                                    MessageBox.Show("Folder moved successfully.", "Notification");
                                }
                            }
                        }
                        else MessageBox.Show("Paths are the same. Nothing to do.", "Notification");
                    }
                    else if (File.Exists(sourcePath)) //true pokud se jedná o soubor (musí existovat)
                    {
                        MessageBox.Show("Moving file " + sourcePath + "\n to directory " + targetPath, "Notification");

                        if (Directory.Exists(targetPath))
                        {
                            targetPath = Path.Combine(targetPath, Path.GetFileName(sourcePath));
                            if (!string.Equals(targetPath, sourcePath)) //false pokud cesty nejsou stejné; pokud by byly stejné, nemá cenu přesouvat
                            {
                                if ((MessageBox.Show("Do you really want to move this file?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes))
                                {
                                    if (!string.Equals(targetPath, sourcePath)) //false pokud cesty nejsou stejné; pokud by byly stejné, nemá cenu přesouvat
                                    {
                                        if (Directory.Exists(targetPath)) //pokud cílová složka existuje
                                        {
                                            if ((MessageBox.Show("File already exists. Do you want to delete it first?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes))
                                            {
                                                File.Delete(targetPath);
                                                MessageBox.Show("Folder deleted successfully.", "Notification");
                                                File.Move(sourcePath, targetPath);
                                                MessageBox.Show("Folder moved successfully.", "Notification");
                                            }
                                        }
                                        else
                                        {
                                            File.Move(sourcePath, targetPath);
                                            MessageBox.Show("File moved successfully.", "Notification");
                                        }
                                    }
                                }
                            }
                            else MessageBox.Show("Paths are the same. Nothing to do.", "Notification");
                        }
                        else
                        {
                            MessageBox.Show(targetPath + "\nwas not found.\nCreating new folder", "Notification");
                            Directory.CreateDirectory(targetPath);
                            targetPath = Path.Combine(targetPath, Path.GetFileName(sourcePath));
                            if ((MessageBox.Show("Do you really want to move this file?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes))
                            {
                                File.Move(sourcePath, targetPath);
                                MessageBox.Show("File moved successfully.", "Notification");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("There was and error while moving.", "Notification");
                    }
                }
                else MessageBox.Show("Paths are the same. Nothing to do.", "Notification");
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "Unauthorized Access");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");

            }
        }

        static public void Delete(string targetPath)
        {
            if (Directory.Exists(targetPath) && ((MessageBox.Show("Are you sure?\n" + targetPath, "Delete folder",
                MessageBoxButtons.YesNo) == DialogResult.Yes)))
            {
                Directory.Delete(targetPath, true);
                MessageBox.Show("Deleted successfully.", "Notification");
            }
            else if (File.Exists(targetPath) && ((MessageBox.Show("Are you sure?\n" + targetPath, "Delete file",
                MessageBoxButtons.YesNo) == DialogResult.Yes)))
            {
                File.SetAttributes(targetPath, File.GetAttributes(targetPath) & ~FileAttributes.ReadOnly);
                File.Delete(targetPath);
                MessageBox.Show("Deleted successfully.", "Notification");
            }
        }

        static public void Rename(string sourcePath, string targetPath)
        {
            if (Directory.Exists(sourcePath) && ((MessageBox.Show("Are you sure?\n" + targetPath, "Rename folder",
                MessageBoxButtons.YesNo) == DialogResult.Yes)))
            {
                Directory.Move(sourcePath, targetPath);
                Thread.Sleep(1000);
            }
            else if (File.Exists(sourcePath) && ((MessageBox.Show("Are you sure?\n" + targetPath, "Rename file",
                MessageBoxButtons.YesNo) == DialogResult.Yes)))
            {
                File.Move(sourcePath, targetPath);
                Thread.Sleep(1000);
            }
        }

        static public void NewFolder(string targetPath, string folderName = "New Folder")
        {
            try
            {
                if (!Directory.Exists(Path.Combine(targetPath, folderName)))
                {
                    Directory.CreateDirectory(Path.Combine(targetPath, folderName));
                }
                else
                {
                    string newPath = Path.Combine(targetPath, NewNameCopy(Path.Combine(targetPath, folderName)));
                    while (Directory.Exists(newPath))
                    {
                        newPath = Path.Combine(Path.GetDirectoryName(newPath), NewNameCopy(newPath));
                    }
                    Directory.CreateDirectory(newPath);
                }
            }
            catch (Exception) { }
        }

        static private void CopyFolder(string sourcePath, string targetPath)
        {
            try
            {
                if (!Directory.Exists(targetPath))
                {
                    Directory.CreateDirectory(targetPath);
                }

                foreach (string file in Directory.GetFiles(sourcePath))
                {
                    string target = Path.Combine(targetPath, Path.GetFileName(file));
                    File.Copy(file, target);
                }

                foreach (string folder in Directory.GetDirectories(sourcePath))
                {
                    string target = Path.Combine(targetPath, Path.GetFileName(folder));
                    CopyFolder(folder, target);
                }
            }
            catch (Exception) { }
        }

        static private string NewNameCopy(string sourcePath = @"D:\testSource") //vezme celou cestu a vrátí pouze nový název (příp. s koncovkou), ne cestu
        {
            string newName = sourcePath;
            try
            {
                string dir = Path.GetDirectoryName(sourcePath);
                string name = Path.GetFileNameWithoutExtension(sourcePath);
                string ext = Path.GetExtension(sourcePath);
                if (Directory.Exists(sourcePath)) //true pokud se jedná o složku (musí existovat)
                {
                    do
                    {
                        newName = name + " - Copy";
                    } while (File.Exists(Path.Combine(dir, newName)));
                }
                else if (File.Exists(sourcePath))
                {
                    do
                    {
                        newName = name + " - Copy" + ext;
                    } while (File.Exists(Path.Combine(dir, newName)));
                }
            }
            catch (Exception) { }

            return newName;
        }

    }
}
