using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlazeIt_Commander
{
    class Navigate
    {
        //navádění
        static public void AutoNavigate(Populate populate, Stack<string> history, ToolStripComboBox comboBox,
            ListView listView, ImageList imgList, Config config, ToolStripStatusLabel files, ToolStripStatusLabel folders,
            ToolStripLabel currentPath, string selectedPath)
        {
            try
            {
                if (listView.FocusedItem.Index == 0)
                {
                    Back(populate, history, comboBox, listView, imgList, config);
                    //Side.BackPath(history, comboBox, listView, imgList, configXml);
                    currentPath.Text = populate.CurrentPath;
                    //counter
                    populate.GetCounter(files, folders);

                }
                else
                {
                    if (File.Exists(selectedPath))
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(selectedPath);
                        }
                        catch (SystemException ex)
                        {
                            MessageBox.Show(ex.Message + "\n" + populate.CurrentPath, "ERROR: FileOpen");
                        }
                    }
                    else
                    {
                        currentPath.Text = selectedPath;
                        Open(populate, history, comboBox, listView, imgList, config, selectedPath);
                    }
                }

                populate.GetCounter(files, folders);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR: AutoNavigate");
            }
        }


        static public void Open(Populate populate, Stack<string> history, ToolStripComboBox comboBox,
            ListView listView, ImageList imgList, Config config, string selectedPath)
        {
            try
            {
                //smaže listview a načte xml soubor
                //najde položky v nové složce
                listView.Items.Clear();
                Xml.Import(config);
                history.Push(selectedPath);
                populate.CurrentPath = selectedPath;
                populate.Show = config.ShowHidden;
                populate.FindAll(comboBox, listView, history, config, imgList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR: Open");
                populate.FindAll(comboBox, listView, history, config, imgList);
            }
        }


        static public void Back(Populate populate, Stack<string> history, ToolStripComboBox comboBox,
            ListView listView, ImageList imgList, Config config)
        {
            try
            {
                //smaže listview a načte xml soubor
                //odstraní poslední cestu ze zásobníku (z historie)
                Xml.Import(config);
                populate.Show = config.ShowHidden;
                if (history.Count != 1) //zásobník vždy obsahuje minimálně jeden string, kvůli jednotkám (D://, C://, ...)
                {
                    listView.Items.Clear();
                    history.Pop();
                    populate.CurrentPath = history.Peek();
                    populate.FindAll(comboBox, listView, history, config, imgList);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR: Back");
                history.Push(comboBox.Text);
                populate.FindAll(comboBox, listView, history, config, imgList);
            }

        }

    }
}
