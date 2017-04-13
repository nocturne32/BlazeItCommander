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
    public partial class History : Form
    {
        public Stack<string> LeftHistory { get; set; }
        public Stack<string> RightHistory { get; set; }
        public string LeftCurrentPath { get; set; }
        public string RightCurrentPath { get; set; }

        public History(Stack<string> lHistory, Stack<string> rHistory)
        {
            //načte historii (jednoduchý zásobník) do každého seznamu 
            InitializeComponent();
            LeftHistory = lHistory;
            LeftCurrentPath = LeftHistory.Peek();
            foreach (string his in lHistory)
                leftListBox.Items.Add(his);

            RightHistory = rHistory;
            RightCurrentPath = RightHistory.Peek();
            foreach (string his in rHistory)
                rightListBox.Items.Add(his);
        }

        private void leftListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                //maže ze zásobníku, dokud se hodnota v zásobníku nerovná vybrané hodnotě v listboxu
                //nastaví hodnotu a poté se vypne a pokračuje se v Main.cs
                while (LeftHistory.Peek() != leftListBox.SelectedItem.ToString())
                {
                    LeftHistory.Pop();
                }
                LeftCurrentPath = LeftHistory.Peek();
                Close();
            }
            catch (Exception) { }
        }

        private void rightListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                //maže ze zásobníku, dokud se hodnota v zásobníku nerovná vybrané hodnotě v listboxu
                //nastaví hodnotu a poté se vypne a pokračuje se v Main.cs
                while (RightHistory.Peek() != rightListBox.SelectedItem.ToString())
                {
                    RightHistory.Pop();
                }
                RightCurrentPath = RightHistory.Peek();
                Close();
            }
            catch (Exception) { }
        }

    }
}
