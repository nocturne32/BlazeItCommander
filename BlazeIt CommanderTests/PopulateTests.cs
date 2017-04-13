using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlazeIt_Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlazeIt_Commander.Tests
{
    [TestClass()]
    public class PopulateTests
    {
        //můj projekt má většinou statické třídy/funkce a nebo funkce bez návratového typu
        //proto jsem udělal test pouze na Populate třídu... 
        //testoval jsem pouze NullReferenceException, jelikož to byl nejčastější problém v debugování  
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void FindAllTest_PopulateObjectIsNull()
        {
            ToolStripComboBox uComboBox = null;
            ListView uListView = null;
            Stack<string> uHistory = null;
            Config uConfig = null;
            ImageList uImgList = null;
            int uImg = 0;
            Populate populate = null;

            populate.FindAll(uComboBox, uListView, uHistory, uConfig, uImgList, uImg);
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void FindReadyDrivesTest_PopulateObjectIsNull()
        {

            ToolStripComboBox uComboBox = null;
            ListView uListView = null;
            Populate populate = null;

            populate.FindReadyDrives(uComboBox, uListView);
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void FindAllFilesTest_PopulateObjectIsNull()
        {

            ToolStripComboBox uComboBox = null;
            ListView uListView = null;
            ImageList uImgList = null;
            Populate populate = null;

            populate.FindAllFiles(uComboBox, uListView, uImgList);
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void FindAllFoldersTest_PopulateObjectIsNull()
        {

            ToolStripComboBox uComboBox = null;
            ListView uListView = null;
            Populate populate = null;

            populate.FindAllFolders(uComboBox, uListView);
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetDriveInfoTest_PopulateObjectIsNull()
        {

            ToolStripComboBox uComboBox = null;
            ListView uListView = null;
            Stack<string> uHistory = null;
            Config uConfig = null;
            ImageList uImgList = null;
            int uImg = 0;
            Populate populate = null;

            populate.FindAll(uComboBox, uListView, uHistory, uConfig, uImgList, uImg);
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetCounterTest_PopulateObjectIsNull()
        {

            ToolStripStatusLabel uFiles = null;
            ToolStripStatusLabel uFolders = null;
            Populate populate = null;

            populate.GetCounter(uFiles, uFolders);
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void ShowHistoryTest_PopulateObjectIsNull()
        {
            Populate u = null;
            Stack<string> history = null;
            u.ClearHistory(history);
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void ClearHistoryTest_PopulateObjectIsNull()
        {
            Populate u = null;
            Stack<string> history = null;
            u.ClearHistory(history);

        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void ShowOnlyFilesTest_PopulateObjectIsNull()
        {

            ToolStripComboBox uComboBox = null;
            ListView uListView = null;
            Stack<string> uHistory = null;
            Config uConfig = null;
            ImageList uImgList = null;
            Populate populate = null;

            populate.ShowOnlyFiles(uComboBox, uListView, uHistory, uConfig, uImgList);
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void OpenRandomFileTest_PopulateObjectIsNull()
        {

            ToolStripComboBox uComboBox = null;
            ListView uListView = null;
            Stack<string> uHistory = null;
            Config uConfig = null;
            ImageList uImgList = null;
            Populate populate = null;

            populate.OpenRandomFile(uComboBox, uListView, uHistory, uConfig, uImgList);
        }
    }
}