using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazeIt_Commander
{
    class Info
    {
        public Info(string targetPath)
        {
            //Najde informaci o dané položce (ItemProperties)
            //hned po zavolání konstruktoru se zavolá tato funkce, stačí tímpádem pouze vytvořit instanci, 
            //aby se našly informace o daném souboru/složce
            FindInfo(targetPath);
        }
        private void FindInfo(string targetPath)
        {
            if (Directory.Exists(targetPath)) //pokud se jedná o složku
            {
                DirectoryInfo dir = new DirectoryInfo(targetPath);
                DirectoryInfo[] dirs = dir.GetDirectories();
                FileInfo[] files = dir.GetFiles();
                Name = dir.Name;
                Type = "Directory";
                Path = dir.FullName;
                Size = "";
                ContentsCount = "Folders: " + dirs.Count() + " Files: " + files.Count();
                CreatedAt = dir.CreationTimeUtc.ToString();
                Attributes = dir.Attributes.ToString();
                //Icon.ExtractAssociatedIcon(targetPath).ToBitmap();
            }
            else if (File.Exists(targetPath)) //pokud se jedná o soubor
            {
                FileInfo file = new FileInfo(targetPath);
                Name = file.Name;
                Type = file.Extension;
                Path = file.FullName;
                Size = Conversions.BytesConversion(file.Length);
                ContentsCount = "";
                CreatedAt = file.CreationTimeUtc.ToString();
                Attributes = file.Attributes.ToString();
            }
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public string Path { get; set; }
        public string Size { get; set; }
        public string ContentsCount { get; set; }
        public string CreatedAt { get; set; }
        public string Attributes { get; set; }
    }
}
