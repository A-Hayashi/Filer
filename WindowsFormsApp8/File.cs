using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;



namespace WindowsFormsApp8.FileSystem
{
    public class File : FilerItem
    {
        FileInfo info;

        public File(string full_name)
        {
            info = new FileInfo(full_name);
        }

        override public FileSystemInfo Info
        {
            get { return info; }
        }

        override public ItemType Type
        {
            get { return ItemType.File; }
        }
    }
}