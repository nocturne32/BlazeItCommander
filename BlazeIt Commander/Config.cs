using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace BlazeIt_Commander
{
    [Serializable()] //určuje, co všechno se má serializovat; v tomto případě všechny vlastnosti
    //toto je třída pro konfiguraci, co se bude ukládat do xml, proto serializace
    public class Config
    {
        public bool ShowHidden { get; set; } = false;
        public int LeftDefaultDrive { get; set; } = 0;
        public int RightDefaultDrive { get; set; } = 0;
        public List<string> Favorites { get; set; }



    }
}