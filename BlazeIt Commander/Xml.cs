using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace BlazeIt_Commander
{
    static class Xml
    {
        //v případě, kdyby nebyl nalezen config.xml, vytvoří se nový
        static public void CreateXml(Config config, string fileName = "config.xml")
        {
            if (!File.Exists(fileName))
                Export(config);
        }

        static public Config Import(Config config, string fileName = "config.xml") //načtení xml souboru
        {
            using (FileStream reader = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                //vytvoření serializeru typu Config
                XmlSerializer serializer = new XmlSerializer(typeof(Config));
                //deserializování obsahu readeru (otevřeného souboru) - převede xml do použitelných hodnot
                //načtené hodnoty se uloží do configu
                config = (Config)serializer.Deserialize(reader);
                return config; //vrátí config s novými hodnotami 
            }
            
        }

        static public void Export(Config config, string fileName = "config.xml") //export xml souboru 
        {
            //vytvoří writer pro zapsání serialozovaného objektu do souboru
            using (TextWriter writer = new StreamWriter(fileName))
            {
                //vytvoření serializeru typu config
                XmlSerializer serializer = new XmlSerializer(typeof(Config));

                //převede hodnoty na xml 
                serializer.Serialize(writer, config);
            }
        }

    }
}
