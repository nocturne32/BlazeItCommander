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
    public partial class Favorites : Form
    {
        Config config = new Config();
        public Stack<string> History { get; private set; }
        public string CurrentPath { get; set; }

        public Favorites(string current, Stack<string> history)
        {
            InitializeComponent();
            CurrentPath = current;
            History = history;
        }

        private void Favorites_Load(object sender, EventArgs e)
        {
            //načte z xml souboru oblíbené složky
            config = Xml.Import(config);
            foreach(string fav in config.Favorites)
                listBoxFavorites.Items.Add(fav);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            Xml.Export(config);
            Close();
        }

        private void listBoxFavorites_KeyDown(object sender, KeyEventArgs e)
        {
            try
            { //použití kláves
                if (e.KeyData == (Keys.Delete))
                {
                    if (listBoxFavorites.Focused)
                    {
                        config.Favorites.Remove(listBoxFavorites.SelectedItem.ToString());
                        listBoxFavorites.Items.Remove(listBoxFavorites.SelectedItem);
                    }
                }
            }
            catch (Exception) { }
        }

        private void listBoxFavorites_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                //po dvojitém kliknutí se zavře okno a zapíše se nová cesta do zásobníku (historie)
                if (listBoxFavorites.Focused)
                {
                    CurrentPath = listBoxFavorites.SelectedItem.ToString();
                    //History.Clear();
                    //string cp = CurrentPath;
                    //History.Push(CurrentPath);
                    //while (cp != Path.GetPathRoot(cp))
                    //{
                    //    cp = Path.GetDirectoryName(cp);
                    //    History.Push(cp);
                    //}
                    History.Push(CurrentPath);
                    btnSaveClose_Click(sender, e);
                }
            }
            catch (Exception) { }
        }

        private void Favorites_KeyDown(object sender, KeyEventArgs e)
        {
        }
    }
}
